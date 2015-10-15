namespace MinecraftServerManager.Controls
{
    partial class EngineEditor
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
            this.engineTree = new MinecraftServerManager.Controls.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new MinecraftServerManager.Controls.ProgressButton();
            this.SuspendLayout();
            // 
            // engineTree
            // 
            this.engineTree.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.engineTree.CheckBoxes = true;
            this.engineTree.Location = new System.Drawing.Point(0, 20);
            this.engineTree.Name = "engineTree";
            this.engineTree.Size = new System.Drawing.Size(500, 350);
            this.engineTree.TabIndex = 0;
            this.engineTree.TabStop = false;
            this.engineTree.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.engineTree_BeforeCheck);
            this.engineTree.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.engineTree_AfterCheck);
            this.engineTree.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.engineTree_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(459, 19);
            this.label1.TabIndex = 12;
            this.label1.Text = "Checked engines will be downloaded and unchecked will be removed.";
            // 
            // saveButton
            // 
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.saveButton.Location = new System.Drawing.Point(0, 370);
            this.saveButton.Name = "saveButton";
            this.saveButton.Progress = 0F;
            this.saveButton.Size = new System.Drawing.Size(500, 30);
            this.saveButton.TabIndex = 11;
            this.saveButton.Text = "PERFORM";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // EngineEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.engineTree);
            this.Name = "EngineEditor";
            this.Size = new System.Drawing.Size(500, 400);
            this.Resize += new System.EventHandler(this.EngineEditor_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MinecraftServerManager.Controls.TreeView engineTree;
        private ProgressButton saveButton;
        private System.Windows.Forms.Label label1;
    }
}
