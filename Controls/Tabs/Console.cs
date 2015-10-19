using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using FastColoredTextBoxNS;
using Microsoft.Win32;

namespace MinecraftServerManager.Controls
{
    public partial class Console : UserControl, IStyleableTab
    {
        public Data.Server serverData;
        private Process process;
        private bool restart = false;
        private Data.Style Style;
        private string tag;
        
        public Console()
        {
            InitializeComponent();
            this.startButton.Text = Utils.Language.GetString("ConsoleRun");
            this.stopButton.Text = Utils.Language.GetString("ConsoleStop");
            this.restartButton.Text = Utils.Language.GetString("ConsoleRestart");
            this.killButton.Text = Utils.Language.GetString("ConsoleKill");
            this.tag = "[" + Utils.Language.GetString("ProgramName") + "]: ";
            Style = Utils.Colors.GetDefaultStyle();
        }

        public bool Close()
        {
            if (process != null && (!process.HasExited))
            {
                DialogResult dr = MessageBox.Show(String.Format(Utils.Language.GetString("WarningServerRunning"), serverData.ToString()), Utils.Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    process.Kill();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void SetFontSize(Control c, int size)
        {
            c.Font = new Font(c.Font.FontFamily, size, c.Font.Style);
        }

        private void Console_Resize(object sender, EventArgs e)
        {
            if (this.Width < 560)
            {
                SetFontSize(this.startButton, 9);
                SetFontSize(this.stopButton, 9);
                SetFontSize(this.restartButton, 9);
                SetFontSize(this.killButton, 9);
            }
            else if (this.Width < 600)
            {
                SetFontSize(this.startButton, 11);
                SetFontSize(this.stopButton, 11);
                SetFontSize(this.restartButton, 11);
                SetFontSize(this.killButton, 11);
            }
            else
            {
                SetFontSize(this.startButton, 12);
                SetFontSize(this.stopButton, 12);
                SetFontSize(this.restartButton, 12);
                SetFontSize(this.killButton, 12);
            }

            int buttonWidth = (this.Width) / 4;
            startButton.Size = new Size(buttonWidth, 40);
            stopButton.Size = new Size(buttonWidth, 40);
            restartButton.Size = new Size(buttonWidth, 40);
            killButton.Size = new Size(this.Width - buttonWidth * 3, 40);
            startButton.Location = new Point(0, 0);
            stopButton.Location = new Point(buttonWidth, 0);
            restartButton.Location = new Point(buttonWidth * 2, 0);
            killButton.Location = new Point(buttonWidth * 3, 0);

            text.Location = new Point(0, 40);
            text.Size = new Size(this.Width, this.Height - 60);

            consoleLabel.Location = new Point(0, this.Height - 20);
            consoleCommand.Location = new Point(16, this.Height - 20);
            consoleCommand.Size = new Size(this.Width - 16, 20);
        }

        public new void Load(Data.Server _serverData, Tabs tabs)
        {
            this.serverData = _serverData;
            foreach (Tab t in tabs.tabs) 
            {
                if (t.control is Console)
                {
                    Console c = (Console) t.control;
                    if (c.serverData == serverData)
                    {
                        tabs.SelectTab(t);
                        return;
                    }
                }
            }
            startButton_MouseLeave(null, null);
            stopButton_MouseLeave(null, null);
            restartButton_MouseLeave(null, null);
            killButton_MouseLeave(null, null);

            tabs.AddTab(serverData.ToString(), this);
            
            this.text.Clear();
            this.text.TextChanged += new EventHandler<TextChangedEventArgs>(Parsers.Log.Parse);
        }

        private string GetJavaPath()
        {
            string currentVersion = null;
            try
            {
                currentVersion = (string)RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment").GetValue("CurrentVersion");
            }
            catch (NullReferenceException)
            {
                currentVersion = (string)RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment").GetValue("CurrentVersion");
            }
            string javaHome = null;
            try
            {
                javaHome = (string)RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment\" + currentVersion).GetValue("JavaHome");
            }
            catch (NullReferenceException)
            {
                javaHome = (string)RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\JavaSoft\Java Runtime Environment\" + currentVersion).GetValue("JavaHome");
            }
            return javaHome + Path.DirectorySeparatorChar + "bin" + Path.DirectorySeparatorChar + "java.exe";
        }

        private void ConsoleOutputHandler(object sender, DataReceivedEventArgs e)
        {
            string s = e.Data;
            if (s == null)
                return;
            this.BeginInvoke(new MethodInvoker(() =>
            {
                text.AppendText(s + "\n");
                text.Navigate(text.Lines.Count - 1);
            }));
        }

        private void ConsoleExited(object sender, EventArgs e)
        {
            text.AppendText(tag + String.Format(Utils.Language.GetString("ServerHalted"), serverData.name) + "\n");
            if (restart)
            {
                startButton_Click(null, null);
                restart = false;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (process != null && (!process.HasExited))
            {
                return;
            }
            ProcessStartInfo info = new ProcessStartInfo();
            info.CreateNoWindow = true;
            info.RedirectStandardError = true;
            info.RedirectStandardOutput = true;
            info.RedirectStandardInput = true;
            info.ErrorDialog = false;
            info.UseShellExecute = false;
            info.WorkingDirectory = serverData.GetDirectory();
            info.FileName = GetJavaPath();
            info.Arguments = "-jar ";
            if (serverData.isImported)
                info.Arguments += "\"" + serverData.jarPath + "\"";
            else
                info.Arguments += "server.jar";
            if (serverData.engine == "Vanilla")
                info.Arguments += " nogui";

            process = new Process();
            process.StartInfo = info;
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += new DataReceivedEventHandler(ConsoleOutputHandler);
            process.ErrorDataReceived += new DataReceivedEventHandler(ConsoleOutputHandler);
            process.Exited += new EventHandler(ConsoleExited);
            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            text.AppendText(tag + String.Format(Utils.Language.GetString("ServerLaunching"), serverData.name) + "\n");
        }

        private void consoleCommand_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                if (consoleCommand.Text != "" && process != null && !process.HasExited)
                {
                    text.AppendText("> " + consoleCommand.Text + "\n");
                    process.StandardInput.WriteLine(consoleCommand.Text);
                    consoleCommand.Text = "";
                }
            }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (process != null && !process.HasExited)
            {
                process.StandardInput.WriteLine("stop");
                text.AppendText(tag + String.Format(Utils.Language.GetString("ServerHalting"), serverData.name) + "\n");
            }
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            if (process == null || process.HasExited)
            {
                startButton_Click(null, null);
                return;
            }
            restart = true;
            stopButton_Click(null, null);
            text.AppendText(tag + String.Format(Utils.Language.GetString("ServerRestarting"), serverData.name) + "\n");
        }

        private void killButton_Click(object sender, EventArgs e)
        {
            if (process != null && !process.HasExited)
            {
                DialogResult dr = MessageBox.Show(String.Format(Utils.Language.GetString("WarningServerKill"), serverData.ToString()), Utils.Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                {
                    process.Kill();
                }
            }
        }

        private void startButton_MouseEnter(object sender, EventArgs e)
        {
            startButton.Image = Utils.Icons.AddColor(Properties.Resources.ConsolePlay, Style.ControlBackColor);
        }

        private void startButton_MouseLeave(object sender, EventArgs e)
        {
            startButton.Image = Utils.Icons.AddColor(Properties.Resources.ConsolePlay, Style.WindowBackColor);
        }

        private void stopButton_MouseEnter(object sender, EventArgs e)
        {
            stopButton.Image = Utils.Icons.AddColor(Properties.Resources.ConsoleStop, Style.ControlBackColor);
        }

        private void stopButton_MouseLeave(object sender, EventArgs e)
        {
            stopButton.Image = Utils.Icons.AddColor(Properties.Resources.ConsoleStop, Style.WindowBackColor);
        }

        private void restartButton_MouseEnter(object sender, EventArgs e)
        {
            restartButton.Image = Utils.Icons.AddColor(Properties.Resources.ConsoleRefresh, Style.ControlBackColor);
        }

        private void restartButton_MouseLeave(object sender, EventArgs e)
        {
            restartButton.Image = Utils.Icons.AddColor(Properties.Resources.ConsoleRefresh, Style.WindowBackColor);
        }

        private void killButton_MouseEnter(object sender, EventArgs e)
        {
            killButton.Image = Utils.Icons.AddColor(Properties.Resources.ConsoleClose, Style.ControlBackColor);
        }

        private void killButton_MouseLeave(object sender, EventArgs e)
        {
            killButton.Image = Utils.Icons.AddColor(Properties.Resources.ConsoleClose, Style.WindowBackColor);
        }

        public void SetStyle(Data.Style style)
        {
            this.Style = style;
            startButton_MouseLeave(null, null);
            stopButton_MouseLeave(null, null);
            restartButton_MouseLeave(null, null);
            killButton_MouseLeave(null, null);
            Utils.Colors.StyleButton(startButton, style);
            Utils.Colors.StyleButton(stopButton, style);
            Utils.Colors.StyleButton(restartButton, style);
            Utils.Colors.StyleButton(killButton, style);
            Utils.Colors.StyleFastColoredTextBox(text, style);
            Utils.Colors.StyleTextBox(consoleCommand, style);
            consoleCommand.BorderStyle = BorderStyle.None;
        }
    }
}
