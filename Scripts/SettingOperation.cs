using Microsoft.Win32;
using System;
using System.Drawing;
using System.Configuration;
using System.Diagnostics;
using System.Windows;
using System.Windows.Media;
using System.Xml;
using MaterialDesignThemes.Wpf;
using System.IO;
using System.Globalization;
using System.Collections.Generic;

namespace DDLM
{
    //define all the operations about settings

    class SettingOperation
    {
        private static Configuration config;

        public static string language;
        public static bool firstTime;
        public static bool autoStart;
        public static bool isDark;
        public static string pc;
        public static string sc;
        public static string alarmPath;
        public static int alarmVolume;

        public SettingOperation()
        {
            config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            ReadSetting();
            if (firstTime)
            {
                config.AppSettings.Settings["firstTime"].Value = Boolean.FalseString;
                config.Save();
            }
        }

        //get setting from setting.xml
        public static void ReadSetting()
        {
            language = ConfigurationManager.AppSettings["language"];
            firstTime = Boolean.Parse(ConfigurationManager.AppSettings["firstTime"]);
            autoStart = Boolean.Parse(ConfigurationManager.AppSettings["autoStart"]);
            isDark = Boolean.Parse(ConfigurationManager.AppSettings["dark"]);
            pc = ConfigurationManager.AppSettings["primaryColor"];
            sc = ConfigurationManager.AppSettings["secondaryColor"];
            alarmPath = ConfigurationManager.AppSettings["alarmPath"];
            alarmVolume = int.Parse(ConfigurationManager.AppSettings["alarmVolume"]);

            SetLanguage(language);
            SetDark();
            SetPrimaryColor();
            SetSecondaryColor();
        }

        public static void SetLanguage(string s)
        {
            language = s;

            var dicts = Application.Current.Resources.MergedDictionaries;
            ResourceDictionary rd = null;
            foreach (var dict in dicts)
                if (dict.Source.ToString().StartsWith(@"Resources\Languages"))
                {
                    rd = dict;
                    break;
                }

            if (rd == null)
            {
                rd = new ResourceDictionary();
                rd.Source = new Uri(@"Resources\Languages\" + s + ".xaml", UriKind.Relative);
                dicts.Add(rd);
            }
            else
                rd.Source = new Uri(@"Resources\Languages\" + s + ".xaml", UriKind.Relative);

            System.Threading.Thread.CurrentThread.CurrentUICulture = new CultureInfo(s);
            System.Threading.Thread.CurrentThread.CurrentCulture = new CultureInfo(s);
        }

        public static void SaveLanguage()
        {
            config.AppSettings.Settings["language"].Value = language.ToString();
            config.Save();
        }

        public static bool SetAutoStart(bool b)
        {
            string startUpPath = Environment.GetFolderPath(Environment.SpecialFolder.Startup);
            try
            {
                autoStart = b;
                if (b)
                {
                    if (!File.Exists(App.path + @"\DDLM.exe.lnk"))
                    {
                        var shellType = Type.GetTypeFromProgID("Wscript.Shell");
                        dynamic shell = Activator.CreateInstance(shellType);
                        var shortcut = shell.CreateShortCut(App.path + @"\DDLM.exe.lnk");
                        shortcut.TargetPath = App.path + "DDLM.exe";
                        shortcut.WorkingDirectory = App.path;
                        shortcut.Save();
                    }
                    if (!File.Exists(startUpPath + @"\DDLM.exe.lnk"))
                        File.Copy(App.path + @"\DDLM.exe.lnk", startUpPath + @"\DDLM.exe.lnk", true);
                }
                else
                    if (File.Exists(startUpPath + @"\DDLM.exe.lnk"))
                        File.Delete(startUpPath + @"\DDLM.exe.lnk");

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public static void SaveAutoStart()
        {
            config.AppSettings.Settings["autoStart"].Value = autoStart.ToString();
            config.Save();
        }

        public static void SetDark()
        {
            var ph = new PaletteHelper();
            var theme = ph.GetTheme();
            if (isDark)
                theme.SetBaseTheme(Theme.Dark);
            else
                theme.SetBaseTheme(Theme.Light);
            ph.SetTheme(theme);
        }

        public static void SaveDark()
        {
            config.AppSettings.Settings["dark"].Value = isDark.ToString();
            config.Save();
        }

        public static void SetPrimaryColor()
        {
            var ph = new PaletteHelper();
            var theme = ph.GetTheme();
            theme.SetPrimaryColor((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(pc));
            ph.SetTheme(theme);
        }

        public static void SavePrimaryColor()
        {
            config.AppSettings.Settings["primaryColor"].Value = pc;
            config.Save();
        }

        public static void SetSecondaryColor()
        {
            var ph = new PaletteHelper();
            var theme = ph.GetTheme();
            theme.SetSecondaryColor((System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(sc));
            ph.SetTheme(theme);
        }

        public static void SaveSecondaryColor()
        {
            config.AppSettings.Settings["secondaryColor"].Value = sc;
            config.Save();
        }

        public static void SaveAlarmPath()
        {
            config.AppSettings.Settings["alarmPath"].Value = alarmPath;
            config.Save();
        }

        public static void SaveVolume()
        {
            config.AppSettings.Settings["alarmVolume"].Value = alarmVolume.ToString();
            config.Save();
        }

    }
}