using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls
{
    public partial class Style : UserControl
    {
        public Style()
        {
            InitializeComponent();
            this.deleteButton.Text = Utils.Language.GetString("Delete");
        }

        private StyleEditor styleEditor;
        public Data.Style style;
        private bool IgnoreCheckedChangedEvent = false;

        public void SetChecked(bool value)
        {
            if (this.selectBox.Checked == value)
                return;
            this.IgnoreCheckedChangedEvent = true;
            this.selectBox.Checked = value;
        }

        public new void Load(StyleEditor _styleEditor, Data.Style _style)
        {
            this.styleEditor = _styleEditor;
            this.style = _style;
            if (style.Selected)
            {
                this.IgnoreCheckedChangedEvent = true;
                this.selectBox.Checked = true;
            }
            this.styleEditor.Controls.Add(this);
            this.styleEditor.StyleControls.Add(this);
            this.styleEditor.RefreshStyles();
            this.selectBox.Text = this.style.Name;
        }

        private void selectBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.IgnoreCheckedChangedEvent)
            {
                this.IgnoreCheckedChangedEvent = false;
                return;
            }
            if (this.selectBox.Checked)
            {
                this.styleEditor.SetSelectedStyle(this);
            }
            else
            {
                this.IgnoreCheckedChangedEvent = true;
                this.selectBox.Checked = true;
            }
        }

        private void Style_Resize(object sender, EventArgs e)
        {
            this.deleteButton.Location = new Point(this.Width - this.deleteButton.Width, 0);
        }

        public void SetStyle(Data.Style style)
        {
            Utils.Colors.StyleButton(this.deleteButton, style);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.style.BuiltIn)
            {
                MessageBox.Show("Nie można usunąć wbudowanego stylu!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.styleEditor.DeleteStyle(this.style);
                this.Dispose();
                this.styleEditor.StyleControls.Remove(this);
                this.styleEditor.RefreshStyles();
            }
        }
    }
}
