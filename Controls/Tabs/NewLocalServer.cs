using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;
using MinecraftServerManager.Utils;
using MinecraftServerManager.Dialogs;

namespace MinecraftServerManager.Controls
{
    public partial class NewLocalServer : UserControl, IStyleableTab
    {
        private Data.Server ServerData;
        private string ServerDirectory;
        private string EngineFile;
        private Data.Style style;
        private Tabs tabs;
        private WebClient Client; 

        public NewLocalServer()
        {
            InitializeComponent();
            this.label1.Text = Language.GetString("Name");
            this.label2.Text = Language.GetString("Engine");
            this.label3.Text = Language.GetString("Version");
            this.label4.Text = Language.GetString("AgreeEula");
            this.readyButton.Text = Language.GetString("Ready");
            this.NewLocalServer_Resize(null, null);
            this.eulaLabelLink.Location = new Point(label4.Width - 4, eulaLabelLink.Location.Y);
            this.eulaCheckBox.Location = new Point(eulaLabelLink.Location.X + eulaLabelLink.Width + 4, this.eulaCheckBox.Location.Y);
            this.versionSelect.Items.AddRange(Main.EngineVersions);
        }

        public new void Load(Tabs _tabs)
        {
            this.tabs = _tabs;
            tabs.AddTab(Language.GetString("NewLocalServerName"), this);
        }

        public bool Close()
        {
            if (Client == null || Client.IsBusy == false)
                return true;
            DialogResult dr = MessageBox.Show(Language.GetString("NewLocalServerAbort"), Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                Client.CancelAsync();
                return true;
            }
            return false;
        }

        private void NewLocalServer_Resize(object sender, EventArgs e)
        {
            this.serverName.Size = new Size(this.Width - 70, 27);
            this.engineSelect.Size = new Size(this.Width - 70, 27);
            this.versionSelect.Size = new Size(this.Width - 70, 27);
            this.readyButton.Width = this.Width;
        }

        public void SetStyle(Data.Style _style)
        {
            style = _style;
            this.readyButton.SetStyle(style);
            Colors.StyleComboBox(this.engineSelect, style);
            Colors.StyleComboBox(this.versionSelect, style);
            Colors.StyleTextBox(this.serverName, style);
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            if (engineSelect.SelectedItem == null)
            {
                Error.Show("ErrorNoEngine");
                return;
            }
            if (this.versionSelect.SelectedItem == null)
            {
                Error.Show("ErrorNoVersion");
                return;
            }
            if (!eulaCheckBox.Checked)
            {
                Error.Show("ErrorNoEula");
                return;
            }
            if (serverName.Text == "")
            {
                Error.Show("ErrorNoServerName");
                return;
            }
            string engine = engineSelect.SelectedItem.ToString(), version = this.versionSelect.SelectedItem.ToString();
            ServerData = new Data.Server();
            ServerData.name = serverName.Text;
            ServerData.version = version;
            ServerData.engine = engine;
            ServerDirectory = ServerData.GetDirectory();
            if (Directory.Exists(ServerDirectory))
            {
                Error.Show("ErrorServerExists");
                return;
            }
            Directory.CreateDirectory(ServerDirectory);
            string engineDirectory = Main.EnginesDirectory + engine + Path.DirectorySeparatorChar;
            Directory.CreateDirectory(engineDirectory);
            EngineFile = engineDirectory + version + ".jar";
            if (File.Exists(EngineFile))
            {
                DownloadProgressCompleted(null, new AsyncCompletedEventArgs(null, false, null));
            }
            else
            {
                string url = "http://mcservermanager.tk/info/servers/" + engine.ToLower() + "-" + version + ".jar";
                if (engine == "Vanilla")
                    url = "https://s3.amazonaws.com/Minecraft.Download/versions/" + version + "/minecraft_server." + version + ".jar";
                Client = new WebClient();
                Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
                Client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadProgressCompleted);
                Client.DownloadFileAsync(new Uri(url), EngineFile);
            }

            this.Enabled = false;
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes;
            string megaBytesReceived = (e.BytesReceived / (1024.0 * 1024.0)).ToString("0.00") + "MB";
            string megaBytesTotal = (e.TotalBytesToReceive / (1024.0 * 1024.0)).ToString("0.00") + "MB";
            readyButton.Text = String.Format(Language.GetString("DownloadProgressServer"), megaBytesReceived, megaBytesTotal);
            this.readyButton.Progress = (float)percentage;
        }

        private void DownloadProgressCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled && File.Exists(ServerDirectory + "server.jar"))
            {
                Directory.Delete(ServerDirectory, true);
                return;
            }
            if (e.Error != null)
            {
                Error.Show("DownloadErrorServer");
                Directory.Delete(ServerDirectory, true);
                File.Delete(EngineFile);
                return;
            }
            ServerData.Save();
            StreamWriter file = File.CreateText(ServerDirectory + "eula.txt");
            file.Write("eula=true");
            file.Close();
            this.readyButton.Text = Language.GetString("DownloadFinished");
            new Computer().FileSystem.CopyFile(EngineFile, ServerData.GetDirectory() + "server.jar", UIOption.AllDialogs);
            this.tabs.mainWindow.serversTree.FullRefresh();
        }
    }
}
