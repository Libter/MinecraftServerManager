using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Windows.Forms;

using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Dialogs
{
    public partial class FtpUploader : Form
    {
        private Data.RemoteServer data;
        private string localFile, remoteFile;
        private readonly int bufferSize = 2048;
        private long fileSize;

        private class WorkerState
        {
            public long totalBytes, readBytes;

            public WorkerState(long _totalBytes, long _readBytes)
            {
                this.totalBytes = _totalBytes;
                this.readBytes = _readBytes;
            }
        }

        public FtpUploader()
        {
            InitializeComponent();
            status.Text = Language.GetString("UploadBegin");
            this.Text = Language.GetString("Upload");
        }

        public void Upload(Data.RemoteServer _data, string _localFile, string _remoteFile)
        {
            this.data = _data;
            this.remoteFile = _remoteFile;
            this.localFile = _localFile;
            this.fileSize = new FileInfo(localFile).Length;
            if (this.fileSize > 8192)
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
            FtpWebRequest ftpRequest = (FtpWebRequest)FtpWebRequest.Create(data.adress + "/" + remoteFile);
            /* Log in to the FTP Server with the User Name and Password Provided */
            ftpRequest.Credentials = new NetworkCredential(data.login, data.password);
            /* When in doubt, use these options */
            ftpRequest.UseBinary = true;
            ftpRequest.UsePassive = true;
            ftpRequest.KeepAlive = true;
            /* Specify the Type of FTP Request */
            ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
            /* Establish Return Communication with the FTP Server */
            Stream ftpStream = ftpRequest.GetRequestStream();
            /* Open a File Stream to Read the File for Upload */
            FileStream localFileStream = new FileStream(localFile, FileMode.Open);
            /* Buffer for the Downloaded Data */
            byte[] byteBuffer = new byte[bufferSize];
            int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
            int totalBytesSent = bytesSent;
            /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
            while (bytesSent != 0)
            {
                ftpStream.Write(byteBuffer, 0, bytesSent);
                bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
                totalBytesSent += bytesSent;
                double progress = totalBytesSent * 100.0 / fileSize;
                WorkerState state = new WorkerState(fileSize, totalBytesSent);
                worker.ReportProgress((int)progress, state);
            }

            /* Resource Cleanup */
            localFileStream.Close();
            ftpStream.Close();
            ftpRequest = null;
        }

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            WorkerState state = (WorkerState)e.UserState;
            this.progress.Value = e.ProgressPercentage;
            string megaBytesReceived = (state.readBytes / (1024.0 * 1024.0)).ToString("0.00") + "MB";
            string megaBytesTotal = (state.totalBytes / (1024.0 * 1024.0)).ToString("0.00") + "MB";
            this.status.Text = Language.GetString("UploadProgress") + " \"" + Path.GetFileName(remoteFile) + "\": " + megaBytesReceived + " / " + megaBytesTotal;
        }

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }

        
    }
}
