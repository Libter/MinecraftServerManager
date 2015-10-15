namespace MinecraftServerManager.Controls
{
    partial class NewLocalServer
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
            this.serverName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.versionSelect = new System.Windows.Forms.ComboBox();
            this.eulaLabelLink = new System.Windows.Forms.LinkLabel();
            this.eulaCheckBox = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.readyButton = new MinecraftServerManager.Controls.ProgressButton();
            this.engineSelect = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name:";
            // 
            // serverName
            // 
            this.serverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.serverName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serverName.Location = new System.Drawing.Point(70, 0);
            this.serverName.Name = "serverName";
            this.serverName.Size = new System.Drawing.Size(330, 27);
            this.serverName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Engine:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(0, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Version:";
            // 
            // versionSelect
            // 
            this.versionSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.versionSelect.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.versionSelect.ForeColor = System.Drawing.SystemColors.WindowText;
            this.versionSelect.FormattingEnabled = true;
            this.versionSelect.Location = new System.Drawing.Point(70, 54);
            this.versionSelect.Name = "versionSelect";
            this.versionSelect.Size = new System.Drawing.Size(330, 27);
            this.versionSelect.TabIndex = 0;
            this.versionSelect.TabStop = false;
            // 
            // eulaLabelLink
            // 
            this.eulaLabelLink.AutoSize = true;
            this.eulaLabelLink.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eulaLabelLink.Location = new System.Drawing.Point(50, 84);
            this.eulaLabelLink.Name = "eulaLabelLink";
            this.eulaLabelLink.Size = new System.Drawing.Size(100, 19);
            this.eulaLabelLink.TabIndex = 0;
            this.eulaLabelLink.TabStop = true;
            this.eulaLabelLink.Text = "Mojang EULA:";
            // 
            // eulaCheckBox
            // 
            this.eulaCheckBox.AutoSize = true;
            this.eulaCheckBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.eulaCheckBox.Location = new System.Drawing.Point(156, 87);
            this.eulaCheckBox.Name = "eulaCheckBox";
            this.eulaCheckBox.Size = new System.Drawing.Size(15, 14);
            this.eulaCheckBox.TabIndex = 0;
            this.eulaCheckBox.TabStop = false;
            this.eulaCheckBox.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(0, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "I agree";
            // 
            // readyButton
            // 
            this.readyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.readyButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.readyButton.Location = new System.Drawing.Point(0, 107);
            this.readyButton.Name = "readyButton";
            this.readyButton.Progress = 0F;
            this.readyButton.Size = new System.Drawing.Size(400, 30);
            this.readyButton.TabIndex = 0;
            this.readyButton.TabStop = false;
            this.readyButton.Text = "Ready";
            this.readyButton.UseVisualStyleBackColor = true;
            this.readyButton.Click += new System.EventHandler(this.readyButton_Click);
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
            this.engineSelect.Size = new System.Drawing.Size(330, 27);
            this.engineSelect.TabIndex = 0;
            this.engineSelect.TabStop = false;
            // 
            // NewLocalServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.readyButton);
            this.Controls.Add(this.eulaCheckBox);
            this.Controls.Add(this.eulaLabelLink);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.versionSelect);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.engineSelect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.serverName);
            this.Controls.Add(this.label1);
            this.Name = "NewLocalServer";
            this.Size = new System.Drawing.Size(400, 400);
            this.Resize += new System.EventHandler(this.NewLocalServer_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox serverName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox versionSelect;
        private System.Windows.Forms.LinkLabel eulaLabelLink;
        private System.Windows.Forms.CheckBox eulaCheckBox;
        private System.Windows.Forms.Label label4;
        private MinecraftServerManager.Controls.ProgressButton readyButton;
        private System.Windows.Forms.ComboBox engineSelect;
    }
}
