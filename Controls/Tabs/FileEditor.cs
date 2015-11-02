using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FastColoredTextBoxNS;
using MinecraftServerManager.Utils;
using MinecraftServerManager.Dialogs;

namespace MinecraftServerManager.Controls
{
    public partial class FileEditor : UserControl, IStyleableTab
    {
        private enum FileType { Text, Image }

        public FileInfo file;
        public bool ftp = false;
        public Data.RemoteServer Data;
        public string ftpFile;

        private bool saved = true;
        private FileType fileType;
        private string[] disallowedExtensions = new string[] {
            "jar", "gz", "zip", "rar", "tar", "tar.gz", "dat", "mca", "lock"
        };
        private string[] imageExtensions = new string[] { "png", "jpg", "jpeg", "bmp", "gif" };

        private FastColoredTextBoxNS.Style KeyStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        private FastColoredTextBoxNS.Style CommentStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);
        private FastColoredTextBoxNS.Style ValueStyle = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        private FastColoredTextBoxNS.Style KeywordStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        private FastColoredTextBoxNS.Style EventStyle = new TextStyle(Brushes.Purple, null, FontStyle.Bold);
        private FastColoredTextBoxNS.Style CommandStyle = new TextStyle(Brushes.Orange, null, FontStyle.Bold);
        private FastColoredTextBoxNS.Style ItemStyle = new TextStyle(Brushes.LightBlue, null, FontStyle.Bold);
        private FastColoredTextBoxNS.Style CharStyle = new TextStyle(Brushes.Red, null, FontStyle.Bold);

        public FileEditor()
        {
            InitializeComponent();
            saveButton.Text = Utils.Language.GetString("Save");
        }

        public new void Load(Data.RemoteServer _data, string file, Tabs tabs)
        {
            ftp = true;
            Data = _data;
            ftpFile = file;
            FtpDownloader downloader = new FtpDownloader();
            string ftpIp = this.Data.adress.Replace("/", "").Split(':')[1];
            string ftpLocalFileName = Main.TempRemoteDirectory + ftpIp + Path.DirectorySeparatorChar + Path.GetFileName(file);
            downloader.Download(Data, ftpLocalFileName, file);
            Load(new FileInfo(ftpLocalFileName), tabs);
        }

        public new void Load(ServersTreeNodes.RemoteFileNode node, Tabs tabs)
        {
            ftp = true;
            Data = node.data;
            ftpFile = node.GetFile();
            FtpDownloader downloader = new FtpDownloader();
            string ftpIp = node.data.adress.Replace("/", "").Split(':')[1];
            string ftpLocalFileName = Main.TempRemoteDirectory + ftpIp + Path.DirectorySeparatorChar + Path.GetFileName(node.GetFile());
            downloader.Download(node.data, ftpLocalFileName, node.GetFile());
            Load(new FileInfo(ftpLocalFileName), tabs);
        }

