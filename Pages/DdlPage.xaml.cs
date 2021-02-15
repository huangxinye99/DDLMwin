using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using MaterialDesignThemes.Wpf;

namespace DDLM
{
    /// <summary>
    /// DdlPage.xaml 的交互逻辑
    /// </summary>
    public partial class DdlPage : Page
    {
        public static DdlPage self;
        public static EventHandler RefreshDdlPageEventHandler;

        public DdlPage()
        {
            InitializeComponent();
            self = this;
            ReloadDdlStackPanel();

            RefreshDdlPageEventHandler = new EventHandler(RefreshDdlPageEvent);
            App.dt.Tick += RefreshDdlPageEventHandler;
        }

        //add new deadline
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

            DdlSettingWindow dsw = new DdlSettingWindow();
            if ((bool)dsw.ShowDialog())
            {
                ReloadDdlStackPanel();
                ShowSnackbar("Deadline添加成功");
            }
        }

        private void ReloadBtn_Click(object sender, RoutedEventArgs e) => ReloadDdlStackPanel();

        public void ShowSnackbar(string s)
        {
            var queue = new SnackbarMessageQueue(TimeSpan.FromSeconds(1));
            Snackbar.MessageQueue = queue;
            queue.Enqueue(s);
        }

        public static void RefreshDdlPageEvent(object sender, EventArgs e)
        {
            foreach (SingleDdl sd in DdlPage.self.DdlStackPanel.Children)
                sd.RefreshSingleDdl();
        }

        //clear the stack panel and add all deadlines
        async public void ReloadDdlStackPanel()
        {
            App.dt.Tick -= DdlPage.RefreshDdlPageEvent;
            App.dt.Tick -= DdlPage.RefreshDdlPageEventHandler;

            UnloadDdlsAnimation();
            if (DdlStackPanel.Children.Count > 0)
                await Task.Delay(1000 + 100 * (DdlStackPanel.Children.Count));

            DdlStackPanel.Children.Clear();

            foreach (Ddl ddl in DdlOperation.ddls)
            {
                SingleDdl sd = new SingleDdl(ddl);
                DdlStackPanel.Children.Add(sd);
                sd.ProgressRect.Width *= sd.percentage;
            }

            App.dt.Tick += RefreshDdlPageEvent;
            LoadDdlsAnimation();
        }

        private void LoadDdlsAnimation()
        {
            Storyboard sb = new Storyboard();
            int i = 1;
            foreach (SingleDdl sd in DdlStackPanel.Children)
            {
                sd.LoadSingleDdlAnimation(sb, i);
                i++;
            }
            sb.Begin(this);
        }

        private void UnloadDdlsAnimation()
        {
            Storyboard sb = new Storyboard();
            int i = 1;
            foreach (SingleDdl sd in DdlStackPanel.Children)
            {
                sd.UnloadSingleDdlAnimation(sb, i);
                i++;
            }
            sb.Begin(this);
        }
    }
}
