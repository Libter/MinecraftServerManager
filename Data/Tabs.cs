using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinecraftServerManager.Data
{
    public class Tabs
    {
        public List<Tab> tabs = new List<Tab>();

        public void Load(Controls.Tabs t)
        {
            foreach (Controls.Tab tab in t.tabs)
            {
                Control c = tab.control;
                Tab tabData = new Tab();
                if (c is Controls.Console)
                {
                    tabData.Type = Tab.TabType.Console;
                    tabData.DataFileName = ((Controls.Console)c).serverData.GetFile();
                }
                else if (c is Controls.RemoteConsole)
                {
                    tabData.Type = Tab.TabType.RemoteConsole;
                    tabData.DataFileName = ((Controls.RemoteConsole)c).DataFileName;
                }
                else if (c is Controls.TextEditor && !((Controls.TextEditor)c).ftp)
                {
                    tabData.Type = Tab.TabType.TextEditor;
                    tabData.DataFileName = ((Controls.TextEditor)c).file.FullName;
                }
                else if (c is Controls.TextEditor && ((Controls.TextEditor)c).ftp)
                {
                    tabData.Type = Tab.TabType.RemoteTextEditor;
                    tabData.DataFileName = ((Controls.TextEditor)c).Data.GetFile();
                    tabData.RemoteFileName = ((Controls.TextEditor)c).ftpFile;
                }
                else if (c is Controls.StyleEditor)
                {
                    tabData.Type = Tab.TabType.StyleEditor;
                    tabData.DataFileName = "null";
                }
                else if (c is Controls.EngineEditor)
                {
                    tabData.Type = Tab.TabType.EngineEditor;
                    tabData.DataFileName = "null";
                }
                else if (c is Controls.NewLocalServer)
                {
                    tabData.Type = Tab.TabType.NewLocalServer;
                    tabData.DataFileName = "null";
                }
                else if (c is Controls.ConnectLocalServer)
                {
                    tabData.Type = Tab.TabType.ConnectLocalServer;
                    tabData.DataFileName = "null";
                }
                else if (c is Controls.ConnectRemoteServer)
                {
                    tabData.Type = Tab.TabType.ConnectRemoteServer;
                    tabData.DataFileName = "null";
                }
                tabs.Add(tabData);
            }
        }

        public static Tabs Deserialize()
        {
            Tabs serverData = new Tabs();
            XmlSerializer serializer = new XmlSerializer(typeof(Tabs));
            StreamReader reader = new StreamReader(Utils.Main.DataDirectory + "Tabs.xml");
            serverData = (Tabs)serializer.Deserialize(reader);
            reader.Close();
            return serverData;
        }

        public void OpenAll(Controls.Tabs t)
        {
            foreach (Tab tab in tabs)
            {
                tab.Open(t);
            }
        }

        public void Save()
        {
            XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Tabs));
            StreamWriter file = new StreamWriter(Utils.Main.DataDirectory + "Tabs.xml");
            writer.Serialize(file, this);
            file.Close();
        }
    }
}
