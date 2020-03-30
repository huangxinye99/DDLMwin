using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DDLMwin
{
    /// <summary>
    /// SingleDdl.xaml 的交互逻辑
    /// </summary>
    public partial class SingleDdl : UserControl
    {
        //SingleDdl shows the information of a deadline

        public static SingleDdl self;
        public readonly int id;
        private readonly string ddlName;
        private readonly DateTime ddlTime;
        private readonly String leftTime;

        public SingleDdl(int id, string name, DateTime ddlTime, String leftTime)
        {
            this.id = id;
            ddlName = name;
            this.ddlTime = ddlTime;
            this.leftTime = leftTime;
            self = this;

            InitializeSingleDdl();
        }

        private void InitializeSingleDdl()
        {
            InitializeComponent();

            ddlNameTextBlock.Text = ddlName;
            ddlTimeTextBlock.Text = ddlTime.ToString();
            leftTimeTextBlock.Text = leftTime;
        }

        //change the info of deadline wen clicked
        private void OpenDdlSettingWindow(object sender, MouseButtonEventArgs e)
        {
            Grid.BackgroundProperty.ToString();
            DdlSettingWindow dsw = new DdlSettingWindow(id, ddlName, ddlTime);
            dsw.ShowDialog();
            if ((bool)dsw.DialogResult)
            {
                DdlPage.self.RefreshDdlStackPanel();

                //show snakebar
                var queue = new SnackbarMessageQueue(TimeSpan.FromSeconds(1));
                DdlPage.self.Snackbar.MessageQueue = queue;
                queue.Enqueue("Deadline更改成功");
            }
        }

        //refresh the left time of deadline
        public void RefreshLeftTimeLabel(object sender, EventArgs e) => leftTimeTextBlock.Text = DdlOperation.GetLeftTime(id);

        private void DdlFocused(object sender, MouseEventArgs e) => (sender as UserControl).Opacity = 1;
        //highlight the SIngleDdl when selected
        private void DdlUnfocused(object sender, MouseEventArgs e) => (sender as UserControl).Opacity = 0.4;

        //create a flow window
        private void FlowDdlBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DdlOperation.flowWindows.Exists(d => d.id == id))
            {
                MessageBox.Show("浮窗已创建");
            }
            else
            {
                DdlFlowWindow dfw = new DdlFlowWindow(id, ddlName, leftTime, 1);
                double[] d = {0, 0, 1 };
                DdlOperation.flowWindowsSetting.Add(id, d);
                dfw.Left = 0;
                dfw.Top = 0;
                dfw.Size = 1;
                DdlOperation.flowWindows.Add(dfw);
                dfw.Show();
            }
        }

        //delete this deadline
        private void DeleteDdlBtn_Click(object sender, RoutedEventArgs e)
        {
            ConfirmWindow cw = new ConfirmWindow();
            cw.ShowDialog();
            if (cw.DialogResult == true)
            {
                //close the flow window if exists
                DdlFlowWindow dfw = DdlOperation.flowWindows.Find(d => d.id == id);
                if (dfw != null)
                {
                    dfw.Close();
                    DdlOperation.flowWindows.Remove(dfw);
                    DdlOperation.flowWindowsSetting.Remove(id);
                }

                DbOperation.Delete(id);
                DdlOperation.RefreshDdls();
                DdlPage.self.RefreshDdlStackPanel();
                DdlPage.self.ShowSnackbar();

            }

        }


    }
}
