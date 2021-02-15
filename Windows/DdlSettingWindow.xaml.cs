using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using MaterialDesignThemes.Wpf;

namespace DDLM
{
    /// <summary>
    /// DdlSettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DdlSettingWindow : Window
    {
        public Ddl ddl;
        public int id = -1;

        public DdlSettingWindow()
        {
            ddl = new Ddl();
            ddl.Name = "New Deadline";
            ddl.StartTime = DateTime.Now;
            ddl.EndTime = DateTime.Now.AddHours(1);
            ddl.Inform = "000";
            ddl.IsRemind = -1;
            InitializeDdlSettingWindow(ddl);
        }

        public DdlSettingWindow(int id)
        {
            ddl = DdlOperation.ddls.Find(d => d.Id == id);
            this.id = id;
            InitializeDdlSettingWindow(ddl);
        }

        public void InitializeDdlSettingWindow(Ddl ddl)
        {
            InitializeComponent();

            DdlNameTextBox.Text = ddl.Name;
            DdlPriority.Value = ddl.Priority;

            InitializeStartTime(ddl.StartTime);
            ChineseCheckbox.IsChecked = ddl.IsChineseCalender;
            InitializeEndTime(ddl.EndTime);

            var format = System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern;
            if (format == "M/d/yyyy")
            {
                StartMonth.SetValue(Grid.ColumnProperty, 0);
                StartDay.SetValue(Grid.ColumnProperty, 1);
                StartYear.SetValue(Grid.ColumnProperty, 2);

                EndMonth.SetValue(Grid.ColumnProperty, 0);
                EndDay.SetValue(Grid.ColumnProperty, 1);
                EndYear.SetValue(Grid.ColumnProperty, 2);
            }
            else if (format == "d/M/yyyy")
            {
                StartDay.SetValue(Grid.ColumnProperty, 0);
                StartMonth.SetValue(Grid.ColumnProperty, 1);
                StartYear.SetValue(Grid.ColumnProperty, 2);

                EndDay.SetValue(Grid.ColumnProperty, 0);
                EndMonth.SetValue(Grid.ColumnProperty, 1);
                EndYear.SetValue(Grid.ColumnProperty, 2);
            }


            LoopCheckbox.IsChecked = ddl.IsLoop;
            if (ddl.IsLoop)
                InitializeLoopinterval(ddl.LoopInterval);

            NoticeCheckbox.IsChecked = (ddl.Inform[0] == '1');
            WindowCheckbox.IsChecked = (ddl.Inform[1] == '1');
            SoundCheckbox.IsChecked = (ddl.Inform[2] == '1');

            RemindCheckbox.IsChecked = ddl.IsRemind != -1;
            if (ddl.IsRemind != -1)
                InitializeRemind(ddl.RemindInterval, ddl.RemindTime);

            if (System.Threading.Thread.CurrentThread.CurrentUICulture.Name != "zh-CN")
            {
                ChineseCheckbox.Visibility = Visibility.Hidden;
                ChineseCheckbox.IsEnabled = false;
            }
        }

        private void InitializeStartTime(DateTime dt)
        {
            GetYearMonthDayFromDateTime(dt, out int year, out int month, out int day, out bool isLeapMonth);
            StartYear.Text = year.ToString();
            StartMonth.Text = month.ToString();
            if (isLeapMonth)
                HintAssist.SetHint(StartMonth, "闰月");
            StartDay.Text = day.ToString();
            StartTimePicker.SelectedTime = dt;
        }

        private void InitializeEndTime(DateTime dt)
        {
            GetYearMonthDayFromDateTime(dt, out int year, out int month, out int day, out bool isLeapMonth);
            EndYear.Text = year.ToString();
            EndMonth.Text = month.ToString();
            if (isLeapMonth)
                HintAssist.SetHint(EndMonth, "闰月");
            EndDay.Text = day.ToString();
            EndTimePicker.SelectedTime = dt;
        }

        private void GetYearMonthDayFromDateTime(DateTime dt, out int year, out int month, out int day, out bool isLeapMonth)
        {
            isLeapMonth = false;

            if (ddl.IsChineseCalender)
            {
                ChineseLunisolarCalendar clc = new ChineseLunisolarCalendar();
                year = clc.GetYear(dt);
                month = clc.GetMonth(dt);
                int leapMonth = clc.GetLeapMonth(year);
                if (leapMonth > 0)
                    if (month > leapMonth)
                        month--;
                    else if (month == leapMonth)
                    {
                        month--;
                        isLeapMonth = true;
                    }
                day = clc.GetDayOfMonth(dt);
            }
            else
            {
                year = dt.Year;
                month = dt.Month;
                day = dt.Day;
            }
        }

        private void InitializeLoopinterval(string dt)
        {
            string[] s = dt.Split('/');
            LoopYear.Text = s[0];
            LoopMonth.Text = s[1];
            LoopDay.Text = s[2];
            LoopHour.Text = s[3];
            LoopMinute.Text = s[4];
            LoopSecond.Text = s[5];
        }

        private void InitializeRemind(string remindInterval, DateTime remindTime)
        {
            RemindTimePicker.SelectedTime = remindTime;

            if (ddl.IsRemind == 0)
            {
                string[] s = remindInterval.Split('/');
                RemindYear.Text = s[0];
                RemindMonth.Text = s[1];
                RemindDay.Text = s[2];
            }
            else
            {
                RemindTimeGrid.SelectedIndex = 1;

                SundayCheckBox.IsChecked = remindInterval[0] == '1';
                MondayCheckBox.IsChecked = remindInterval[1] == '1';
                TuesdayCheckBox.IsChecked = remindInterval[2] == '1';
                WednesdayCheckBox.IsChecked = remindInterval[3] == '1';
                ThursdayCheckBox.IsChecked = remindInterval[4] == '1';
                FridayCheckBox.IsChecked = remindInterval[5] == '1';
                SaturdayCheckBox.IsChecked = remindInterval[6] == '1';
            }

        }

        public void CloseWindow(object sender, RoutedEventArgs e) => Close();

        private void NoBtn_Click(object sender, RoutedEventArgs e) => CloseWindow(sender, e);

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            //set name
            if (DdlNameTextBox.Text.Length == 0)
            {
                ShowSnakebar(HintAssist.GetHint(DdlNameTextBox) + NullError.Text);
                return;
            }
            ddl.Name = DdlNameTextBox.Text;

            //set priority
            ddl.Priority = DdlPriority.Value;

            //set start time
            if (!GetStartTime(out DateTime startTime))
                return;
            ddl.StartTime = startTime;

            //set end time
            if (!GetEndTime(out DateTime endTime))
                return;
            ddl.EndTime = endTime;
            ddl.IsChineseCalender = (bool)ChineseCheckbox.IsChecked;

            //check start time < end time
            if (endTime.CompareTo(startTime) <= 0)
            {
                ShowSnakebar(StartEndTimeError.Text);
                return;
            }

            //set loop
            String loopInterval = "";
            if ((bool)LoopCheckbox.IsChecked && !GetLoopInterval(out loopInterval))
                return;
            ddl.IsLoop = (bool)LoopCheckbox.IsChecked;
            if (ddl.IsLoop)
                ddl.LoopInterval = loopInterval;

            //set inform
            ddl.Inform = ((bool)NoticeCheckbox.IsChecked ? "1" : "0") +
                        ((bool)WindowCheckbox.IsChecked ? "1" : "0") +
                        ((bool)SoundCheckbox.IsChecked ? "1" : "0");

            //set remind
            string remindInterval = "";
            if ((bool)RemindCheckbox.IsChecked && !GetRemindInterval(out remindInterval))
                return;
            ddl.IsRemind = (bool)RemindCheckbox.IsChecked ? 0 : -1;
            if (ddl.IsRemind != -1)
            {
                ddl.RemindInterval = remindInterval;
                DateTime? st = RemindTimePicker.SelectedTime;
                if (!st.HasValue)
                {
                    ShowSnakebar(HintAssist.GetHint(RemindTimePicker) + NullError.Text);
                    return;
                }
                ddl.RemindTime = ddl.StartTime.Date + ((DateTime)st).TimeOfDay;

                if (RemindTimeGrid.SelectedIndex == 1)
                    ddl.IsRemind = 1;
                DdlOperation.NextRemind(ddl, true);
            }

            if (id == -1)
                DatabaseOperation.Insert(ddl);
            else
                DatabaseOperation.Update(ddl);

            DdlOperation.RefreshDdls();

            DialogResult = true;
            CloseWindow(sender, e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                YesBtn_Click(sender, e);
            else if (e.Key == Key.Escape)
                CloseWindow(sender, e);
        }

        private void DragWindow(object sender, MouseButtonEventArgs e) => this.DragMove();

        private void StartMonth_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((bool)!ChineseCheckbox.IsChecked)
                return;
            if (HintAssist.GetHint(StartMonth).ToString() == "月")
                HintAssist.SetHint(StartMonth, "闰月");
            else
                HintAssist.SetHint(StartMonth, "月");
        }

