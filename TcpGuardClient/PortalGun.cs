﻿using Quick.Protocol.Core;
using Quick.Protocol.Tcp;
using Quick.Protocol.WebSocket.Client;
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
            listener = new TcpListener(IPAddress.Parse(portalModel.LocalIpAddress), portalModel.LocalPort);
            listener.Start();
            _ = beginAcceptTcpClient();
        }

        private async Task beginAcceptTcpClient()
        {
            TcpClient tcpClient = null;
            try
            {
                tcpClient= await listener.AcceptTcpClientAsync();
                var uri = new Uri(serverModel.Url);
                QpClient qpClient = null;
                switch (uri.Scheme)
                {
                    case "tcp":
                        qpClient = new QpTcpClient(new QpTcpClientOptions()
                        {
                            Host = uri.Host,
                            Port = uri.Port,
                            Password = serverModel.Password,
                            EnableCompress = serverModel.EnableCompress,
                            EnableEncrypt = serverModel.EnableEncrypt,
                            InstructionSet = new[] { TcpGuard.Core.Protocol.V1.Instruction.Instance }
                        });
                        break;
                    case "ws":
                        qpClient = new QpWebSocketClient(new QpWebSocketClientOptions()
                        {
                            Url = serverModel.Url,
                            Password = serverModel.Password,
                            EnableCompress = serverModel.EnableCompress,
                            EnableEncrypt = serverModel.EnableEncrypt,
                            InstructionSet = new[] { TcpGuard.Core.Protocol.V1.Instruction.Instance }
                        });
                        break;
                }
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
                        Port = portalModel.RemotePort,
                        SendInterval = portalModel.SendInterval
                    }));
                    if (rep.Code != 0)
                    {
                        qpClient.Close();
                        throw new ApplicationException(rep.Message);
                    }
                }
                var portal = new Portal(qpClient, tcpClient, portalModel.SendInterval);
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
                try { tcpClient?.Close(); } catch { }
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
