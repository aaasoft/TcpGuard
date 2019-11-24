using Quick.Protocol.Commands;
using Quick.Protocol.Tcp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TcpGuard.Core;
using TcpGuard.Core.Protocol.V1.Commands;

namespace TcpGuardServer
{
    public class QpManager
    {
        private QpTcpServer server;
        private CommandExecuterManager commandExecuterManager;

        public QpManager(int port, string password)
        {
            server = new QpTcpServer(new QpTcpServerOptions()
            {
                Address = IPAddress.Any,
                Port = port,
                Password = password,
                InstructionSet = new[] { TcpGuard.Core.Protocol.V1.Instruction.Instance }
            });
            commandExecuterManager = new CommandExecuterManager();
            commandExecuterManager.Add<GetVersionCommand>(new CommandExecuters.GetVersion());
            commandExecuterManager.Add<ConnectCommand>(new CommandExecuters.Connect());
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
