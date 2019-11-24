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

        private int send_buffer_index = 0;
        private byte[] send_buffer;
        private int packageSendInterval;
        private CancellationTokenSource cts;

        public event EventHandler Stoped;

        public Portal(QpCommandHandler handler, TcpClient tcpClient, int packageSendInterval) : this(handler, tcpClient, packageSendInterval, 80 * 1024) { }

        public Portal(QpCommandHandler handler, TcpClient tcpClient, int packageSendInterval, int bufferSize)
        {
            this.handler = handler;
            this.tcpClient = tcpClient;
            this.packageSendInterval = packageSendInterval;
            this.stream = tcpClient.GetStream();
            send_buffer = new byte[bufferSize];
        }

        public void Start()
        {
            cts?.Cancel();
            cts = new CancellationTokenSource();
            beginSendPackage(cts.Token);
            handler.PackageReceived += Handler_PackageReceived;
            stream.CopyToAsync(this).ContinueWith(t => Stop());
        }

        private void beginSendPackage(CancellationToken token)
        {
            Task.Delay(packageSendInterval, token).ContinueWith(t =>
             {
                 if (t.IsCanceled)
                     return;
                 lock (send_buffer)
                 {
                     if (send_buffer_index > 0)
                     {
                         handler.SendPackage(new TcpPackage() { Buffer = send_buffer.Take(send_buffer_index).ToArray() })
                         .ContinueWith(t2 =>
                             {
                                 if (t2.IsFaulted)
                                     Stop();
                             });
                         send_buffer_index = 0;
                     }
                 }
                 beginSendPackage(token);
             });
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
            //如果没有设置发包间隔，则直接发送
            if (packageSendInterval <= 0)
            {
                handler.SendPackage(new TcpPackage() { Buffer = buffer.Skip(offset).Take(count).ToArray() }).Wait();
                return;
            }
            var sleepTime = 0;
            while (true)
            {
                if (sleepTime > 0)
                    Thread.Sleep(sleepTime);

                lock (send_buffer)
                {
                    var bufferLeftCount = send_buffer.Length - send_buffer_index;
                    if (count > bufferLeftCount)
                    {
                        sleepTime = 10;
                        continue;
                    }
                    Array.Copy(buffer, offset, send_buffer, send_buffer_index, count);
                    send_buffer_index += count;
                    break;
                }
            }
        }
    }
}
