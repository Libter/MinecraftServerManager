using System;
using System.Windows.Forms;
using System.Collections.Generic;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Controls.ServersTreeNodes
{
    public class RemoteDirectoryNode : TreeNode
    {
        public string directory { get; private set; }
        public Data.RemoteServer data {get; private set;}
        private List<string> names = new List<string>();
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private List<string> dirs = new List<string>();

        public RemoteDirectoryNode(RemoteDirectoryNode parent, string _directory, Data.RemoteServer _data)
        {
            this.data = _data;
            this.directory = _directory;

            this.ImageIndex = ServersTreeView.FolderCloseIcon;
            this.SelectedImageIndex = this.ImageIndex;

            this.timer.Tick += new EventHandler(timer_tick);
            this.timer.Interval = 100;
            this.timer.Start();

            int last = directory.LastIndexOf('/');
            string name = directory.Substring(0, directory.Length - 1);
            if (last != -1)
                this.Text = name.Substring(name.LastIndexOf("/") + 1);
            else
                this.Text = directory;

            parent.Nodes.Add(this);

            Virtualize();
        }

        public RemoteDirectoryNode(ServersTreeView treeView, string _directory, Data.RemoteServer _data, string name)
            : base(name)
        {
            this.data = _data;
            this.directory = _directory;

            this.timer.Tick += new EventHandler(timer_tick);
            this.timer.Interval = 100;
            this.timer.Start();

            treeView.Nodes.Add(this);

            Virtualize();
        }

        private void timer_tick(object sender, EventArgs e)
        {
        }

        public virtual void Refresh()
        {
            string[] listed = Ftp.directoryListDetailed(data, directory);
            List<string> dirs = new List<string>();
            List<string> files = new List<string>();
            this.Nodes.Clear();
            foreach (string elem in listed)
            {
                string[] splitted = elem.Split(new string[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                if (splitted.Length >= 9 && splitted[0].IndexOf("d") > -1)
                {
                    if (splitted.Length >= 10 && splitted[9] == "->")
                        continue;
                    string name = "";
                    for (int i = 8; i < splitted.Length; i++)
                    {
                        name += splitted[i] + " ";
                    }
                    name = Strings.CutLastChars(name, 1);
                    if (name != ".." && name != ".")
                        dirs.Add(directory + name + "/");
                }
                else if (splitted.Length >= 9)
                {
                    if (splitted.Length >= 10 && splitted[9] == "->")
                        continue;
                    string name = "";
                    for (int i = 8; i < splitted.Length; i++)
                    {
                        name += splitted[i] + " ";
                    }
                    
                    name = Strings.CutLastChars(name, 1);
                    files.Add(directory + name);
                }
            }
            dirs.Sort();
            files.Sort();
            if (this is RemoteServerNode)
               new RemoteConsoleNode((RemoteServerNode) this);
            foreach (string dir in dirs)
            {
                new RemoteDirectoryNode(this, dir, data);
            }
            foreach (string file in files)
            {
                new RemoteFileNode(this, file, data);
            }
        }

        private void Virtualize()
        {
            new FakeChildNode(this);
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
