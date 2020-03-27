using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DDLMwin
{
    /// <summary>
    /// DdlPage.xaml 的交互逻辑
    /// </summary>
       
    //DdlPage can show all deadlines and add new deadline
    public partial class DdlPage : Page
    {
        public static DdlPage self;

        public DdlPage()
        {
            InitializeComponent();
            self = this;

            RefreshDdlStackPanel();
            DdlOperation.dt.Tick += new EventHandler(DdlOperation.RefreshDdlPageEvent);
        }

        //add new deadline
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            DdlSettingWindow dsw = new DdlSettingWindow();
            if ((bool)dsw.ShowDialog())
            {
                RefreshDdlStackPanel();

                //show snakebar
                var queue = new SnackbarMessageQueue(TimeSpan.FromSeconds(1));
                Snackbar.MessageQueue = queue;
                queue.Enqueue("Deadline添加成功");
            } 
        }

        //show snackbar when delete success
        public void ShowSnackbar()
        {
            var queue = new SnackbarMessageQueue(TimeSpan.FromSeconds(1));
            Snackbar.MessageQueue = queue;
            queue.Enqueue("删除成功");
        }

        //clear the stack panel and add all deadlines
        public void RefreshDdlStackPanel()
        {
            DdlStackPanel.Children.Clear();
            foreach (Ddl ddl in DdlOperation.ddls)
            {
                SingleDdl sd = new SingleDdl(ddl.Id, ddl.Name, ddl.Time, DdlOperation.GetLeftTime(ddl.Id));
                DdlStackPanel.Children.Add(sd);
            }
        }
    }
}
