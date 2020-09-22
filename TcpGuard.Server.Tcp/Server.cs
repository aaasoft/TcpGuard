using Quick.Protocol.Commands;
using Quick.Protocol.Tcp;
using System;
using TcpGuard.Core.Protocol.V1.Commands;

namespace TcpGuard.Server.Tcp
{
    public class Server
    {
        private QpTcpServer server;
        private CommandExecuterManager commandExecuterManager;

        public Server(QpTcpServerOptions options)
        {
            server = new QpTcpServer(options);
            commandExecuterManager = new CommandExecuterManager();
            commandExecuterManager.UseTcpGuardServer();
        }

        public void Start()
        {
            server.ChannelConnected += Server_ChannelConnected;
            server.Start();
        }

        private void Server_ChannelConnected(object sender, Quick.Protocol.Core.QpServerChannel e)
        {
            e.CommandExecuter = commandExecuterManager;
        }

        public void Stop()
        {
            server.Stop();
        }
    }
}
