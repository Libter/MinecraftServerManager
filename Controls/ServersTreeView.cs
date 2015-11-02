using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Windows.Forms;
using System.Collections;
using System.Drawing;
using System.Diagnostics;
using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.FileIO;
using MinecraftServerManager.Utils;
using MinecraftServerManager.Dialogs;
using MinecraftServerManager.Controls.ServersTreeNodes;

namespace MinecraftServerManager.Controls
{
    public class ServersTreeView : TreeView
    {
        private ImageList _imageList = new ImageList();
        private List<Image> _imageListCopy = new List<Image>();
        private Hashtable _systemIcons = new Hashtable();
        private Tabs tabs;
        private string OldLabelEditName;
        private LabelEditAction EditAction;
        private TreeNode DragNode;

        private ContextMenuStrip
            serverContextMenu, directoryContextMenu, fileContextMenu, openContextMenu,
            remoteServerContextMenu, remoteDirectoryContextMenu, remoteFileContextMenu;

        public static readonly int
            FolderOpenIcon = 0, FolderCloseIcon = 1, LocalServerIcon = 2,
            RemoteServerIcon = 3, ConsoleIcon = 4, PropertiesIcon = 5;

        private enum LabelEditAction { None, Rename, NewFile, NewDirectory };

        #region Main

        public ServersTreeView()
        {
            ImageList = _imageList;
            ImageList.ColorDepth = ColorDepth.Depth32Bit;
            MouseDown += new MouseEventHandler(ServersTreeView_MouseDown);
            BeforeExpand += new TreeViewCancelEventHandler(ServersTreeView_BeforeExpand);
            BeforeCollapse += new TreeViewCancelEventHandler(ServersTreeView_BeforeCollapse);
            DoubleClick += new EventHandler(openMenu_Click);
            BeforeLabelEdit += new NodeLabelEditEventHandler(ServersTreeView_BeforeLabelEdit);
            AfterLabelEdit += new NodeLabelEditEventHandler(ServersTreeView_AfterLabelEdit);
            ItemDrag += new ItemDragEventHandler(ServersTreeView_ItemDrag);
            DragOver += new DragEventHandler(ServersTreeView_DragOver);
            DragDrop += new DragEventHandler(ServersTreeView_DragDrop);
            
            LabelEdit = true;
            AllowDrop = true;

            ItemHeight = ItemHeight + 2;

            InitializeComponent();
        }

        public void Load(Tabs _tabs)
        {
            tabs = _tabs;
            FullRefresh();
        }

        public void FullRefresh()
        {
            _systemIcons.Clear();
            _imageList.Images.Clear();
            Nodes.Clear();

            _imageList.Images.Add(Properties.Resources.FolderOpenIcon);
            _systemIcons.Add(FolderOpenIcon, 0);
            _imageList.Images.Add(Properties.Resources.FolderCloseIcon);
            _systemIcons.Add(FolderCloseIcon, 0);
            _imageList.Images.Add(Properties.Resources.LocalIcon);
            _systemIcons.Add(LocalServerIcon, 0);
            _imageList.Images.Add(Properties.Resources.RemoteIcon);
            _systemIcons.Add(RemoteServerIcon, 0);
            _imageList.Images.Add(Properties.Resources.ConsoleIcon);
            _systemIcons.Add(ConsoleIcon, 0);
            _imageList.Images.Add(Properties.Resources.MenuSettings);

            foreach (string server in Directory.GetDirectories(Utils.Main.ServersDirectory))
            {
                if (File.Exists(server + Path.DirectorySeparatorChar + "ServerCreatorData.xml")) //old file name
                {
                    File.Move(server + Path.DirectorySeparatorChar + "ServerCreatorData.xml", server + Path.DirectorySeparatorChar + "ServerManagerData.xml");
                }
                if (File.Exists(server + Path.DirectorySeparatorChar + "ServerManagerData.xml"))
                {
                    Data.Server serverData = Data.Server.Deserialize(server + Path.DirectorySeparatorChar + "ServerManagerData.xml");

                    ServerNode node = new ServerNode(this, new DirectoryInfo(server), serverData);

                    node.Expand();
                }
            }
            foreach (string importedServer in Directory.GetFiles(Main.ImportDirectory))
            {
                Data.Server serverData = Data.Server.Deserialize(importedServer);
                if (Directory.Exists(serverData.path) && File.Exists(serverData.jarPath))
                {
                    ServerNode node = new ServerNode(this, new DirectoryInfo(serverData.path), serverData);
                    node.Expand();
                }
            }

            foreach (string remoteServer in Directory.GetDirectories(Utils.Main.RemoteDirectory))
            {
                if (File.Exists(remoteServer + Path.DirectorySeparatorChar + "MainData.xml"))
                {
                    Data.RemoteServer serverData = Data.RemoteServer.Deserialize(remoteServer + Path.DirectorySeparatorChar + "MainData.xml");

                    RemoteServerNode node = new RemoteServerNode(this, serverData);
                }
            }
        }

