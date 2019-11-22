using System;
using System.IO;
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

        public Portal(Stream streamA, Stream streamB) : this(streamA, streamB, 1 * 1024 * 1024) { }

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
            _ = beginReadStream(streamA, streamA_Buffer, streamB, streamB_Buffer, cts.Token);
            _ = beginReadStream(streamB, streamB_Buffer, streamA, streamA_Buffer, cts.Token);
        }

        private async Task beginReadStream(Stream streamA, byte[] streamA_buffer, Stream streamB, byte[] streamB_buffer, CancellationToken token)
        {
            try
            {
                var ret = await streamA.ReadAsync(streamA_Buffer, 0, streamA_Buffer.Length);
                if (ret <= 0)
                {
                    Stop();
                    return;
                }
                for (var i = 0; i < ret / 2; i++)
                {
                    var a = streamA_Buffer[i];
                    streamA_Buffer[i] = streamA_Buffer[ret - 1 - i];
                    streamA_Buffer[ret - 1 - i] = a;
                }
                await streamB.WriteAsync(streamA_Buffer, 0, ret);
                await streamB.FlushAsync();
                _ = beginReadStream(streamA, streamA_Buffer, streamB, streamB_Buffer, token);
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
        }
    }
}
