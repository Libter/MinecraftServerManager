namespace MinecraftServerManager.Controls
{
    partial class TextEditor
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
            this.saveButton = new MinecraftServerManager.Controls.Button();
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
            this.text.AutoIndent = false;
            this.text.AutoIndentChars = false;
            this.text.AutoScrollMinSize = new System.Drawing.Size(29, 16);
            this.text.BackBrush = null;
            this.text.CharHeight = 16;
            this.text.CharWidth = 9;
            this.text.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.text.Font = new System.Drawing.Font("Courier New", 11F);
            this.text.IsReplaceMode = false;
            this.text.Location = new System.Drawing.Point(0, 0);
            this.text.Name = "text";
            this.text.Paddings = new System.Windows.Forms.Padding(0);
            this.text.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.text.Size = new System.Drawing.Size(700, 470);
            this.text.TabIndex = 0;
            this.text.TabStop = false;
            this.text.Zoom = 100;
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
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.text);
            this.Name = "TextEditor";
            this.Size = new System.Drawing.Size(700, 500);
            this.Resize += new System.EventHandler(this.TextEditor_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.text)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FastColoredTextBoxNS.FastColoredTextBox text;
        private MinecraftServerManager.Controls.Button saveButton;
    }
}
