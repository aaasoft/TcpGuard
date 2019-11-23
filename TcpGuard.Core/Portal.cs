using Quick.Protocol.Core;
using System;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
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
        private byte[] buffer;
        private CancellationTokenSource cts;

        public event EventHandler Stoped;

        public Portal(QpCommandHandler handler, TcpClient tcpClient) : this(handler, tcpClient, 1 * 1024) { }

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
                stream.WriteAsync(package.Buffer, 0, package.Buffer.Length);
            }
        }

        private Task beginReadStream(CancellationToken token)
        {
            return Task.Run(() => readStream(token));
        }

        private void readStream(CancellationToken token)
        {
            try
            {
                while (true)
                {
                    if (token.IsCancellationRequested)
                        throw new TaskCanceledException();
                    if (!stream.DataAvailable)
                    {
                        Thread.Sleep(10);
                        continue;
                    }
                    var ret = stream.Read(buffer, 0, buffer.Length);
                    if (ret > 0)
                    {
                        var tmpBuffer = new byte[ret];
                        Array.Copy(buffer, 0, tmpBuffer, 0, ret);
                        handler.SendPackage(new TcpPackage() { Buffer = tmpBuffer });
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
