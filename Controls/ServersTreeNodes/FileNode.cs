using System;
using System.Windows.Forms;
using System.IO;

namespace MinecraftServerManager.Controls.ServersTreeNodes
{
    public class FileNode : TreeNode
    {
        private FileInfo file;
        private DirectoryNode directoryNode;

        public FileInfo GetFile()
        {
            return file;
        }

        public FileNode(DirectoryNode _directoryNode, FileInfo fileInfo)
            : base(fileInfo.Name)
        {
            this.directoryNode = _directoryNode;
            this.file = fileInfo;

            directoryNode.Nodes.Add(this);

            try
            {
                this.ImageIndex = ((ServersTreeView)this.TreeView).GetLocalFileIconImageIndex(file.FullName);
                this.SelectedImageIndex = this.ImageIndex;
            }
            catch (Exception) { }
        }
    }
}
