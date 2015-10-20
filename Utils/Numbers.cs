using System.Collections.Generic;

namespace MinecraftServerManager.Utils
{
    public class Numbers
    {
        public static int Max(List<int> numbers)
        {
            int max = 0;
            foreach (int n in numbers)
                if (n > max)
                    max = n;
            return max;
        }

        public static readonly int MenuPadding = 14;
    }
}
