using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls.Menus
{
    public partial class Language : UserControl
    {
        private Tabs tabs;

        public Language()
        {
            InitializeComponent();
            this.english.Text = "     " + Utils.Language.GetString("MenuEnglish");
            this.polish.Text = "     " + Utils.Language.GetString("MenuPolish");

            using (Graphics g = CreateGraphics())
            {
                List<int> widthList = new List<int>();
                widthList.Add(g.MeasureString(polish.Text, polish.Font).ToSize().Width);
                widthList.Add(g.MeasureString(english.Text, english.Font).ToSize().Width);

                int width = Utils.Numbers.Max(widthList) + Utils.Numbers.MenuPadding;
                Width = width + 2;
                polish.Width = width;
                english.Width = width;
            }
        }

        public new void Load(Tabs _tabs)
        {
            this.tabs = _tabs;
        }

        public void SetStyle(Data.Style style)
        {
            this.BackColor = style.WindowBackColor;
            this.english.BackColor = style.ControlBackColor;
            this.polish.BackColor = style.ControlBackColor;
        }

        private void english_Click(object sender, EventArgs e)
        {
            ChangeLanguage("en");
        }

        private void polish_Click(object sender, EventArgs e)
        {
            ChangeLanguage("pl");
        }

        private void ChangeLanguage(string s)
        {
            DialogResult dr = MessageBox.Show(Utils.Language.GetString("WarningLanguageChange"), 
                Utils.Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dr == DialogResult.Yes)
            {
                Data.Language language = new Data.Language(s);
                language.Save();
                Application.Restart();
            }
        }
    }
}
