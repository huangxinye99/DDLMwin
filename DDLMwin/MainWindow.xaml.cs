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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DDLMwin
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        readonly Uri ddlPageUri = new Uri("DdlPage.xaml", UriKind.Relative);
        readonly Uri settingPageUri = new Uri("SettingPage.xaml", UriKind.Relative);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void DdlsBtn_Clicked(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(ddlPageUri);

        }

        private void SettingBtn_Clicked(object sender, RoutedEventArgs e)
        {
            mainFrame.NavigationService.Navigate(settingPageUri);
        }


    }
}
