using System;
using System.Windows;
using System.Windows.Controls;
using swf = System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Data;
using System.Globalization;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using MaterialDesignColors;


namespace DDLM
{
    /// <summary>
    /// SettingPage.xaml 的交互逻辑
    /// </summary>
    public partial class SettingPage : Page
    {

        public SettingPage()
        {
            InitializeComponent();

            foreach (ComboBoxItem item in LanguageComboBox.Items)
                if (SettingOperation.language.Equals(item.Tag))
                {
                    LanguageComboBox.SelectedItem = item;
                    break;
                }
            AutoStartCheckBox.IsChecked = SettingOperation.autoStart;
            DarkCheckBox.IsChecked = SettingOperation.isDark;

            Button btn;
            foreach (PrimaryColor pc in Enum.GetValues(typeof(PrimaryColor)))
            {
                btn = new Button();
                btn.Style = FindResource("MaterialDesignFloatingActionMiniButton") as Style;
                btn.Background = new SolidColorBrush(SwatchHelper.Lookup[(MaterialDesignColor)pc]);
                btn.Margin = new Thickness(3);
                btn.HorizontalAlignment = HorizontalAlignment.Stretch;
                btn.Click += PrimaryColorBtn_Click;
                PrimaryColorBtnPanel.Children.Add(btn);
            }
            foreach (SecondaryColor sc in Enum.GetValues(typeof(SecondaryColor)))
            {
                btn = new Button();
                btn.Style = FindResource("MaterialDesignFloatingActionMiniButton") as Style;
                btn.Background = new SolidColorBrush(SwatchHelper.Lookup[(MaterialDesignColor)sc]);
                btn.Margin = new Thickness(3);
                btn.HorizontalAlignment = HorizontalAlignment.Stretch;
                btn.Click += SecondaryColorBtn_Click;
                SecondaryColorBtnPanel.Children.Add(btn);
            }

            AlarmPathTextBox.Text = SettingOperation.alarmPath;
            AlarmVolumeSlider.Value = SettingOperation.alarmVolume;

            OpenAnimation();
        }

        private void LanguageComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tag = (LanguageComboBox.SelectedItem as ComboBoxItem).Tag.ToString();
            SettingOperation.SetLanguage(tag);
            SettingOperation.SaveLanguage();
            MainWindow.ReloadMainWindow();
        }

        private void AutoStartCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (SettingOperation.SetAutoStart(true))
                SettingOperation.SaveAutoStart();
            else
                AutoStartCheckBox.IsChecked = false;
        }

        private void AutoStartCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (SettingOperation.SetAutoStart(false))
                SettingOperation.SaveAutoStart();
            else
                AutoStartCheckBox.IsChecked = true;
        }

        private void DarkCheckBox_Clicked(object sender, RoutedEventArgs e)
        {
            SettingOperation.isDark = (bool)DarkCheckBox.IsChecked;
            SettingOperation.SetDark();
            SettingOperation.SaveDark();
        }

        private void PrimaryColorBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingOperation.pc = ((SolidColorBrush)(sender as Button).Background).Color.ToString();
            SettingOperation.SetPrimaryColor();
            SettingOperation.SavePrimaryColor();
        }

        private void SecondaryColorBtn_Click(object sender, RoutedEventArgs e)
        {
            SettingOperation.sc = ((SolidColorBrush)(sender as Button).Background).Color.ToString();
            SettingOperation.SetSecondaryColor();
            SettingOperation.SaveSecondaryColor();
        }

        private void AlarmPathLocateBtn_Click(object sender, RoutedEventArgs e)
        {
            string file = "";
            swf.OpenFileDialog ofd = new swf.OpenFileDialog();
            if (ofd.ShowDialog() == swf.DialogResult.OK)
                file = ofd.FileName;
            if (file == "")
                return;
            AlarmPathTextBox.Text = file;
            SettingOperation.alarmPath = file;
            SettingOperation.SaveAlarmPath();
        }


        private void AlarmVolumeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
            => SettingOperation.alarmVolume = ((int)AlarmVolumeSlider.Value);

        private void AlarmVolumeSlider_MouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
            => AlarmVolumeSlider.Value += e.Delta > 0 ? 1 : -1;

        private void AlarmVolumeSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
            => SettingOperation.SaveVolume();

        public void OpenAnimation()
        {
            Storyboard sb = new Storyboard();

            int num = 1;
            num = AddAnimationToItem(sb, num, Container);

            sb.Begin(this);
        }

        private int AddAnimationToItem(Storyboard sb, int num, FrameworkElement parent)
        {
            if (parent.Opacity == 0)
            {
                StoryboardOperation.AddNewAnimation(sb, 100, 0, 0.1 * num, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, parent, "(RenderTransform).(TranslateTransform.Y)");
                StoryboardOperation.AddNewAnimation(sb, 0, 1, 0.1 * num, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, parent, "(Opacity)");
                num++;
            }

            if (parent.GetType().IsSubclassOf(typeof(Panel)))
                foreach (FrameworkElement child in (parent as Panel).Children)
                    num = AddAnimationToItem(sb, num, child);

            return num;
        }

    }

    public class WidthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double pageWidth = (double)value - int.Parse((string)parameter);
            return pageWidth;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }

}
