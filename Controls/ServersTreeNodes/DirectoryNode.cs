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
        private DirectoryInfo Directory;
        protected List<string> names = new List<string>();
        protected Timer timer = new Timer();

        public DirectoryNode(DirectoryNode parent, DirectoryInfo directoryInfo)
            : base(directoryInfo.Name)
        {
            Directory = directoryInfo;

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
            Directory = directoryInfo;

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
                    if (Directory.Exists)
                        new Computer().FileSystem.DeleteDirectory(Directory.FullName, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                    if (this is ServerNode && ((ServerNode)this).GetServerData().isImported)
                        File.Delete(((ServerNode)this).GetServerData().GetFile());
                    Destroy();
                }
                catch (OperationCanceledException) { }
                return;
            }
            List<string> newNames = new List<string>();
            foreach (DirectoryInfo directoryInfo in Directory.GetDirectories())
                newNames.Add(directoryInfo.FullName);
            foreach (FileInfo fileInfo in Directory.GetFiles())
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
                names.Clear();
                Nodes.Clear();
                foreach (DirectoryInfo directoryInfo in Directory.GetDirectories())
                {
                    new DirectoryNode(this, directoryInfo);
                    names.Add(directoryInfo.FullName);
                }
                foreach (FileInfo fileInfo in Directory.GetFiles())
                {
                    new FileNode(this, fileInfo);
                    names.Add(fileInfo.FullName);
                }
            }
        }

        private void Virtualize()
        {
            int fileCount = 0;

            fileCount = Directory.GetFiles().Length;
            if ((fileCount + Directory.GetDirectories().Length) > 0)
                new FakeChildNode(this);
        }

        public DirectoryInfo GetDirectory()
        {
            return Directory;
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
