using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Threading;
using swf = System.Windows.Forms;

namespace DDLM
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        public static swf.NotifyIcon ni;
        public static MainWindow mw;
        public static string path;
        public static readonly DispatcherTimer dt = new DispatcherTimer();

        protected override void OnStartup(StartupEventArgs e)
        {
            Process currentProcess = Process.GetCurrentProcess();

            foreach (Process item in Process.GetProcessesByName(currentProcess.ProcessName))
            {
                if (item.Id != currentProcess.Id && (item.StartTime - currentProcess.StartTime).TotalMilliseconds <= 0)
                {
                    MessageBox.Show("DDLM已启动");

                    currentProcess.Kill();
                    currentProcess.WaitForExit();
                    break;
                }
            }
            base.OnStartup(e);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            path = AppDomain.CurrentDomain.BaseDirectory;

            _ = new DatabaseOperation();
            _ = new DdlOperation();
            _ = new SettingOperation();
            _ = new FlowWindowOperation();

            RemoveIcon();
            AddIcon();

            this.DispatcherUnhandledException += new DispatcherUnhandledExceptionEventHandler(AppDispatcherUnhandledException);

            dt.Interval = new TimeSpan(0, 0, 1);
            dt.Start();

            FlowWindowOperation.ShowAllFlowWindowEvent(sender, e);

            if (SettingOperation.firstTime)
                OpenInfoPage();
            else
                OpenDdlPage();
        }

        private void Application_Exit(object sender, ExitEventArgs e) => CloseDdlm();

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e) => CloseDdlm();

        private void CloseDdlm()
        {
            RemoveIcon();
            FlowWindowOperation.SaveFlowWindows();
            Shutdown();
        }

        private void AddIcon()
        {
            if (ni != null)
                return;

            ni = new swf.NotifyIcon
            {
                Text = "Deadline Matters",
                Icon = new System.Drawing.Icon(GetResourceStream(new Uri(@"Resources\Logo.ico", UriKind.Relative)).Stream),
                Visible = true
            };
            ni.MouseDoubleClick += new swf.MouseEventHandler(OpenDdlPage);

            swf.ContextMenu menu = new swf.ContextMenu();

            swf.MenuItem mainWindowItem = new swf.MenuItem
            {
                Text = "主页"
            };
            mainWindowItem.Click += new EventHandler(OpenDdlPage);

            swf.MenuItem addDdlItem = new swf.MenuItem
            {
                Text = "添加DDL"
            };
            addDdlItem.Click += new EventHandler(delegate { AddNewDdl(); });

            swf.MenuItem showFlowWindowItem = new swf.MenuItem
            {
                Text = "显示浮窗"
            };
            showFlowWindowItem.Click += new EventHandler(FlowWindowOperation.ShowAllFlowWindowEvent);

            swf.MenuItem hideFlowWindowItem = new swf.MenuItem
            {
                Text = "隐藏浮窗"
            };
            hideFlowWindowItem.Click += new EventHandler(FlowWindowOperation.HideAllFlowWindowEvent);

            swf.MenuItem settingItem = new swf.MenuItem
            {
                Text = "设置"
            };
            settingItem.Click += new EventHandler(OpenSettingPage);

            swf.MenuItem closeItem = new swf.MenuItem
            {
                Text = "退出DDLM"
            };
            closeItem.Click += new EventHandler(delegate { this.Shutdown(); });

            menu.MenuItems.Add(mainWindowItem);
            menu.MenuItems.Add(addDdlItem);
            menu.MenuItems.Add(showFlowWindowItem);
            menu.MenuItems.Add(hideFlowWindowItem);
            menu.MenuItems.Add(settingItem);
            menu.MenuItems.Add(closeItem);
            ni.ContextMenu = menu;
        }

        private void AddNewDdl()
        {
            if ((bool)new DdlSettingWindow().ShowDialog() && mw != null && (App.mw.MainFrame.Content.GetType().Name == "DdlPage"))
                ((DdlPage)App.mw.MainFrame.Content).ReloadDdlStackPanel();
        }

        private void RemoveIcon()
        {
            if (ni != null)
            {
                ni.Dispose();
                ni = null;
            }
        }

        private void OpenDdlPage()
        {
            if (mw == null)
                mw = new MainWindow();
            mw.Show();
        }

        private void OpenDdlPage(Object sender, EventArgs e) => OpenDdlPage();

        private void OpenSettingPage(Object sender, EventArgs e)
        {
            if (mw == null)
                mw = new MainWindow();

            mw.MainFrame.Content = new SettingPage();
            mw.DdlPageBtn.IsChecked = false;
            mw.SettingPageBtn.IsChecked = true;
            mw.Show();
        }

        private void OpenInfoPage()
        {
            if (mw == null)
                mw = new MainWindow();

            mw.MainFrame.Content = new InfoPage();
            mw.DdlPageBtn.IsChecked = false;
            mw.InfoPageBtn.IsChecked = true;
            mw.Show();
        }

        private void AppDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception + "\n 请在GitHub上报告错误，并重启应用。", "出错了！");
        }

        public static void ShowBalloonTip(string s)
        {
            ni.BalloonTipText = s;
            ni.ShowBalloonTip(2000);
        }
    }
}
