using System;
using System.ComponentModel;
using System.Windows;

namespace DDLMwin
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SettingPage sp;
        public static AboutPage ap;

        public MainWindow()
        {
            InitializeComponent();

            sp = new SettingPage();
            ap = new AboutPage();

            this.Closing += CloseMainWindow;
            this.Closing += StopRefreshDdlPage;
        }

        private void CloseMainWindow(object sender, CancelEventArgs e) => App.mw = null;

        //open deadline page
        private void DdlsBtn_Clicked(object sender, RoutedEventArgs e) => mainFrame.Content = new DdlPage();

        //open setting page
        private void SettingBtn_Clicked(object sender, RoutedEventArgs e) => mainFrame.Content = sp;

        //open about page
        private void AboutBtn_Clicked(object sender, RoutedEventArgs e) => mainFrame.Content = ap;

        private void StopRefreshDdlPage(object sender, EventArgs e) => DdlOperation.dt.Tick -= new EventHandler(DdlOperation.RefreshDdlPageEvent);
    }
}
