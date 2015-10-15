using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Controls
{
    public partial class ConnectLocalServer : UserControl, IStyleableTab
    {
        private Tabs tabs;

        public ConnectLocalServer()
        {
            InitializeComponent();
            this.label5.Text = Language.GetString("Name");
            this.label4.Text = Language.GetString("Engine");
            this.label3.Text = Language.GetString("Version");
            this.label1.Text = Language.GetString("SelectServerDirectory");
            this.label2.Text = Language.GetString("SelectServerFile");
            this.selectDirectoryButton.Text = Language.GetString("BrowseDirectory");
            this.selectJarButton.Text = Language.GetString("BrowseDirectory");
            this.readyButton.Text = Language.GetString("Ready");
            this.versionSelect.Items.AddRange(Main.EngineVersions);
            this.versionSelect.Items.Add(Language.GetString("OtherFemale"));
            this.engineSelect.Items.Add(Language.GetString("OtherMale"));
        }

        public new void Load(Tabs _tabs)
        {
            this.tabs = _tabs;
            tabs.AddTab(Language.GetString("ConnectLocalServer"), this);
        }

        public void SetStyle(Data.Style style)
        {
            Colors.StyleButton(this.selectDirectoryButton, style);
            Colors.StyleButton(this.selectJarButton, style);
            Colors.StyleButton(this.readyButton, style);
            Colors.StyleTextBox(this.serverName, style);
        }

        private void selectDirectoryButton_Click(object sender, EventArgs e)
        {
            DialogResult result = selectDirectory.ShowDialog();
            if (result == DialogResult.OK)
                selectDirectoryButton.Text = Language.GetString("SelectedDirectory") + " " + Path.GetFileName(selectDirectory.SelectedPath);
        }

        private void selectJarButton_Click(object sender, EventArgs e)
        {
            selectJar.InitialDirectory = selectDirectory.SelectedPath;
            DialogResult result = selectJar.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (Path.GetDirectoryName(selectJar.FileName) != selectDirectory.SelectedPath)
                    Dialogs.Error.Show("ErrorEngineNotInDirectory");
                else
                    selectJarButton.Text = Language.GetString("SelectedFile") + " " + Path.GetFileName(selectJar.FileName);
            }
        }

        private void next_Click(object sender, EventArgs e)
        {
            #region validation
            if (serverName.Text == "")
            {
                Dialogs.Error.Show("ErrorNoServerName");
                return;
            }
            if (engineSelect.SelectedItem == null)
            {
                Dialogs.Error.Show("ErrorNoEngine");
                return;
            }
            if (this.versionSelect.SelectedItem == null)
            {
                Dialogs.Error.Show("ErrorNoVersion");
                return;
            }
            if (selectDirectory.SelectedPath == "")
            {
                Dialogs.Error.Show("ErrorNoDirectory");
                return;
            }
            if (selectJar.FileName == "")
            {
                Dialogs.Error.Show("ErrorNoJar");
                return;
            }
            #endregion

            Data.Server data = new Data.Server();
            data.engine = engineSelect.SelectedItem.ToString();
            data.name = serverName.Text;
            data.version = versionSelect.SelectedItem.ToString();
            data.path = selectDirectory.SelectedPath;
            data.jarPath = selectJar.FileName;
            data.isImported = true;

            if (File.Exists(data.GetFile()))
            {
                Dialogs.Error.Show("ErrorServerExists");
                return;
            }
            
            data.Save();

            this.Enabled = false;

            tabs.mainWindow.serversTree.FullRefresh();
        }

        private void ConnectLocalServer_Resize(object sender, EventArgs e)
        {
            this.selectDirectoryButton.Size = new Size(this.Width - 200, 30);
            this.selectJarButton.Size = new Size(this.Width - 200, 30);
            this.readyButton.Size = new Size(this.Width, 30);
            this.serverName.Size = new Size(this.Width - 70, 27);
            this.versionSelect.Size = new Size(this.Width - 70, 27);
            this.engineSelect.Size = new Size(this.Width - 70, 27);
        }
    }
}
