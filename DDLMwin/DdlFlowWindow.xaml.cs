using System;
using System.Windows;
using System.Windows.Input;

namespace DDLMwin
{
    /// <summary>
    /// DdlFlowWindow.xaml 的交互逻辑
    /// </summary>
    
    //DdlFlowWindow creates a float window shows the name and left time of a deadline
    public partial class DdlFlowWindow : Window
    {
        public static DdlFlowWindow self;
        public readonly int id;
        private double _size;
        private double Size
        {
            get => _size;
            set => _size = (value < 0.1) ? 0.1 : value;
        }

        public DdlFlowWindow(int id)
        {
            this.id = id;
            self = this;
            Size = 1;

            InitializeComponent();
            DdlNameTextBlock.Text = DdlOperation.ddls.Find(d => d.Id == id).Name;
            LeftTimeTextBlock.Text = DdlOperation.GetLeftTime(id);
        }

        public DdlFlowWindow(int id, string name, String leftTime)
        {
            this.id = id;
            self = this;
            
            Size = 1;

            InitializeComponent();
            DdlNameTextBlock.Text = name;
            LeftTimeTextBlock.Text = leftTime;
        }

        private void DragWindow(object sender, EventArgs e) => this.DragMove();

        //change the size of FLowWindow
        private void FlowWindow_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Size += ((double)e.Delta) / 1200;
            DdlNameTextBlock.FontSize = 50 * Size;
            LeftTimeTextBlock.FontSize = 50 * Size;
        }

        //double click to close the FlowWindow
        private void FlowWindow_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DdlOperation.flowWindows.Remove(this);
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
    }
}
