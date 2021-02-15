using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DDLM
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DdlPage dp;
        public static SettingPage sp;
        public static InfoPage ip;

        public MainWindow()
        {
            InitializeComponent();

            this.Closing += CloseMainWindow;
            this.Closing += StopRefreshDdlPage;
        }

        private void CloseMainWindow(object sender, CancelEventArgs e) => App.mw = null;

        private void StopRefreshDdlPage(object sender, CancelEventArgs e){
            dp = null;
            sp = null;
            ip = null;
            App.dt.Tick -= DdlPage.RefreshDdlPageEvent;
            App.dt.Tick -= DdlPage.RefreshDdlPageEventHandler;
        }

        private void DdlPageBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (dp == null)
                dp = new DdlPage();
            MainFrame.Content = dp;
            CheckBtnAnimation(DdlsIcon, DdlsTextBlock);
        }

        private void DdlPageBtn_Unchecked(object sender, RoutedEventArgs e)
            => UncheckBtnAnimation(DdlsIcon, DdlsTextBlock);

        private void SettingPageBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (sp == null)
                sp = new SettingPage();
            MainFrame.Content = sp;
            CheckBtnAnimation(SettingIcon, SettingTextBlock);
        }

        private void SettingPageBtn_Unchecked(object sender, RoutedEventArgs e)
            => UncheckBtnAnimation(SettingIcon, SettingTextBlock);

        private void InfoPageBtn_Checked(object sender, RoutedEventArgs e)
        {
            if (ip == null)
                ip = new InfoPage();
            MainFrame.Content = ip;
            CheckBtnAnimation(InfoIcon, InfoTextBlock);
        }

        private void InfoPageBtn_Unchecked(object sender, RoutedEventArgs e)
            => UncheckBtnAnimation(InfoIcon, InfoTextBlock);

        public static void ReloadMainWindow()
        {
            dp = null;
            ip = null;
        }

        private void CheckBtnAnimation(DependencyObject icon, TextBlock tb)
        {
            Storyboard sb = new Storyboard();

            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, icon, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, -45, 0, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, icon, "(materialDesign:PackIcon.RenderTransform).(RotateTransform.Angle)");
            StoryboardOperation.AddNewAnimation(sb, -30, 0, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, tb, "(ContentControl.RenderTransform).(TranslateTransform.X)");

            sb.Begin(this);
        }

        private void UncheckBtnAnimation(DependencyObject icon, TextBlock tb)
        {
            Storyboard sb = new Storyboard();

            StoryboardOperation.AddNewAnimation(sb, 1, 0, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, icon, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 0, -30, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, tb, "(ContentControl.RenderTransform).(TranslateTransform.X)");

            sb.Begin(this);
        }
    }
}
