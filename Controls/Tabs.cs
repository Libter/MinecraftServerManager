using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls
{
    public class Tabs : UserControl
    {
        public Data.Style Style;

        public List<Tab> tabs = new List<Tab>();

        public Tab SelectedTab;

        public MainWindow mainWindow;

        public Tabs()
        {
            this.Resize += new EventHandler(Tabs_Resize);
        }

        public new void Load(MainWindow _mainWindow)
        {
            this.mainWindow = _mainWindow;
        }

        public void AddTab(string name, Control control)
        {
            Tab tab = new Tab(name, control, this);
            this.tabs.Add(tab);
            this.Controls.Add(tab);

            RefreshTabs();

            SelectTab(tab);

            Tabs_Resize(null, null);
        }

        public void SelectTab(Tab tab)
        {
            Tab previousSelectedTab = this.SelectedTab;
            this.SelectedTab = tab;
            if (previousSelectedTab != null)
            {

                previousSelectedTab.control.Hide();
                previousSelectedTab.Tab_MouseLeave(null, null);
            }
            this.SelectedTab.BackColor = tab.StartBackColor;
            tab.control.Show();

            Tabs_Resize(null, null);
        }

        public void RemoveTab(Tab tab)
        {
            tab.control.Hide();
            tabs.Remove(tab);
            this.Controls.Remove(tab);

            if (this.SelectedTab.Equals(tab) && tabs.Count > 0)
                SelectTab(tabs[tabs.Count - 1]);

            RefreshTabs();
        }

        public void RefreshTabs()
        {
            for (int i = 0; i < tabs.Count; i++)
            {
                if (i == 0)
                    tabs[i].Location = new Point(0, 0);
                else
                    tabs[i].Location = new Point(tabs[i - 1].Location.X + tabs[i - 1].Width, 0);
            }
        }

        public void Tabs_Resize(object sender, EventArgs e)
        {
            if (this.SelectedTab != null)
                this.SelectedTab.Tab_Resize();
        }

        public void SetStyle(Data.Style style)
        {
            this.Style = style;
            foreach (Tab tab in tabs)
            {
                tab.SetStyle(style);
            }
        }
    }
}
