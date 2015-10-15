using System;
using System.IO;
using System.Xml.Serialization;

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
            return Utils.Main.RemoteDirectory + name + Path.DirectorySeparatorChar + "RconData.xml";
        }

        public void Save()
        {
            XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Data.RemoteServerRcon));
            StreamWriter file = new StreamWriter(GetFile());
            writer.Serialize(file, this);
            file.Close();
        }
    }
}
