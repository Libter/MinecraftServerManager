using System;
using System.Drawing;
using System.Windows.Forms;

namespace MinecraftServerManager.Controls
{
    public class ProgressButton : Button
    {
        public ProgressButton() : base() 
        {
            this.Progress = 0;
            this.Paint += new PaintEventHandler(ProgressButton_Paint);
            this.MouseEnter += new EventHandler(ProgressButton_MouseEnter);
            this.MouseLeave +=new EventHandler(ProgressButton_MouseLeave);
            this.TextChanged +=new EventHandler(ProgressButton_TextChanged);
        }

        private Data.Style Style;
        private bool MouseOver = false;

        private float progress;

        public float Progress
        {
            get { return progress; }

            set
            {
                if (value != Progress)
                    this.Invalidate();
                progress = value;
            }
        }

        public void ProgressButton_MouseEnter(object sender, EventArgs e)
        {
            this.MouseOver = true;
        }

        public void ProgressButton_MouseLeave(object sender, EventArgs e)
        {
            this.MouseOver = false;
        }

        public void ProgressButton_TextChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        public void ProgressButton_Paint(object sender, PaintEventArgs e)
        {
            if (this.Style == null)
                return;
            float width = this.Width * Progress;
            if (MouseOver)
                e.Graphics.FillRectangle(new SolidBrush(Style.WindowBackColor), this.ClientRectangle);
            else
                e.Graphics.FillRectangle(new SolidBrush(Style.ControlBackColor), this.ClientRectangle);
            e.Graphics.FillRectangle(new SolidBrush(Style.WindowBackColor), 0, 0, width, this.Height);
            TextRenderer.DrawText(e.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor);
        }

        public void SetStyle(Data.Style style)
        {
            this.Style = style;
        }
    }
}
