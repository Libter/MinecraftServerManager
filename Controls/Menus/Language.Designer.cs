namespace MinecraftServerManager.Controls.Menus
{
    partial class Language
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
            this.english = new MinecraftServerManager.Controls.Button();
            this.polish = new MinecraftServerManager.Controls.Button();
            this.SuspendLayout();
            // 
            // english
            // 
            this.english.BackColor = System.Drawing.Color.White;
            this.english.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.english.FlatAppearance.BorderSize = 0;
            this.english.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.english.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.english.Image = global::MinecraftServerManager.Properties.Resources.MenuEnglish;
            this.english.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.english.Location = new System.Drawing.Point(1, 1);
            this.english.Name = "english";
            this.english.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.english.Size = new System.Drawing.Size(110, 30);
            this.english.TabIndex = 1;
            this.english.TabStop = false;
            this.english.Text = "     ENGLISH";
            this.english.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.english.UseVisualStyleBackColor = false;
            this.english.Click += new System.EventHandler(this.english_Click);
            // 
            // polish
            // 
            this.polish.BackColor = System.Drawing.Color.White;
            this.polish.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.polish.FlatAppearance.BorderSize = 0;
            this.polish.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.polish.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.polish.Image = global::MinecraftServerManager.Properties.Resources.MenuPolish;
            this.polish.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.polish.Location = new System.Drawing.Point(1, 31);
            this.polish.Name = "polish";
            this.polish.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.polish.Size = new System.Drawing.Size(110, 30);
            this.polish.TabIndex = 2;
            this.polish.TabStop = false;
            this.polish.Text = "     POLISH";
            this.polish.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.polish.UseVisualStyleBackColor = false;
            this.polish.Click += new System.EventHandler(this.polish_Click);
            // 
            // Language
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.polish);
            this.Controls.Add(this.english);
            this.Name = "Language";
            this.Size = new System.Drawing.Size(112, 62);
            this.ResumeLayout(false);

        }

        #endregion

        private MinecraftServerManager.Controls.Button english;
        private Button polish;
    }
}
