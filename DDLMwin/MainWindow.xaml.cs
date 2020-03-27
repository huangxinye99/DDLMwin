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
        public static DdlPage dp;
        public static SettingPage sp;
        public static AboutPage ap;

        public MainWindow()
        {
            InitializeComponent();

            dp = new DdlPage();
            sp = new SettingPage();
            ap = new AboutPage();

            this.Closing += CloseMainWindow;
        }

        private void CloseMainWindow(object sender, CancelEventArgs e) => App.mw = null;

        //open deadline page
        private void DdlsBtn_Clicked(object sender, RoutedEventArgs e) => mainFrame.Content = dp;

        //open setting page
        private void SettingBtn_Clicked(object sender, RoutedEventArgs e) => mainFrame.Content = sp;

        //open about page
        private void AboutBtn_Clicked(object sender, RoutedEventArgs e) => mainFrame.Content = ap;

        
    }
}
