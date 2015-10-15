using System;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Windows.Forms;

using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Dialogs
{
    public partial class FtpDownloader : Form
    {
        private Data.RemoteServer data;
        private string localFile, remoteFile;
        private readonly int bufferSize = 2048;
        private long fileSize;
        private FileStream localFileStream;
        private Stream ftpStream;
        private FtpWebResponse ftpResponse;
        private FtpWebRequest ftpRequest;
        private bool cancel;

        private class WorkerState
        {
            public long totalBytes, readBytes;

            public WorkerState(long _totalBytes, long _readBytes)
            {
                this.totalBytes = _totalBytes;
                this.readBytes = _readBytes;
            }
        }

        public FtpDownloader()
        {
            InitializeComponent();
            this.status.Text = Language.GetString("DownloadBegin");
            this.Text = Language.GetString("Upload");
        }

        public void Download(Data.RemoteServer _data, string _localFile, string _remoteFile)
        {

            this.data = _data;
            this.remoteFile = _remoteFile;
            this.localFile = _localFile;
            string[] files = Utils.Ftp.directoryListDetailed(data, remoteFile.Substring(0, remoteFile.LastIndexOf("/")) + "/");
            foreach(string elem in files) 
            {
                string[] splitted = elem.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                if (splitted.Length >= 9)
                {
                    string name = "";
                    for (int i = 8; i < splitted.Length; i++)
                    {
                        name += splitted[i] + " ";
                    }
                    name = Utils.Strings.CutLastChars(name, 1);
                    if (name == Path.GetFileName(remoteFile))
                        this.fileSize = long.Parse(splitted[4]); 
                }
            }
            if (this.fileSize > 65536)
            {
                worker.RunWorkerAsync();
                this.ShowDialog();
            }
            else
            {
                worker_DoWork(null, null);
            }
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            /* Create an FTP Request */
            ftpRequest = (FtpWebRequest)FtpWebRequest.Create(data.adress + "/" + remoteFile);
            /* Log in to the FTP Server with the User Name and Password Provided */
            ftpRequest.Credentials = new NetworkCredential(data.login, data.password);
            /* When in doubt, use these options */
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;
            /* Specify the Type of FTP Request */
            ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
            /* Establish Return Communication with the FTP Server */
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
            /* Get the FTP Server's Response Stream */
            ftpStream = ftpResponse.GetResponseStream();
            /* Open a File Stream to Write the Downloaded File */
            Directory.CreateDirectory(Path.GetDirectoryName(localFile));
            localFileStream = new FileStream(localFile, FileMode.Create);
            /* Buffer for the Downloaded Data */
            byte[] byteBuffer = new byte[bufferSize];
            int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
            int totalBytesRead = bytesRead;
            /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
            while (bytesRead > 0)
            {
                if (cancel)
                {
                    localFileStream.Close();
                    ftpRequest.Abort();
                    ftpStream.Close();
                    ftpResponse.Close();
                    ftpRequest = null;
                    ftpResponse = null;
                    ftpStream = null;
                    localFileStream = null;
                    e.Cancel = true;
                    return;
                }
                localFileStream.Write(byteBuffer, 0, bytesRead);
                bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
                totalBytesRead += bytesRead;
                double progress = totalBytesRead * 100.0 / fileSize;
                WorkerState state = new WorkerState(fileSize, totalBytesRead);
                worker.ReportProgress((int)progress, state);
            }

            /* Resource Cleanup */
            localFileStream.Close();
            ftpStream.Close();
            ftpResponse.Close();
            ftpRequest = null;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WorkerState state = (WorkerState)e.UserState;
            this.progress.Value = e.ProgressPercentage;
            string megaBytesReceived = (state.readBytes / (1024.0 * 1024.0)).ToString("0.00") + "MB";
            string megaBytesTotal = (state.totalBytes / (1024.0 * 1024.0)).ToString("0.00") + "MB";
            this.status.Text = Language.GetString("DownloadProgress") + " \"" + Path.GetFileName(remoteFile) + "\": " + megaBytesReceived + " / " + megaBytesTotal;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void FtpDownloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancel = true;
        }


    }
}
