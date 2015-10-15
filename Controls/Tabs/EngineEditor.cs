using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Controls
{
    public partial class EngineEditor : UserControl, IStyleableTab
    {
        public EngineEditor()
        {
            InitializeComponent();
            this.label1.Text = Language.GetString("EngineEditorHeader");
            this.saveButton.Text = Language.GetString("PerformButton");
        }

        private WebClient Client;
        private List<DownloadUnit> DownloadQueue = new List<DownloadUnit>();
        private int DownloadIndex = 0;
        private bool IgnoreAfterCheck = false;

        private class DownloadUnit
        {
            public DownloadUnit(string url, string file, string readable, int version, int engine) 
            {
                this.VersionIndex = version;
                this.EngineIndex = engine;
                this.Url = new Uri(url);
                this.File = file;
                this.Readable = readable;
            }

            public Uri Url;
            public int VersionIndex;
            public int EngineIndex;
            public string File;
            public string Readable;
        }

        private class DeleteUnit
        {
            public DeleteUnit(string file, int version, int engine) 
            {
                this.VersionIndex = version;
                this.EngineIndex = engine;
                this.File = file;
            }

            public int VersionIndex;
            public int EngineIndex;
            public string File;
        }

        private void EngineEditor_Resize(object sender, EventArgs e)
        {
            this.engineTree.Size = new Size(this.Width, this.Height - 50);
            this.saveButton.Location = new Point(0, this.Height - 30);
            this.saveButton.Size = new Size(this.Width, 30);
        }

        public new void Load(Tabs tabs)
        {
            foreach (Tab t in tabs.tabs)
            {
                if (t.control is EngineEditor)
                {
                    tabs.SelectTab(t);
                    return;
                }
            }
            this.FullRefresh();
            tabs.AddTab(Language.GetString("EngineEditorName"), this);
        }

        private void FullRefresh()
        {
            this.engineTree.Nodes.Clear();
            this.engineTree.Nodes.Add("Spigot");
            this.engineTree.Nodes.Add("PaperSpigot");
            this.engineTree.Nodes.Add("CraftBukkit");
            this.engineTree.Nodes.Add("Vanilla");
            Directory.CreateDirectory(Utils.Main.EnginesDirectory + "Spigot");
            Directory.CreateDirectory(Utils.Main.EnginesDirectory + "PaperSpigot");
            Directory.CreateDirectory(Utils.Main.EnginesDirectory + "CraftBukkit");
            Directory.CreateDirectory(Utils.Main.EnginesDirectory + "Vanilla");
            foreach (TreeNode tn in this.engineTree.Nodes)
            {
                bool allChecked = true;
                foreach (string version in Utils.Main.EngineVersions)
                {
                    TreeNode ntn = new TreeNode();
                    if (File.Exists(Utils.Main.EnginesDirectory + tn.Text + Path.DirectorySeparatorChar + version + ".jar"))
                    {
                        ntn.Text = version + " (" + Language.GetString("Downloaded") + ")";
                        ntn.Checked = true;
                    }
                    else
                    {
                        ntn.Text = version + " (" + Language.GetString("NotDownloaded") + ")";
                        allChecked = false;
                    }
                    ntn.Tag = version;
                    tn.Nodes.Add(ntn);
                }
                if (allChecked)
                    tn.Checked = true;
            }
        }

        public void SetStyle(Data.Style style)
        {
            this.saveButton.SetStyle(style);
            this.engineTree.BackColor = style.ControlBackColor;
            this.engineTree.ForeColor = style.ForeColor;
        }

        private void Download()
        {
            if (DownloadIndex == DownloadQueue.Count)
            {
                saveButton.Enabled = true;
                saveButton.Progress = 0;
                saveButton.Text = Language.GetString("PerformButton");
                DownloadQueue.Clear();
                return;
            }
            DownloadUnit du = DownloadQueue[DownloadIndex];
            Client = new WebClient();
            Client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            Client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadProgressCompleted);
            Client.DownloadFileAsync(du.Url, du.File);
        }

        private void engineTree_BeforeCheck(object sender, TreeViewCancelEventArgs e)
        {
            if (Client != null && Client.IsBusy)
                e.Cancel = true;
        }

        private void engineTree_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (IgnoreAfterCheck)
                return;
            foreach (TreeNode tn in e.Node.Nodes)
            {
                IgnoreAfterCheck = true;
                tn.Checked = e.Node.Checked;
                IgnoreAfterCheck = false;
            }
            if (e.Node.Nodes.Count == 0)
            {
                bool allChecked = true;
                foreach (TreeNode ctn in e.Node.Parent.Nodes)
                    if (!ctn.Checked)
                        allChecked = false;
                IgnoreAfterCheck = true;
                e.Node.Parent.Checked = allChecked;
                IgnoreAfterCheck = false;
            }
        }

        private void engineTree_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TreeViewHitTestInfo hit = this.engineTree.HitTest(e.X, e.Y);
            hit.Node.Checked = !(hit.Node.Checked);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            List<DeleteUnit> DeleteQueue = new List<DeleteUnit>();
            foreach (TreeNode engineNode in this.engineTree.Nodes)
            {
                foreach (TreeNode versionNode in engineNode.Nodes)
                {
                    string engine = engineNode.Text;
                    string version = (string) versionNode.Tag;
                    string file = Utils.Main.EnginesDirectory + engine + Path.DirectorySeparatorChar + version + ".jar";
                    string url = "http://mcservermanager.tk/info/servers/" + engine.ToLower() + "-" + version + ".jar";
                    if (engine == "Vanilla")
                        url = "https://s3.amazonaws.com/Minecraft.Download/versions/" + version + "/minecraft_server." + version + ".jar";
                    if (versionNode.Checked && !File.Exists(file))
                        DownloadQueue.Add(new DownloadUnit(url, file, engine + " " + version, versionNode.Index, engineNode.Index));
                    if (!versionNode.Checked && File.Exists(file))
                        DeleteQueue.Add(new DeleteUnit(file, versionNode.Index, engineNode.Index));
                }
            }
            DownloadIndex = 0;
            
            DialogResult dr = MessageBox.Show(String.Format(Language.GetString("EngineEditorPerform"), DownloadQueue.Count, DeleteQueue.Count),
                              Language.GetString("Information"), MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (dr == DialogResult.Yes)
            {
                saveButton.Enabled = false;
                foreach (DeleteUnit du in DeleteQueue)
                {
                    File.Delete(du.File);
                    TreeNode tn = this.engineTree.Nodes[du.EngineIndex].Nodes[du.VersionIndex];
                    tn.Text = tn.Text.Replace(Language.GetString("Downloaded"), Language.GetString("NotDownloaded"));
                }
                DeleteQueue.Clear();
                Download();
            }
            else
            {
                DeleteQueue.Clear();
                DownloadQueue.Clear();
            }
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            double bytesIn = double.Parse(e.BytesReceived.ToString());
            double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
            double percentage = bytesIn / totalBytes;
            string megaBytesReceived = (e.BytesReceived / (1024.0 * 1024.0)).ToString("0.00") + "MB";
            string megaBytesTotal = (e.TotalBytesToReceive / (1024.0 * 1024.0)).ToString("0.00") + "MB";
            saveButton.Text = Language.GetString("DownloadEngine") + " " + DownloadQueue[DownloadIndex].Readable + ": " + megaBytesReceived + " / " + megaBytesTotal;
            this.saveButton.Progress = (float)percentage;
        }

        private void DownloadProgressCompleted(object sender, AsyncCompletedEventArgs e)
        {
            DownloadUnit du = DownloadQueue[DownloadIndex];
            if (e.Cancelled)
            {
                if (File.Exists(du.File))
                    File.Delete(du.File);
                return;
            }
            TreeNode tn = this.engineTree.Nodes[du.EngineIndex].Nodes[du.VersionIndex];
            tn.Text = tn.Text.Replace(Language.GetString("NotDownloaded"), Language.GetString("Downloaded"));
            DownloadIndex++;
            Download();
        }

        public bool Close()
        {
            if (Client == null || Client.IsBusy == false)
                return true;
            DialogResult dr = MessageBox.Show(Language.GetString("EngineEditorAbort"), Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (dr == DialogResult.Yes)
            {
                Client.CancelAsync();
                return true;
            }
            return false;
        }
    }
}
