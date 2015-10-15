using System;
using System.Windows.Forms;
using System.IO;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Controls.ServersTreeNodes
{
    public class RemoteFileNode : TreeNode
    {
        private string file;
        private RemoteDirectoryNode directoryNode;
        public Data.RemoteServer data {get; private set;}

        public string GetFile()
        {
            return file;
        }

        public RemoteFileNode(RemoteDirectoryNode _directoryNode, string _file, Data.RemoteServer _data)
        {
            this.directoryNode = _directoryNode;
            this.file = _file;
            this.data = _data;

            directoryNode.Nodes.Add(this);

            int last = file.LastIndexOf('/');
            if (last != -1)
                this.Text = file.Substring(file.LastIndexOf("/") + 1);
            else
                this.Text = file;

            try
            {
                this.ImageIndex = ((ServersTreeView)this.TreeView).GetRemoteFileIconImageIndex(file);
                this.SelectedImageIndex = this.ImageIndex;
            }
            catch (Exception) { }
        }
    }
}
