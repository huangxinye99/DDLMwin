using System;
using System.Windows;
using System.Windows.Input;
using swf = System.Windows.Forms;

namespace DDLMwin
{
    /// <summary>
    /// DdlFlowWindow.xaml 的交互逻辑
    /// </summary>

    //DdlFlowWindow creates a float window shows the name and left time of a deadline
    public partial class DdlFlowWindow : Window
    {
        private int threshold;
        public static DdlFlowWindow self;
        public readonly int id;
        private double _size;
        public double Size
        {
            get => _size;
            set => _size = (value < 0.1) ? 0.1 : value;
        }

        public DdlFlowWindow(int id, string name, string leftTime, double size)
        {
            this.id = id;
            self = this;
            Size = size;

            InitializeComponent();
            DdlNameTextBlock.Text = name;
            LeftTimeTextBlock.Text = leftTime;
            DdlNameTextBlock.FontSize = 50 * Size;
            LeftTimeTextBlock.FontSize = 50 * Size;
        }

        private void DragWindow(object sender, EventArgs e)
        {
            DragMove();
            InScreen();
        }

        //change the size of FLowWindow
        private void FlowWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Size += ((double)e.Delta) / 1200;
            DdlNameTextBlock.FontSize = 50 * Size;
            LeftTimeTextBlock.FontSize = 50 * Size;
            InScreen();
        }

        //double click to close the FlowWindow
        private void FlowWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DdlOperation.flowWindows.Remove(this);
            DdlOperation.flowWindowsSetting.Remove(id);
            if (SettingOperation.autoShow)
                DdlOperation.ShowNearestFlowWindow();
            Close();
        }

        //open the DdlSettingWindow of this deadline
        private void FlowWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            DdlSettingWindow dsw = new DdlSettingWindow(id);
            dsw.ShowDialog();
            //if ((bool)dsw.DialogResult)
            //    DdlNameTextBlock.Text = dsw.DdlNameTextBox.Text;

        }

        //make the flow window in current screen
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
    }
}
