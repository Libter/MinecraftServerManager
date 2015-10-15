using System;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls.ServersTreeNodes
{
    public class ConsoleNode : TreeNode
    {
        public new ServerNode Parent { get; private set; }

        public ConsoleNode(ServerNode parent)
            : base(Utils.Language.GetString("Console"))
        {
            this.ImageIndex = ServersTreeView.ConsoleIcon;
            this.SelectedImageIndex = this.ImageIndex;
            this.Parent = parent;
            this.Parent.Nodes.Add(this);
        }
    }
}
