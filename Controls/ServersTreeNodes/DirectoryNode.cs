using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;

namespace MinecraftServerManager.Controls.ServersTreeNodes
{
    public class DirectoryNode : TreeNode
    {
        public bool Delete = false;
        private DirectoryInfo directory;
        protected List<string> IgnoredFiles = new List<string>();
        protected List<string> names = new List<string>();
        protected Timer timer = new Timer();

        public DirectoryNode(DirectoryNode parent, DirectoryInfo directoryInfo)
            : base(directoryInfo.Name)
        {
            directory = directoryInfo;

            ImageIndex = ServersTreeView.FolderCloseIcon;
            SelectedImageIndex = ImageIndex;

            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = 100;
            timer.Start();

            parent.Nodes.Add(this);

            Virtualize();
        }

        public DirectoryNode(ServersTreeView treeView, DirectoryInfo directoryInfo, string name)
            : base(name)
        {
            directory = directoryInfo;

            timer.Tick += new EventHandler(timer_tick);
            timer.Interval = 100;
            timer.Start();

            treeView.Nodes.Add(this);

            Virtualize();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            try
            {
                 if (IsExpanded || Delete)
                    Refresh();
            }
            catch (Exception) { }
        }

        public virtual void Refresh()
        {
            if (Delete)
            {
                try
                {
                    if (directory.Exists)
                        new Computer().FileSystem.DeleteDirectory(directory.FullName, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                    if (this is ServerNode && ((ServerNode)this).GetServerData().isImported)
                        File.Delete(((ServerNode)this).GetServerData().GetFile());
                    Destroy();
                }
                catch (OperationCanceledException) { }
                return;
            }

            List<string> newNames = new List<string>();
            foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
                newNames.Add(directoryInfo.FullName);
            foreach (FileInfo fileInfo in directory.GetFiles())
            {
                if (IgnoredFiles.Contains(fileInfo.Name)) continue;
                newNames.Add(fileInfo.FullName);
            }

            bool equals = true;
            if (newNames.Count != names.Count)
                equals = false;
            else
                for (int i = 0; i < newNames.Count; i++)
                    if (newNames[i] != names[i])
                    {
                        equals = false;
                        break;
                    }

            if (!equals)
            {
                names = newNames;
                Nodes.Clear();

                if (this is ServerNode) new ConsoleNode((ServerNode)this);

                foreach (string path in names)
                {
                    if (Directory.Exists(path))
                        new DirectoryNode(this, new DirectoryInfo(path));
                    if (File.Exists(path))
                        new FileNode(this, new FileInfo(path));
                }
            }
        }

        private void Virtualize()
        {
            int fileCount = 0;

            fileCount = directory.GetFiles().Length;
            if ((fileCount + directory.GetDirectories().Length) > 0)
                new FakeChildNode(this);
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
            Remove();
            timer.Stop();
        }
    }
}
