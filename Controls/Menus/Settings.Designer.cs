namespace MinecraftServerManager.Controls.Menus
{
    partial class Settings
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
            this.style = new MinecraftServerManager.Controls.Button();
            this.engine = new MinecraftServerManager.Controls.Button();
            this.SuspendLayout();
            // 
            // style
            // 
            this.style.BackColor = System.Drawing.Color.White;
            this.style.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.style.FlatAppearance.BorderSize = 0;
            this.style.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.style.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.style.Image = global::MinecraftServerManager.Properties.Resources.MenuStyle;
            this.style.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.style.Location = new System.Drawing.Point(1, 1);
            this.style.Name = "style";
            this.style.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.style.Size = new System.Drawing.Size(188, 30);
            this.style.TabIndex = 1;
            this.style.TabStop = false;
            this.style.Text = "     MANAGE STYLES";
            this.style.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.style.UseVisualStyleBackColor = false;
            this.style.Click += new System.EventHandler(this.style_Click);
            // 
            // engine
            // 
            this.engine.BackColor = System.Drawing.Color.White;
            this.engine.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.engine.FlatAppearance.BorderSize = 0;
            this.engine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.engine.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.engine.Image = global::MinecraftServerManager.Properties.Resources.MenuEngine;
            this.engine.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.engine.Location = new System.Drawing.Point(1, 31);
            this.engine.Name = "engine";
            this.engine.Padding = new System.Windows.Forms.Padding(0, 0, 14, 0);
            this.engine.Size = new System.Drawing.Size(188, 30);
            this.engine.TabIndex = 2;
            this.engine.TabStop = false;
            this.engine.Text = "     ORGANIZE ENGINES";
            this.engine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.engine.UseVisualStyleBackColor = false;
            this.engine.Click += new System.EventHandler(this.engine_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.engine);
            this.Controls.Add(this.style);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(190, 62);
            this.ResumeLayout(false);

        }

        #endregion

        private MinecraftServerManager.Controls.Button style;
        private Button engine;
    }
}
