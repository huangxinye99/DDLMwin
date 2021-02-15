using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DDLM
{
    class FlowWindowOperation
    {
        public static List<FlowWindow> flowWindows = new List<FlowWindow>();

        public FlowWindowOperation()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load(App.path + "FlowWindowPosition.xml");
            }
            catch (Exception)
            {
                xml.AppendChild(xml.CreateXmlDeclaration("1.0", "UTF-8", null));
                xml.AppendChild(xml.CreateElement("", "root", ""));
                xml.Save(App.path + "FlowWindowPosition.xml");
            }
            XmlNodeList xnl = xml.SelectSingleNode("root").ChildNodes;
            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;
                int id = int.Parse(xe.GetAttribute("id"));
                XmlNodeList xeXnl = xe.ChildNodes;
                double x = double.Parse(xeXnl.Item(0).InnerText);
                double y = double.Parse(xeXnl.Item(1).InnerText);
                double size = double.Parse(xeXnl.Item(2).InnerText);
                double[] d = { x, y, size };

                try
                {
                    FlowWindow dfw = new FlowWindow(DdlOperation.ddls.Find(ddl => ddl.Id == id), size);
                    dfw.Left = x;
                    dfw.Top = y;
                    flowWindows.Add(dfw);
                }
                catch (Exception)
                {
                    continue;
                }

            }

            App.dt.Tick += RefreshFlowWindowsEvent;
        }

        public static void RefreshFlowWindowsEvent(object sender, EventArgs e)
        {
            foreach (FlowWindow dfw in flowWindows)
                dfw.RefreshFlowWindow();
        }

        public static void SaveFlowWindows()
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(App.path + "FlowWindowPosition.xml");
            XmlNode root = xml.SelectSingleNode("root");
            root.RemoveAll();
            foreach (FlowWindow fw in flowWindows)
            {
                XmlElement flowWindow = xml.CreateElement("flowWindow");
                XmlAttribute id = xml.CreateAttribute("id");
                id.InnerText = fw.ddl.Id.ToString();
                flowWindow.SetAttribute("id", fw.ddl.Id.ToString());

                XmlElement posX = xml.CreateElement("posX");
                posX.InnerText = fw.Left.ToString();
                XmlElement posY = xml.CreateElement("posY");
                posY.InnerText = fw.Top.ToString();
                XmlElement size = xml.CreateElement("size");
                size.InnerText = fw.Size.ToString();

                flowWindow.AppendChild(posX);
                flowWindow.AppendChild(posY);
                flowWindow.AppendChild(size);
                root.AppendChild(flowWindow);
            }

            xml.Save(App.path + "FlowWindowPosition.xml");
        }


        public static void ShowAllFlowWindowEvent(object sender, EventArgs e)
        {
            foreach (FlowWindow dfw in flowWindows)
                dfw.Show();
        }

        public static void HideAllFlowWindowEvent(object sender, EventArgs e)
        {
            foreach (FlowWindow dfw in flowWindows)
                dfw.Hide();
        }
    }


}
