using System;
using System.Text;

namespace MinecraftServerManager.Utils.MinecraftRcon
{
    internal sealed class RconMessageAnswer
    {
        public static readonly RconMessageAnswer EMPTY = new RconMessageAnswer(false, new byte[] { });

        private bool success = false;
        private string answer = string.Empty;
        private byte[] data = null;
        private int responseId = -1;

        public RconMessageAnswer(bool success, byte[] data, int responseId = -1)
        {
            this.success = success;
            this.data = data;
            this.responseId = responseId;
        }

        public byte[] Data
        {
            get
            {
                return this.data;
            }
        }

        public bool Success
        {
            get
            {
                return this.success;
            }
        }

        public string Answer
        {
            get
            {
                return ASCIIEncoding.UTF8.GetString(this.data);
            }
        }

        public int ResponseId
        {
            get
            {
                return this.responseId;
            }
        }
    }
}
