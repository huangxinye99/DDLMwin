using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Xml;

namespace DDLMwin
{
    //define all the operations about settings

    class SettingOperation
    {
        public static XmlDocument xd = new XmlDocument();
        public static XmlNode xn;

        public static bool autoStart;
        public static bool isDark;
        public static string primaryColor;
        public static string secondaryColor;
        public static Boolean showMessageBox;
        public static Boolean alarm;
        public static string alarmPath;
        public static int alarmVolume;

        public SettingOperation()
        {
            ReadSetting();
        }

        //get setting from setting.xml
        public static void ReadSetting()
        {
            xd.Load("Setting.xml");
            xn = xd.SelectSingleNode("setting");

            autoStart = Boolean.Parse(xn.SelectSingleNode("autoStart").InnerText);
            isDark = Boolean.Parse(xn.SelectSingleNode("dark").InnerText);
            primaryColor = xn.SelectSingleNode("primaryColor").InnerText;
            secondaryColor = xn.SelectSingleNode("secondaryColor").InnerText;
            showMessageBox = Boolean.Parse(xn.SelectSingleNode("showMessageBox").InnerText);
            alarm = Boolean.Parse(xn.SelectSingleNode("alarm").InnerText);
            alarmPath = xn.SelectSingleNode("alarmPath").InnerText;
            alarmVolume = int.Parse(xn.SelectSingleNode("alarmVolume").InnerText);

            String[] flowDdlIdString = xn.SelectSingleNode("flowDdlId").InnerText.Split(' ');
            for (int i = 0; i < flowDdlIdString.Length - 1; i++)
                try
                {
                    DdlOperation.flowWindows.Add(new DdlFlowWindow(int.Parse(flowDdlIdString[i])));
                }
                catch { }

            SetTheme();
        }

        //save setting
        internal static void SaveSetting()
        {
            if (autoStart.ToString() != xn.SelectSingleNode("autoStart").InnerText)
                SetAutoStart();

            xn.SelectSingleNode("autoStart").InnerText = autoStart.ToString();
            xn.SelectSingleNode("dark").InnerText = isDark.ToString();
            xn.SelectSingleNode("primaryColor").InnerText = primaryColor;
            xn.SelectSingleNode("secondaryColor").InnerText = secondaryColor;
            xn.SelectSingleNode("showMessageBox").InnerText = showMessageBox.ToString();
            xn.SelectSingleNode("alarm").InnerText = alarm.ToString();
            xn.SelectSingleNode("alarmPath").InnerText = alarmPath;
            xn.SelectSingleNode("alarmVolume").InnerText = alarmVolume.ToString();

            String s = "";
            foreach (var ddl in DdlOperation.flowWindows)
                s = s + ddl.id + " ";
            xn.SelectSingleNode("flowDdlId").InnerText = s;

            xd.Save("Setting.xml");
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
