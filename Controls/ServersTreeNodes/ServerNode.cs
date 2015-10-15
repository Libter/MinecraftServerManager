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
            this.serverData = _serverData;
            this.directory = directoryInfo;
            this.ImageIndex = ServersTreeView.LocalServerIcon;
            this.SelectedImageIndex = this.ImageIndex;
        }

        public override void Refresh()
        {
            List<string> newNames = new List<string>();
            foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
                newNames.Add(directoryInfo.FullName);
            foreach (FileInfo fileInfo in directory.GetFiles())
            {
                if (fileInfo.Name == "eula.txt" || fileInfo.Name == "ServerManagerData.xml" || fileInfo.Name == "server.jar")
                    continue;
                newNames.Add(fileInfo.FullName);
            }
            bool equals = true;
            if (newNames.Count != names.Count)
                equals = false;
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
            if (this.Nodes.Count == 1 && this.Nodes[0] is FakeChildNode)
                equals = false;
            if (!equals)
            {
                this.names.Clear();
                this.Nodes.Clear();
                new ConsoleNode(this);
                //new PropertiesNode(this);
                foreach (DirectoryInfo directoryInfo in directory.GetDirectories())
                {
                    new DirectoryNode(this, directoryInfo);
                    this.names.Add(directoryInfo.FullName);
                }
                foreach (FileInfo fileInfo in directory.GetFiles())
                {
                    if (fileInfo.Name == "eula.txt" || fileInfo.Name == "ServerManagerData.xml" || fileInfo.Name == "server.jar")
                        continue;
                    new FileNode(this, fileInfo);
                    this.names.Add(fileInfo.FullName);
                }
            }
        }

    }

}
