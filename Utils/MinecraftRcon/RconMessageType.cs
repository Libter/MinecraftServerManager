using System;

namespace MinecraftServerManager.Utils.MinecraftRcon
{
    public sealed class RconMessageType
    {
        private int type = -1;

        private RconMessageType(int type)
        {
            this.type = type;
        }

        public int Value
        {
            get
            {
                return this.type;
            }
        }

        public static bool operator ==(RconMessageType x, RconMessageType y)
        {
            if (Object.Equals(x, null))
            {
                return false;
            }

            if (Object.Equals(y, null))
            {
                return false;
            }

            return x.Value == y.Value;
        }

        public static bool operator !=(RconMessageType x, RconMessageType y)
        {
            if (Object.Equals(x, null))
            {
                return true;
            }

            if (Object.Equals(y, null))
            {
                return true;
            }

            return x.Value != y.Value;
        }

        public static bool operator ==(RconMessageType x, int y)
        {
            if (Object.Equals(x, null))
            {
                return false;
            }

            return x.Value == y;
        }

        public static bool operator !=(RconMessageType x, int y)
        {
            if (Object.Equals(x, null))
            {
                return true;
            }

            return x.Value != y;
        }

        public static readonly RconMessageType Response = new RconMessageType(0);
        public static readonly RconMessageType Command = new RconMessageType(2);
        public static readonly RconMessageType Login = new RconMessageType(3);
        public static readonly RconMessageType Invalid = new RconMessageType(-1);
    }
}
