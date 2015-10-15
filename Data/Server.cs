using System;
using System.IO;
using System.Xml.Serialization;

namespace MinecraftServerManager.Data
{
    public class Server
    {
        public String name;
        public String engine;
        public String version;
        public String path;
        public String jarPath;
        public bool isImported;

        public static Server Deserialize(string filename)
        {
            Data.Server serverData = new Data.Server();
            XmlSerializer serializer = new XmlSerializer(typeof(Data.Server));
            StreamReader reader = new StreamReader(filename);
            serverData = (Data.Server)serializer.Deserialize(reader);
            reader.Close();
            return serverData;
        }

        public override string ToString()
        {
            return name + " (" + engine + " " + version + ")";
        }

        public string GetFile()
        {
            if (isImported)
                return Utils.Main.ImportDirectory + name + ".xml";
            else
                return Utils.Main.ServersDirectory + name + Path.DirectorySeparatorChar + "ServerManagerData.xml";
        }

        public string GetDirectory()
        {
            if (isImported)
                return path;
            else
                return Utils.Main.ServersDirectory + name + Path.DirectorySeparatorChar;
        }

        public void Save()
        {
            XmlSerializer writer = new System.Xml.Serialization.XmlSerializer(typeof(Data.Server));
            StreamWriter file = new StreamWriter(GetFile());
            writer.Serialize(file, this);
            file.Close();
        }

        public static bool operator ==(Server s1, Server s2) 
        {
            if (s1.engine == s2.engine &&
                s1.jarPath == s2.jarPath &&
                s1.name == s2.name &&
                s1.version == s2.version &&
                s1.path == s2.path &&
                s1.isImported == s2.isImported)
                return true;
            else
                return false;
        }

        public static bool operator !=(Server s1, Server s2)
        {
            if (s1 == s2)
                return false;
            else
                return true;
        }
    }
}
