using System;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using MaterialDesignThemes.Wpf;


namespace DDLM
{
    /// <summary>
    /// SingleDdl.xaml 的交互逻辑
    /// </summary>
    public partial class SingleDdl : UserControl
    {
        public Ddl ddl;
        public double percentage;
        private bool isDeleteComfirmed, isAnimationPlaying;

        public SingleDdl(Ddl ddl)
        {
            this.ddl = ddl;
            TimeSpan leftTime = DdlOperation.leftTimesDict[ddl.Id];
            percentage = 1 - leftTime.TotalSeconds / ddl.EndTime.Subtract(ddl.StartTime).TotalSeconds;

            InitializeComponent();

            ReloadSingleDdl();
        }

        private void SingleDdl_MouseEnter(object sender, MouseEventArgs e) => FocusSingleDdlAnimation();

        private void SingleDdl_MouseLeave(object sender, MouseEventArgs e) => UnfocusSingleDdlAnimation();

        private void SingleDdl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (BtnPanel.IsVisible)
                HideBtnPanelAnimation();
            else
                ShowBtnPanelAnimation();
        }

        private void SettingDdlBtn_Click(object sender, RoutedEventArgs e)
        {
            Grid.BackgroundProperty.ToString();
            DdlSettingWindow dsw = new DdlSettingWindow(ddl.Id);
            if ((bool)dsw.ShowDialog())
            {
                ReloadSingleDdlWithAnimation();

                if (FlowWindowOperation.flowWindows.Exists(d => d.ddl.Id == ddl.Id))
                    FlowWindowOperation.flowWindows.Find(d => d.ddl.Id == ddl.Id).DdlNameTextBlock.Text = ddl.Name;
                DdlPage.self.ShowSnackbar(ddl.Name + " 更改成功");
            }
        }

        private void FlowDdlBtn_Click(object sender, RoutedEventArgs e)
        {
            if (FlowWindowOperation.flowWindows.Exists(d => d.ddl.Id == ddl.Id))
                return;
            else
            {
                FlowWindow fw = new FlowWindow(ddl, 1);
                double[] d = { 0, 0, 1 };
                fw.Left = 0;
                fw.Top = 0;
                FlowWindowOperation.flowWindows.Add(fw);
                fw.Show();
            }
        }

        private void DeleteDdlBtn_Click(object sender, RoutedEventArgs e)
        {
            if (isDeleteComfirmed)
            {
                FlowWindow dfw = FlowWindowOperation.flowWindows.Find(d => d.ddl.Id == ddl.Id);
                if (dfw != null)
                {
                    dfw.Close();
                    FlowWindowOperation.flowWindows.Remove(dfw);
                }

                DatabaseOperation.Delete(ddl.Id);
                DdlOperation.RefreshDdls();
                DdlPage.self.ReloadDdlStackPanel();
                DdlPage.self.ShowSnackbar("删除成功");
            }
            else
            {
                isDeleteComfirmed = true;
                PackIcon icon = new PackIcon();
                icon.Kind = PackIconKind.CheckBold;
                icon.Height = 24;
                icon.Width = 24;
                DeleteDdlBtn.Content = icon;
            }
        }

        public void RefreshSingleDdl()
        {
            bool b = DdlOperation.leftTimesDict.TryGetValue(ddl.Id, out TimeSpan leftTime);
            if (!b || isAnimationPlaying)
                return;

            //Update LeftTimeTextBlock
            leftTimeTextBlock.Text = (leftTime < TimeSpan.Zero ? "-" : "") + leftTime.ToString(@"d\:hh\:mm\:ss");

            //Update ProgressRect
            if (leftTime.TotalSeconds < 1)
            {
                if (leftTime.TotalSeconds >= 0 || ddl.IsLoop)
                    ReloadSingleDdlWithAnimation();
                else
                    ProgressRect.Fill = (SolidColorBrush)FindResource("SecondaryHueMidBrush");
            }
            else
                ProgressRect.Fill = (SolidColorBrush)FindResource("PrimaryHueLightBrush");
            percentage = 1 - leftTime.TotalSeconds / ddl.EndTime.Subtract(ddl.StartTime).TotalSeconds;
            if (percentage >= 1)
                percentage = 1;
            else if (percentage <= 0)
                percentage = 0;
            ProgressRect.Width = ActualWidth * percentage;
        }

        public void ReloadSingleDdl()
        {
            ddl = DdlOperation.ddls.Find(d => d.Id == ddl.Id);

            TimeSpan leftTime = DdlOperation.leftTimesDict[ddl.Id];
            percentage = 1 - leftTime.TotalSeconds / ddl.EndTime.Subtract(ddl.StartTime).TotalSeconds;

            string startTimeStr, endTimeStr;
            if (ddl.IsChineseCalender)
            {
                startTimeStr = DdlOperation.GetChineseDateTimeString(ddl.StartTime);
                endTimeStr = DdlOperation.GetChineseDateTimeString(ddl.EndTime);
            }
            else
            {
                startTimeStr = ddl.StartTime.ToString();
                endTimeStr = ddl.EndTime.ToString();
            }

            ddlTime.Text = startTimeStr + " —— " + endTimeStr;
            ddlNameTextBlock.Text = ddl.Name;
            ddlPriority.Value = ddl.Priority;
            leftTimeTextBlock.Text = (leftTime < TimeSpan.Zero ? "-" : "") + leftTime.ToString(@"d\:hh\:mm\:ss");

            RefreshSingleDdl();
        }