        public Tabs GetTabs()
        {
            return tabs;
        }

        private void ServersTreeView_MouseDown(object sender, MouseEventArgs e)
        {
            TreeNode node = GetNodeAt(e.X, e.Y);
            SelectedNode = node;

            if (e.Button == MouseButtons.Right)
            {
                if (SelectedNode is ServerNode)
                {
                    serverContextMenu.Show(this, e.X, e.Y);
                }
                else if (SelectedNode is DirectoryNode)
                {
                    directoryContextMenu.Show(this, e.X, e.Y);
                }
                else if (SelectedNode is FileNode)
                {
                    fileContextMenu.Show(this, e.X, e.Y);
                }
                else if (SelectedNode is RemoteServerNode)
                {
                    remoteServerContextMenu.Show(this, e.X, e.Y);
                }
                else if (SelectedNode is RemoteDirectoryNode)
                {
                    remoteDirectoryContextMenu.Show(this, e.X, e.Y);
                }
                else if (SelectedNode is RemoteFileNode)
                {
                    remoteFileContextMenu.Show(this, e.X, e.Y);
                }
                else if (SelectedNode is ConsoleNode || SelectedNode is RemoteConsoleNode)
                {
                    openContextMenu.Show(this, e.X, e.Y);
                } else if (SelectedNode is PropertiesNode)
                {
                    openContextMenu.Show(this, e.X, e.Y);
                }
            }
        }

        private void ServersTreeView_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is ServerNode)
            {
                ((ServerNode)e.Node).Refresh();
            }
            else if (e.Node is RemoteServerNode)
            {
                ((RemoteServerNode)e.Node).Refresh();
            }
            else if (e.Node is RemoteDirectoryNode)
            {
                ((RemoteDirectoryNode)e.Node).Refresh();
                e.Node.ImageIndex = FolderOpenIcon;
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
            else if (e.Node is DirectoryNode)
            {
                ((DirectoryNode)e.Node).Refresh();
                e.Node.ImageIndex = FolderOpenIcon;
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void ServersTreeView_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node is ServerNode)
            { 
            }
            else if (e.Node is RemoteServerNode)
            {
            }
            else if (e.Node is RemoteDirectoryNode)
            {
                e.Node.ImageIndex = FolderCloseIcon;
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
            else if (e.Node is DirectoryNode)
            {
                e.Node.ImageIndex = FolderCloseIcon;
                e.Node.SelectedImageIndex = e.Node.ImageIndex;
            }
        }

        private void ServersTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (EditAction == LabelEditAction.None)
                e.CancelEdit = true;
        }

        private void ServersTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            LabelEditAction EditAction = this.EditAction;
            EditAction = LabelEditAction.None;
            if (e.Label == null || e.Label == "")
            {
                if (EditAction == LabelEditAction.Rename)
                {
                    if (OldLabelEditName != null)
                        e.Node.Text = OldLabelEditName;
                }
                else if (EditAction == LabelEditAction.NewFile || EditAction == LabelEditAction.NewDirectory)
                {
                    e.Node.Remove();
                }
                e.CancelEdit = true;
                return;
            }

