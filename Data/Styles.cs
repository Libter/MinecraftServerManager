using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace MinecraftServerManager.Data
{
    public class Styles
    {
        public List<Style> styles = new List<Style>();

        public void Save()
        {
            XmlSerializer writer = new XmlSerializer(typeof(Styles));
            StreamWriter file = new StreamWriter(Utils.Main.DataDirectory + "Styles.xml");
            writer.Serialize(file, this);
            file.Close();
        }

        public static Styles Deserialize()
        {
            Styles data = new Styles();
            XmlSerializer serializer = new XmlSerializer(typeof(Styles));
            StreamReader reader = new StreamReader(Utils.Main.DataDirectory + "Styles.xml");
            data = (Styles)serializer.Deserialize(reader);
            reader.Close();
            return data;
        }
    }
}