        private void EndMonth_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((bool)!ChineseCheckbox.IsChecked)
                return;
            if (HintAssist.GetHint(StartMonth).ToString() == "月")
                HintAssist.SetHint(StartMonth, "闰月");
            else
                HintAssist.SetHint(StartMonth, "月");
        }

        private bool GetIntFromTextBox(TextBox tb, out int num)
        {
            num = -1;
            if (tb.Text == "")
            {
                num = 0;
                return true;
            }

            if (int.TryParse(tb.Text, out num))
            {
                if (num < 0)
                {
                    ShowSnakebar(tb.Name + MinusError.Text);
                    return false;
                }
                return true;

            }
            else
            {
                ShowSnakebar(tb.Name + NanError.Text);
                return false;
            }
        }

        private bool GetStartTime(out DateTime startTime)
        {
            startTime = new DateTime();
            ChineseLunisolarCalendar clc = new ChineseLunisolarCalendar();
            DateTime? st;
            int year, month, day;

            st = StartTimePicker.SelectedTime;
            if (!st.HasValue)
            {
                ShowSnakebar(HintAssist.GetHint(StartTimePicker) + NullError.Text);
                return false;
            }

            DateTime selectedTime = (DateTime)st;
            if (GetIntFromTextBox(StartYear, out year) && GetIntFromTextBox(StartMonth, out month) && GetIntFromTextBox(StartDay, out day))
            {
                if ((bool)ChineseCheckbox.IsChecked)
                {
                    if (day > clc.GetDaysInMonth(year, month))
                    {
                        ShowSnakebar(StartDateError.Text);
                        return false;
                    }

                    int leapMonth = clc.GetLeapMonth(year) - 1;
                    if (HintAssist.GetHint(StartMonth).ToString() == "闰月")
                    {
                        if (month == leapMonth)
                            month++;
                        else
                        {
                            ShowSnakebar(StartDateError.Text);
                            return false;
                        }
                    }
                    else
                    {
                        if (leapMonth > 0 && month > leapMonth)
                            month++;
                    }

                    startTime = clc.ToDateTime(year, month, day, selectedTime.Hour, selectedTime.Minute, selectedTime.Second, 0);

                }
                else
                {
                    if (day > DateTime.DaysInMonth(year, month))
                    {
                        ShowSnakebar(StartDateError.Text);
                        return false;
                    }
                    startTime = new DateTime(year, month, day, selectedTime.Hour, selectedTime.Minute, selectedTime.Second);
                }
                return true;
            }
            else
                return false;
        }

        private bool GetEndTime(out DateTime endTime)
        {
            endTime = new DateTime();
            ChineseLunisolarCalendar clc = new ChineseLunisolarCalendar();
            DateTime? st;
            int year, month, day;

            if (!DurationBtn.IsEnabled)  //end time
            {
                st = EndTimePicker.SelectedTime;
                if (!st.HasValue)
                {
                    ShowSnakebar(HintAssist.GetHint(EndTimePicker) + NullError.Text);
                    return false;
                }
                DateTime selectedTime = (DateTime)st;

                if (GetIntFromTextBox(EndYear, out year) && GetIntFromTextBox(EndMonth, out month) && GetIntFromTextBox(EndDay, out day))
                {
                    if ((bool)ChineseCheckbox.IsChecked)
                    {
                        if (day > clc.GetDaysInMonth(year, month))
                        {
                            ShowSnakebar(EndDateError.Text);
                            return false;
                        }


                        int leapMonth = clc.GetLeapMonth(year) - 1;
                        if (HintAssist.GetHint(EndMonth).ToString() == "闰月")
                        {
                            if (month == leapMonth)
                                month++;
                            else
                            {
                                ShowSnakebar(EndDateError.Text);
                                return false;
                            }
                        }
                        else
                        {
                            if (leapMonth > 0 && month > leapMonth)
                                month++;
                        }
                        endTime = clc.ToDateTime(year, month, day, selectedTime.Hour, selectedTime.Minute, selectedTime.Second, 0);
                    }
                    else
                    {
                        if (day > DateTime.DaysInMonth(year, month))
                        {
                            ShowSnakebar(EndDateError.Text);
                            return false;
                        }
                        endTime = new DateTime(year, month, day, selectedTime.Hour, selectedTime.Minute, selectedTime.Second);
                    }
                    return true;
                }
                else
                    return false;
            }
            else   //duration
            {
                if (GetIntFromTextBox(DurationYear, out year) && GetIntFromTextBox(DurationMonth, out month) && GetIntFromTextBox(DurationDay, out day) &&
                    GetIntFromTextBox(DurationHour, out int hour) && GetIntFromTextBox(DurationMinute, out int minute) && GetIntFromTextBox(DurationSecond, out int second))
                {
                    if (year + month + day + hour + minute + second == 0)
                    {
                        ShowSnakebar(DurationBtn.Content + ZerotimeError.Text);
                        return false;
                    }
                    else
                    {

                        endTime = DdlOperation.AddTime(ddl.StartTime, year, month, day, hour, minute, second, (bool)ChineseCheckbox.IsChecked);
                        return true;
                    }
                }
                else
                    return false;

            }
        }

        private bool GetLoopInterval(out string loopInterval)
        {
            loopInterval = "";
            if (GetIntFromTextBox(LoopYear, out int year) && GetIntFromTextBox(LoopMonth, out int month) && GetIntFromTextBox(LoopDay, out int day) &&
                GetIntFromTextBox(LoopHour, out int hour) && GetIntFromTextBox(LoopMinute, out int minute) && GetIntFromTextBox(LoopSecond, out int second))
            {
                loopInterval = year + "/" + month + "/" + day + "/"
                            + hour + "/" + minute + "/" + second;
                if (((bool)LoopCheckbox.IsChecked) && loopInterval == "0/0/0/0/0/0")
                {
                    ShowSnakebar(LoopCheckbox.Content + NullError.Text);
                    return false;
                }
                return true;
            }
            else
                return false;
        }

        private bool GetRemindInterval(out string remindInterval)
        {
            remindInterval = "";

            if (RemindTimeGrid.SelectedIndex == 0)
                if (GetIntFromTextBox(RemindYear, out int year) && GetIntFromTextBox(RemindMonth, out int month) && GetIntFromTextBox(RemindDay, out int day))
                    remindInterval = year + "/" + month + "/" + day;
                else
                    return false;
            else
                remindInterval =
                    ((bool)SundayCheckBox.IsChecked ? "1" : "0") +
                    ((bool)MondayCheckBox.IsChecked ? "1" : "0") +
                    ((bool)TuesdayCheckBox.IsChecked ? "1" : "0") +
                    ((bool)WednesdayCheckBox.IsChecked ? "1" : "0") +
                    ((bool)ThursdayCheckBox.IsChecked ? "1" : "0") +
                    ((bool)FridayCheckBox.IsChecked ? "1" : "0") +
                    ((bool)SaturdayCheckBox.IsChecked ? "1" : "0");

            if ((bool)RemindCheckbox.IsChecked && (remindInterval == "0/0/0" || remindInterval == "0000000"))
            {
                ShowSnakebar(RemindCheckbox.Content + NullError.Text);
                return false;
            }
            return true;
        }

        private void ShowSnakebar(string s)
        {
            var queue = new SnackbarMessageQueue(TimeSpan.FromSeconds(1));
            Snackbar.MessageQueue = queue;
            queue.Enqueue(s);
        }

    }

}
