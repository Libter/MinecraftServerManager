using System.IO;

namespace MinecraftServerManager.Utils
{
    class Strings
    {
        public static string CutLastChars(string s, int i) 
        {
            return s.Remove(s.Length - i);
        }

        public static char GetLastChar(string s)
        {
            return s[s.Length - 1];
        }
    }
}
