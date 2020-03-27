using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace DDLMwin
{
    //define all the operations about deadlines

    class DdlOperation
    {
        public static List<Ddl> ddls;
        public static Dictionary<int, TimeSpan> leftTimes = new Dictionary<int, TimeSpan>();
        //public readonly static List<TimeSpan> leftTimes;
        static MediaPlayer player;
        public static List<DdlFlowWindow> flowWindows = new List<DdlFlowWindow>();
        public static readonly DispatcherTimer dt = new DispatcherTimer();

        public DdlOperation()
        {
            ddls = DbOperation.Select();

            //add left time of deadlines
            foreach (Ddl ddl in ddls)
                leftTimes.Add(ddl.Id, CalcLeftTime(ddl.Time));

            dt.Tick += new EventHandler(DdlOperation.CalcLeftTimesEvent);
            dt.Tick += new EventHandler(DdlOperation.RefreshFlowWindowsEvent);
            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();
        }

        //calculate the left time of a deadline
        public static TimeSpan CalcLeftTime(DateTime time) => time.Subtract(DateTime.Now);

        //return string
        public static string GetLeftTime(int id)
        {
            TimeSpan ts = leftTimes[id];
            return ((ts < TimeSpan.Zero) ? "-" : "") + ts.ToString(@"d\:hh\:mm\:ss");
        }

        //calculate the left time of all deadlines
        public static void CalcLeftTimes()
        {
            foreach (Ddl ddl in ddls)
            {
                TimeSpan ts = CalcLeftTime(ddl.Time);
                leftTimes[ddl.Id] = ts;
                if (CheckExpired(ts))
                    Alert(ddl);
            }
        }

        public static void CalcLeftTimesEvent(object sender, EventArgs e) => CalcLeftTimes();

        //check if the deadline was expired
        private static Boolean CheckExpired(TimeSpan ts) => (ts.TotalSeconds < 0 && ts.TotalSeconds > -1) ? true : false;

        //alert the alarm
        private static void Alert(Ddl ddl)
        {
            if (SettingOperation.alarm)
            {
                try
                {
                    player = new MediaPlayer
                    {
                        Volume = SettingOperation.alarmVolume
                    };
                    player.Open(new Uri(SettingOperation.alarmPath));
                    player.Play();
                }
                catch (Exception) { MessageBox.Show("音频加载失败！"); }
            }

            if (SettingOperation.showMessageBox)
                MessageBox.Show(ddl.Name + "时间到！");
        }

        //refresh the list and distionary after add/update/delete deadlines
        public static void RefreshDdls()
        {
            ddls = DbOperation.Select();
            leftTimes.Clear();
            foreach (Ddl ddl in ddls)
                leftTimes.Add(ddl.Id, CalcLeftTime(ddl.Time));
        }

        public static void RefreshDdlPageEvent(object sender, EventArgs e)
        {
            foreach (SingleDdl child in DdlPage.self.DdlStackPanel.Children)
                child.leftTimeTextBlock.Text = DdlOperation.GetLeftTime(child.id);
        }

        public static void RefreshFlowWindowsEvent(object sender, EventArgs e)
        {
            foreach (DdlFlowWindow dfw in flowWindows)
                dfw.LeftTimeTextBlock.Text = GetLeftTime(dfw.id);
        }

        //show all flow deadlines
        public static void ShowAllFlowWindowEvent(object sender, EventArgs e)
        {
            foreach (DdlFlowWindow dfw in flowWindows)
                dfw.Show();
        }

        //hide all flow deadlines
        public static void HideAllFlowWindowEvent(object sender, EventArgs e)
        {
            foreach (DdlFlowWindow dfw in flowWindows)
                dfw.Hide();
        }

    }
}
