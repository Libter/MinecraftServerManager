using System;
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
