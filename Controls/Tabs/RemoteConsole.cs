using System;
using System.Drawing;
using System.Text;
using System.Net;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Serialization;
using FastColoredTextBoxNS;
using MinecraftServerManager.Utils;
using MinecraftServerManager.Utils.MinecraftRcon;

namespace MinecraftServerManager.Controls
{
    public partial class RemoteConsole : UserControl, IStyleableTab
    {
        public string DataFileName;

        private Data.RemoteServer data;
        private RconClient rcon;
        private FtpWebResponse ftpResponse;
        private FtpWebRequest ftpRequest;
        private Stream stream;
        private Thread logThread;
        private int bytesRead = 2048, logLength = 0;

        public RemoteConsole()
        {
            InitializeComponent();
            this.Disposed += (object sender, EventArgs e) => {
                if (logThread != null && logThread.IsAlive)
                    logThread.Abort(); };
        }

        private void Console_Resize(object sender, EventArgs e)
        {
            text.Size = new Size(this.Width, this.Height - 20);

            consoleLabel.Location = new Point(0, this.Height - 20);
            consoleCommand.Location = new Point(20, this.Height - 20);
            consoleCommand.Size = new Size(this.Width - 20, 20);
        }

        private void LoadFromFile(string name, Tabs tabs)
        {
            Data.RemoteServerRcon serverData = new Data.RemoteServerRcon();
            XmlSerializer serializer = new XmlSerializer(typeof(Data.RemoteServerRcon));
            StreamReader reader = new StreamReader(Utils.Main.RemoteDirectory + name + Path.DirectorySeparatorChar + "RconData.xml");
            serverData = (Data.RemoteServerRcon)serializer.Deserialize(reader);
            reader.Close();
            rcon = RconClient.INSTANCE;
            rcon.setupStream(serverData.adress, serverData.port, serverData.password);
            text.Clear();
            text.TextChanged += new EventHandler<TextChangedEventArgs>(Parsers.Log.Parse);
            foreach (Tab t in tabs.tabs)
            {
                if (t.control is RemoteConsole)
                {
                    RemoteConsole c = (RemoteConsole) t.control;
                    if (c.data == data)
                    {
                        tabs.SelectTab(t);
                        return;
                    }
                }
            }
            tabs.AddTab(name, this);
            logThread = new Thread(new ThreadStart(logThreadWork));
            logThread.Start();
        }

        public new void Load(Data.RemoteServer _data, string name, Tabs tabs)
        {
            DataFileName = Utils.Main.RemoteDirectory + name + Path.DirectorySeparatorChar + "MainData.xml";
            this.data = _data;
            if (File.Exists(Utils.Main.RemoteDirectory + name + Path.DirectorySeparatorChar + "RconData.xml"))
            {
                LoadFromFile(name, tabs);
            }
        }

        private void consoleCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (consoleCommand.Text != "")
                {
                    text.AppendText("> " + consoleCommand.Text + "\n");
                    string answer = rcon.sendMessage(RconMessageType.Command, consoleCommand.Text);
                    if (answer != "")
                        text.AppendText(answer + "\n");
                    consoleCommand.Text = "";
                    text.Navigate(text.Lines.Count - 1);
                }
            }
        }

        private void logThreadWork()
        {
            while (true)
            {
                if (stream == null || !stream.CanRead)
                {
                    ftpRequest = (FtpWebRequest)FtpWebRequest.Create(data.adress + "/logs/latest.log");
                    ftpRequest.Credentials = new NetworkCredential(data.login, data.password);
                    ftpRequest.UseBinary = true;
                    ftpRequest.UsePassive = true;
                    ftpRequest.KeepAlive = true;
                    ftpRequest.ContentOffset = logLength;
                    ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    stream = ftpResponse.GetResponseStream();
                }
                byte[] buffer = new byte[2048];
                bytesRead = 2048;
                while (bytesRead == 2048)
                {
                    bytesRead = stream.Read(buffer, 0, 2048);
                    logLength += bytesRead;
                    if (bytesRead > 0) {
                        try
                        {
                            text.Invoke(new Action(() =>
                            {
                                text.AppendText(Encoding.UTF8.GetString(buffer, 0, bytesRead));
                                text.Navigate(text.Lines.Count - 1);
                            }));
                        }
                        catch (Exception) { }
                    }
                }
            }
        }

        public void SetStyle(Data.Style style)
        {
            Colors.StyleFastColoredTextBox(text, style);
            Colors.StyleTextBox(consoleCommand, style);
        }
    }
}
