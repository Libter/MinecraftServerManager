namespace MinecraftServerManager.Controls
{
    partial class NewStyle
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.foreColor = new System.Windows.Forms.Panel();
            this.foreColorLabel = new System.Windows.Forms.Label();
            this.controlBackColor = new System.Windows.Forms.Panel();
            this.controlBackColorLabel = new System.Windows.Forms.Label();
            this.windowBackColor = new System.Windows.Forms.Panel();
            this.windowBackColorLabel = new System.Windows.Forms.Label();
            this.nameText = new System.Windows.Forms.TextBox();
            this.save = new MinecraftServerManager.Controls.Button();
            this.foreColor.SuspendLayout();
            this.controlBackColor.SuspendLayout();
            this.windowBackColor.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Style name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(0, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Text and icons color:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(0, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(196, 19);
            this.label3.TabIndex = 3;
            this.label3.Text = "Window background color:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(0, 70);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 19);
            this.label4.TabIndex = 4;
            this.label4.Text = "Control background color:";
            // 
            // foreColor
            // 
            this.foreColor.Controls.Add(this.foreColorLabel);
            this.foreColor.Location = new System.Drawing.Point(202, 30);
            this.foreColor.Name = "foreColor";
            this.foreColor.Size = new System.Drawing.Size(298, 20);
            this.foreColor.TabIndex = 5;
            this.foreColor.Click += new System.EventHandler(this.foreColor_Click);
            // 
            // foreColorLabel
            // 
            this.foreColorLabel.AutoSize = true;
            this.foreColorLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.foreColorLabel.Location = new System.Drawing.Point(150, 0);
            this.foreColorLabel.Name = "foreColorLabel";
            this.foreColorLabel.Size = new System.Drawing.Size(59, 19);
            this.foreColorLabel.TabIndex = 0;
            this.foreColorLabel.Text = "Change";
            this.foreColorLabel.Click += new System.EventHandler(this.foreColorLabel_Click);
            // 
            // controlBackColor
            // 
            this.controlBackColor.Controls.Add(this.controlBackColorLabel);
            this.controlBackColor.Location = new System.Drawing.Point(202, 70);
            this.controlBackColor.Name = "controlBackColor";
            this.controlBackColor.Size = new System.Drawing.Size(298, 20);
            this.controlBackColor.TabIndex = 7;
            this.controlBackColor.Click += new System.EventHandler(this.controlBackColor_Click);
            // 
            // controlBackColorLabel
            // 
            this.controlBackColorLabel.AutoSize = true;
            this.controlBackColorLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.controlBackColorLabel.Location = new System.Drawing.Point(150, 0);
            this.controlBackColorLabel.Name = "controlBackColorLabel";
            this.controlBackColorLabel.Size = new System.Drawing.Size(59, 19);
            this.controlBackColorLabel.TabIndex = 1;
            this.controlBackColorLabel.Text = "Change";
            this.controlBackColorLabel.Click += new System.EventHandler(this.controlBackColorLabel_Click);
            // 
            // windowBackColor
            // 
            this.windowBackColor.Controls.Add(this.windowBackColorLabel);
            this.windowBackColor.Location = new System.Drawing.Point(202, 50);
            this.windowBackColor.Name = "windowBackColor";
            this.windowBackColor.Size = new System.Drawing.Size(298, 20);
            this.windowBackColor.TabIndex = 8;
            this.windowBackColor.Click += new System.EventHandler(this.windowBackColor_Click);
            // 
            // windowBackColorLabel
            // 
            this.windowBackColorLabel.AutoSize = true;
            this.windowBackColorLabel.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.windowBackColorLabel.Location = new System.Drawing.Point(150, 0);
            this.windowBackColorLabel.Name = "windowBackColorLabel";
            this.windowBackColorLabel.Size = new System.Drawing.Size(59, 19);
            this.windowBackColorLabel.TabIndex = 2;
            this.windowBackColorLabel.Text = "Change";
            this.windowBackColorLabel.Click += new System.EventHandler(this.windowBackColorLabel_Click);
            // 
            // nameText
            // 
            this.nameText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.nameText.Font = new System.Drawing.Font("Calibri", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nameText.Location = new System.Drawing.Point(202, 0);
            this.nameText.Name = "nameText";
            this.nameText.Size = new System.Drawing.Size(298, 29);
            this.nameText.TabIndex = 9;
            // 
            // save
            // 
            this.save.FlatAppearance.BorderSize = 0;
            this.save.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.save.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.save.Location = new System.Drawing.Point(0, 90);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(500, 30);
            this.save.TabIndex = 10;
            this.save.Text = "ADD STYLE";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // NewStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.save);
            this.Controls.Add(this.nameText);
            this.Controls.Add(this.windowBackColor);
            this.Controls.Add(this.controlBackColor);
            this.Controls.Add(this.foreColor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "NewStyle";
            this.Size = new System.Drawing.Size(500, 120);
            this.Resize += new System.EventHandler(this.NewStyle_Resize);
            this.foreColor.ResumeLayout(false);
            this.foreColor.PerformLayout();
            this.controlBackColor.ResumeLayout(false);
            this.controlBackColor.PerformLayout();
            this.windowBackColor.ResumeLayout(false);
            this.windowBackColor.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel foreColor;
        private System.Windows.Forms.Panel controlBackColor;
        private System.Windows.Forms.Panel windowBackColor;
        private System.Windows.Forms.TextBox nameText;
        private System.Windows.Forms.Label foreColorLabel;
        private System.Windows.Forms.Label controlBackColorLabel;
        private System.Windows.Forms.Label windowBackColorLabel;
        private MinecraftServerManager.Controls.Button save;
    }
}
