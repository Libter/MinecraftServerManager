namespace MinecraftServerManager.Controls
{
    partial class FileEditor
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.picturePanel = new System.Windows.Forms.Panel();
            this.saveButton = new MinecraftServerManager.Controls.Button();
            ((System.ComponentModel.ISupportInitialize)(this.text)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.picturePanel.SuspendLayout();
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
            this.text.AutoIndent = false;
            this.text.AutoIndentChars = false;
            this.text.AutoScrollMinSize = new System.Drawing.Size(27, 15);
            this.text.BackBrush = null;
            this.text.CharHeight = 15;
            this.text.CharWidth = 8;
            this.text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.text.Font = new System.Drawing.Font("Courier New", 10F);
            this.text.IsReplaceMode = false;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Name = "text";
            this.text.Paddings = new System.Windows.Forms.Padding(0);
            this.text.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.text.Size = new System.Drawing.Size(700, 470);
            this.text.TabIndex = 0;
            this.text.TabStop = false;
            this.text.Visible = false;
            this.text.Zoom = 100;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(200, 39);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // picturePanel
            // 
            this.picturePanel.AutoScroll = true;
            this.picturePanel.Controls.Add(this.pictureBox);
            this.picturePanel.Location = new System.Drawing.Point(3, 470);
            this.picturePanel.Name = "picturePanel";
            this.picturePanel.Size = new System.Drawing.Size(200, 39);
            this.picturePanel.TabIndex = 0;
            this.picturePanel.Visible = false;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.LightGray;
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(0, 470);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(700, 30);
            this.saveButton.TabIndex = 0;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // FileEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.picturePanel);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.text);
            this.Name = "FileEditor";
            this.Size = new System.Drawing.Size(700, 500);
            this.Resize += new System.EventHandler(this.TextEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.text)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.picturePanel.ResumeLayout(false);
            this.picturePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox text;
        private MinecraftServerManager.Controls.Button saveButton;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel picturePanel;
    }
}
