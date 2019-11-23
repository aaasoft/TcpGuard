using Quick.Protocol.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TcpGuard.Core;
using TcpGuard.Core.Protocol.V1.Commands;
using TcpGuardClient.Model;

namespace TcpGuardClient
{

    public class PortalGun
    {
        private ServerModel serverModel;
        private PortalModel portalModel;
        private TcpListener listener;
        public PortalGun(ServerModel serverModel, PortalModel portalModel)
        {
            this.serverModel = serverModel;
            this.portalModel = portalModel;
        }

        public void Start()
        {
            listener = new TcpListener(IPAddress.Any, portalModel.Port);
            listener.Start();
            _ = beginAcceptTcpClient();
        }

        private async Task beginAcceptTcpClient()
        {
            var tcpClient = await listener.AcceptTcpClientAsync();
            try
            {
                var qpClient = new QpTcpClient(new QpTcpClientOptions()
                {
                    Host = serverModel.Host,
                    Port = serverModel.Port,
                    Password = serverModel.Password,
                    EnableCompress = serverModel.EnableCompress,
                    EnableEncrypt = serverModel.EnableEncrypt,
                    InstructionSet = new[] { TcpGuard.Core.Protocol.V1.Instruction.Instance }
                });
                qpClient.Disconnected += (sender, e) =>
                {
                    try { tcpClient.Close(); } catch { }
                };
                await qpClient.ConnectAsync();
                var rep = await qpClient.SendCommand(ConnectCommand.Create(new ConnectCommand.CommandContent()
                {
                    Host = portalModel.RemoteHost,
                    Port = portalModel.RemotePort
                }));
                if (rep.Code != 0)
                {
                    qpClient.Close();
                    throw new ApplicationException(rep.Message);
                }
                var portal = new Portal(qpClient, tcpClient.GetStream());
                portal.Stoped += (sender, e) =>
                {
                    try { qpClient.Close(); } catch { }
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
