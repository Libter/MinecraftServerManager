namespace MinecraftServerManager.Controls
{
    partial class ConnectLocalServer
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.selectDirectoryButton = new System.Windows.Forms.Button();
            this.selectJarButton = new System.Windows.Forms.Button();
            this.readyButton = new System.Windows.Forms.Button();
            this.selectJar = new System.Windows.Forms.OpenFileDialog();
            this.selectDirectory = new System.Windows.Forms.FolderBrowserDialog();
            this.versionSelect = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.engineSelect = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.serverName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(3, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select server directory:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(3, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select server jar file:";
            // 
            // selectDirectoryButton
            // 
            this.selectDirectoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectDirectoryButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectDirectoryButton.Location = new System.Drawing.Point(200, 81);
            this.selectDirectoryButton.Name = "selectDirectoryButton";
            this.selectDirectoryButton.Size = new System.Drawing.Size(300, 30);
            this.selectDirectoryButton.TabIndex = 7;
            this.selectDirectoryButton.Text = "Browse...";
            this.selectDirectoryButton.UseVisualStyleBackColor = true;
            this.selectDirectoryButton.Click += new System.EventHandler(this.selectDirectoryButton_Click);
            // 
            // selectJarButton
            // 
            this.selectJarButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectJarButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectJarButton.Location = new System.Drawing.Point(200, 111);
            this.selectJarButton.Name = "selectJarButton";
            this.selectJarButton.Size = new System.Drawing.Size(300, 30);
            this.selectJarButton.TabIndex = 8;
            this.selectJarButton.Text = "Browse...";
            this.selectJarButton.UseVisualStyleBackColor = true;
            this.selectJarButton.Click += new System.EventHandler(this.selectJarButton_Click);
            // 
            // readyButton
            // 
            this.readyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readyButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.readyButton.Location = new System.Drawing.Point(0, 141);
            this.readyButton.Name = "readyButton";
            this.readyButton.Size = new System.Drawing.Size(500, 30);
            this.readyButton.TabIndex = 12;
            this.readyButton.Text = "Ready";
            this.readyButton.UseVisualStyleBackColor = true;
            this.readyButton.Click += new System.EventHandler(this.next_Click);
            // 
            // selectJar
            // 
            this.selectJar.Filter = "Pliki Javy (*.jar) | *.jar";
            // 
            // versionSelect
            // 
            this.versionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionSelect.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.versionSelect.ForeColor = System.Drawing.SystemColors.WindowText;
            this.versionSelect.FormattingEnabled = true;
            this.versionSelect.Location = new System.Drawing.Point(70, 54);
            this.versionSelect.Name = "versionSelect";
            this.versionSelect.Size = new System.Drawing.Size(430, 27);
            this.versionSelect.TabIndex = 16;
            this.versionSelect.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 18;
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
            this.engineSelect.Location = new System.Drawing.Point(70, 27);
            this.engineSelect.Name = "engineSelect";
            this.engineSelect.Size = new System.Drawing.Size(430, 27);
            this.engineSelect.TabIndex = 15;
            this.engineSelect.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(3, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Engine:";
            // 
            // serverName
            // 
            this.serverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serverName.Location = new System.Drawing.Point(70, 0);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(430, 27);
            this.serverName.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(3, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 19);
            this.label5.TabIndex = 14;
            this.label5.Text = "Name:";
            // 
            // ConnectLocalServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.versionSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.engineSelect);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.selectJarButton);
            this.Controls.Add(this.selectDirectoryButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ConnectLocalServer";
            this.Size = new System.Drawing.Size(500, 171);
            this.Resize += new System.EventHandler(this.ConnectLocalServer_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button selectDirectoryButton;
        private System.Windows.Forms.Button selectJarButton;
        private System.Windows.Forms.Button readyButton;
        private System.Windows.Forms.OpenFileDialog selectJar;
        private System.Windows.Forms.FolderBrowserDialog selectDirectory;
        private System.Windows.Forms.ComboBox versionSelect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox engineSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Label label5;
    }
}
