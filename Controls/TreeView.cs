using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls
{
    public class TreeView : System.Windows.Forms.TreeView
    {
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x203)
            {
                Point Hitpoint = new Point((int)(m.LParam));
                TreeViewHitTestInfo tvhti = HitTest(Hitpoint);
                if (tvhti != null && tvhti.Location == TreeViewHitTestLocations.StateImage)
                {
                    this.SelectedNode = tvhti.Node;
                    TreeNodeMouseClickEventArgs tvs = new TreeNodeMouseClickEventArgs(this.SelectedNode, MouseButtons.Left, 2, Hitpoint.X, Hitpoint.Y);
                    MouseEventArgs mvs = new MouseEventArgs(MouseButtons.Left, 2, Hitpoint.X, Hitpoint.Y, 0);
                    OnNodeMouseDoubleClick(tvs);
                    OnMouseDoubleClick(mvs);
                    OnDoubleClick(new EventArgs());
                    m.Result = IntPtr.Zero;
                    return;
                }
                else
                    base.WndProc(ref m);
            }
            else
                base.WndProc(ref m);
        }
    }
}
