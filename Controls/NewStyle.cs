using System;
using System.Drawing;
using System.Windows.Forms;
using MinecraftServerManager.Utils;
using MinecraftServerManager.Dialogs;

namespace MinecraftServerManager.Controls
{
    public partial class NewStyle : UserControl
    {
        private StyleEditor styleEditor;

        public NewStyle()
        {
            InitializeComponent();
            this.label1.Text = Language.GetString("StyleName");
            this.label2.Text = Language.GetString("StyleColorFore");
            this.label3.Text = Language.GetString("StyleColorBack");
            this.label4.Text = Language.GetString("StyleColorControl");
            this.foreColorLabel.Text = Language.GetString("Change");
            this.windowBackColorLabel.Text = Language.GetString("Change");
            this.controlBackColorLabel.Text = Language.GetString("Change");
            this.save.Text = Language.GetString("StyleAddButton");
        }

        private void foreColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                foreColor.BackColor = cd.Color;
                foreColorLabel.ForeColor = Colors.Invert(cd.Color);
            }
        }

        private void controlBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                controlBackColor.BackColor = cd.Color;
                controlBackColorLabel.ForeColor = Colors.Invert(cd.Color);
            }
        }

        private void windowBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                windowBackColor.BackColor = cd.Color;
                windowBackColorLabel.ForeColor = Colors.Invert(cd.Color);
            }
        }

        private void NewStyle_Resize(object sender, EventArgs e)
        {
            this.nameText.Size = new Size(this.Width - 200, 30);
            this.foreColor.Size = new Size(this.Width - 200, 20);
            this.controlBackColor.Size = new Size(this.Width - 200, 20);
            this.windowBackColor.Size = new Size(this.Width - 200, 20);
            this.save.Size = new Size(this.Width, 30);
            this.foreColorLabel.Location = new Point((this.Width - 200 - this.foreColorLabel.Width) / 2, 0);
            this.controlBackColorLabel.Location = new Point((this.Width - 200 - this.controlBackColorLabel.Width) / 2, 0);
            this.windowBackColorLabel.Location = new Point((this.Width - 200 - this.windowBackColorLabel.Width) / 2, 0);
        }

        private void foreColorLabel_Click(object sender, EventArgs e)
        {
            foreColor_Click(sender, e);
        }

        private void controlBackColorLabel_Click(object sender, EventArgs e)
        {
            controlBackColor_Click(sender, e);
        }

        private void windowBackColorLabel_Click(object sender, EventArgs e)
        {
            windowBackColor_Click(sender, e);
        }


        public void SetStyle(Data.Style style)
        {
            Utils.Colors.StyleButton(this.save, style);
            this.nameText.ForeColor = style.ForeColor;
            this.nameText.BackColor = style.ControlBackColor;
            this.foreColor.BackColor = style.ForeColor;
            this.controlBackColor.BackColor = style.ControlBackColor;
            this.windowBackColor.BackColor = style.WindowBackColor;
            this.foreColorLabel.ForeColor = Colors.Invert(this.foreColor.BackColor);
            this.controlBackColorLabel.ForeColor = Colors.Invert(this.controlBackColor.BackColor);
            this.windowBackColorLabel.ForeColor = Colors.Invert(this.windowBackColor.BackColor);
        }

        public new void Load(StyleEditor _styleEditor)
        {
            this.styleEditor = _styleEditor;
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (this.nameText.Text == String.Empty)
            {
                Error.Show("ErrorNoStyleName");
                return;
            }
            Data.Style newStyle = new Data.Style();
            newStyle.Name = nameText.Text;
            newStyle.ForeColor = foreColor.BackColor;
            newStyle.ControlBackColor = controlBackColor.BackColor;
            newStyle.WindowBackColor = windowBackColor.BackColor;
            styleEditor.AddStyle(newStyle);
        }
    }
}
