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

        public QpManager(ConfigModel configModel)
        {
            server = new QpTcpServer(new QpTcpServerOptions()
            {
                ServerProgram = nameof(TcpGuardServer),
                Address = IPAddress.Parse(configModel.Host),
                Port = configModel.Port,
                Password = configModel.Password,
                InstructionSet = new[] { TcpGuard.Core.Protocol.V1.Instruction.Instance }
            });
            commandExecuterManager = new CommandExecuterManager();
            commandExecuterManager.Add<GetVersionCommand>(new TcpGuard.Core.CommandExecuters.GetVersion());
            commandExecuterManager.Add<ConnectCommand>(new TcpGuard.Core.CommandExecuters.Connect());
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
