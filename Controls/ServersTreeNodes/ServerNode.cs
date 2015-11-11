using System.Collections.Generic;
using System.IO;

namespace MinecraftServerManager.Controls.ServersTreeNodes
{
    public class ServerNode : DirectoryNode
    {
        private Data.Server serverData;
        private DirectoryInfo directory;

        public Data.Server GetServerData()
        {
            return serverData;
        }

        public ServerNode(ServersTreeView treeView, DirectoryInfo directoryInfo, Data.Server _serverData)
            : base(treeView, directoryInfo, _serverData.ToString())
        {
            IgnoredFiles.Add("ServerManagerData.xml");
            IgnoredFiles.Add("eula.txt");
            IgnoredFiles.Add("server.jar");
            serverData = _serverData;
            directory = directoryInfo;
            ImageIndex = ServersTreeView.LocalServerIcon;
            SelectedImageIndex = ImageIndex;
        }

    }

}
