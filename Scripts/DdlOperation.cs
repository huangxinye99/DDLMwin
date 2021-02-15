using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Media;
using SQLite;

namespace DDLM
{
    public class Ddl
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }

        public int Priority { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsChineseCalender { get; set; }

        public bool IsLoop { get; set; }
        public string LoopInterval { get; set; }

        public string Inform { get; set; } //notice window sound

        public int IsRemind { get; set; }
        public DateTime RemindTime { get; set; }
        public string RemindInterval { get; set; }
    }

    class DdlOperation
    {
        public static List<Ddl> ddls;
        public static Dictionary<int, TimeSpan> leftTimesDict = new Dictionary<int, TimeSpan>();

        static MediaPlayer player;

        public DdlOperation()
        {
            player = new MediaPlayer();

            ddls = DatabaseOperation.Select();
            foreach (Ddl ddl in ddls)
                leftTimesDict.Add(ddl.Id, CalcLeftTime(ddl.EndTime));

            App.dt.Tick += CalcLeftTimesEvent;
            App.dt.Tick += RemindTimesEvent;
        }

        private static void CalcLeftTimesEvent(object sender, EventArgs e) => CalcLeftTimes();

        private static void RemindTimesEvent(object sender, EventArgs e) => RemindDdls();

        private static void CalcLeftTimes()
        {
            foreach (Ddl ddl in ddls)
            {
                TimeSpan ts = CalcLeftTime(ddl.EndTime);
                leftTimesDict[ddl.Id] = ts;
                if (ts.TotalSeconds <= 0)
                {
                    if (ts.TotalSeconds > -1)
                        AlertDdl(ddl);
                    if (ddl.IsLoop)
                        NextLoop(ddl);
                }
            }
        }

        public static TimeSpan CalcLeftTime(DateTime time) => time.Subtract(DateTime.Now);

        public static void AlertDdl(Ddl ddl)
        {
            if (ddl.Inform[0] == '1')
                App.ShowBalloonTip(ddl.Name + "时间到！");

            if (ddl.Inform[2] == '1')
            {
                try
                {
                    player.Open(new Uri(SettingOperation.alarmPath));
                    player.Play();
                    player.Volume = SettingOperation.alarmVolume / 100f;
                }
                catch (Exception) { App.ShowBalloonTip("音频加载失败！"); }
            }

            if (ddl.Inform[1] == '1')
                MessageBox.Show(ddl.Name + " 时间到！");
        }

        private static void NextLoop(Ddl ddl)
        {
            string[] str = ddl.LoopInterval.Split('/');
            DateTime startTime = ddl.StartTime, endTime = ddl.EndTime;
            int[] loopInterval = new int[6];
            for (int i = 0; i < 6; i++)
                loopInterval[i] = int.Parse(str[i]);

            startTime = endTime;
            endTime = AddTime(endTime, loopInterval[0], loopInterval[1], loopInterval[2], loopInterval[3], loopInterval[4], loopInterval[5], ddl.IsChineseCalender);

            while (endTime <= DateTime.Now)
            {
                startTime = AddTime(startTime, loopInterval[0], loopInterval[1], loopInterval[2], loopInterval[3], loopInterval[4], loopInterval[5], ddl.IsChineseCalender);
                endTime = AddTime(endTime, loopInterval[0], loopInterval[1], loopInterval[2], loopInterval[3], loopInterval[4], loopInterval[5], ddl.IsChineseCalender);
            }
            ddl.StartTime = startTime;
            ddl.EndTime = endTime;

            DatabaseOperation.Update(ddl);
        }

        public static DateTime AddTime(DateTime dt, int year, int month, int day, int hour, int minute, int second, bool isChineseCalender)
        {
            if (isChineseCalender)
            {
                ChineseLunisolarCalendar clc = new ChineseLunisolarCalendar();

                int lm = clc.GetLeapMonth(clc.GetYear(dt)) ;
                if (lm != 0 && clc.GetMonth(dt) >= lm)
                    dt = clc.AddMonths(dt, -1);
                dt = clc.AddYears(dt, year);
                lm = clc.GetLeapMonth(clc.GetYear(dt));
                if (lm != 0 && clc.GetMonth(dt) > lm)
                    dt = clc.AddMonths(dt, 1);

                dt = clc.AddMonths(dt, month);
                dt = clc.AddDays(dt, day);
                dt = clc.AddHours(dt, hour);
                dt = clc.AddMinutes(dt, minute);
                dt = clc.AddSeconds(dt, second);
            }
            else
                dt = dt.AddYears(year).AddMonths(month).AddDays(day).AddHours(hour).AddMinutes(minute).AddSeconds(second);

            return dt;
        }

        public static void RemindDdls()
        {
            foreach (Ddl ddl in ddls)
            {
                if (ddl.IsRemind == -1)
                    continue;

                if (ddl.RemindTime <= DateTime.Now)
                {
                    var leftTime = DdlOperation.leftTimesDict[ddl.Id];
                    if (leftTime.CompareTo(TimeSpan.Zero) > 0)
                        App.ShowBalloonTip(ddl.Name + "剩余" + DdlOperation.leftTimesDict[ddl.Id].ToString(@"d\:hh\:mm\:ss"));
                    else 
                        App.ShowBalloonTip(ddl.Name + "已过去" + DdlOperation.leftTimesDict[ddl.Id].ToString(@"d\:hh\:mm\:ss"));

                    NextRemind(ddl, false);
                }
            }
        }

        public static void NextRemind(Ddl ddl, bool recalculate)
        {
            DateTime now = DateTime.Now;
            if (recalculate)
                ddl.RemindTime = now.Date.AddDays(-1) + ddl.RemindTime.TimeOfDay;

            if (ddl.IsRemind == 0)
            {
                DateTime rt = ddl.RemindTime;
                string[] remindIntervalString = ddl.RemindInterval.Split('/');
                int[] remindInterval = { int.Parse(remindIntervalString[0]), int.Parse(remindIntervalString[1]), int.Parse(remindIntervalString[2]) };

                while (rt <= now)
                    rt = AddTime(rt, remindInterval[0], remindInterval[1], remindInterval[2], 0, 0, 0, ddl.IsChineseCalender);
                ddl.RemindTime = rt;
                DatabaseOperation.Update(ddl.Id, "RemindTime", rt);
            }
            else
            {
                DateTime rt = ddl.RemindTime;

                while (rt <= now || ddl.RemindInterval[Convert.ToInt16(rt.DayOfWeek)] != '1')
                    rt = rt.AddDays(1);
                ddl.RemindTime = rt;
                DatabaseOperation.Update(ddl.Id, "RemindTime", rt);
            }
        }

        public static void RefreshDdls()
        {
            ddls = DatabaseOperation.Select();
            leftTimesDict.Clear();
            foreach (Ddl ddl in ddls)
                leftTimesDict.Add(ddl.Id, CalcLeftTime(ddl.EndTime));
        }

        public static String GetChineseDateTimeString(DateTime dt)
        {
            ChineseLunisolarCalendar clc = new ChineseLunisolarCalendar();
            int year = clc.GetYear(dt),
                month = clc.GetMonth(dt),
                leapMonth = clc.GetLeapMonth(year),
                day = clc.GetDayOfMonth(dt);

            return GetChineseYearString(year) + " " + GetChineseMonthString(month, leapMonth) + " " + GetChineseDayString(day) + " " + dt.TimeOfDay.ToString();
        }

        private static string GetChineseYearString(int year)
        {
            string[] years0 = { "甲", "乙", "丙", "丁", "戊", "己", "庚", "辛", "壬", "癸" };
            string[] years1 = { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };

            int tianGan = (year - 4) % 10;
            int diZhi = (year - 4) % 12;
            return years0[tianGan] + years1[diZhi] + "(" + year + ")";
        }

        private static string GetChineseMonthString(int month, int leapMonth)
        {
            string[] months = { "正", "二", "三", "四", "五", "六", "七", "八", "九", "十", "冬", "腊" };

            bool isLeap = false;
            if (leapMonth > 0)
            {
                if (month > leapMonth)
                    month--;
                else if (month == leapMonth)
                {
                    month--;
                    isLeap = true;
                }
            }

            return (isLeap ? "闰" : "") + months[month - 1] + "月";
        }

        private static string GetChineseDayString(int day)
        {
            string[] days0 = { "初", "十", "廿" };
            string[] days1 = { "一", "二", "三", "四", "五", "六", "七", "八", "九", "十" };

            if (day == 30)
                return "三十";
            else if (day == 20)
                return "二十";
            else
                return days0[(day - 1) / 10] + days1[(day - 1) % 10];
        }
    }
}
