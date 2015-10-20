using System;
using System.IO;
using System.Xml.Serialization;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Data
{
    public class RemoteServerRcon
    {
        public String name;
        public String adress;
        public int port;
        public String password;

        public string GetFile()
        {
            return Main.RemoteDirectory + name + Path.DirectorySeparatorChar + "RconData.xml";
        }

        public string GetDirectory()
        {
            return Main.RemoteDirectory + name;
        }

        public void Save()
        {
            Directory.CreateDirectory(GetDirectory());
            XmlSerializer writer = new XmlSerializer(typeof(RemoteServerRcon));
            StreamWriter file = new StreamWriter(GetFile());
            writer.Serialize(file, this);
            file.Close();
        }
    }
}
