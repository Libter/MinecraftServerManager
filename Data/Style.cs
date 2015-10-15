using System;
using System.IO;
using System.Drawing;
using System.Xml.Serialization;

namespace MinecraftServerManager.Data
{
    public class Style
    {
        [XmlIgnore]
        public Color ForeColor;
        [XmlIgnore]
        public Color ControlBackColor;
        [XmlIgnore]
        public Color WindowBackColor;

        public string Name;
        public bool Selected = false;
        public bool BuiltIn = false;

        [XmlElement("ForeColor")]
        public int ForeColorAsArgb
        {
            get { return ForeColor.ToArgb(); }
            set { ForeColor = Color.FromArgb(value); }
        }

        [XmlElement("ControlBackColor")]
        public int ControlBackColorAsArgb
        {
            get { return ControlBackColor.ToArgb(); }
            set { ControlBackColor = Color.FromArgb(value); }
        }

        [XmlElement("WindowBackColor")]
        public int WindowBackColorAsArgb
        {
            get { return WindowBackColor.ToArgb(); }
            set { WindowBackColor = Color.FromArgb(value); }
        }
        
        /// <summary>
        /// NOT USE THIS METHOD!
        /// This is for obscufator only!
        /// </summary>
        public static Style Deserialize()
        {
            Style data = new Style();
            XmlSerializer serializer = new XmlSerializer(typeof(Style));
            StreamReader reader = new StreamReader("");
            data = (Style)serializer.Deserialize(reader);
            reader.Close();
            return data;
        }
    }
}
