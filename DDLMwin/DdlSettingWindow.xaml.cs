using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DDLMwin
{
    /// <summary>
    /// DdlSettingWindow.xaml 的交互逻辑
    /// </summary>
    
    //DdlSettingWindow sets the information of a deadline
    public partial class DdlSettingWindow : Window
    {
        public string ddlName = "New Deadline";
        public DateTime ddlTime;
        public int id = 0;

        public DdlSettingWindow()
        {
            ddlTime = DateTime.Now.AddHours(1);
            InitializeDdlSettingWindow();
        }

        public DdlSettingWindow(int id)
        {
            this.id = id;
            Ddl ddl = DdlOperation.ddls.Find(d => d.Id == id);
            ddlName = ddl.Name;
            ddlTime = ddl.Time;
            InitializeDdlSettingWindow();
        }

        public DdlSettingWindow(int id, String ddlName, DateTime ddlTime)
        {
            this.ddlName = ddlName;
            this.ddlTime = ddlTime;
            this.id = id;
            InitializeDdlSettingWindow();
        }

        private void InitializeDdlSettingWindow()
        {
            InitializeComponent();

            DdlNameTextBox.Text = ddlName;
            DatePicker.SelectedDate = ddlTime.Date;
            TimePicker.SelectedTime = ddlTime;
        }

        private void DragWindow(object sender, MouseButtonEventArgs e) => this.DragMove();

        public void CloseWindow(object sender, RoutedEventArgs e) => this.Close();

        private void NoBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
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
                ddlName = DdlNameTextBox.Text;
                DateTime ddlTime = CalcDdlTime();
                if (CheckTime(ddlTime))
                {
                    if (id == 0)
                        SaveDdl(ddlName, ddlTime);
                    else
                        SaveDdl(id, ddlName, ddlTime);
                    
                    MessageBox.Show("Deadline已设置 \n名称：" + ddlName + "\n时间：" + ddlTime);

                    DdlFlowWindow dfw = DdlOperation.flowWindows.Find(fw => fw.id == id);
                    if (dfw != null)
                        dfw.DdlNameTextBlock.Text = ddlName;

                    this.DialogResult = true;
                    CloseWindow(sender, e);
                }
                else
                    MessageBox.Show("Deadline早于当前时间！");
            }
            else
            {
                MessageBox.Show("Deadline名称不能为空！");
            }
        }

        //check if the textbox is null
        private Boolean CheckNull()
        {
            if (DdlNameTextBox.Text.Length == 0)
                return false;
            return true;
        }

        //get DateTime from two pickers
        private DateTime CalcDdlTime()
        {
            DateTime ddlTime = (DateTime)TimePicker.SelectedTime;
            TimeSpan ts = (TimeSpan)(DatePicker.SelectedDate - ddlTime.Date);
            ddlTime = ddlTime.AddDays(ts.Days);
            return ddlTime;
        }

        //check if deadline time is ahead of now
        private Boolean CheckTime(DateTime ddlTime)
        {
            DateTime now = DateTime.Now;
            TimeSpan ts = ddlTime - now;
            if (ts.TotalSeconds > 0)
                return true;
            return false;
        }

        //add new deadline
        private void SaveDdl(string ddlName, DateTime ddlTime)
        {
            DbOperation.Insert(ddlName, ddlTime);
            
            DdlOperation.RefreshDdls();
        }

        //update the deadline
        private void SaveDdl(int id, String ddlName, DateTime ddlTime)
        {
            DbOperation.Update(id, ddlName, ddlTime);
            DdlOperation.RefreshDdls();

        }

    }
}
