namespace MinecraftServerManager.Dialogs
{
    partial class TextInput
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private static void InitializeComponent()
        {
            label = new System.Windows.Forms.Label();
            textBox1 = new System.Windows.Forms.TextBox();
            acceptButton = new MinecraftServerManager.Controls.Button();
            cancelButton = new MinecraftServerManager.Controls.Button();
            f.SuspendLayout();
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(12, 9);
            label.Name = "label";
            label.Size = new System.Drawing.Size(29, 13);
            label.TabIndex = 0;
            label.Text = "label";
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(12, 25);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(200, 20);
            textBox1.TabIndex = 1;
            // 
            // acceptButton
            // 
            acceptButton.Location = new System.Drawing.Point(12, 52);
            acceptButton.Name = "acceptButton";
            acceptButton.Size = new System.Drawing.Size(97, 23);
            acceptButton.TabIndex = 2;
            acceptButton.Text = "button1";
            acceptButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.Location = new System.Drawing.Point(115, 52);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(97, 23);
            cancelButton.TabIndex = 3;
            cancelButton.Text = "button1";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // TextInput
            // 
            f.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            f.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            f.ClientSize = new System.Drawing.Size(224, 87);
            f.Controls.Add(cancelButton);
            f.Controls.Add(acceptButton);
            f.Controls.Add(textBox1);
            f.Controls.Add(label);
            f.MaximumSize = new System.Drawing.Size(240, 126);
            f.MinimumSize = new System.Drawing.Size(240, 126);
            f.Name = "TextInput";
            f.Text = "TextInput";
            f.ResumeLayout(false);
            f.PerformLayout();

        }

        #endregion

        private static System.Windows.Forms.Label label;
        private static System.Windows.Forms.TextBox textBox1;
        private static MinecraftServerManager.Controls.Button acceptButton;
        private static MinecraftServerManager.Controls.Button cancelButton;
    }
}