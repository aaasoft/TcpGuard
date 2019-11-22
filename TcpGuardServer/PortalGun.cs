using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpGuard.Core;
using TcpGuard.Core.Protocol.V1.Model;

namespace TcpGuardServer
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
            try
            {
                var tcpClient = await listener.AcceptTcpClientAsync();
                var targetTcpClient = new TcpClient();
                await targetTcpClient.ConnectAsync(model.RemoteHost, model.Port);
                var portal = new Portal(tcpClient.GetStream(), targetTcpClient.GetStream());
                portal.Start();
                _ = beginAcceptTcpClient();
            }
            catch { }
        }

        public void Stop()
        {
            listener.Stop();
        }
    }
}
