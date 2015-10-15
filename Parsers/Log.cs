using FastColoredTextBoxNS;
using System.Drawing;

namespace MinecraftServerManager.Parsers
{
    class Log
    {
        private static Style ConsoleCommandStyle = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        private static Style CharStyle = new TextStyle(Brushes.Red, null, FontStyle.Bold);
        private static Style ThreadStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        private static Style TimeStyle = new TextStyle(Brushes.Gray, null, FontStyle.Regular);

        private static Style SevereStyle = new TextStyle(Brushes.DarkRed, null, FontStyle.Bold);
        private static Style ErrorStyle = new TextStyle(Brushes.Red, null, FontStyle.Bold);
        private static Style WarnStyle = new TextStyle(Brushes.Orange, null, FontStyle.Regular);
        private static Style InfoStyle = new TextStyle(Brushes.LightBlue, null, FontStyle.Regular);
        private static Style FineStyle = new TextStyle(Brushes.Green, null, FontStyle.Regular);

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
}
