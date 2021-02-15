using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using swf = System.Windows.Forms;

namespace DDLM
{
    /// <summary>
    /// FlowWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FlowWindow : Window
    {
        public Ddl ddl;
        private int threshold;
        public static FlowWindow self;
        public double percentage;
        private double _size;
        public double Size
        {
            get => _size;
            set => _size = (value < 0.2) ? 0.2 : value;
        }

        public FlowWindow(Ddl inputDdl, double size)
        {
            ddl = inputDdl;
            self = this;
            Size = size;

            InitializeComponent();
            DdlNameTextBlock.Text = ddl.Name;
            DdlNameTextBlock.FontSize = 50 * Size;

            LeftTimeTextBlock.FontSize = 50 * Size;
            RefreshFlowWindow();

            OpenAnimation();
        }

        private void DdlFlowWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
            InScreen();
        }

        private void DdlFlowWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Size += ((double)e.Delta) / 1200;
            DdlNameTextBlock.FontSize = 50 * Size;
            LeftTimeTextBlock.FontSize = 50 * Size;
            InScreen();
            RefreshFlowWindow();
        }

        private void DdlFlowWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            FlowWindowOperation.flowWindows.Remove(this);
            Close();
        }

        private void DdlFlowWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DdlSettingWindow dsw = new DdlSettingWindow(ddl.Id);
            if ((bool)dsw.ShowDialog())
            {
                ddl = DdlOperation.ddls.Find(d => d.Id == ddl.Id);
                DdlNameTextBlock.Text = ddl.Name;
                if (App.mw != null && (App.mw.MainFrame.Content.GetType().Name == "DdlPage"))
                {
                    DdlPage dp = (DdlPage)App.mw.MainFrame.Content;
                    var sds = dp.DdlStackPanel.Children;
                    foreach (SingleDdl sd in sds)
                        if (sd.ddl.Id == ddl.Id)
                        {
                            sd.ReloadSingleDdlWithAnimation();
                            break;
                        }
                }
            }
        }

        private void InScreen()
        {
            System.Drawing.Point p = new System.Drawing.Point((int)Left, (int)Top);

            swf.Screen currentScreen = swf.Screen.FromPoint(p);

            var workingArea = currentScreen.WorkingArea;
            threshold = (int)(workingArea.Height * 0.03);

            if (Left < workingArea.X + threshold)
                Left = workingArea.X;
            else if (Left + Width > workingArea.Width + workingArea.X - threshold)
                Left = workingArea.Width + workingArea.X - Width;

            if (Top < workingArea.Y + threshold)
                Top = workingArea.Y;
            else if (Top + Height > workingArea.Height + workingArea.Y - threshold)
                Top = workingArea.Height + workingArea.Y - Height;
        }

        public void RefreshFlowWindow()
        {
            bool b = DdlOperation.leftTimesDict.TryGetValue(ddl.Id, out TimeSpan leftTime);
            if (!b)
                return;
            LeftTimeTextBlock.Text = (leftTime < TimeSpan.Zero ? "-" : "") + leftTime.ToString(@"d\:hh\:mm\:ss");
            percentage = 1 - leftTime.TotalSeconds / ddl.EndTime.Subtract(ddl.StartTime).TotalSeconds;
            if (percentage >= 1)
            {
                ProgressRect.Fill = (SolidColorBrush)FindResource("SecondaryHueMidBrush");
                percentage = 1;
            }
            else if (percentage > 0)
                ProgressRect.Fill = (SolidColorBrush)FindResource("PrimaryHueLightBrush");
            else
                percentage = 0;

            Container.Width = DdlNameTextBlock.ActualWidth + NullTextBlock.ActualWidth + LeftTimeTextBlock.ActualWidth;
            ProgressRect.Width = Width * percentage;

            InScreen();
        }

        private void OpenAnimation()
        {
            Storyboard sb = new Storyboard();

            StoryboardOperation.AddNewAnimation(sb, -150, 0, 0, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, Container, "(RenderTransform).(TranslateTransform.X)");
            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, Bg, "(RenderTransform).(ScaleTransform.ScaleX)");
            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0.5, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, ProgressRect, "(RenderTransform).(ScaleTransform.ScaleX)");

            sb.Begin(this);
        }

        private void CloseAnimation()
        {
            Storyboard sb = new Storyboard();

            StoryboardOperation.AddNewAnimation(sb, -150, 0, 0, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, Container, "(RenderTransform).(TranslateTransform.X)");
            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, Bg, "(RenderTransform).(ScaleTransform.ScaleX)");
            StoryboardOperation.AddNewAnimation(sb, 0, 1, 0.5, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, ProgressRect, "(RenderTransform).(ScaleTransform.ScaleX)");

            sb.Begin(this);
        }

    }

}
