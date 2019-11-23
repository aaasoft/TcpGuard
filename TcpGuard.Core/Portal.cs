using Quick.Protocol.Core;
using System;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TcpGuard.Core.Protocol.V1.Pkgs;

namespace TcpGuard.Core
{
    public class Portal
    {
        private QpCommandHandler handler;
        private TcpClient tcpClient;
        private NetworkStream stream;

        private int bufferIndex = 0;
        private byte[] buffer;
        private CancellationTokenSource cts;
        private DateTime lastSendTime = DateTime.MinValue;

        public event EventHandler Stoped;

        public Portal(QpCommandHandler handler, TcpClient tcpClient) : this(handler, tcpClient, 80 * 1024) { }

        public Portal(QpCommandHandler handler, TcpClient tcpClient, int bufferSize)
        {
            this.handler = handler;
            this.tcpClient = tcpClient;
            this.stream = tcpClient.GetStream();
            buffer = new byte[bufferSize];
        }

        public void Start()
        {
            cts?.Cancel();
            cts = new CancellationTokenSource();

            handler.PackageReceived += Handler_PackageReceived;
            beginReadStream(cts.Token);
        }

        private void Handler_PackageReceived(object sender, Quick.Protocol.Packages.IPackage e)
        {
            if (e is TcpPackage)
            {
                var package = (TcpPackage)e;
                try
                {
                    stream.Write(package.Buffer, 0, package.Buffer.Length);
                    stream.Flush();
                }
                catch
                {
                    Stop();
                }
            }
        }

        private Task beginReadStream(CancellationToken token)
        {
            return Task.Run(() => readStream(token));
        }

        private void flushBuffer()
        {
            var tmpBuffer = new byte[bufferIndex];
            Array.Copy(buffer, 0, tmpBuffer, 0, bufferIndex);
            handler.SendPackage(new TcpPackage()
            {
                Buffer = tmpBuffer
            }).Wait();
        }

        private void readStream(CancellationToken token)
        {
            try
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException();
                    var freeBufferLength = buffer.Length - bufferIndex;
                    if (!stream.DataAvailable)
                    {
                        Thread.Sleep(100);
                        continue;
                    }
                    var ret = stream.ReadAsync(buffer, bufferIndex, freeBufferLength, token).Result;
                    if (ret > 0)
                    {
                        bufferIndex += ret;
                        //如果缓存满了，或者有0.01秒没有发送数据了
                        if (bufferIndex >= buffer.Length - 1
                            || (DateTime.Now - lastSendTime).TotalMilliseconds > 10)
                        {
                            flushBuffer();
                            bufferIndex = 0;
                            lastSendTime = DateTime.Now;
                        }
                    }
                }
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

            try { stream.Close(); } catch { }
            try { tcpClient.Close(); } catch { }
            Stoped?.Invoke(this, EventArgs.Empty);
        }
    }
}
