using System;
using System.Windows.Forms;
using MinecraftServerManager.Utils;

namespace MinecraftServerManager.Controls.Menus
{
    public class AddServer : UserControl
    {
        private Button connectLocalServer;
        private Button connectRemoteServer;
        private Button newLocalServer;

        private ServersTreeView Tree;
        private Tabs tabs;

        public AddServer()
        {
            InitializeComponent();
            newLocalServer.Text = "     " + Utils.Language.GetString("MenuAddServerLocal");
            connectLocalServer.Text = "     " + Utils.Language.GetString("MenuConnectServerLocal");
            connectRemoteServer.Text = "     " + Utils.Language.GetString("MenuConnectServerRemote");
        }

        public new void Load(ServersTreeView tree, Tabs _tabs)
        {
            this.Tree = tree;
            this.tabs = _tabs;
        }

        private void InitializeComponent()
        {
            this.newLocalServer = new Button();
            this.connectLocalServer = new Button();
            this.connectRemoteServer = new Button();
            this.SuspendLayout();
            // 
            // newLocalServer
            // 
            this.newLocalServer.BackColor = System.Drawing.Color.White;
            this.newLocalServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.newLocalServer.FlatAppearance.BorderSize = 0;
            this.newLocalServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newLocalServer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newLocalServer.Image = global::MinecraftServerManager.Properties.Resources.MenuCreateLocalServer;
            this.newLocalServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newLocalServer.Location = new System.Drawing.Point(1, 1);
            this.newLocalServer.Name = "newLocalServer";
            this.newLocalServer.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.newLocalServer.Size = new System.Drawing.Size(228, 30);
            this.newLocalServer.TabIndex = 0;
            this.newLocalServer.TabStop = false;
            this.newLocalServer.Text = "     CREATE LOCAL SERVER";
            this.newLocalServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newLocalServer.UseVisualStyleBackColor = false;
            this.newLocalServer.Click += new System.EventHandler(this.newLocalServer_Click);
            // 
            // connectLocalServer
            // 
            this.connectLocalServer.BackColor = System.Drawing.Color.White;
            this.connectLocalServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.connectLocalServer.FlatAppearance.BorderSize = 0;
            this.connectLocalServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectLocalServer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectLocalServer.Image = global::MinecraftServerManager.Properties.Resources.MenuConnectLocalServer;
            this.connectLocalServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectLocalServer.Location = new System.Drawing.Point(1, 31);
            this.connectLocalServer.Name = "connectLocalServer";
            this.connectLocalServer.Size = new System.Drawing.Size(228, 30);
            this.connectLocalServer.TabIndex = 0;
            this.connectLocalServer.TabStop = false;
            this.connectLocalServer.Text = "     CONNECT LOCAL SERVER";
            this.connectLocalServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectLocalServer.UseVisualStyleBackColor = false;
            this.connectLocalServer.Click += new System.EventHandler(this.connectLocalServer_Click);
            // 
            // connectRemoteServer
            // 
            this.connectRemoteServer.BackColor = System.Drawing.Color.White;
            this.connectRemoteServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.connectRemoteServer.FlatAppearance.BorderSize = 0;
            this.connectRemoteServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.connectRemoteServer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.connectRemoteServer.Image = global::MinecraftServerManager.Properties.Resources.MenuConnectRemoteServer;
            this.connectRemoteServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectRemoteServer.Location = new System.Drawing.Point(1, 61);
            this.connectRemoteServer.Name = "connectRemoteServer";
            this.connectRemoteServer.Padding = new System.Windows.Forms.Padding(0, 0, 9, 0);
            this.connectRemoteServer.Size = new System.Drawing.Size(228, 30);
            this.connectRemoteServer.TabIndex = 0;
            this.connectRemoteServer.TabStop = false;
            this.connectRemoteServer.Text = "     CONNECT REMOTE SERVER";
            this.connectRemoteServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectRemoteServer.UseVisualStyleBackColor = false;
            this.connectRemoteServer.Click += new System.EventHandler(this.connectRemoteServer_Click);
            // 
            // AddServer
            // 
            this.Controls.Add(this.connectRemoteServer);
            this.Controls.Add(this.connectLocalServer);
            this.Controls.Add(this.newLocalServer);
            this.Name = "AddServer";
            this.Size = new System.Drawing.Size(230, 92);
            this.ResumeLayout(false);

        }

        private void newLocalServer_Click(object sender, EventArgs e)
        {
            NewLocalServer nsl = new NewLocalServer();
            nsl.Load(tabs);
        }

        private void connectLocalServer_Click(object sender, EventArgs e)
        {
            ConnectLocalServer cls = new ConnectLocalServer();
            cls.Load(tabs);
        }

        private void connectRemoteServer_Click(object sender, EventArgs e)
        {
            ConnectRemoteServer crs = new ConnectRemoteServer();
            crs.Load(tabs);
        }

        public void SetStyle(Data.Style style)
        {
            this.BackColor = style.WindowBackColor;
            this.newLocalServer.BackColor = style.ControlBackColor;
            this.newLocalServer.Image = Utils.Icons.AddColor(Properties.Resources.MenuCreateLocalServer, style.ForeColor);
            this.connectLocalServer.BackColor = style.ControlBackColor;
            this.connectLocalServer.Image = Utils.Icons.AddColor(Properties.Resources.MenuConnectLocalServer, style.ForeColor);
            this.connectRemoteServer.BackColor = style.ControlBackColor;
            this.connectRemoteServer.Image = Utils.Icons.AddColor(Properties.Resources.MenuConnectRemoteServer, style.ForeColor);
        }
    }
}
