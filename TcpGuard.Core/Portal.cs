using Quick.Protocol.Core;
using System;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TcpGuard.Core.Protocol.V1.Pkgs;

namespace TcpGuard.Core
{
    public class Portal : AbstractWriteOnlyStream
    {
        private QpCommandHandler handler;
        private TcpClient tcpClient;
        private NetworkStream stream;

        private byte[] send_buffer;
        private CancellationTokenSource cts;

        public event EventHandler Stoped;

        public Portal(QpCommandHandler handler, TcpClient tcpClient) : this(handler, tcpClient, 80 * 1024) { }

        public Portal(QpCommandHandler handler, TcpClient tcpClient, int bufferSize)
        {
            this.handler = handler;
            this.tcpClient = tcpClient;
            this.stream = tcpClient.GetStream();
            send_buffer = new byte[bufferSize];
        }

        public void Start()
        {
            cts?.Cancel();
            cts = new CancellationTokenSource();

            handler.PackageReceived += Handler_PackageReceived;
            stream.CopyToAsync(this).ContinueWith(t => Stop());
        }

        private void Handler_PackageReceived(object sender, Quick.Protocol.Packages.IPackage e)
        {
            if (e is TcpPackage)
            {
                var package = (TcpPackage)e;
                try
                {
                    stream.Write(package.Buffer, 0, package.Buffer.Length);
                }
                catch
                {
                    Stop();
                }
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

        public override void Flush() { }

        public override void Write(byte[] buffer, int offset, int count)
        {
            handler.SendPackage(new TcpPackage() { Buffer = buffer.Skip(offset).Take(count).ToArray() }).Wait();
        }
    }
}
