using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls
{
    public interface IStyleableTab
    {
        void SetStyle(Data.Style style);
    }

    public class Tab : UserControl
    {
        private Button closeButton;
        private Label text;
        public Control control;
        private Tabs panel;

        public Color StartBackColor = Color.White;

        public Tab(string _text, Control _control, Tabs _panel)
        {
            InitializeComponent();
            this.text.Text = _text;
            this.Width = this.text.Width + 26;
            this.closeButton.Location = new Point(this.Width - 20, 0);
            this.control = _control;
            this.panel = _panel;
            this.control.Hide();
            this.control.Location = new Point(0, 20);
            this.BackColor = Color.LightGray;
            this.panel.Controls.Add(_control);
            if (panel.Style != null)
                SetStyle(panel.Style);
        }

        private void InitializeComponent()
        {
            this.text = new System.Windows.Forms.Label();
            this.closeButton = new Button();
            this.SuspendLayout();
            // 
            // text
            // 
            this.text.AutoSize = true;
            this.text.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.text.Location = new System.Drawing.Point(3, 0);
            this.text.Name = "text";
            this.text.Size = new System.Drawing.Size(113, 19);
            this.text.TabIndex = 0;
            this.text.Text = "Lorem ipsum.txt";
            this.text.Click += new System.EventHandler(this.text_Click);
            this.text.MouseEnter += new System.EventHandler(this.Tab_MouseEnter);
            this.text.MouseLeave += new System.EventHandler(this.Tab_MouseLeave);
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = global::MinecraftServerManager.Properties.Resources.CloseImage;
            this.closeButton.Location = new System.Drawing.Point(180, 0);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(20, 20);
            this.closeButton.TabIndex = 1;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            this.closeButton.MouseEnter += new System.EventHandler(this.Tab_MouseEnter);
            this.closeButton.MouseLeave += new System.EventHandler(this.Tab_MouseLeave);
            // 
            // Tab
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.text);
            this.Name = "Tab";
            this.Size = new System.Drawing.Size(200, 20);
            this.MouseEnter += new System.EventHandler(this.Tab_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.Tab_MouseLeave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public bool Close()
        {
            if (this.control is TextEditor)
                return ((TextEditor)this.control).Close();
            else if (this.control is Console)
                return ((Console)this.control).Close();
            else if (this.control is StyleEditor)
                return ((StyleEditor)this.control).Close();
            else if (this.control is NewLocalServer)
                return ((NewLocalServer)this.control).Close();
            return true;
        }

        public void closeButton_Click(object sender, EventArgs e)
        {
            if (this.Close())
                panel.RemoveTab(this);
        }

        public void Tab_Resize()
        {
            control.Size = new Size(panel.Width, panel.Height - 20);
        }

        private void text_Click(object sender, EventArgs e)
        {
            panel.SelectTab(this);
        }

        private void Tab_MouseEnter(object sender, EventArgs e)
        {
            if (!this.Equals(panel.SelectedTab))
                this.BackColor = Utils.Colors.Dark(StartBackColor, 16);
            else
                this.BackColor = StartBackColor;
        }

        public void Tab_MouseLeave(object sender, EventArgs e)
        {
            if (!this.Equals(panel.SelectedTab))
                this.BackColor = Utils.Colors.Dark(StartBackColor, 32);
            else
                this.BackColor = StartBackColor;
        }

        public void SetStyle(Data.Style style)
        {
            this.StartBackColor = Utils.Colors.Bright(style.ControlBackColor, 32);
            this.ForeColor = style.ForeColor;
            Tab_MouseLeave(null, null);
            this.control.BackColor = style.ControlBackColor;
            this.control.ForeColor = style.ForeColor;
            this.closeButton.Image = Utils.Icons.AddColor(Properties.Resources.CloseImage, style.ForeColor);
            if (this.control is IStyleableTab)
                ((IStyleableTab)this.control).SetStyle(style);
        }
    }
}
