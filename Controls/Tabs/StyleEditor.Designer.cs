namespace MinecraftServerManager.Controls
{
    partial class StyleEditor
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
            this.selectStyleLabel = new System.Windows.Forms.Label();
            this.newStyle = new MinecraftServerManager.Controls.NewStyle();
            this.newStyleLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // selectStyleLabel
            // 
            this.selectStyleLabel.AutoSize = true;
            this.selectStyleLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.selectStyleLabel.Location = new System.Drawing.Point(0, 0);
            this.selectStyleLabel.Name = "selectStyleLabel";
            this.selectStyleLabel.Size = new System.Drawing.Size(90, 19);
            this.selectStyleLabel.TabIndex = 0;
            this.selectStyleLabel.Text = "Select style:";
            // 
            // newStyle
            // 
            this.newStyle.Location = new System.Drawing.Point(0, 40);
            this.newStyle.Name = "newStyle";
            this.newStyle.Size = new System.Drawing.Size(500, 120);
            this.newStyle.TabIndex = 1;
            // 
            // newStyleLabel
            // 
            this.newStyleLabel.AutoSize = true;
            this.newStyleLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newStyleLabel.Location = new System.Drawing.Point(0, 20);
            this.newStyleLabel.Name = "newStyleLabel";
            this.newStyleLabel.Size = new System.Drawing.Size(77, 19);
            this.newStyleLabel.TabIndex = 2;
            this.newStyleLabel.Text = "Add style:";
            // 
            // StyleEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.newStyleLabel);
            this.Controls.Add(this.newStyle);
            this.Controls.Add(this.selectStyleLabel);
            this.Name = "StyleEditor";
            this.Size = new System.Drawing.Size(700, 400);
            this.Resize += new System.EventHandler(this.StyleEditor_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label selectStyleLabel;
        private NewStyle newStyle;
        private System.Windows.Forms.Label newStyleLabel;


    }
}
