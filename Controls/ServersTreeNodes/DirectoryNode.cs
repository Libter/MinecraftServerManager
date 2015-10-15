using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace MinecraftServerManager.Controls.ServersTreeNodes
{
    public class DirectoryNode : TreeNode
    {
        private DirectoryInfo directory;
        protected List<string> names = new List<string>();
        protected Timer timer = new Timer();

        public DirectoryNode(DirectoryNode parent, DirectoryInfo directoryInfo)
            : base(directoryInfo.Name)
        {
            this.directory = directoryInfo;

            this.ImageIndex = ServersTreeView.FolderCloseIcon;
            this.SelectedImageIndex = this.ImageIndex;

            this.timer.Tick += new EventHandler(timer_tick);
            this.timer.Interval = 100;
            this.timer.Start();

            parent.Nodes.Add(this);

            Virtualize();
        }

        public DirectoryNode(ServersTreeView treeView, DirectoryInfo directoryInfo, string name)
            : base(name)
        {
            this.directory = directoryInfo;

            this.timer.Tick += new EventHandler(timer_tick);
            this.timer.Interval = 100;
            this.timer.Start();

            treeView.Nodes.Add(this);

            Virtualize();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            try
            {
                if (this.IsExpanded)
                    Refresh();
            }
            catch (Exception) { }
        }

        public virtual void Refresh()
        {
            List<string> newNames = new List<string>();
            foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
                newNames.Add(directoryInfo.FullName);
            foreach (FileInfo fileInfo in directory.GetFiles())
                newNames.Add(fileInfo.FullName);
            bool equals = true;
            if (newNames.Count != names.Count)
            {
                equals = false;
            }
            else
            {
                for (int i = 0; i < newNames.Count; i++)
                {
                    if (newNames[i] != names[i])
                    {
                        equals = false;
                        break;
                    }
                }
            }
            if (!equals)
            {
                this.names.Clear();
                this.Nodes.Clear();
                foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
                {
                    new DirectoryNode(this, directoryInfo);
                    this.names.Add(directoryInfo.FullName);
                }
                foreach (FileInfo fileInfo in directory.GetFiles())
                {
                    new FileNode(this, fileInfo);
                    this.names.Add(fileInfo.FullName);
                }
            }
        }

        private void Virtualize()
        {
            int fileCount = 0;

            try
            {
                fileCount = this.directory.GetFiles().Length;

                if ((fileCount + this.directory.GetDirectories().Length) > 0)
                    new FakeChildNode(this);
            }
            catch
            {
            }
        }

        public DirectoryInfo GetDirectory()
        {
            return directory;
        }

        public new ServersTreeView TreeView
        {
            get { return (ServersTreeView)base.TreeView; }
        }

        public void Destroy()
        {
            this.Remove();
            this.timer.Stop();
        }
    }
}
