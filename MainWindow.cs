using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager
{
    public partial class MainWindow : Form
    {
        private long startTime;
        private Controls.Menus.AddServer addServerMenuItems = new Controls.Menus.AddServer();
        private Controls.Menus.Settings settingsMenuItems = new Controls.Menus.Settings();
        private Controls.Menus.Language languageMenuItems = new Controls.Menus.Language();

        #region Main

        public MainWindow()
        {
            InitializeComponent();

            Text = Language.GetString("FullProgramName");
            settingsMenu.Text = "     " + Language.GetString("SettingsMenu");
            addServerMenu.Text = "     " + Language.GetString("AddServerMenu");
            languageMenu.Text = "     " + Language.GetString("MenuLanguage");
            serversTreeLabel.Text = Language.GetString("ServersTreeHeader");

            serversTree.Load(tabs);
            addServerMenuItems.Load(serversTree, tabs);
            tabs.Load(this);

            addServerMenuItems.Hide();
            settingsMenuItems.Hide();
            languageMenuItems.Hide();

            settingsMenuItems.Load(tabs);

            using (Graphics g = CreateGraphics())
            {
                int addServerMenuWidth = g.MeasureString(addServerMenu.Text, addServerMenu.Font).ToSize().Width + Numbers.MenuPadding;
                int settingMenuWidth = g.MeasureString(settingsMenu.Text, settingsMenu.Font).ToSize().Width + Numbers.MenuPadding;
                int languageMenuWidth = g.MeasureString(languageMenu.Text, languageMenu.Font).ToSize().Width + Numbers.MenuPadding;

                addServerMenu.Width = addServerMenuWidth;
                settingsMenu.Width = settingMenuWidth;
                languageMenu.Width = languageMenuWidth;

                addServerMenu.Location = new Point(0, 0);
                settingsMenu.Location = new Point(addServerMenuWidth, 0);
                languageMenu.Location = new Point(addServerMenuWidth + settingMenuWidth, 0);

                addServerMenuItems.Location = new Point(0, 30);
                settingsMenuItems.Location = new Point(addServerMenuWidth, 30);
                languageMenuItems.Location = new Point(addServerMenuWidth + settingMenuWidth, 30);
            }

            this.Controls.Add(addServerMenuItems);
            this.Controls.Add(settingsMenuItems);
            this.Controls.Add(languageMenuItems);
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            this.treeTabsContainer.Location = new Point(5, 30);
            this.treeTabsContainer.Size = new Size(this.Width - 28, this.Height - 74);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (File.Exists(Main.DataDirectory + "Styles.xml"))
            {
                Data.Styles styles = Data.Styles.Deserialize();
                foreach (Data.Style s in styles.styles)
                {
                    if (s.Selected)
                        this.SetStyle(s);
                }
            }
            else
            {
                this.SetStyle(Colors.GetDefaultStyle());
            }
            startTime = DateTime.Now.Ticks;
            if (File.Exists(Main.DataDirectory + "Tabs.xml"))
            {
                Data.Tabs.Deserialize().OpenAll(this.tabs);
            }
            this.WindowState = FormWindowState.Maximized;
            hideMenusTimer.Start();
            //check for updates
            try
            {
                WebClient client = new WebClient();
                client.DownloadStringCompleted += new DownloadStringCompletedEventHandler(versionChecked);
                client.DownloadStringAsync(new Uri("http://mcservermanager.tk/info/version.txt"));
            }
            catch (Exception) { }
        }

        private void versionChecked(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                Version latestVersion = new Version(e.Result);
                Version currentVersion = new Version(Application.ProductVersion);
                if (latestVersion > currentVersion)
                {
                    DialogResult dr = MessageBox.Show(Language.GetString("UpdateMessage"), Language.GetString("Update"), MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        if (Language.SelectedLanguage == "en")
                            Process.Start("http://mcservermanager.tk/Server manager.exe");
                        else if (Language.SelectedLanguage == "pl")
                            Process.Start("http://mcservermanager.tk/Menedżer serwera.exe");
                    }
                }
            }
            catch (Exception) { }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (Controls.Tab tp in tabs.tabs)
            {
                Controls.Tab tab = tp;
                    if (!tab.Close())
                       e.Cancel = true;
            }
            if (!e.Cancel)
            {
                Data.Tabs tabsData = new Data.Tabs();
                tabsData.Load(this.tabs);
                tabsData.Save();
                //stats
                long time = (long)(new TimeSpan(DateTime.Now.Ticks).TotalSeconds - new TimeSpan(startTime).TotalSeconds);
                try
                {
                    if (Main.HasInternetConnection())
                    {
                        WebClient client = new WebClient();
                        client.DownloadString("http://mcservermanager.tk/info/stats/index.php?time=" + time);
                        if (File.Exists(Main.DataDirectory + "Styles.xml"))
                            client.UploadFile("http://mcservermanager.tk/info/stats/styles/index.php", Main.DataDirectory + "Styles.xml");
                        if (File.Exists(Main.DataDirectory + "Tabs.xml"))
                            client.UploadFile("http://mcservermanager.tk/info/stats/tabs/index.php", Main.DataDirectory + "Tabs.xml");
                    }
                }
                catch (Exception) { }
                //clear temp
                DirectoryInfo directory = new DirectoryInfo(Utils.Main.TempDirectory);
                foreach (FileInfo file in directory.GetFiles()) file.Delete();
                foreach (DirectoryInfo subDirectory in directory.GetDirectories()) subDirectory.Delete(true);
            }
        }

        #endregion

        #region Menus

        private void addServerMenu_MouseEnter(object sender, EventArgs e)
        {
            this.addServerMenuItems.BringToFront();
            this.addServerMenuItems.Show();
        }

        private void settingsMenu_MouseEnter(object sender, EventArgs e)
        {
            this.settingsMenuItems.BringToFront();
            this.settingsMenuItems.Show();
        }

        private void languageMenu_MouseEnter(object sender, EventArgs e)
        {
            this.languageMenuItems.BringToFront();
            this.languageMenuItems.Show();
        }

        private void hideMenusTimer_Tick(object sender, EventArgs e)
        {
            Point p = this.PointToClient(Cursor.Position);
            if (!(this.addServerMenu.Bounds.Contains(p) || this.addServerMenuItems.Bounds.Contains(p)))
                this.addServerMenuItems.Hide();
            if (!(this.settingsMenu.Bounds.Contains(p) || this.settingsMenuItems.Bounds.Contains(p)))
                this.settingsMenuItems.Hide();
            if (!(this.languageMenu.Bounds.Contains(p) || this.languageMenuItems.Bounds.Contains(p)))
                this.languageMenuItems.Hide();
        }

        #endregion      

        private void treeTabsContainer_SplitterMoved(object sender, SplitterEventArgs e)
        {
            this.ActiveControl = null;
        }

        public void SetStyle(Data.Style style)
        {
            this.BackColor = style.WindowBackColor;
            this.ForeColor = style.ForeColor;
            this.tabs.BackColor = style.WindowBackColor;
            this.serversTreeLabel.BackColor = style.ControlBackColor;
            this.serversTreeLabel.ForeColor = style.ForeColor;

            this.addServerMenu.Image = Icons.AddColor(Properties.Resources.MenuAdd, style.ForeColor);
            this.settingsMenu.Image = Icons.AddColor(Properties.Resources.MenuSettings, style.ForeColor);
            this.languageMenu.Image = Icons.AddColor(Properties.Resources.MenuLanguage, style.ForeColor);

            this.serversTree.SetStyle(style);
            this.addServerMenuItems.SetStyle(style);
            this.settingsMenuItems.SetStyle(style);
            this.languageMenuItems.SetStyle(style);
            this.tabs.SetStyle(style);
        }

        private void MainWindow_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            e.IsInputKey = true;
        }

        private void treeTabsContainer_Panel1_Resize(object sender, EventArgs e)
        {
            this.serversTree.Size = new Size(this.treeTabsContainer.Panel1.Width, this.treeTabsContainer.Panel1.Height - 20);
        }
    }
}
