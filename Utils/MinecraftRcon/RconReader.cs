using System;
using System.Threading;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.IO;
using System.Threading.Tasks;

namespace MinecraftServerManager.Utils.MinecraftRcon
{
    internal class RconReader : IDisposable
    {
        public static readonly RconReader INSTANCE = new RconReader();

        private bool isInit = false;
        private BinaryReader reader = null;
        private ConcurrentBag<RconMessageAnswer> answers = new ConcurrentBag<RconMessageAnswer>();

        private RconReader()
        {
            this.isInit = false;
        }

        public void setup(BinaryReader reader)
        {
            this.reader = reader;
            this.isInit = true;
            this.readerThread();
        }

        public RconMessageAnswer getAnswer(int messageId)
        {
            var matching = this.answers.Where(n => n.ResponseId == messageId).ToList();
            var data = new List<byte>();
            var dummy = RconMessageAnswer.EMPTY;

            if (matching.Count > 0)
            {
                matching.ForEach(n => { data.AddRange(n.Data); this.answers.TryTake(out dummy); });
                return new RconMessageAnswer(true, data.ToArray(), messageId);
            }
            else
            {
                return RconMessageAnswer.EMPTY;
            }
        }

        private void readerThread()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    if (this.isInit == false)
                    {
                        return;
                    }

                    try
                    {
                        var len = this.reader.ReadInt32();
                        var reqId = this.reader.ReadInt32();
                        var type = this.reader.ReadInt32();
                        var data = len > 10 ? this.reader.ReadBytes(len - 10) : new byte[] { };
                        var pad = this.reader.ReadBytes(2);
                        var msg = new RconMessageAnswer(reqId > -1, data, reqId);
                        this.answers.Add(msg);
                    }
                    catch (EndOfStreamException)
                    {
                        return;
                    }
                    catch (ObjectDisposedException)
                    {
                        return;
                    }
                    catch
                    {
                        return;
                    }

                    Thread.Sleep(1);
                }
            }, TaskCreationOptions.LongRunning);
        }

        #region IDisposable implementation
        public void Dispose()
        {
            this.isInit = false;
        }
        #endregion
    }
}
