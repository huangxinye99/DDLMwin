using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;

namespace DDLMwin
{
    /// <summary>
    /// DdlSettingWindow.xaml 的交互逻辑
    /// </summary>
    public partial class DdlSettingWindow : Window
    {

        public string ddlName = "New Deadline";
        public DateTime time;
        public TextBox ddlNameTextBox;
        public DatePicker datePicker;
        public TimePicker timePicker;
        public int id = 0;

        public DdlSettingWindow(int id)
        {
            InitializeDdlSettingWindow();
            this.id = id;
        }

        public DdlSettingWindow()
        {
            InitializeDdlSettingWindow();
        }

        private void InitializeDdlSettingWindow()
        {
            InitializeComponent();
            ddlNameTextBox = this.FindName("DdlNameTextBox") as TextBox;
            datePicker = this.FindName("DatePicker") as DatePicker;
            timePicker = this.FindName("TimePicker") as TimePicker;

            if(id == 0)
            {
                time = DateTime.Now.AddHours(1);
                ddlNameTextBox.Text = ddlName;
                datePicker.SelectedDate = time.Date;
                timePicker.SelectedTime = time;
            }
            else
            {
                //get data from database using id
                GetDdl(id);
                time = DateTime.Now.AddHours(1);
                ddlNameTextBox.Text = ddlName;
                datePicker.SelectedDate = time.Date;
                timePicker.SelectedTime = time;
            }

        }

        private void DragWindow(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        public void CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow(sender, e);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                YesBtn_Click(sender, e);
        }

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            //put the data into the database
            if (CheckNull())
            {
                DateTime ddlTime = CalcDdlTime();
                if (CheckTime(ddlTime))
                {
                    SaveDdl(ddlName, ddlTime);
                    MessageBox.Show("Deadline已设置");
                    CloseWindow(sender, e);
                }
                else
                    MessageBox.Show("Deadline早于当前时间！");
            }
        }

        private Boolean CheckNull()
        {
            if (ddlNameTextBox.Text.Length == 0)
            {
                MessageBox.Show("Deadline名称不能为空！");
                return false;
            }
            /*if (datePicker.SelectedDate == null)
            {
                MessageBox.Show("日期不能为空！");
                return false;
            }
            if (timePicker.SelectedTime == null)
            {
                MessageBox.Show("时间不能为空！");
                return false;
            }*/
            return true;
        }

        private DateTime CalcDdlTime()
        {
            DateTime ddlTime = (DateTime)timePicker.SelectedTime;
            TimeSpan ts = (TimeSpan)(datePicker.SelectedDate - DateTime.Now.Date);
            ddlTime = ddlTime.AddDays(ts.Days);
            return ddlTime;
        }

        private Boolean CheckTime(DateTime ddlTime)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = ddlTime - now;
            if (ts.TotalSeconds > 0)
                return true;
            return false;
        }

        private void GetDdl(int id)
        {

        }

        private void SaveDdl(string ddlName, DateTime ddlTime)
        {

        }

    }
}
