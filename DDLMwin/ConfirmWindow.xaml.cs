using System.Windows;
using System.Windows.Input;

namespace DDLMwin
{
    /// <summary>
    /// ComfirmWindow.xaml 的交互逻辑
    /// </summary>
    
    //ConfirmWindow confirms the delete operation
    public partial class ConfirmWindow : Window
    {
        public ConfirmWindow()
        {
            InitializeComponent();
        }

        private void NoBtn_Click(object sender, RoutedEventArgs e) => CloseWindow(sender, e);

        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            CloseWindow(sender, e);
        }

        private void DragWindow(object sender, MouseButtonEventArgs e) => this.DragMove();

        public void CloseWindow(object sender, RoutedEventArgs e) => this.Close();
    }
}
