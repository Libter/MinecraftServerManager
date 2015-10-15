using System;
using System.IO;
using System.Xml.Serialization;

namespace MinecraftServerManager.Data
{
    public class Tab
    {
        public enum TabType { Console, RemoteConsole, TextEditor, RemoteTextEditor, StyleEditor, EngineEditor, NewLocalServer, ConnectLocalServer, ConnectRemoteServer };

        public TabType Type;

        public string DataFileName;
        public string RemoteFileName;

        public void Open(Controls.Tabs tabs)
        {
            if (DataFileName == null)
                return;
            if (Type == TabType.Console)
            {
                Server data = Server.Deserialize(DataFileName);
                Controls.Console console = new Controls.Console();
                console.Load(data, tabs);
            }
            else if (Type == TabType.RemoteConsole)
            {
                RemoteServer rs = RemoteServer.Deserialize(DataFileName);
                Controls.RemoteConsole remoteConsole = new Controls.RemoteConsole();
                remoteConsole.Load(rs, rs.name, tabs);
            }
            else if (Type == TabType.TextEditor)
            {
                Controls.TextEditor textEditor = new Controls.TextEditor();
                textEditor.Load(new FileInfo(DataFileName), tabs);
            }
            else if (Type == TabType.RemoteTextEditor)
            {
                RemoteServer rs = RemoteServer.Deserialize(DataFileName);
                Controls.TextEditor textEditor = new Controls.TextEditor();
                textEditor.Load(rs, this.RemoteFileName, tabs);
            }
            else if (Type == TabType.StyleEditor)
            {
                Controls.StyleEditor se = new Controls.StyleEditor();
                se.Load(tabs);
            }
            else if (Type == TabType.EngineEditor)
            {
                Controls.EngineEditor ee = new Controls.EngineEditor();
                ee.Load(tabs);
            }
            else if (Type == TabType.NewLocalServer)
            {
                Controls.NewLocalServer nls = new Controls.NewLocalServer();
                nls.Load(tabs);
            }
            else if (Type == TabType.ConnectLocalServer)
            {
                Controls.ConnectLocalServer cls = new Controls.ConnectLocalServer();
                cls.Load(tabs);
            }
            else if (Type == TabType.ConnectRemoteServer)
            {
                Controls.ConnectRemoteServer crs = new Controls.ConnectRemoteServer();
                crs.Load(tabs);
            }
        }

        /// <summary>
        /// NOT USE THIS METHOD!
        /// This is for obscufator only!
        /// </summary>
        public static Tab Deserialize()
        {
            Tab serverData = new Tab();
            XmlSerializer serializer = new XmlSerializer(typeof(Tab));
            StreamReader reader = new StreamReader("");
            serverData = (Tab)serializer.Deserialize(reader);
            reader.Close();
            return serverData;
        }
    }
}
