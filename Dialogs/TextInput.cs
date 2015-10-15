using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MinecraftServerManager.Dialogs
{
    public partial class TextInput
    {
        private static Form f;

        public static string ShowDialog(string title, string _label, string text, string ok, string cancel)
        {
            f = new Form();
            InitializeComponent();
            f.Text = title;
            label.Text = _label;
            acceptButton.Text = ok;
            cancelButton.Text = cancel;
            acceptButton.DialogResult = DialogResult.OK;
            cancelButton.DialogResult = DialogResult.Cancel;
            textBox1.Text = text;

            DialogResult dr = f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                return textBox1.Text;
            }
            else
            {
                return "";
            }
        }
    }
}
