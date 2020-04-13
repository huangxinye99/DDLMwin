using MaterialDesignThemes.Wpf;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using swf = System.Windows.Forms;

namespace DDLMwin
{
    /// <summary>
    /// SettingPage.xaml 的交互逻辑
    /// </summary>
    
    //SettingPage change the setting of DDLM
    public partial class SettingPage : Page
    {
        private readonly byte[] primaryColor = new byte[3];
        private readonly byte[] secondaryColor = new byte[3];
        private byte r = 0;
        private byte g = 0;
        private byte b = 0;
        private int selectedColor = 0;

        public SettingPage()
        {
            primaryColor = GetColorFromString(SettingOperation.primaryColor);
            secondaryColor = GetColorFromString(SettingOperation.secondaryColor);

            InitializeComponent();

            AutoStartCheckBox.IsChecked = SettingOperation.autoStart;
            DarkSwitch.IsChecked = SettingOperation.isDark;
            PrimaryColorBtn.Background = new SolidColorBrush(Color.FromRgb(primaryColor[0], primaryColor[1], primaryColor[2]));
            SecondaryColorBtn.Background = new SolidColorBrush(Color.FromRgb(secondaryColor[0], secondaryColor[1], secondaryColor[2]));
            SetSliderAndLabel();
            AutoShowCheckBox.IsChecked = SettingOperation.autoShow;
            MessageCheckBox.IsChecked = SettingOperation.showMessageBox;
            AlarmCheckBox.IsChecked = SettingOperation.alarm;
            AlarmPathTextBox.Text = SettingOperation.alarmPath;
            AlarmVolumeSlider.Value = SettingOperation.alarmVolume;
            ColorLabel.Content = SettingOperation.primaryColor;
        }

        private void PrimaryColorBtn_Click(object sender, RoutedEventArgs e)
        {
            r = primaryColor[0];
            g = primaryColor[1];
            b = primaryColor[2];
            selectedColor = 0;
            SetSliderAndLabel();
        }

        private void SecondaryColorBtn_Click(object sender, RoutedEventArgs e)
        {
            r = secondaryColor[0];
            g = secondaryColor[1];
            b = secondaryColor[2];
            selectedColor = 1;
            SetSliderAndLabel();
        }

        private void RedSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            r = (byte)e.NewValue;
            SetBtnColorAndLabel();
        }

        private void GreenSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            g = (byte)e.NewValue;
            SetBtnColorAndLabel();
        }

        private void BlueSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            b = (byte)e.NewValue;
            SetBtnColorAndLabel();
        }

        //locate the alarm path
        private void AlarmPathLocateBtn_Click(object sender, RoutedEventArgs e)
        {
            swf.OpenFileDialog ofd = new swf.OpenFileDialog();
            if (ofd.ShowDialog() == swf.DialogResult.OK)
                AlarmPathTextBox.Text = ofd.FileName;
        }

        //save setting
        private void YesBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingOperation.autoStart = (bool)AutoStartCheckBox.IsChecked;
            SettingOperation.isDark = (bool)DarkSwitch.IsChecked;
            SettingOperation.primaryColor = GetStringFromColor(primaryColor);
            SettingOperation.secondaryColor = GetStringFromColor(secondaryColor);
            SettingOperation.autoShow = (bool)AutoShowCheckBox.IsChecked;
            SettingOperation.showMessageBox = (bool)MessageCheckBox.IsChecked;
            SettingOperation.alarm = (bool)AlarmCheckBox.IsChecked;
            SettingOperation.alarmPath = AlarmPathTextBox.Text;
            SettingOperation.alarmVolume = (int)AlarmVolumeSlider.Value;
            SettingOperation.SaveSetting();

            var queue = new SnackbarMessageQueue(TimeSpan.FromSeconds(1));
            Snackbar.MessageQueue = queue;
            queue.Enqueue("设置成功");
        }

        //convert string to color(r, g, b)
        private byte[] GetColorFromString(string s)
        {
            byte[] i = new byte[3];
            string[] colors = s.Split(' ');
            for (int num = 0; num < 3; num++)
                i[num] = byte.Parse(colors[num]);
            return i;
        }

        //convert color(r, g, b) to string
        private string GetStringFromColor(byte[] bs)
        {
            string s = "";
            foreach (byte b in bs)
                s = s + b.ToString() + " ";
            return s;
        }

        //when the value of slider changes, set the background color of button and the text of label
        private void SetBtnColorAndLabel()
        {
            switch (selectedColor)
            {
                case 0: //change primary color
                    primaryColor[0] = r;
                    primaryColor[1] = g;
                    primaryColor[2] = b;
                    PrimaryColorBtn.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
                    ColorLabel.Content = GetStringFromColor(primaryColor);
                    break;

                case 1: //change sencondary color
                    secondaryColor[0] = r;
                    secondaryColor[1] = g;
                    secondaryColor[2] = b;
                    SecondaryColorBtn.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
                    ColorLabel.Content = GetStringFromColor(secondaryColor);
                    break;
            }

        }

        //when the button is clicked, set the value of three slider and the text of label
        private void SetSliderAndLabel()
        {
            switch (selectedColor)
            {
                case 0:
                    r = primaryColor[0];
                    g = primaryColor[1];
                    b = primaryColor[2];
                    RedSlider.Value = r;
                    GreenSlider.Value = g;
                    BlueSlider.Value = b;
                    ColorLabel.Content = GetStringFromColor(primaryColor);
                    break;

                case 1:
                    r = secondaryColor[0];
                    g = secondaryColor[1];
                    b = secondaryColor[2];
                    RedSlider.Value = r;
                    GreenSlider.Value = g;
                    BlueSlider.Value = b;
                    ColorLabel.Content = GetStringFromColor(secondaryColor);
                    break;
            }
        }
    }

}
