using Quick.Protocol.Core;
using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using TcpGuard.Core.Protocol.V1.Pkgs;

namespace TcpGuard.Core
{
    public class Portal
    {
        private QpCommandHandler handler;
        private Stream stream;
        private byte[] buffer;
        private CancellationTokenSource cts;

        public event EventHandler Stoped;

        public Portal(QpCommandHandler handler, Stream stream) : this(handler, stream, 1 * 1024) { }

        public Portal(QpCommandHandler handler, Stream stream, int bufferSize)
        {
            this.handler = handler;
            this.stream = stream;

            buffer = new byte[bufferSize];
        }

        public void Start()
        {
            cts?.Cancel();
            cts = new CancellationTokenSource();

            handler.PackageReceived += Handler_PackageReceived;
            _ = beginReadStream(cts.Token);
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

        private async Task beginReadStream(CancellationToken token)
        {
            if (token.IsCancellationRequested)
                return;
            try
            {
                var ret = await stream.ReadAsync(buffer, 0, buffer.Length, token);
                if (ret <= 0)
                {
                    Stop();
                    return;
                }
                var tmpBuffer = new byte[ret];
                Array.Copy(buffer, 0, tmpBuffer, 0, ret);
                await handler.SendPackage(new TcpPackage() { Buffer = tmpBuffer });
                _ = beginReadStream(token);
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

            try { stream.Close(); }
            catch { }
            Stoped?.Invoke(this, EventArgs.Empty);
        }
    }
}
