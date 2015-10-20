using System;
using System.Drawing;
using System.Net;
using System.ComponentModel;
using System.Windows.Forms;
using MinecraftServerManager.Dialogs;
using MinecraftServerManager.Utils;
using MinecraftServerManager.Utils.MinecraftRcon;

namespace MinecraftServerManager.Controls
{
    public partial class ConnectRemoteServer : UserControl, IStyleableTab
    {
        private Tabs tabs;
        private string error;
        private Data.RemoteServer ftpData;
        private Data.RemoteServerRcon rconData;

        public ConnectRemoteServer()
        {
            InitializeComponent();
            label5.Text = Language.GetString("Name");
            label4.Text = Language.GetString("Engine");
            label3.Text = Language.GetString("Version");
            label1.Text = Language.GetString("IpAdress");
            label2.Text = Language.GetString("DataFtp");
            label6.Text = Language.GetString("Port");
            label7.Text = Language.GetString("User");
            label8.Text = Language.GetString("Password");
            label11.Text = Language.GetString("DataRcon");
            label12.Text = Language.GetString("Port");
            label9.Text = Language.GetString("Password");
            readyButton.Text = Language.GetString("Ready");
            versionSelect.Items.AddRange(Main.EngineVersions);
            versionSelect.Items.Add(Language.GetString("OtherFemale"));
            engineSelect.Items.Add(Language.GetString("OtherMale"));
        }

        public new void Load(Tabs _tabs)
        {
            tabs = _tabs;
            tabs.AddTab(Language.GetString("ConnectRemoteServer"), this);
        }

        public void SetStyle(Data.Style style)
        {
            Colors.StyleButton(readyButton, style);
            Colors.StyleTextBox(serverName, style);
            Colors.StyleTextBox(serverIP, style);
            Colors.StyleTextBox(ftpPassword, style);
            Colors.StyleTextBox(ftpPort, style);
            Colors.StyleTextBox(ftpUser, style);
            Colors.StyleTextBox(rconPassword, style);
            Colors.StyleTextBox(rconPort, style);
        }

        private void readyButton_Click(object sender, EventArgs e)
        {
            int ftpPortNumber, rconPortNumber;
            if (serverName.Text == "")
                Error.Show("ErrorNoServerName");
            else if (engineSelect.SelectedItem == null)
                Error.Show("ErrorNoEngine");
            else if (versionSelect.SelectedItem == null)
                Error.Show("ErrorNoVersion");
            else if (serverIP.Text == "")          
                Error.Show("ErrorNoServerIp");            
            else if (ftpUser.Text == "" || ftpPassword.Text == "" || ftpPort.Text == "")
                Error.Show("ErrorNoFtpData");            
            else if (rconPassword.Text == "" || rconPort.Text == "")            
                Error.Show("ErrorNoRconData");           
            else if (!int.TryParse(ftpPort.Text, out ftpPortNumber))           
                Error.Show("ErrorNanPortFtp");           
            else if (ftpPortNumber < 0 || ftpPortNumber > 65535)           
                Error.Show("ErrorOorPortFtp");          
            else if (!int.TryParse(rconPort.Text, out rconPortNumber))          
                Error.Show("ErrorNanPortRcon");           
            else if (rconPortNumber < 0 || rconPortNumber > 65535)           
                Error.Show("ErrorOorPortRcon");          
            else {
                ftpData = new Data.RemoteServer();
                ftpData.adress = "ftp://" + serverIP.Text + ":" + ftpPort.Text + "/";
                ftpData.login = ftpUser.Text;
                ftpData.password = ftpPassword.Text;
                ftpData.name = serverName.Text;
                ftpData.engine = engineSelect.SelectedItem.ToString();
                ftpData.version = versionSelect.SelectedItem.ToString();

                rconData = new Data.RemoteServerRcon();
                rconData.adress = serverIP.Text;
                rconData.name = serverName.Text;
                rconData.port = rconPortNumber;
                rconData.password = rconPassword.Text;

                Enabled = false;
                worker.RunWorkerAsync();
            }
            
        }

        private void ConnectRemoteServer_Resize(object sender, EventArgs e)
        {
            serverIP.Size = new Size(Width - 91, 27);
            serverName.Size = new Size(Width - 91, 27);
            versionSelect.Size = new Size(Width - 91, 27);
            engineSelect.Size = new Size(Width - 91, 27);
            ftpPort.Size = new Size(Width - 91, 27);
            ftpPassword.Size = new Size(Width - 91, 27);
            ftpUser.Size = new Size(Width - 91, 27);
            rconPassword.Size = new Size(Width - 91, 27);
            rconPort.Size = new Size(Width - 91, 27);
            readyButton.Size = new Size(Width, 30);
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            error = "";
            
            try
            {
                Ftp.directoryListSimple(ftpData, "");
            }
            catch (WebException)
            {
                error = "ErrorFtp";
                return;
            }

            RconClient rcon = RconClient.INSTANCE;
            rcon.setupStream(rconData.adress, rconData.port, rconData.password);
            if (!rcon.isInit)
            {
                error = "ErrorRcon";
                return;
            }

            ftpData.Save();
            rconData.Save();
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (error == "")
                tabs.mainWindow.serversTree.FullRefresh();
            else
            {
                Enabled = true;
                Error.Show(error);
            }
        }
    }
}
