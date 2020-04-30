using System;
using System.Windows;
using swf = System.Windows.Forms;

namespace DDLMwin
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        private static swf.NotifyIcon ni;
        public static MainWindow mw;
        public static string path;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            path = AppDomain.CurrentDomain.BaseDirectory;

            _ = new DbOperation();
            _ = new DdlOperation();
            _ = new SettingOperation();

            RemoveIcon();
            AddIcon();

            DdlOperation.ShowAllFlowWindowEvent(sender, e);
            if (SettingOperation.autoShow)
                DdlOperation.ShowNearestFlowWindow();

            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(AppDispatcherUnhandledException);
        }

        private void Application_Exit(object sender, ExitEventArgs e) => CloseDdlm();

        private void Application_SessionEnding(object sender, SessionEndingCancelEventArgs e) => CloseDdlm();

        private void CloseDdlm()
        {
            RemoveIcon();
            DdlOperation.SaveFlowWindowPos();
            SettingOperation.SaveSetting();
            this.Shutdown();
        }

        private void AddIcon()
        {
            if (ni != null)
                return;
            ni = new swf.NotifyIcon();
            ni.Text = "Deadline Matters";
            ni.Icon = new System.Drawing.Icon(path + "Logo.ico");
            ni.Visible = true;
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
            addDdlItem.Click += new EventHandler(OpenDdlPage);
            addDdlItem.Click += new EventHandler(delegate { new DdlSettingWindow().ShowDialog(); });

            swf.MenuItem showFlowWindowItem = new swf.MenuItem
            {
                Text = "显示浮窗"
            };
            showFlowWindowItem.Click += new EventHandler(DdlOperation.ShowAllFlowWindowEvent);

            swf.MenuItem hideFlowWindowItem = new swf.MenuItem
            {
                Text = "隐藏浮窗"
            };
            hideFlowWindowItem.Click += new EventHandler(DdlOperation.HideAllFlowWindowEvent);

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

        private void RemoveIcon()
        {
            if (ni != null)
            {
                ni.Visible = false;
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
            OpenDdlPage(sender, e);
            mw.DdlsBtn.IsChecked = false;
            mw.SettingBtn.IsChecked = true;
            mw.mainFrame.Content = new SettingPage();
        }

        private void AppDispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception + "\n 请在GitHub上报告错误，并重启应用。" , "出错了！");
        }
    }
}
