namespace MinecraftServerManager.Controls
{
    partial class RemoteConsole
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
            this.consoleLabel = new System.Windows.Forms.Label();
            this.consoleCommand = new System.Windows.Forms.TextBox();
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
            this.text.AutoScrollMinSize = new System.Drawing.Size(2, 14);
            this.text.BackBrush = null;
            this.text.CharHeight = 14;
            this.text.CharWidth = 8;
            this.text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.text.IsReplaceMode = false;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Name = "text";
            this.text.Paddings = new System.Windows.Forms.Padding(0);
            this.text.ReadOnly = true;
            this.text.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.text.ShowLineNumbers = false;
            this.text.Size = new System.Drawing.Size(700, 480);
            this.text.TabIndex = 3;
            this.text.Zoom = 100;
            // 
            // consoleLabel
            // 
            this.consoleLabel.AutoSize = true;
            this.consoleLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold);
            this.consoleLabel.Location = new System.Drawing.Point(3, 480);
            this.consoleLabel.Name = "consoleLabel";
            this.consoleLabel.Size = new System.Drawing.Size(16, 19);
            this.consoleLabel.TabIndex = 5;
            this.consoleLabel.Text = "/";
            // 
            // consoleCommand
            // 
            this.consoleCommand.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.consoleCommand.Font = new System.Drawing.Font("Calibri", 12F);
            this.consoleCommand.Location = new System.Drawing.Point(20, 480);
            this.consoleCommand.Name = "consoleCommand";
            this.consoleCommand.Size = new System.Drawing.Size(677, 20);
            this.consoleCommand.TabIndex = 6;
            this.consoleCommand.KeyDown += new System.Windows.Forms.KeyEventHandler(this.consoleCommand_KeyDown);
            // 
            // RemoteConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.consoleCommand);
            this.Controls.Add(this.consoleLabel);
            this.Controls.Add(this.text);
            this.Name = "RemoteConsole";
            this.Size = new System.Drawing.Size(700, 500);
            this.Resize += new System.EventHandler(this.Console_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.text)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox text;
        private System.Windows.Forms.Label consoleLabel;
        private System.Windows.Forms.TextBox consoleCommand;
    }
}
