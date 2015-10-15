using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace MinecraftServerManager.Controls.ServersTreeNodes
{
    public class RemoteServerNode : RemoteDirectoryNode
    {
        private Data.RemoteServer ServerData;

        public Data.RemoteServer GetServerData()
        {
            return ServerData;
        }

        public RemoteServerNode(ServersTreeView treeView, Data.RemoteServer _serverData)
            : base(treeView, "/", _serverData, _serverData.ToString())
        {
            this.ServerData = _serverData;
            this.ImageIndex = ServersTreeView.RemoteServerIcon;
            this.SelectedImageIndex = this.ImageIndex;
        }
    }

}
