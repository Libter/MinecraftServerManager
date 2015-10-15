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
    }
}
