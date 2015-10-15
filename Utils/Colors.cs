using System.Drawing;
using System.Windows.Forms;

namespace MinecraftServerManager.Utils
{
    public class Colors
    {
        public static Color Bright(Color color, int i)
        {
            if (color.R < i)
                color = Color.FromArgb(i, color.G, color.B);
            if (color.G < i)
                color = Color.FromArgb(color.R, i, color.B);
            if (color.B < i)
                color = Color.FromArgb(color.R, color.G, i);
            return color;
        }

        public static Color Dark(Color color, int i)
        {
            color = Bright(color, i);
            return Color.FromArgb(color.R - i, color.G - i, color.B - i);
        }

        public static Color Invert(Color color)
        {
            return Color.FromArgb(255 - color.R, 255 - color.G, 255 - color.B);
        }

        public static void StyleTextBox(TextBox textBox, Data.Style style)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.BackColor = style.ControlBackColor;
            textBox.ForeColor = style.ForeColor;
        }

        public static void StyleButton(Button button, Data.Style style)
        {
            button.BackColor = style.ControlBackColor;
            button.FlatAppearance.MouseOverBackColor = style.WindowBackColor;
            button.FlatAppearance.MouseDownBackColor = style.WindowBackColor;
            button.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 255, 255);
            button.FlatAppearance.BorderSize = 0;
            button.TabIndex = 0;
            button.TabStop = false;
        }

        public static void StyleComboBox(ComboBox comboBox, Data.Style style)
        {
            comboBox.BackColor = style.ControlBackColor;
            comboBox.ForeColor = style.ForeColor;
        }

        public static void StyleFastColoredTextBox(FastColoredTextBoxNS.FastColoredTextBox box, Data.Style style)
        {
            box.BackColor = style.ControlBackColor;
            box.ForeColor = style.ForeColor;
            box.CaretColor = style.ForeColor;
            box.IndentBackColor = style.ControlBackColor;
            box.ServiceLinesColor = style.WindowBackColor;
        }

        public static Data.Style GetDefaultStyle()
        {
            Data.Style brightGold = new Data.Style();
            brightGold.ForeColor = Color.Black;
            brightGold.ControlBackColor = Color.White;
            brightGold.WindowBackColor = Color.Gold;
            brightGold.Name = Utils.Language.GetString("StyleBrightGold");
            brightGold.Selected = true;
            return brightGold;
        }
    }
}
