namespace MinecraftServerManager.Controls
{
    partial class Style
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
            this.selectBox = new System.Windows.Forms.CheckBox();
            this.deleteButton = new MinecraftServerManager.Controls.Button();
            this.SuspendLayout();
            // 
            // selectBox
            // 
            this.selectBox.AutoSize = true;
            this.selectBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectBox.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectBox.Location = new System.Drawing.Point(3, 3);
            this.selectBox.Name = "selectBox";
            this.selectBox.Size = new System.Drawing.Size(113, 23);
            this.selectBox.TabIndex = 0;
            this.selectBox.TabStop = false;
            this.selectBox.Text = "Lorem ipsum";
            this.selectBox.UseVisualStyleBackColor = true;
            this.selectBox.CheckedChanged += new System.EventHandler(this.selectBox_CheckedChanged);
            // 
            // deleteButton
            // 
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.deleteButton.Location = new System.Drawing.Point(122, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(60, 30);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // Style
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.selectBox);
            this.Name = "Style";
            this.Size = new System.Drawing.Size(185, 30);
            this.Resize += new System.EventHandler(this.Style_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox selectBox;
        private MinecraftServerManager.Controls.Button deleteButton;
    }
}
