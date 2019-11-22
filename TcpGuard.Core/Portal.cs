using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace TcpGuard.Core
{
    public class Portal
    {
        private Stream streamA, streamB;
        private byte[] streamA_Buffer, streamB_Buffer;
        private CancellationTokenSource cts;

        public event EventHandler Stoped;

        public Portal(Stream streamA, Stream streamB) : this(streamA, streamB, 1 * 1024) { }

        public Portal(Stream streamA, Stream streamB, int bufferSize)
        {
            this.streamA = streamA;
            this.streamB = streamB;

            streamA_Buffer = new byte[bufferSize];
            streamB_Buffer = new byte[bufferSize];
        }

        public void Start()
        {
            cts?.Cancel();
            cts = new CancellationTokenSource();
            _ = beginReadStream(streamA, streamA_Buffer, streamB, cts.Token);
            _ = beginReadStream(streamB, streamB_Buffer, streamA, cts.Token);
        }

        private async Task beginReadStream(Stream streamA, byte[] buffer, Stream streamB, CancellationToken token)
        {
            try
            {
                var ret = await streamA.ReadAsync(buffer, 0, buffer.Length);
                if (ret <= 0)
                {
                    Stop();
                    return;
                }
                for (var i = 0; i < ret / 2; i++)
                {
                    var a = buffer[i];
                    buffer[i] = buffer[ret - 1 - i];
                    buffer[ret - 1 - i] = a;
                }
                await streamB.WriteAsync(buffer, 0, ret);
                await streamB.FlushAsync();
                _ = beginReadStream(streamA, buffer, streamB, token);
            }
            catch
            {
                Stop();
            }
        }

        public void Stop()
        {
            cts?.Cancel();
            cts = null;

            try { streamA.Close(); }
            catch { }
            try { streamB.Close(); }
            catch { }

            Stoped?.Invoke(this, EventArgs.Empty);
        }
    }
}