        async public void ReloadSingleDdlWithAnimation()
        {
            isAnimationPlaying = true;
            Storyboard sb = new Storyboard();
            UnloadSingleDdlAnimation(sb, 0);
            sb.Begin(this);
            await Task.Delay(1000);

            ReloadSingleDdl();
            ProgressRect.RenderTransform = new ScaleTransform(0, 1);

            sb = new Storyboard();
            LoadSingleDdlAnimation(sb, 0);
            sb.Begin(this);
            await Task.Delay(1000);
            isAnimationPlaying = false;
        }

        public void FocusSingleDdlAnimation()
        {
            Storyboard sb = new Storyboard();

            StoryboardOperation.AddNewAnimation(sb, 0.5, 1, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, DdlBackground, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, DdlBackground, "(Grid.Effect).(DropShadowEffect.Opacity)");

            sb.Begin(this);
        }

        public void UnfocusSingleDdlAnimation()
        {
            Storyboard sb = new Storyboard();

            StoryboardOperation.AddNewAnimation(sb, 1, 0.5, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, DdlBackground, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 1, 0, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, DdlBackground, "(Grid.Effect).(DropShadowEffect.Opacity)");

            if (BtnPanel.IsVisible)
                HideBtnPanelAnimation();

            sb.Begin(this);
        }

        public void LoadSingleDdlAnimation(Storyboard sb, int i)
        {
            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0.1 * i, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, Container, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, -150, 0, 0.1 * i, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, Container, "(RenderTransform).(TranslateTransform.X)");
            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0.1 * i + 1, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, ProgressRect, "(RenderTransform).(ScaleTransform.ScaleX)");
        }

        public void UnloadSingleDdlAnimation(Storyboard sb, int i)
        {
            StoryboardOperation.AddNewAnimation(sb, 1, 0, 0.1 * i, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseIn, Container, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 0, 150, 0.1 * i, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseIn, Container, "(RenderTransform).(TranslateTransform.X)");
            StoryboardOperation.AddNewAnimation(sb, 1, 0, 0.1 * i + 1, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseIn, ProgressRect, "(RenderTransform).(ScaleTransform.ScaleX)");
        }

        public void ShowBtnPanelAnimation()
        {
            BtnPanel.Visibility = Visibility.Visible;

            Storyboard sb = new Storyboard();

            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, BtnPanel, "(Opacity)");

            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0.1, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, SettingDdlBtn, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 25, 0, 0.1, 0.5, StoryboardOperation.EaseType.BackEase, EasingMode.EaseOut, SettingDdlBtn, "(ContentControl.RenderTransform).(TranslateTransform.Y)");
            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0.2, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, FlowDdlBtn, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 25, 0, 0.2, 0.5, StoryboardOperation.EaseType.BackEase, EasingMode.EaseOut, FlowDdlBtn, "(ContentControl.RenderTransform).(TranslateTransform.Y)");
            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0.3, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, DeleteDdlBtn, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 25, 0, 0.3, 0.5, StoryboardOperation.EaseType.BackEase, EasingMode.EaseOut, DeleteDdlBtn, "(ContentControl.RenderTransform).(TranslateTransform.Y)");

            sb.Begin(this);
        }
        
        async public void HideBtnPanelAnimation()
        {
            Storyboard sb = new Storyboard();

            StoryboardOperation.AddNewAnimation(sb, 1, 0, 0.3, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseIn, BtnPanel, "(Opacity)");

            StoryboardOperation.AddNewAnimation(sb, 1, 0, 0.1, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseIn, SettingDdlBtn, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 0, 25, 0.1, 0.5, StoryboardOperation.EaseType.BackEase, EasingMode.EaseIn, SettingDdlBtn, "(ContentControl.RenderTransform).(TranslateTransform.Y)");
            StoryboardOperation.AddNewAnimation(sb, 1, 0, 0.2, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseIn, FlowDdlBtn, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 0, 25, 0.2, 0.5, StoryboardOperation.EaseType.BackEase, EasingMode.EaseIn, FlowDdlBtn, "(ContentControl.RenderTransform).(TranslateTransform.Y)");
            StoryboardOperation.AddNewAnimation(sb, 1, 0, 0.3, 0.5, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseIn, DeleteDdlBtn, "(Opacity)");
            StoryboardOperation.AddNewAnimation(sb, 0, 25, 0.3, 0.5, StoryboardOperation.EaseType.BackEase, EasingMode.EaseIn, DeleteDdlBtn, "(ContentControl.RenderTransform).(TranslateTransform.Y)");

            sb.Begin(this);
            isDeleteComfirmed = false;
            await Task.Delay(800);
            PackIcon icon = new PackIcon();
            icon.Kind = PackIconKind.Delete;
            icon.Height = 24;
            icon.Width = 24;
            DeleteDdlBtn.Content = icon;
            BtnPanel.Visibility = Visibility.Hidden;
        }
    }
}