        public new void Load(FileInfo _file, Tabs tabs)
        {
            fileType = FileType.Text;
            file = _file;
            foreach (Tab t in tabs.tabs)
            {
                if (t.control is FileEditor)
                {
                    FileEditor te = (FileEditor)t.control;
                    if (te.file.FullName == file.FullName)
                    {
                        tabs.SelectTab(t);
                        return;
                    }
                }
            }
            foreach (string extension in imageExtensions)
            {
                if (file.Extension == "." + extension)
                {
                    fileType = FileType.Image;
                    break;
                }
            }
            foreach (string extension in disallowedExtensions)
            {
                if (file.Extension == "." + extension) {
                    Error.Show("ErrorFileNotText");
                    return;
                }
            }
            switch (fileType)
            {
                case FileType.Text:
                    if (file.Length > 1024 * 1024)
                    {
                        Error.Show("ErrorFileTooBig");
                        return;
                    }
                    try
                    {
                        StreamReader sr = new StreamReader(file.FullName);
                        text.Text = sr.ReadToEnd();
                        sr.Close();
                        saved = true;
                    }
                    catch (IOException)
                    {
                        Error.Show("ErrorFileUnknown");
                        return;
                    }

                    text.Visible = true;
                    saveButton.Visible = true;

                    if (file.Extension == ".properties")
                        text.TextChanged += new EventHandler<TextChangedEventArgs>(PropertiesParser);
                    else if (file.Extension == ".yml")
                        text.TextChanged += new EventHandler<TextChangedEventArgs>(YamlParser);
                    else if (file.Extension == ".json")
                        text.TextChanged += new EventHandler<TextChangedEventArgs>(JsonParser);
                    else if (file.Extension == ".log")
                        text.TextChanged += new EventHandler<TextChangedEventArgs>(Log.Parse);
                    else if (file.Extension == ".sk")
                        text.TextChanged += new EventHandler<TextChangedEventArgs>(SkriptParser);
                    text.TextChanged += new EventHandler<TextChangedEventArgs>(Parser);
                    break;
                case FileType.Image:
                    picturePanel.Visible = true;
                    picturePanel.Location = new Point(0, 0);
                    pictureBox.Image = new Bitmap(file.FullName);
                    break;
            }
            tabs.AddTab(file.Name, this);
        }