            if (EditAction == LabelEditAction.Rename)
            {
                #region ActionRename
                if (e.Node is FileNode)
                {
                    FileNode node = (FileNode) e.Node;
                    FileInfo file = node.GetFile();
                    string path = file.DirectoryName + Path.DirectorySeparatorChar + e.Label;

                    if (File.Exists(path))
                    {
                        Error.Show("ErrorFileExists");
                        e.CancelEdit = true; return;
                    }
                    try { file.MoveTo(path);}
                    catch (IOException)
                    {
                        Error.Show("ErrorFileInvalidName");
                        e.CancelEdit = true; return;
                    }
                }

                else if(e.Node is ServerNode)
                {
                    ServerNode node = (ServerNode) e.Node;
                    DirectoryInfo directory = node.GetDirectory();
                    string path = directory.Parent.FullName + Path.DirectorySeparatorChar + e.Label;

                    if (Directory.Exists(path))
                    {
                        Error.Show("ErrorServerExists");
                    }
                    else
                    {
                        try
                        {
                            directory.MoveTo(path);
                            node.GetServerData().name = e.Label;
                            node.GetServerData().Save();
                        }
                        catch (IOException)
                        {
                            Error.Show("ErrorServerInvalidName");
                        }
                    }
                    node.Text = node.GetServerData().ToString();
                    e.CancelEdit = true;
                }

                else if(e.Node is DirectoryNode)
                {
                    DirectoryNode node = (DirectoryNode) e.Node;
                    DirectoryInfo directory = node.GetDirectory();
                    string path = directory.Parent.FullName + Path.DirectorySeparatorChar + e.Label;

                    if (Directory.Exists(path))
                    {
                        Error.Show("ErrorDirectoryExists");
                        e.CancelEdit = true; return;
                    }
                    try
                    {
                        directory.MoveTo(path);
                    }
                    catch (IOException)
                    {
                        Error.Show("ErrorDirectoryInvalidName");
                        e.CancelEdit = true; return;
                    }
                }

                else if(e.Node is RemoteServerNode)
                {
                    RemoteServerNode node = (RemoteServerNode) e.Node;
                    Data.RemoteServer data = new Data.RemoteServer();
                    data.name = e.Label;
                    if (!Directory.Exists(data.GetDirectory()))
                    {
                        Directory.Move(node.GetServerData().GetDirectory(), data.GetDirectory());
                        node.GetServerData().name = e.Label;
                        node.GetServerData().Save();
                    }
                    node.Text = node.GetServerData().ToString();
                    e.CancelEdit = true;
                }

                else if(e.Node is RemoteDirectoryNode)
                {
                    RemoteDirectoryNode node = (RemoteDirectoryNode) e.Node;
                    Ftp.rename(node.data, node.directory, e.Label);
                    ((RemoteDirectoryNode)e.Node.Parent).Refresh();
                    e.CancelEdit = true;
                }

                else if (e.Node is RemoteFileNode)
                {
                    RemoteFileNode node = (RemoteFileNode) e.Node;
                    Ftp.rename(node.data, node.GetFile(), e.Label);
                    ((RemoteDirectoryNode)e.Node.Parent).Refresh();
                    e.CancelEdit = true;
                }
                #endregion
            }

            else if (EditAction == LabelEditAction.NewFile)
            {
                #region ActionNewFile
                if (e.Node.Parent is DirectoryNode)
                {
                    DirectoryNode node = (DirectoryNode) e.Node.Parent;
                    string path = node.GetDirectory().FullName + Path.DirectorySeparatorChar + e.Label;
                    if (File.Exists(path))
                    {
                        Error.Show("ErrorFileExists");
                    }
                    else
                    {
                        try
                        {
                            File.Create(path).Close();
                        }
                        catch (IOException)
                        {
                            Error.Show("ErrorFileInvalidName");
                        }
                    }
                    e.Node.Remove();
                }
                else if (e.Node.Parent is RemoteDirectoryNode)
                {
                    RemoteDirectoryNode node = (RemoteDirectoryNode) e.Node.Parent;
                    File.Create(Main.TempDirectory + e.Label).Close();
                    Ftp.upload(node.data, node.directory + e.Label, Main.TempDirectory + e.Label);
                    e.Node.Remove();
                    node.Refresh();
                }
                #endregion;
            }

