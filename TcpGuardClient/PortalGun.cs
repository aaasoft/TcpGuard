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
        private Dictionary<PortalModel, Portal> portalDict = new Dictionary<PortalModel, Portal>();

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
                //check version
                {
                    var rep = await qpClient.SendCommand(new GetVersionCommand());
                    if (rep.Code != 0)
                        throw new ApplicationException("Get server verion error,reason:" + rep.Message);
                    var serverVersion = rep.Data;
                    var clientVersion = this.GetType().Assembly.GetName().Version;
                    if (clientVersion != serverVersion)
                        throw new ApplicationException($"Client[{clientVersion}] and server[{serverVersion}] version not match.");

                }
                //connect
                {
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
                }
                var portal = new Portal(qpClient, tcpClient);
                portal.Stoped += (sender, e) =>
                {
                    try { qpClient.Close(); } catch { }
                    try { tcpClient.Close(); } catch { }
                };
                portal.Start();
                lock (portalDict)
                    portalDict[portalModel] = portal;
                _ = beginAcceptTcpClient();
            }
            catch
            {
                try { tcpClient.Close(); } catch { }
                lock (portalDict)
                    if (portalDict.ContainsKey(portalModel))
                        portalDict.Remove(portalModel);
            }
        }

        public void Stop()
        {
            listener.Stop();
            lock (portalDict)
                foreach (var portal in portalDict.Values)
                    portal.Stop();
        }
    }
}
