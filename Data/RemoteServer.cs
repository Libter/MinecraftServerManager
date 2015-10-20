using System;
using System.IO;
using System.Xml.Serialization;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Data
{
    public class RemoteServer
    {
        public string name;
        public string engine;
        public string version;
        public string adress;
        public string login;
        public string password;

        public static RemoteServer Deserialize(string filename)
        {
            RemoteServer serverData = new RemoteServer();
            XmlSerializer serializer = new XmlSerializer(typeof(RemoteServer));
            StreamReader reader = new StreamReader(filename);
            serverData = (Data.RemoteServer)serializer.Deserialize(reader);
            reader.Close();
            return serverData;
        }
        
        public override string ToString()
        {
            return name + " (" + engine + " " + version + ")";
        }

        public string GetDirectory()
        {
            return Main.RemoteDirectory + name;
        }

        public string GetFile()
        {
            return Main.RemoteDirectory + name + Path.DirectorySeparatorChar + "MainData.xml";
        }

        public void Save()
        {
            Directory.CreateDirectory(GetDirectory());
            XmlSerializer writer = new XmlSerializer(typeof(RemoteServer));
            StreamWriter file = new StreamWriter(GetFile());
            writer.Serialize(file, this);
            file.Close();
        }

        public static bool operator ==(RemoteServer s1, RemoteServer s2)
        {
            if (s1.adress == s2.adress &&
                s1.engine == s2.engine &&
                s1.login == s2.login &&
                s1.name == s2.name &&
                s1.password == s2.password &&
                s1.version == s2.version)
                return true;
            else
                return false;
        }

        public static bool operator !=(RemoteServer s1, RemoteServer s2)
        {
            if (s1 == s2)
                return false;
            else
                return true;
        }
    }
}