            else if (EditAction == LabelEditAction.NewDirectory)
            {
                #region ActionNewDirectory
                if (e.Node.Parent is DirectoryNode)
                {
                    DirectoryNode node = (DirectoryNode) e.Node.Parent;
                    string path = node.GetDirectory().FullName + Path.DirectorySeparatorChar + e.Label;
                    if (Directory.Exists(path))
                    {
                        Error.Show("ErrorDirectoryExists");
                    }
                    else
                    {
                        try
                        {
                            Directory.CreateDirectory(path);
                        }
                        catch (IOException)
                        {
                            Error.Show("ErrorDirectoryInvalidName");
                        }
                    }
                    e.Node.Remove();
                }
                else if (e.Node.Parent is RemoteDirectoryNode)
                {
                    RemoteDirectoryNode node = (RemoteDirectoryNode) e.Node.Parent;
                    Ftp.createDirectory(node.data, node.directory + e.Label);
                    e.Node.Remove();
                    node.Refresh();
                }
                #endregion
            }
        }

        private void ServersTreeView_ItemDrag(object sender, ItemDragEventArgs e)
        {
            TreeNode node = (TreeNode)e.Item;

            if (node is FileNode || node is DirectoryNode || node is RemoteFileNode)
            {
                SelectedNode = node;
                DragNode = node;
                DoDragDrop(e.Item, DragDropEffects.Move);
            }
        }

        private void ServersTreeView_DragOver(object sender, DragEventArgs e)
        {
            Point point = PointToClient(new Point(e.X, e.Y));
            TreeNode node = GetNodeAt(point);

            if ((node is DirectoryNode || node is RemoteDirectoryNode) && DragNode.Parent != node)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ServersTreeView_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Effect != DragDropEffects.Move)
                return;

            Point point = PointToClient(new Point(e.X, e.Y));
            TreeNode node = GetNodeAt(point);

            if (node is DirectoryNode)
            {
                DirectoryInfo directory = ((DirectoryNode)node).GetDirectory();
                if (DragNode is FileNode)
                {
                    FileInfo file = ((FileNode)DragNode).GetFile();
                    file.MoveTo(directory.FullName + Path.DirectorySeparatorChar + file.Name);
                }
                else if (DragNode is DirectoryNode)
                {
                    DirectoryNode movedDirectoryNode = ((DirectoryNode)DragNode);
                    DirectoryInfo movedDirectory = movedDirectoryNode.GetDirectory();
                    movedDirectory.MoveTo(directory.FullName + Path.DirectorySeparatorChar + movedDirectory.Name);
                }
            }
            else if (node is RemoteDirectoryNode)
            {
                RemoteDirectoryNode remoteDirectoryNode = ((RemoteDirectoryNode)node);
                string directory = remoteDirectoryNode.directory;
                if (DragNode is RemoteFileNode)
                {
                    string file = ((RemoteFileNode)DragNode).GetFile();
                    Ftp.move(remoteDirectoryNode.data, file, directory + Path.GetFileName(file));
                    DragNode.Remove();
                    remoteDirectoryNode.Refresh();
                }
            }
        }

        public int GetLocalFileIconImageIndex(string path)
        {
            string extension = Path.GetExtension(path);

            if (_systemIcons.ContainsKey(extension) == false)
            {
                if (Main.IsLinux)
                    _imageList.Images.Add(Icon.ExtractAssociatedIcon(path));
                else
                    _imageList.Images.Add(Icons.GetSmallFileIcon(path));
                _systemIcons.Add(extension, _imageList.Images.Count - 1);
            }

            return (int)_systemIcons[Path.GetExtension(path)];
        }

        public int GetRemoteFileIconImageIndex(string path)
        {
            string extension = Path.GetExtension(path);

            if (_systemIcons.ContainsKey(extension) == false)
            {
                path = Utils.Main.TempDirectory + "get_icon" + extension;
                File.Create(path).Close();
                _imageList.Images.Add(Utils.Icons.GetSmallFileIcon(path));
                _systemIcons.Add(extension, _imageList.Images.Count - 1);
            }

            return (int)_systemIcons[Path.GetExtension(path)];
        }

        private void InitializeComponent()
        {
            serverContextMenu = new ContextMenuStrip();
            directoryContextMenu = new ContextMenuStrip();
            remoteServerContextMenu = new ContextMenuStrip();
            remoteDirectoryContextMenu = new ContextMenuStrip();
            remoteFileContextMenu = new ContextMenuStrip();
            fileContextMenu = new ContextMenuStrip();
            openContextMenu = new ContextMenuStrip();
            SuspendLayout();

            serverContextMenu.Items.Add(CreateRenameMenuItem());
            serverContextMenu.Items.Add(CreateRemoveMenuItem());
            serverContextMenu.Items.Add(CreateCopyClipboardMenuItem());
            serverContextMenu.Items.Add(CreatePasteClipboardMenuItem());
            serverContextMenu.Items.Add(CreateNewFileMenuItem());
            serverContextMenu.Items.Add(CreateNewDirectoryMenuItem());
            serverContextMenu.Items.Add(CreateCopyFileMenuItem());
            serverContextMenu.Items.Add(CreateCopyDirectoryMenuItem());
            serverContextMenu.Items.Add(CreateMoveFileMenuItem());
            serverContextMenu.Items.Add(CreateMoveDirectoryMenuItem());
            serverContextMenu.Items.Add(CreateExploreMenuItem());

            directoryContextMenu.Items.Add(CreateRenameMenuItem());
            directoryContextMenu.Items.Add(CreateRemoveMenuItem());
            directoryContextMenu.Items.Add(CreateCopyClipboardMenuItem());
            directoryContextMenu.Items.Add(CreatePasteClipboardMenuItem());
            directoryContextMenu.Items.Add(CreateNewFileMenuItem());
            directoryContextMenu.Items.Add(CreateNewDirectoryMenuItem());
            directoryContextMenu.Items.Add(CreateCopyFileMenuItem());
            directoryContextMenu.Items.Add(CreateCopyDirectoryMenuItem());
            directoryContextMenu.Items.Add(CreateMoveFileMenuItem());
            directoryContextMenu.Items.Add(CreateMoveDirectoryMenuItem());
            directoryContextMenu.Items.Add(CreateExploreMenuItem());

            remoteServerContextMenu.Items.Add(CreateRenameMenuItem());
            remoteServerContextMenu.Items.Add(CreateRemoveMenuItem());
            remoteServerContextMenu.Items.Add(CreateNewFileMenuItem());
            remoteServerContextMenu.Items.Add(CreateNewDirectoryMenuItem());
            remoteServerContextMenu.Items.Add(CreateCopyFileMenuItem());
            remoteServerContextMenu.Items.Add(CreateCopyDirectoryMenuItem());

            remoteDirectoryContextMenu.Items.Add(CreateRenameMenuItem());
            remoteDirectoryContextMenu.Items.Add(CreateRemoveMenuItem());
            remoteDirectoryContextMenu.Items.Add(CreateNewFileMenuItem());
            remoteDirectoryContextMenu.Items.Add(CreateNewDirectoryMenuItem());
            remoteDirectoryContextMenu.Items.Add(CreateCopyFileMenuItem());
            remoteDirectoryContextMenu.Items.Add(CreateCopyDirectoryMenuItem());

            remoteFileContextMenu.Items.Add(CreateOpenMenuItem());
            remoteFileContextMenu.Items.Add(CreateRenameMenuItem());
            remoteFileContextMenu.Items.Add(CreateRemoveMenuItem());

            openContextMenu.Items.Add(CreateOpenMenuItem());

            fileContextMenu.Items.Add(CreateOpenMenuItem());
            fileContextMenu.Items.Add(CreateRenameMenuItem());
            fileContextMenu.Items.Add(CreateRemoveMenuItem());
            fileContextMenu.Items.Add(CreateCopyClipboardMenuItem());

            ResumeLayout(false);
        }

        public void SetStyle(Data.Style style)
        {
            BackColor = style.ControlBackColor;
            ForeColor = style.ForeColor;

            _imageList.Images[0] = Icons.AddColor(Properties.Resources.FolderOpenIcon, ForeColor);
            _imageList.Images[1] = Icons.AddColor(Properties.Resources.FolderCloseIcon, ForeColor);
            _imageList.Images[2] = Icons.AddColor(Properties.Resources.LocalIcon, ForeColor);
            _imageList.Images[3] = Icons.AddColor(Properties.Resources.RemoteIcon, ForeColor);
            _imageList.Images[4] = Icons.AddColor(Properties.Resources.ConsoleIcon, ForeColor);
        }

        #endregion

        #region MenuEvents

        private void uploadDirectory(Data.RemoteServer data, string localDirectory, string remoteDirectory)
        {
            foreach (string directory in Directory.GetDirectories(localDirectory))
            {
                string dirname = remoteDirectory + "/" + Path.GetFileName(directory) + "/";
                Ftp.createDirectory(data, dirname);
                uploadDirectory(data, directory, dirname);
            }
            foreach (string file in Directory.GetFiles(localDirectory))
            {
                new FtpUploader().Upload(data, file, remoteDirectory + "/" + Path.GetFileName(file));
            }
        }

        private void newFileMenu_Click(object sender, EventArgs e)
        {
            EditAction = LabelEditAction.NewFile;
            SelectedNode.Expand();
            TreeNode newNode = SelectedNode.Nodes.Add("");

            string emptyFilePath = Main.TempDirectory + "empty_file";
            File.Create(emptyFilePath).Close();
            newNode.ImageIndex = GetLocalFileIconImageIndex(emptyFilePath);

            newNode.BeginEdit();
        }

        private void newDirectoryMenu_Click(object sender, EventArgs e)
        {
            EditAction = LabelEditAction.NewDirectory;
            SelectedNode.Expand();
            TreeNode newNode = SelectedNode.Nodes.Add("");
            newNode.ImageIndex = FolderCloseIcon;

            newNode.BeginEdit();
        }

        private void removeMenu_Click(object sender, EventArgs e)
        {
            if (SelectedNode is FileNode)
            {
                FileNode node = (FileNode)SelectedNode;
                FileInfo file = node.GetFile();
                DialogResult result = MessageBox.Show(
                    String.Format(Language.GetString("DialogFileRemove"), file.Name),
                    Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    file.Delete();
                    node.Remove();
                }
            }
            else if (SelectedNode is DirectoryNode)
            {
                DirectoryNode node = (DirectoryNode)SelectedNode;
                DirectoryInfo directory = node.GetDirectory();
                string message;
                if (SelectedNode is ServerNode)
                    message = String.Format(Language.GetString("DialogDirectoryRemove"), directory.Name);
                else
                    message = String.Format(Language.GetString("DialogServerRemove"), directory.Name);
                DialogResult result = MessageBox.Show(message, Language.GetString("Warning"), 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    node.Delete = true;
                }
            }
            else if (SelectedNode is RemoteServerNode)
            {
                RemoteServerNode node = (RemoteServerNode)SelectedNode;
                DialogResult result = MessageBox.Show(
                String.Format(Language.GetString("DialogRemoteServerRemove"), node.GetServerData().name),
                    Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.Yes)
                {
                    Directory.Delete(Main.RemoteDirectory + node.GetServerData().name, true);
                    node.Destroy();
                }
            }
            else if (SelectedNode is RemoteDirectoryNode)
            {
                RemoteDirectoryNode node = (RemoteDirectoryNode)SelectedNode;
                DialogResult dr = MessageBox.Show(
                   String.Format(Language.GetString("DialogDirectoryRemove"), node.Text),
                   Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dr == DialogResult.Yes)
                {
                    Ftp.deleteDirectory(node.data, node.directory);
                    node.Destroy();
                }
            }
            else if (SelectedNode is RemoteFileNode)
            {
                RemoteFileNode node = (RemoteFileNode)SelectedNode;
                DialogResult dr = MessageBox.Show(
                   String.Format(Language.GetString("DialogFileRemove"), node.Text),
                   Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                if (dr == DialogResult.Yes)
                {
                    Ftp.deleteFile(node.data, node.GetFile());
                    node.Remove();
                }
            }
        }

        private void exploreMenu_Click(object sender, EventArgs e)
        {
            if (SelectedNode != null)
            {
                if (SelectedNode is DirectoryNode)
                {
                    DirectoryNode node = (DirectoryNode)SelectedNode;
                    Process.Start("explorer.exe", node.GetDirectory().FullName);
                }
            }
        }

        private void renameMenu_Click(object sender, EventArgs e)
        {
            OldLabelEditName = null;

            if (SelectedNode is ServerNode)
            {
                ServerNode node = (ServerNode) SelectedNode;
                OldLabelEditName = node.Text;
                node.Text = node.GetServerData().name;
            }
            else if (SelectedNode is RemoteServerNode)
            {
                RemoteServerNode node = (RemoteServerNode) SelectedNode;
                OldLabelEditName = node.Text;
                node.Text = node.GetServerData().name;
            }

            EditAction = LabelEditAction.Rename;
            SelectedNode.BeginEdit();
            SelectedNode = null;
        }

        private void openMenu_Click(object sender, EventArgs e)
        {
            if (SelectedNode is FileNode)
            {
                FileNode i = (FileNode)SelectedNode;
                FileEditor te = new FileEditor();
                te.Load(i.GetFile(), tabs);
            }
            else if (SelectedNode is RemoteFileNode)
            {
                RemoteFileNode i = (RemoteFileNode)SelectedNode;
                FileEditor te = new FileEditor();
                te.Load(i, tabs);
            }
            else if (SelectedNode is ConsoleNode)
            {
                ConsoleNode node = (ConsoleNode)SelectedNode;
                Console console = new Console();
                console.Load(node.Parent.GetServerData(), tabs);
            }
            else if (SelectedNode is RemoteConsoleNode)
            {
                RemoteConsoleNode node = (RemoteConsoleNode)SelectedNode;
                RemoteConsole console = new RemoteConsole();
                console.Load(node.Parent.data, node.Parent.GetServerData().name, tabs);
            } else if (SelectedNode is PropertiesNode)
            {
                PropertiesNode node = (PropertiesNode)SelectedNode;
                PropertiesEditor editor = new PropertiesEditor();
                editor.Load(tabs);
            }
        }

        private void moveFileMenu_Click(object sender, EventArgs e)
        {
            if (SelectedNode is DirectoryNode)
            {
                DirectoryNode node = (DirectoryNode)SelectedNode;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string[] fileNames = openFile.FileNames;
                    for (int j = 0; j < fileNames.Length; j++)
                    {
                        string filename = fileNames[j];
                        string newName = node.GetDirectory().FullName + Path.DirectorySeparatorChar + Path.GetFileName(filename);
                        if (File.Exists(newName))
                        {
                            Error.Show("ErrorFileExists");
                            return;
                        }
                        File.Move(filename, newName);
                    }
                }
            }
        }

        private void copyFileMenu_Click(object sender, EventArgs e)
        {
            if (SelectedNode is DirectoryNode)
            {
                DirectoryNode node = (DirectoryNode)SelectedNode;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string[] fileNames = openFile.FileNames;
                    for (int j = 0; j < fileNames.Length; j++)
                    {
                        string filename = fileNames[j];
                        string newName = node.GetDirectory().FullName + Path.DirectorySeparatorChar + Path.GetFileName(filename);
                        if (File.Exists(newName))
                        {
                            Error.Show("ErrorFileExists");
                            return;
                        }
                        try
                        {
                            new Computer().FileSystem.CopyFile(filename, newName, UIOption.AllDialogs);
                        }
                        catch (OperationCanceledException) { }
                        node.Refresh();
                    }
                }
            }
            else if (SelectedNode is RemoteDirectoryNode)
            {
                RemoteDirectoryNode node = (RemoteDirectoryNode)SelectedNode;
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Multiselect = true;
                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string[] fileNames = openFile.FileNames;
                    for (int j = 0; j < fileNames.Length; j++)
                    {
                        string filename = fileNames[j];
                        string newName = node.directory + Path.GetFileName(filename);
                        new Dialogs.FtpUploader().Upload(node.data, filename, newName);
                        node.Refresh();
                    }
                }
            }
        }

        private void copyClipboardMenu_Click(object sender, EventArgs e)
        {
            if (SelectedNode is DirectoryNode)
            {
                DirectoryNode node = (DirectoryNode)SelectedNode;
                StringCollection path = new StringCollection();
                path.Add(node.GetDirectory().FullName);
                Clipboard.SetFileDropList(path);
            }
            else if (SelectedNode is FileNode)
            {
                FileNode node = (FileNode)SelectedNode;
                StringCollection path = new StringCollection();
                path.Add(node.GetFile().FullName);
                Clipboard.SetFileDropList(path);
            }
        }

        private void pasteClipboardMenu_Click(object sender, EventArgs e)
        {
            if (SelectedNode is DirectoryNode)
            {
                DirectoryNode node = (DirectoryNode)SelectedNode;
                StringCollection paths = Clipboard.GetFileDropList();
                foreach (string path in paths)
                {
                    if (Directory.Exists(path))
                    {
                        string newName = node.GetDirectory().FullName + Path.DirectorySeparatorChar + Path.GetFileName(path);
                        try
                        {
                            new Computer().FileSystem.CopyDirectory(path, newName, UIOption.AllDialogs);
                        }
                        catch (InvalidOperationException)
                        {
                            Error.Show("ErrorOperationUnknown");
                        }
                        catch (OperationCanceledException) { }
                    }
                    if (File.Exists(path))
                    {
                        string newName = node.GetDirectory().FullName + Path.DirectorySeparatorChar + Path.GetFileName(path);
                        try
                        {
                            new Computer().FileSystem.CopyFile(path, newName, UIOption.AllDialogs);
                        }
                        catch (OperationCanceledException) { }
                    }
                }
            }
        }

        private void copyDirectoryMenu_Click(object sender, EventArgs e)
        {
            if (SelectedNode is DirectoryNode)
            {
                DirectoryNode node = (DirectoryNode)SelectedNode;
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string newName = node.GetDirectory().FullName + Path.DirectorySeparatorChar + Path.GetFileName(fbd.SelectedPath);
                    if (Directory.Exists(newName))
                    {
                        Error.Show("ErrorDirectoryExists");
                        return;
                    }
                    try
                    {
                        new Computer().FileSystem.CopyDirectory(fbd.SelectedPath, newName, UIOption.AllDialogs);
                    }
                    catch (OperationCanceledException) { }
                }
            } 
            else if (SelectedNode is RemoteDirectoryNode) 
            {
                RemoteDirectoryNode node = (RemoteDirectoryNode)SelectedNode;
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string remoteName = node.directory + Path.GetFileName(fbd.SelectedPath);
                    Utils.Ftp.createDirectory(node.data, remoteName);
                    uploadDirectory(node.data, fbd.SelectedPath, remoteName);
                }
                node.Refresh();
            }
        }

        private void moveDirectoryMenu_Click(object sender, EventArgs e)
        {
            if (SelectedNode is DirectoryNode)
            {
                DirectoryNode node = (DirectoryNode)SelectedNode;
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    string newName = node.GetDirectory().FullName + Path.DirectorySeparatorChar + Path.GetFileName(fbd.SelectedPath);
                    if (Directory.Exists(newName))
                    {
                        Error.Show("ErrorDirectoryExists");
                        return;
                    }
                    Directory.Move(fbd.SelectedPath, newName);
                }
            }
        }

        #endregion

        #region MenuFactory
        private ToolStripMenuItem CreateRemoveMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("Delete");
            menuItem.Click += new EventHandler(removeMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateExploreMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("ExplorerOpen");
            menuItem.Click += new EventHandler(exploreMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateRenameMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("Rename");
            menuItem.Click += new EventHandler(renameMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateOpenMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("Open");
            menuItem.Click += new EventHandler(openMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateNewFileMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("NewFile");
            menuItem.Click += new EventHandler(newFileMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateNewDirectoryMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("NewDirectory");
            menuItem.Click += new EventHandler(newDirectoryMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateCopyFileMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("CopyFile");
            menuItem.Click += new EventHandler(copyFileMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateMoveFileMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("MoveFile");
            menuItem.Click += new EventHandler(moveFileMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateCopyDirectoryMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("CopyDirectory");
            menuItem.Click += new EventHandler(copyDirectoryMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateMoveDirectoryMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("MoveDirectory");
            menuItem.Click += new EventHandler(moveDirectoryMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreateCopyClipboardMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("CopyClipboard");
            menuItem.Click += new EventHandler(copyClipboardMenu_Click);
            return menuItem;
        }

        private ToolStripMenuItem CreatePasteClipboardMenuItem()
        {
            ToolStripMenuItem menuItem = new ToolStripMenuItem();
            menuItem.Text = Language.GetString("PasteClipboard");
            menuItem.Click += new EventHandler(pasteClipboardMenu_Click);
            return menuItem;
        }

        #endregion
    }
}
