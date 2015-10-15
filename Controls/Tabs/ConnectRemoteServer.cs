using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;
using MinecraftServerManager.Dialogs;
using MinecraftServerManager.Utils;
using MinecraftServerManager.Utils.MinecraftRcon;

namespace MinecraftServerManager.Controls
{
    public partial class ConnectRemoteServer : UserControl, IStyleableTab
    {
        private Tabs tabs;

        public ConnectRemoteServer()
        {
            InitializeComponent();
            this.label5.Text = Language.GetString("Name");
            this.label4.Text = Language.GetString("Engine");
            this.label3.Text = Language.GetString("Version");
            this.label1.Text = Language.GetString("IpAdress");
            this.label2.Text = Language.GetString("DataFtp");
            this.label6.Text = Language.GetString("Port");
            this.label7.Text = Language.GetString("User");
            this.label8.Text = Language.GetString("Password");
            this.label11.Text = Language.GetString("DataRcon");
            this.label12.Text = Language.GetString("Port");
            this.label9.Text = Language.GetString("Password");
            this.readyButton.Text = Language.GetString("Ready");
            this.versionSelect.Items.AddRange(Main.EngineVersions);
            this.versionSelect.Items.Add(Language.GetString("OtherFemale"));
            this.engineSelect.Items.Add(Language.GetString("OtherMale"));
        }

        public new void Load(Tabs _tabs)
        {
            this.tabs = _tabs;
            tabs.AddTab(Language.GetString("ConnectRemoteServer"), this);
        }

        public void SetStyle(Data.Style style)
        {
            Utils.Colors.StyleButton(this.readyButton, style);
            Utils.Colors.StyleTextBox(this.serverName, style);
            Utils.Colors.StyleTextBox(this.serverIP, style);
            Utils.Colors.StyleTextBox(this.ftpPassword, style);
            Utils.Colors.StyleTextBox(this.ftpPort, style);
            Utils.Colors.StyleTextBox(this.ftpUser, style);
            Utils.Colors.StyleTextBox(this.rconPassword, style);
            Utils.Colors.StyleTextBox(this.rconPort, style);
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            #region validation
            if (serverName.Text == "")
            {
                Error.Show("ErrorNoServerName");
                return;
            }
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
            if (serverIP.Text == "")
            {
                Error.Show("ErrorNoServerIp");
                return;
            }
            if (ftpUser.Text == "" || ftpPassword.Text == "" || ftpPort.Text == "")
            {
                Error.Show("ErrorNoFtpData");
                return;
            }
            if (rconPassword.Text == "" || rconPort.Text == "")
            {
                Error.Show("ErrorNoRconData");
                return;
            }

            int ftpPortNumber, rconPortNumber;
            if (!int.TryParse(ftpPort.Text, out ftpPortNumber))
            {
                Error.Show("ErrorNanPortFtp");
                return;
            }
            else if (ftpPortNumber < 0 || ftpPortNumber > 65535)
            {
                Error.Show("ErrorOorPortFtp");
            }

            if (!int.TryParse(rconPort.Text, out rconPortNumber))
            {
                Error.Show("ErrorNanPortRcon");
                return;
            }
            else if (rconPortNumber < 0 || rconPortNumber > 65535)
            {
                Error.Show("ErrorOorPortRcon");
            }
            #endregion

            string ip = serverIP.Text;
            int port = ftpPortNumber;
            string user = ftpUser.Text;
            string password = ftpPassword.Text;

            Data.RemoteServer ftpData = new Data.RemoteServer();
            Data.RemoteServerRcon rconData = new Data.RemoteServerRcon();

            try
            {
                ftpData.adress = "ftp://" + ip + ":" + port + "/";
                ftpData.login = user;
                ftpData.password = password;
                ftpData.name = serverName.Text;
                ftpData.engine = engineSelect.SelectedItem.ToString();
                ftpData.version = versionSelect.SelectedItem.ToString();

                Utils.Ftp.directoryListSimple(ftpData, "");

                ftpData.Save();
            }
            catch (WebException)
            {
                Error.Show("ErrorFtp");
                return;
            }

            RconClient rcon = RconClient.INSTANCE;
            rcon.setupStream(serverIP.Text, rconPortNumber, rconPassword.Text);
            if (rcon.isInit)
            {
                rconData.name = serverName.Text;
                rconData.adress = serverIP.Text;
                rconData.password = rconPassword.Text;
                rconData.port = rconPortNumber;
                rconData.Save();
            }
            else
            {
                Error.Show("ErrorRcon");
                return;
            }

            rconData.Save();
            ftpData.Save();

            this.Enabled = false;

            tabs.mainWindow.serversTree.FullRefresh();
        }

        private void ConnectRemoteServer_Resize(object sender, EventArgs e)
        {
            this.serverIP.Size = new Size(this.Width - 91, 27);
            this.serverName.Size = new Size(this.Width - 91, 27);
            this.versionSelect.Size = new Size(this.Width - 91, 27);
            this.engineSelect.Size = new Size(this.Width - 91, 27);
            this.ftpPort.Size = new Size(this.Width - 91, 27);
            this.ftpPassword.Size = new Size(this.Width - 91, 27);
            this.ftpUser.Size = new Size(this.Width - 91, 27);
            this.rconPassword.Size = new Size(this.Width - 91, 27);
            this.rconPort.Size = new Size(this.Width - 91, 27);
            this.readyButton.Size = new Size(this.Width, 30);
        }
    }
}
