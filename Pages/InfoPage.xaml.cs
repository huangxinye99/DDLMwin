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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DDLM
{
    /// <summary>
    /// AboutPage.xaml 的交互逻辑
    /// </summary>
    public partial class InfoPage : Page
    {
        public InfoPage()
        {
            InitializeComponent();
            OpenAnimation();
        }

        private void OpenAnimation()
        {
            Storyboard sb = new Storyboard();

            int i = 1;
            foreach (DependencyObject item in sp.Children)
            {
                StoryboardOperation.AddNewAnimation(sb, 100, 0, 0.1 * i, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, item, "(RenderTransform).(TranslateTransform.Y)");
                StoryboardOperation.AddNewAnimation(sb, 0, 1, 0.1 * i, 1, StoryboardOperation.EaseType.CubicEase, EasingMode.EaseOut, item, "(Opacity)");
                i++;
            }

            sb.Begin(this);

        }
    }
}
