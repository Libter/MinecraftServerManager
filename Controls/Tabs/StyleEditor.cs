using System;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Controls
{
    public partial class StyleEditor : UserControl, IStyleableTab
    {
        private Data.Styles styles;

        public List<Style> StyleControls = new List<Style>();

        private Tabs tabs;

        public StyleEditor()
        {
            InitializeComponent();
            this.selectStyleLabel.Text = Language.GetString("StyleSelect");
            this.newStyleLabel.Text = Language.GetString("StyleAdd");
        }

        public new void Load(Tabs _tabs)
        {
            this.tabs = _tabs;
            foreach (Tab t in tabs.tabs)
            {
                if (t.control is StyleEditor)
                {
                    tabs.SelectTab(t);
                    return;
                }
            }
            if (File.Exists(Main.DataDirectory + "Styles.xml"))
            {
                styles = Data.Styles.Deserialize();
            }
            else 
            {
                styles = new Data.Styles();
                Data.Style brightGold = new Data.Style();
                brightGold.ForeColor = Color.Black;
                brightGold.ControlBackColor = Color.White;
                brightGold.WindowBackColor = Color.Gold;
                brightGold.Name = Language.GetString("StyleBrightGold");
                brightGold.Selected = true;
                brightGold.BuiltIn = true;
                Data.Style dark = new Data.Style();
                dark.ForeColor = Color.FromArgb(224, 224, 224);
                dark.ControlBackColor = Color.FromArgb(32, 32, 32);
                dark.WindowBackColor = Color.Black;
                dark.Name = Language.GetString("StyleDark");
                dark.BuiltIn = true;
                styles.styles.Add(brightGold);
                styles.styles.Add(dark);
            }
            foreach (Data.Style s in styles.styles) 
            {
                if (s.Selected)
                    this.tabs.mainWindow.SetStyle(s);

                //fix old style names
                if (s.BuiltIn && (s.Name.ToLower() == "jasne złoto (wbudowany)" || s.Name.ToLower() == "bright gold (built-in)"))
                    s.Name = Language.GetString("StyleBrightGold");
                if (s.BuiltIn && (s.Name.ToLower() == "ciemny (wbudowany)" || s.Name.ToLower() == "dark (build-in)"))
                    s.Name = Language.GetString("StyleDark");

                //change language of style names
                if (s.BuiltIn && (s.Name == Resources.LanguagePL.StyleBrightGold || s.Name == Resources.LanguageEN.StyleBrightGold))
                    s.Name = Language.GetString("StyleBrightGold");
                if (s.BuiltIn && (s.Name == Resources.LanguagePL.StyleDark || s.Name == Resources.LanguageEN.StyleDark))
                    s.Name = Language.GetString("StyleDark");

                Style style = new Style();
                style.Load(this, s);
            }
            newStyle.Load(this);
            tabs.AddTab(Language.GetString("StyleEditorName"), this);
        }

        private void StyleEditor_Resize(object sender, EventArgs e)
        {
            this.newStyle.Size = new Size(this.Width, 120);
            foreach (Style s in StyleControls)
            {
                s.Size = new Size(this.Width, 30);
            }
        }

        public void SetStyle(Data.Style style)
        {
            this.newStyle.SetStyle(style);
            foreach (Style s in StyleControls)
            {
                s.SetStyle(style);
            }
        }

        public void RefreshStyles()
        {
            for (int i = 0; i < StyleControls.Count; i++)
            {
                StyleControls[i].Location = new Point(0, 20 + i * 30);
            }
            this.newStyleLabel.Location = new Point(0, 20 + StyleControls.Count * 30);
            this.newStyle.Location = new Point(0, 40 + StyleControls.Count * 30);
        }

        public void SetSelectedStyle(Style style)
        {
            foreach (Style s in this.StyleControls)
            {
                s.SetChecked(false);
                s.style.Selected = false;
            }
            style.SetChecked(true);
            style.style.Selected = true;
            this.tabs.mainWindow.SetStyle(style.style);
        }

        public bool Close()
        {
            styles.Save();
            return true;
        }

        public void DeleteStyle(Data.Style style)
        {
            this.styles.styles.Remove(style);
        }

        public void AddStyle(Data.Style s)
        {
            this.styles.styles.Add(s);
            Style style = new Style();
            style.Load(this, s);
            this.StyleEditor_Resize(null, null);
            RefreshStyles();
        }
    }
}
