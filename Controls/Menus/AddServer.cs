using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls.Menus
{
    public class AddServer : UserControl
    {
        private Button connectLocalServer;
        private Button connectRemoteServer;
        private Button createLocalServer;

        private ServersTreeView Tree;
        private Tabs tabs;

        public AddServer()
        {
            InitializeComponent();
            createLocalServer.Text = "     " + Utils.Language.GetString("MenuAddServerLocal");
            connectLocalServer.Text = "     " + Utils.Language.GetString("MenuConnectServerLocal");
            connectRemoteServer.Text = "     " + Utils.Language.GetString("MenuConnectServerRemote");

            using (Graphics g = CreateGraphics())
            {
                List<int> widthList = new List<int>();
                widthList.Add(g.MeasureString(createLocalServer.Text, createLocalServer.Font).ToSize().Width);
                widthList.Add(g.MeasureString(connectLocalServer.Text, connectLocalServer.Font).ToSize().Width);
                widthList.Add(g.MeasureString(connectRemoteServer.Text, connectRemoteServer.Font).ToSize().Width);

                int width = Utils.Numbers.Max(widthList) + Utils.Numbers.MenuPadding;
                Width = width + 2;
                createLocalServer.Width = width;
                connectLocalServer.Width = width;
                connectRemoteServer.Width = width;
            }
        }

        public new void Load(ServersTreeView tree, Tabs _tabs)
        {
            this.Tree = tree;
            this.tabs = _tabs;
        }

        private void InitializeComponent()
        {
            this.connectRemoteServer = new MinecraftServerManager.Controls.Button();
            this.connectLocalServer = new MinecraftServerManager.Controls.Button();
            this.createLocalServer = new MinecraftServerManager.Controls.Button();
            this.SuspendLayout();
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
            this.connectRemoteServer.Size = new System.Drawing.Size(228, 30);
            this.connectRemoteServer.TabIndex = 0;
            this.connectRemoteServer.TabStop = false;
            this.connectRemoteServer.Text = "     CONNECT REMOTE SERVER";
            this.connectRemoteServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.connectRemoteServer.UseVisualStyleBackColor = false;
            this.connectRemoteServer.Click += new System.EventHandler(this.connectRemoteServer_Click);
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
            // createLocalServer
            // 
            this.createLocalServer.BackColor = System.Drawing.Color.White;
            this.createLocalServer.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.createLocalServer.FlatAppearance.BorderSize = 0;
            this.createLocalServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createLocalServer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.createLocalServer.Image = global::MinecraftServerManager.Properties.Resources.MenuCreateLocalServer;
            this.createLocalServer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createLocalServer.Location = new System.Drawing.Point(1, 1);
            this.createLocalServer.Name = "createLocalServer";
            this.createLocalServer.Size = new System.Drawing.Size(228, 30);
            this.createLocalServer.TabIndex = 0;
            this.createLocalServer.TabStop = false;
            this.createLocalServer.Text = "     CREATE LOCAL SERVER";
            this.createLocalServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createLocalServer.UseVisualStyleBackColor = false;
            this.createLocalServer.Click += new System.EventHandler(this.newLocalServer_Click);
            // 
            // AddServer
            // 
            this.Controls.Add(this.connectRemoteServer);
            this.Controls.Add(this.connectLocalServer);
            this.Controls.Add(this.createLocalServer);
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
            this.createLocalServer.BackColor = style.ControlBackColor;
            this.createLocalServer.Image = Utils.Icons.AddColor(Properties.Resources.MenuCreateLocalServer, style.ForeColor);
            this.connectLocalServer.BackColor = style.ControlBackColor;
            this.connectLocalServer.Image = Utils.Icons.AddColor(Properties.Resources.MenuConnectLocalServer, style.ForeColor);
            this.connectRemoteServer.BackColor = style.ControlBackColor;
            this.connectRemoteServer.Image = Utils.Icons.AddColor(Properties.Resources.MenuConnectRemoteServer, style.ForeColor);
        }
    }
}
