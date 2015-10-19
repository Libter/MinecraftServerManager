using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls.Menus
{
    public partial class Settings : UserControl
    {
        private Tabs tabs;

        public Settings()
        {
            InitializeComponent();
            this.style.Text = "     " + Utils.Language.GetString("MenuSettingsStyles");
            this.engine.Text = "     " + Utils.Language.GetString("MenuSettingsEngines");

            using (Graphics g = CreateGraphics())
            {
                List<int> widthList = new List<int>();
                widthList.Add(g.MeasureString(style.Text, style.Font).ToSize().Width);
                widthList.Add(g.MeasureString(engine.Text, engine.Font).ToSize().Width);

                int width = Utils.Numbers.Max(widthList) + Utils.Numbers.MenuPadding;
                Width = width + 2;
                style.Width = width;
                engine.Width = width;
            }
        }

        public new void Load(Tabs _tabs)
        {
            this.tabs = _tabs;
        }

        private void style_Click(object sender, EventArgs e)
        {
            StyleEditor se = new StyleEditor();
            se.Load(tabs);
        }

        private void engine_Click(object sender, EventArgs e)
        {
            EngineEditor ee = new EngineEditor();
            ee.Load(tabs);
        }

        public void SetStyle(Data.Style style)
        {
            this.BackColor = style.WindowBackColor;
            this.style.BackColor = style.ControlBackColor;
            this.style.Image = Utils.Icons.AddColor(Properties.Resources.MenuStyle, style.ForeColor);
            this.engine.BackColor = style.ControlBackColor;
            this.engine.Image = Utils.Icons.AddColor(Properties.Resources.MenuEngine, style.ForeColor);
        }
    }
}
