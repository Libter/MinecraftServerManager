using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftServerManager.Utils
{
    class Strings
    {
        public static string CutLastChars(string s, int i) 
        {
            return s.Remove(s.Length - i);
        }
    }
}
