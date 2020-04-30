using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace DDLMwin
{
    //define all the operations about settings

    class SettingOperation
    {
        private static Configuration config;

        public static bool autoStart;
        public static bool isDark;
        public static string primaryColor;
        public static string secondaryColor;
        public static bool autoShow;
        public static bool showMessageBox;
        public static bool alarm;
        public static string alarmPath;
        public static int alarmVolume;

        public SettingOperation()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ReadSetting();
        }

        //get setting from setting.xml
        public static void ReadSetting()
        {
            autoStart = Boolean.Parse(ConfigurationManager.AppSettings["autoStart"]);
            isDark = Boolean.Parse(ConfigurationManager.AppSettings["dark"]);
            primaryColor = ConfigurationManager.AppSettings["primaryColor"];
            secondaryColor = ConfigurationManager.AppSettings["secondaryColor"];
            autoShow = Boolean.Parse(ConfigurationManager.AppSettings["autoShow"]);
            showMessageBox = Boolean.Parse(ConfigurationManager.AppSettings["showMessageBox"]);
            alarm = Boolean.Parse(ConfigurationManager.AppSettings["alarm"]);
            alarmPath = ConfigurationManager.AppSettings["alarmPath"];
            alarmVolume = int.Parse(ConfigurationManager.AppSettings["alarmVolume"]);

            XmlDocument xml = new XmlDocument();
            xml.Load(App.path+"FlowWindowSetting.xml");
            XmlNodeList xnl = xml.SelectSingleNode("root").ChildNodes;
            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;
                int id = int.Parse(xe.GetAttribute("id"));
                XmlNodeList xeXnl = xe.ChildNodes;
                double x = double.Parse(xeXnl.Item(0).InnerText);
                double y = double.Parse(xeXnl.Item(1).InnerText);
                double size = double.Parse(xeXnl.Item(2).InnerText);
                double[] d = {x, y, size};
                DdlOperation.flowWindowsSetting.Add(id, d);

                DdlFlowWindow dfw = new DdlFlowWindow(id, DdlOperation.ddls.Find(ddl => ddl.Id == id).Name, DdlOperation.GetLeftTime(id), size);
                DdlOperation.flowWindows.Add(dfw);
            }
            
            SetTheme();
        }

        //save setting
        internal static void SaveSetting()
        {
            if (autoStart.ToString() != ConfigurationManager.AppSettings["autoStart"])
                SetAutoStart();

            config.AppSettings.Settings["autoStart"].Value = autoStart.ToString();
            config.AppSettings.Settings["dark"].Value = isDark.ToString();
            config.AppSettings.Settings["primaryColor"].Value = primaryColor;
            config.AppSettings.Settings["secondaryColor"].Value = secondaryColor;
            config.AppSettings.Settings["autoShow"].Value = autoShow.ToString();
            config.AppSettings.Settings["showMessageBox"].Value = showMessageBox.ToString();
            config.AppSettings.Settings["alarm"].Value = alarm.ToString();
            config.AppSettings.Settings["alarmPath"].Value = alarmPath;
            config.AppSettings.Settings["alarmVolume"].Value = alarmVolume.ToString();

            XmlDocument xml = new XmlDocument();
            xml.Load(App.path + "FlowWindowSetting.xml");
            XmlNode root = xml.SelectSingleNode("root");
            root.RemoveAll();

            foreach (var kvp in DdlOperation.flowWindowsSetting)
            {
                XmlElement flowWindow = xml.CreateElement("flowWindow");
                XmlAttribute id = xml.CreateAttribute("id");
                id.InnerText = kvp.Key.ToString();
                flowWindow.SetAttribute("id", kvp.Key.ToString());

                XmlElement posX = xml.CreateElement("posX");
                posX.InnerText = kvp.Value[0].ToString();
                XmlElement posY = xml.CreateElement("posY");
                posY.InnerText = kvp.Value[1].ToString();
                XmlElement size = xml.CreateElement("size");
                size.InnerText = kvp.Value[2].ToString();

                flowWindow.AppendChild(posX);
                flowWindow.AppendChild(posY);
                flowWindow.AppendChild(size);
                root.AppendChild(flowWindow);
            }

            xml.Save(App.path+ "FlowWindowSetting.xml");
            config.Save();
            SetTheme();
        }

        //set the theme & color of DDLM
        private static void SetTheme()
        {
            var ph = new PaletteHelper();
            var theme = ph.GetTheme();
            if (isDark)
                theme.SetBaseTheme(Theme.Dark);
            else
                theme.SetBaseTheme(Theme.Light);
            GetColorFromString(primaryColor, out byte r, out byte g, out byte b);
            theme.SetPrimaryColor(Color.FromRgb(r, g, b));
            GetColorFromString(secondaryColor, out r, out g, out b);
            theme.SetSecondaryColor(Color.FromRgb(r, g, b));
            ph.SetTheme(theme);
        }

        //convert string to color
        private static void GetColorFromString(string s, out byte r, out byte g, out byte b)
        {
            string[] colors = s.Split(' ');
            r = byte.Parse(colors[0]);
            g = byte.Parse(colors[1]);
            b = byte.Parse(colors[2]);
            return;
        }

        //run on system start
        private static void SetAutoStart()
        {
            try
            {
                RegistryKey rk = Registry.CurrentUser;
                RegistryKey key = rk.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                if (key == null)
                    rk.CreateSubKey("SOFTWARE//Microsoft//Windows//CurrentVersion//Run");
                if (autoStart)
                {
                    //add key
                    key.SetValue("DDLMwin", Process.GetCurrentProcess().MainModule.FileName);
                    key.Close();
                }
                else
                {
                    //delete key
                    string[] keyNames = key.GetValueNames();
                    foreach (string keyName in keyNames)
                    {
                        if (keyName.ToUpper() == "DDLMwin".ToUpper())
                        {
                            key.DeleteValue("DDLMwin");
                            key.Close();
                        }
                    }
                }
            }
            catch (Exception) { MessageBox.Show("开机启动设置失败！\n请尝试以管理员身份启动DDLM"); }
        }
    }
}
