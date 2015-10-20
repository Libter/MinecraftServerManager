namespace MinecraftServerManager.Controls
{
    partial class Console
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
            this.components = new System.ComponentModel.Container();
            this.text = new FastColoredTextBoxNS.FastColoredTextBox();
            this.consoleCommand = new System.Windows.Forms.TextBox();
            this.consoleLabel = new System.Windows.Forms.Label();
            this.killButton = new MinecraftServerManager.Controls.Button();
            this.restartButton = new MinecraftServerManager.Controls.Button();
            this.stopButton = new MinecraftServerManager.Controls.Button();
            this.startButton = new MinecraftServerManager.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)(this.text)).BeginInit();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.text.AutoScrollMinSize = new System.Drawing.Size(2, 16);
            this.text.BackBrush = null;
            this.text.CharHeight = 16;
            this.text.CharWidth = 9;
            this.text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.text.Font = new System.Drawing.Font("Courier New", 11F);
            this.text.IsReplaceMode = false;
            this.text.Location = new System.Drawing.Point(4, 54);
            this.text.Margin = new System.Windows.Forms.Padding(0);
            this.text.Name = "text";
            this.text.Paddings = new System.Windows.Forms.Padding(0);
            this.text.ReadOnly = true;
            this.text.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.text.ShowLineNumbers = false;
            this.text.Size = new System.Drawing.Size(693, 422);
            this.text.TabIndex = 3;
            this.text.TabStop = false;
            this.text.Zoom = 100;
            // 
            // consoleCommand
            // 
            this.consoleCommand.BackColor = System.Drawing.Color.White;
            this.consoleCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleCommand.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.consoleCommand.Location = new System.Drawing.Point(20, 480);
            this.consoleCommand.Name = "consoleCommand";
            this.consoleCommand.Size = new System.Drawing.Size(677, 20);
            this.consoleCommand.TabIndex = 0;
            this.consoleCommand.TabStop = false;
            this.consoleCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.consoleCommand_KeyDown);
            // 
            // consoleLabel
            // 
            this.consoleLabel.AutoSize = true;
            this.consoleLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.consoleLabel.Location = new System.Drawing.Point(0, 480);
            this.consoleLabel.Name = "consoleLabel";
            this.consoleLabel.Size = new System.Drawing.Size(16, 19);
            this.consoleLabel.TabIndex = 5;
            this.consoleLabel.Text = "/";
            // 
            // killButton
            // 
            this.killButton.BackColor = System.Drawing.Color.White;
            this.killButton.FlatAppearance.BorderSize = 0;
            this.killButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.killButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.killButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.killButton.Image = global::MinecraftServerManager.Properties.Resources.ConsoleClose;
            this.killButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.killButton.Location = new System.Drawing.Point(522, 0);
            this.killButton.Margin = new System.Windows.Forms.Padding(0);
            this.killButton.Name = "killButton";
            this.killButton.Size = new System.Drawing.Size(175, 40);
            this.killButton.TabIndex = 0;
            this.killButton.TabStop = false;
            this.killButton.Text = "HALT";
            this.killButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.killButton.UseVisualStyleBackColor = false;
            this.killButton.Click += new System.EventHandler(this.killButton_Click);
            this.killButton.MouseEnter += new System.EventHandler(this.killButton_MouseEnter);
            this.killButton.MouseLeave += new System.EventHandler(this.killButton_MouseLeave);
            // 
            // restartButton
            // 
            this.restartButton.BackColor = System.Drawing.Color.White;
            this.restartButton.FlatAppearance.BorderSize = 0;
            this.restartButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.restartButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restartButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.restartButton.Image = global::MinecraftServerManager.Properties.Resources.ConsoleRefresh;
            this.restartButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.restartButton.Location = new System.Drawing.Point(358, 0);
            this.restartButton.Margin = new System.Windows.Forms.Padding(0);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(158, 40);
            this.restartButton.TabIndex = 0;
            this.restartButton.TabStop = false;
            this.restartButton.Text = "RESTART";
            this.restartButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.restartButton.UseVisualStyleBackColor = false;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            this.restartButton.MouseEnter += new System.EventHandler(this.restartButton_MouseEnter);
            this.restartButton.MouseLeave += new System.EventHandler(this.restartButton_MouseLeave);
            // 
            // stopButton
            // 
            this.stopButton.BackColor = System.Drawing.Color.White;
            this.stopButton.FlatAppearance.BorderSize = 0;
            this.stopButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.stopButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.stopButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.stopButton.Image = global::MinecraftServerManager.Properties.Resources.ConsoleStop;
            this.stopButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stopButton.Location = new System.Drawing.Point(179, 0);
            this.stopButton.Margin = new System.Windows.Forms.Padding(0);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(173, 40);
            this.stopButton.TabIndex = 0;
            this.stopButton.TabStop = false;
            this.stopButton.Text = "STOP";
            this.stopButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.stopButton.UseVisualStyleBackColor = false;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            this.stopButton.MouseEnter += new System.EventHandler(this.stopButton_MouseEnter);
            this.stopButton.MouseLeave += new System.EventHandler(this.stopButton_MouseLeave);
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.White;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gold;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.startButton.Image = global::MinecraftServerManager.Properties.Resources.ConsolePlay;
            this.startButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.startButton.Location = new System.Drawing.Point(4, 0);
            this.startButton.Margin = new System.Windows.Forms.Padding(0);
            this.startButton.Name = "startButton";
            this.startButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.startButton.Size = new System.Drawing.Size(169, 40);
            this.startButton.TabIndex = 0;
            this.startButton.TabStop = false;
            this.startButton.Text = "RUN";
            this.startButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            this.startButton.MouseEnter += new System.EventHandler(this.startButton_MouseEnter);
            this.startButton.MouseLeave += new System.EventHandler(this.startButton_MouseLeave);
            // 
            // Console
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.killButton);
            this.Controls.Add(this.consoleLabel);
            this.Controls.Add(this.consoleCommand);
            this.Controls.Add(this.text);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.startButton);
            this.Name = "Console";
            this.Size = new System.Drawing.Size(700, 500);
            this.Resize += new System.EventHandler(this.Console_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.text)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MinecraftServerManager.Controls.Button startButton;
        private MinecraftServerManager.Controls.Button stopButton;
        private MinecraftServerManager.Controls.Button restartButton;
        private FastColoredTextBoxNS.FastColoredTextBox text;
        private System.Windows.Forms.TextBox consoleCommand;
        private System.Windows.Forms.Label consoleLabel;
        private MinecraftServerManager.Controls.Button killButton;
    }
}
