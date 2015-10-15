using System.Windows.Forms;

namespace MinecraftServerManager.Controls.ServersTreeNodes
{
    public class FakeChildNode : TreeNode
    {
        public FakeChildNode(TreeNode parent)
            : base()
        {
            parent.Nodes.Add(this);
        }
    }
}
