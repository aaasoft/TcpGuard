using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TcpGuard.Core.Protocol.V1.Model;

namespace TcpGuard.Core
{
    public class PortalGun
    {
        private PortalModel model;
        private TcpListener listener;
        public PortalGun(PortalModel model)
        {
            this.model = model;
        }

        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, model.Port);
            listener.Start();
            _ = beginAcceptTcpClient();
        }

        private async Task beginAcceptTcpClient()
        {
            var tcpClient = await listener.AcceptTcpClientAsync();
            try
            {
                var targetTcpClient = new TcpClient();
                Console.WriteLine($"{Assembly.GetEntryAssembly().GetName().Name}: [{tcpClient.Client.RemoteEndPoint}]Connected to [{model.Port}].");
                Console.WriteLine($"{Assembly.GetEntryAssembly().GetName().Name}: Connecting to [{model.RemoteHost}:{model.RemotePort}].");

                await targetTcpClient.ConnectAsync(model.RemoteHost, model.RemotePort);
                var portal = new Portal(tcpClient.GetStream(), targetTcpClient.GetStream());
                portal.Stoped += (sender, e) =>
                  {
                      Console.WriteLine($"{Assembly.GetEntryAssembly().GetName().Name}: [{tcpClient.Client.RemoteEndPoint}] disconnected.");

                      try { targetTcpClient.Close(); } catch { }
                      try { tcpClient.Close(); } catch { }
                  };
                portal.Start();
                _ = beginAcceptTcpClient();
            }
            catch
            {
                try { tcpClient.Close(); } catch { }
            }
        }

        public void Stop()
        {
            listener.Stop();
        }
    }
}
