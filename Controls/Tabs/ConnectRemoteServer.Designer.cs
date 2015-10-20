namespace MinecraftServerManager.Controls
{
    partial class ConnectRemoteServer
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.versionSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.engineSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.serverIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ftpPort = new System.Windows.Forms.TextBox();
            this.ftpUser = new System.Windows.Forms.TextBox();
            this.ftpPassword = new System.Windows.Forms.TextBox();
            this.rconPassword = new System.Windows.Forms.TextBox();
            this.rconPort = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.readyButton = new System.Windows.Forms.Button();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // versionSelect
            // 
            this.versionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionSelect.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.versionSelect.ForeColor = System.Drawing.SystemColors.WindowText;
            this.versionSelect.FormattingEnabled = true;
            this.versionSelect.Location = new System.Drawing.Point(91, 54);
            this.versionSelect.Name = "versionSelect";
            this.versionSelect.Size = new System.Drawing.Size(409, 27);
            this.versionSelect.TabIndex = 22;
            this.versionSelect.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 24;
            this.label3.Text = "Version:";
            // 
            // engineSelect
            // 
            this.engineSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.engineSelect.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.engineSelect.ForeColor = System.Drawing.SystemColors.WindowText;
            this.engineSelect.FormattingEnabled = true;
            this.engineSelect.Items.AddRange(new object[] {
            "Spigot",
            "PaperSpigot",
            "CraftBukkit",
            "Vanilla"});
            this.engineSelect.Location = new System.Drawing.Point(91, 27);
            this.engineSelect.Name = "engineSelect";
            this.engineSelect.Size = new System.Drawing.Size(409, 27);
            this.engineSelect.TabIndex = 21;
            this.engineSelect.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 23;
            this.label4.Text = "Engine:";
            // 
            // serverName
            // 
            this.serverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serverName.Location = new System.Drawing.Point(91, 0);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(409, 27);
            this.serverName.TabIndex = 19;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 20;
            this.label5.Text = "Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "IP adress:";
            // 
            // serverIP
            // 
            this.serverIP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverIP.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serverIP.Location = new System.Drawing.Point(91, 81);
            this.serverIP.Name = "serverIP";
            this.serverIP.Size = new System.Drawing.Size(409, 27);
            this.serverIP.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 19);
            this.label2.TabIndex = 28;
            this.label2.Text = "FTP data:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(3, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 19);
            this.label6.TabIndex = 30;
            this.label6.Text = "Port:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(3, 164);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 19);
            this.label7.TabIndex = 31;
            this.label7.Text = "User:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(3, 191);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 19);
            this.label8.TabIndex = 32;
            this.label8.Text = "Password:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(3, 218);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 19);
            this.label11.TabIndex = 35;
            this.label11.Text = "RCON data:";
            // 
            // ftpPort
            // 
            this.ftpPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ftpPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ftpPort.Location = new System.Drawing.Point(91, 135);
            this.ftpPort.Name = "ftpPort";
            this.ftpPort.Size = new System.Drawing.Size(409, 27);
            this.ftpPort.TabIndex = 37;
            this.ftpPort.Text = "21";
            // 
            // ftpUser
            // 
            this.ftpUser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ftpUser.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ftpUser.Location = new System.Drawing.Point(91, 162);
            this.ftpUser.Name = "ftpUser";
            this.ftpUser.Size = new System.Drawing.Size(409, 27);
            this.ftpUser.TabIndex = 38;
            // 
            // ftpPassword
            // 
            this.ftpPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ftpPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ftpPassword.Location = new System.Drawing.Point(91, 189);
            this.ftpPassword.Name = "ftpPassword";
            this.ftpPassword.PasswordChar = '•';
            this.ftpPassword.Size = new System.Drawing.Size(409, 27);
            this.ftpPassword.TabIndex = 39;
            // 
            // rconPassword
            // 
            this.rconPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rconPassword.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rconPassword.Location = new System.Drawing.Point(91, 270);
            this.rconPassword.Name = "rconPassword";
            this.rconPassword.PasswordChar = '•';
            this.rconPassword.Size = new System.Drawing.Size(409, 27);
            this.rconPassword.TabIndex = 45;
            // 
            // rconPort
            // 
            this.rconPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rconPort.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rconPort.Location = new System.Drawing.Point(91, 243);
            this.rconPort.Name = "rconPort";
            this.rconPort.Size = new System.Drawing.Size(409, 27);
            this.rconPort.TabIndex = 43;
            this.rconPort.Text = "25575";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(3, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 19);
            this.label9.TabIndex = 42;
            this.label9.Text = "Password:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(3, 245);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 19);
            this.label12.TabIndex = 40;
            this.label12.Text = "Port:";
            // 
            // readyButton
            // 
            this.readyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readyButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.readyButton.Location = new System.Drawing.Point(0, 297);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(500, 30);
            this.readyButton.TabIndex = 46;
            this.readyButton.Text = "Ready";
            this.readyButton.UseVisualStyleBackColor = true;
            this.readyButton.Click += new System.EventHandler(this.readyButton_Click);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // ConnectRemoteServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.rconPassword);
            this.Controls.Add(this.rconPort);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.ftpPassword);
            this.Controls.Add(this.ftpUser);
            this.Controls.Add(this.ftpPort);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.versionSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.engineSelect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.label5);
            this.Name = "ConnectRemoteServer";
            this.Size = new System.Drawing.Size(500, 327);
            this.Resize += new System.EventHandler(this.ConnectRemoteServer_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox versionSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox engineSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox ftpPort;
        private System.Windows.Forms.TextBox ftpUser;
        private System.Windows.Forms.TextBox ftpPassword;
        private System.Windows.Forms.TextBox rconPassword;
        private System.Windows.Forms.TextBox rconPort;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button readyButton;
        private System.ComponentModel.BackgroundWorker worker;
    }
}
