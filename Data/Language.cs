using System.IO;
using System.Xml.Serialization;

namespace MinecraftServerManager.Data
{
    public class Language
    {
        public string SelectedLanguage;

        public Language() { }

        public Language(string SelectedLanguage)
        {
            this.SelectedLanguage = SelectedLanguage;
        }

        public static Language Deserialize()
        {
            Language obj = new Language();
            XmlSerializer serializer = new XmlSerializer(typeof(Language));
            StreamReader reader = new StreamReader(Utils.Main.DataDirectory + "Language.xml");
            obj = (Language)serializer.Deserialize(reader);
            reader.Close();
            return obj;
        }

        public void Save()
        {
            XmlSerializer writer = new XmlSerializer(typeof(Language));
            StreamWriter file = new StreamWriter(Utils.Main.DataDirectory + "Language.xml");
            writer.Serialize(file, this);
            file.Close();
        }
    }
}