        public bool Close()
        {
            if (!saved)
            {
                DialogResult dr = MessageBox.Show(String.Format(Utils.Language.GetString("WarningFileNotSaved"), file.Name), 
                                  Utils.Language.GetString("Warning"), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (dr == DialogResult.Yes)
                    saveButton_Click(null, null);
            }
            return true;
        }

        private void TextEditor_Resize(object sender, EventArgs e)
        {
            switch (fileType)
            {
                case FileType.Text:
                    text.Size = new Size(Width, Height - 30);
                    saveButton.Location = new Point(0, Height - 30);
                    saveButton.Size = new Size(Width, 30);
                    break;
                case FileType.Image:
                    picturePanel.Size = Size;
                    break;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            StreamWriter sr = new StreamWriter(file.FullName);
            sr.Write(text.Text);
            sr.Close();
            saved = true;
            if (ftp)
                new FtpUploader().Upload(Data, file.FullName, ftpFile);
        }

        public void SetStyle(Data.Style style)
        {
            Colors.StyleFastColoredTextBox(text, style);
            Colors.StyleButton(saveButton, style);
        }

        #region Parsers

        private void Parser(object sender, TextChangedEventArgs e)
        {
            saved = false;
        }

        private void PropertiesParser(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(CommentStyle);
            e.ChangedRange.ClearStyle(CharStyle);
            e.ChangedRange.ClearStyle(KeyStyle);
            e.ChangedRange.ClearStyle(KeywordStyle);
            e.ChangedRange.ClearStyle(ValueStyle);
            e.ChangedRange.SetStyle(CommentStyle, "#.*");
            e.ChangedRange.SetStyle(CharStyle, "=");
            e.ChangedRange.SetStyle(KeyStyle, ".*=");
            e.ChangedRange.SetStyle(KeywordStyle, @"=\b(true|false)\b");
            e.ChangedRange.SetStyle(ValueStyle, "=.*");
        }

        private void YamlParser(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(CommentStyle);
            e.ChangedRange.ClearStyle(CharStyle);
            e.ChangedRange.ClearStyle(KeyStyle);
            e.ChangedRange.ClearStyle(KeywordStyle);
            e.ChangedRange.ClearStyle(ValueStyle);
            e.ChangedRange.SetStyle(CommentStyle, "#.*");
            e.ChangedRange.SetStyle(CharStyle, ":");
            e.ChangedRange.SetStyle(CharStyle, @"\s-\s");
            e.ChangedRange.SetStyle(KeyStyle, ".*:");
            e.ChangedRange.SetStyle(KeywordStyle, @"\b(true|false)\b");
            e.ChangedRange.SetStyle(ValueStyle, ":.*");
            e.ChangedRange.SetStyle(ValueStyle, "-.*");
        }

        private void JsonParser(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(CharStyle);
            e.ChangedRange.ClearStyle(KeyStyle);
            e.ChangedRange.ClearStyle(KeywordStyle);
            e.ChangedRange.ClearStyle(ValueStyle);
            e.ChangedRange.SetStyle(CharStyle, @"[\[\]{},:]");
            e.ChangedRange.SetStyle(KeyStyle, "\".*\"\\s*:");
            e.ChangedRange.SetStyle(KeywordStyle, @"\b(true|false)\b");
            e.ChangedRange.SetStyle(ValueStyle, ":\\s*.*");
        }

        private void SkriptParser(object sender, TextChangedEventArgs e)
        {
            e.ChangedRange.ClearStyle(CommentStyle);
            e.ChangedRange.ClearStyle(KeywordStyle);
            e.ChangedRange.ClearStyle(EventStyle);
            e.ChangedRange.ClearStyle(CommandStyle);
            e.ChangedRange.ClearStyle(ItemStyle);
            e.ChangedRange.SetStyle(CommentStyle, "#.*");
            e.ChangedRange.SetStyle(KeywordStyle, @"\b(else if|else|if|loop|while)\b");
            e.ChangedRange.SetStyle(EventStyle, 
                @"\b(at|on bed enter|on entering bed|on bed leave|on leaving bed|on block damage|on break|on breaking|on mine|on mining|" +
                @"on mining|on bucket empty|on bucket fill|on burn|on burning|on can build check|on chat|on chunk generate|on chunk populate|" + 
                @"on chunk load|on chunk unload|on right click|on rightclick|on left click|on leftclick|on click|on combust|on combusting|" + 
                @"on command|on player connect|on player connecting|on connect|on connecting|on craft|on creeper power|on damage|on damaging|" + 
                @"on death|on dispense|on drop|on enderman place|on enderman pickup|on sheep eat|on xp spawn|on exp spawn|on xperience spawn|" + 
                @"on experience spawn|on spawn of xp|on spawn of exp|on spawn of xperience|on spawn of experience|on explode|on exploding|" + 
                @"on explosion|on explosion prime|on fade|on fading|on first join|on first login|on fish|on fishing|on flow|on flowing|" +
                @"on form|on forming|on fuel burn|on gamemode change|on game mode change|on grow|on heal|on healing|on food level change|" +
                @"on food meter change|on food bar change|on hunger level change|on hunger meter change|on hunger bar change|on ignite|" + 
                @"on ignition|on item spawn|on player login|on player logging in|on player join|on player joining|on login|" +
                @"on logging in|on join|on joining|on kick|on being kicked|on leaves decay|on level|on level up|on lightning strike|" +
                @"on step on|on step over|on stepping on|on stepping over|on walk on|on walk over|on walking on|on walking over|" +
                @"on block physics|on physics|on pickup|on pick up|on picking up|on pigzap|on pig zap|on piston extend|on piston retract|" +
                @"on place|on placing|on portal|on portal create|on portal enter|on entering portal|on entering a portal|on step|on trip|" +
                @"on projectile hit|on quit|on redstone|on respawn|on respawning|on script load|on script init|on server start|on server load|" +
                @"on skript start|on skript load|on server stop|on skript stop|on shoot|on sign change|on ore smelt|on ore smelting|on smelt|" +
                @"on smelting|on smelt of ore|on smelting of ore|on toggling sneak|on toggle sneak|on sneak toggle|on spawn|on spawning|" + 
                @"on spawn change|on spread|on sprint toggle|on toggling sprint| on toggle sprint|on tame|on taming|on target|" +
                @"on entity target|on entity untarget|on entity un-target|on untarget|on un-target|on teleport|on teleporting|" +
                @"on throw of egg|on throw of an egg|on throwing of egg|on throwing of an egg|on tool change|on item held change|" +
                @"on held item change|on vehicle create|on create vehicle|on create a vehicle|on creating vehicle|on vehicle damage|" +
                @"on damage vehicle|on damaging vehicle|on damaging a vehicle|damage a vehicle|on vehicle destroy|on destroy vehicle|" + 
                @"on destroying vehicle|on destruction of vehicle|on destroy a vehicle|on destroying a vehicle|on destruction of a vehicle|" +
                @"on vehicle enter|on enter vehicle|on entering vehicle|on enter a vehicle|on entering a vehicle|on vehicle exit|" +
                @"on exit vehicle|on exiting vehicle|on exit a vehicle|on exiting a vehicle|on weather change|on world init|on world load|" +
                @"on world loading|on world save|on world saving|on world unload|on world unloading|on zombie break door|" +
                @"on zombie breaking a door|on zombie breaking a wooden door|every)\b");

            e.ChangedRange.SetStyle(CommandStyle, 
                @"\b(ip-ban|ban|unban|broadcast|cancel event|cancel the event|add|give|increase|set|remove|subtract|reduce|clear|delete|" +
                @"make|execute|damage|heal|repair|wait|halt|drop|enchant|disenchant|equip|make|exit|stop|create|explosion|ignite|" +
                @"set fire to|set|light|extinguish|kick|kill|create|strike|lightning|log|message|send|op|deop|open|show|poision|cure|" +
                @"unpoison|apply|remove|push|enable|disable|shear|unshear|un-shear|shoot|spawn|teleport|toggle|grow|generate|tree|ride|dye)\b");

            e.ChangedRange.SetStyle(ItemStyle, 
                @"\b(can build|is allowed to build|are allowed to build|can't build|cannot build|isn't allowed to build|" +
                @"is not allowed to build|aren't allowed to build|are not allowed to build|can hold|has enough space to hold|" +
                @"has enough space for|has space for|have space to hold|have space for|have enough space to hold|has space for|" +
                @"have enough space for|can't hold|cannot hold|has not enough space for|has not enough space to hold|" +
                @"have not enough space to hold|have not enough space for|has not space for|has not space to hold|" +
                @"have not space to hold|have not space for|a|haven't enough space for|have't enough space to hold|" +
                @"haven't enough space to hold|havn't enough space for|haven't space for|haven't space to hold|haven't space to hold|" +
                @"haven't space for|hasn't enough space for|hasn't enough space to hold|hasn't enough space to hold|hasn't enough space for|" +
                @"hasn't space for|hasn't space to hold|haasn't space to hold|hasn't space for|don't have enough space for|" +
                @"don't have enough space to hold|don't have enough space to hold|don't have enough space for|don't have space for|" +
                @"don't have space to hold|don't have space to hold|don't have not space for|doesn't have enough space for|" +
                @"chance of|has|have|contains|doesn't have|don't have|doesn't have|does not have|don't contain|doesn't contain|" +
                @"does not contain|do not contain|damage cause|exists|is set|are set|does not exist|don't exist|do not exist|" +
                @"doesn't exist |does not exist|isn't set|is not set|aren't set|are not set|has permission|doesn't have permission|" + 
                @"has the permission|has the permission|has permission|have permission|have the permissions|alive|dead|is banned|" + 
                @"are banned|isn't banned|aren't banned|is ip banned|are ip banned|isn't ip banned|aren't ip banned|is blocking|" +
                @"are blocking|isn't blocking|aren't blocking|is not blocking|are not blocking|is burning|is on fire|are burning|" +
                @"are on fire|isn't burning|isn't on fire|is not burning|is not on fire|aren't burning|aren't on fire|are not burning|" +
                @"are not on fire|is empty|are empty|isn't empty|is not empty|aren't empty|are not empty|is enchanted|are enchanted|" +
                @"isn't enchanted|is not enchanted|aren't enchanted|are not enchanted|is flying|are flying|isn't flying|is not flying|" +
                @"aren't flying|are not flying|is holding|are holding|isn't holding|is not holding|aren't holding|are not holding|is in|" +
                @"are in|is not in|isn't in|aren't in|are not in|is of type|are of type|is not of type|are not of type|isn't of type|" +
                @"aren't of type|is poisoned|are poisoned|isn't poisoned|is not poisoned|aren't poisoned|are not poisoned|is riding|" +
                @"are riding|isn't riding|is not riding|aren't riding|are not riding|is sleeping|are sleeping|isn't sleeping|" +
                @"is not sleeping|aren't sleeping|are not sleeping|is sneaking|are sneaking|isn't sneaking|is not sneaking|" +
                @"aren't sneaking|are not sneaking|is sprinting|are sprinting|isn't sprinting|is not sprinting|aren't sprinting|" +
                @"are not sprinting|is wearing|are wearing|isn't wearing|is not wearing|aren't wearing|are not wearing|north|northeast|" +
                @"northwest|south|southeast|southwest|east|west|above|over|up|down|below|under|beneath|altitude|amount|number|size|arg|" +
                @"argument|boot|boots|shoe|shoes|leg|legging|legs|leggings|chestplate|chestplates|helm|helmet|helms|helmets|slot|attacked|" +
                @"damaged|victim|attacker|damager|biome|block|blocks|event-block|chunk|event-chunk|clicked|color|colours|colour|colors|" +
                @"command|label|compass target|console|server|coordinate|location|damage|data|durability|damage value|damage values|" +
                @"data values|data value|difference|distance between|drops|element|ender chest|enderchest|facing|food bar|food level|" +
                @"food meter|hunger bar|hunger level|hunger level|former|paste|state|future|to-be|after|afterwards|ore|fuel" +
                @"|result&#x000D;&#x000A;game mode|gamemode|head|eyehealth|id|inventory|ip|item|items|spawned|last spawned|" +
                @"lastly spawned|level|level progress|sky light level|sun light level|block light level|skylight level|sunlight level|" +
                @"blocklight level|position|money|balance|name|display name|now|between|from|integer|integers|number|numbers|passenger|" +
                @"random|remaining air|floor|round|ceil|rounded|floor|shooter|line|skull|walk speed|fly speed|target|targeted block|time|" +
                @"tool|held item|type of|vehicle|version|weather|world|worlds|yaw|pitch|loop-value|loop-player|loop-integer)\b");
        }

        public class Log
        {
            private static FastColoredTextBoxNS.Style ConsoleCommandStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
            private static FastColoredTextBoxNS.Style CharStyle = new TextStyle(Brushes.Red, null, FontStyle.Bold);
            private static FastColoredTextBoxNS.Style ThreadStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
            private static FastColoredTextBoxNS.Style TimeStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);

            private static FastColoredTextBoxNS.Style SevereStyle = new TextStyle(Brushes.DarkRed, null, FontStyle.Bold);
            private static FastColoredTextBoxNS.Style ErrorStyle = new TextStyle(Brushes.Red, null, FontStyle.Bold);
            private static FastColoredTextBoxNS.Style WarnStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
            private static FastColoredTextBoxNS.Style InfoStyle = new TextStyle(Brushes.LightBlue, null, FontStyle.Regular);
            private static FastColoredTextBoxNS.Style FineStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);

            public static void Parse(object sender, TextChangedEventArgs e)
            {
                e.ChangedRange.SetStyle(CharStyle, @"[>\[\]]");
                e.ChangedRange.SetStyle(ConsoleCommandStyle, ">.*");

                e.ChangedRange.SetStyle(ThreadStyle, @"\[" + Utils.Language.GetString("ProgramName") + @"\]");

                e.ChangedRange.SetStyle(FineStyle, @"\bFINE\b");
                e.ChangedRange.SetStyle(InfoStyle, @"\bINFO\b");
                e.ChangedRange.SetStyle(WarnStyle, @"\bWARN\b");
                e.ChangedRange.SetStyle(ErrorStyle, @"\bERROR\b");
                e.ChangedRange.SetStyle(SevereStyle, @"\bSEVERE\b");

                e.ChangedRange.SetStyle(TimeStyle, @"\[\d\d:\d\d:\d\d");
                e.ChangedRange.SetStyle(ThreadStyle, @"\[.*thread/");
            }
        }

        #endregion
    }
}
