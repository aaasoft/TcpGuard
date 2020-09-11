using Microsoft.AspNetCore.Builder;
using Quick.Protocol.Commands;
using Quick.Protocol.WebSocket.Server.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using TcpGuard.Core;
using TcpGuard.Core.Protocol.V1.Commands;

namespace TcpGuardSite
{
    public class QpManager
    {
        private QpWebSocketServer server;
        private CommandExecuterManager commandExecuterManager;

        public QpManager(IApplicationBuilder app, ConfigModel configModel)
        {
            app.UseQuickProtocol(new QpWebSocketServerOptions()
            {
                ServerProgram = nameof(TcpGuardSite),
                Path = "/",
                Password = configModel.Password,
                InstructionSet = new[] { TcpGuard.Core.Protocol.V1.Instruction.Instance }
            }, out server);
            commandExecuterManager = new CommandExecuterManager();
            commandExecuterManager.Add<GetVersionCommand>(new CommandExecuters.GetVersion());
            commandExecuterManager.Add<ConnectCommand>(new CommandExecuters.Connect());
        }

        public void Start()
        {
            server.ChannelConnected += Server_ChannelConnected;
        }

        private void Server_ChannelConnected(object sender, Quick.Protocol.Core.QpServerChannel e)
        {
            e.CommandExecuter = commandExecuterManager;
        }

        public void Stop()
        {
            server.ChannelConnected -= Server_ChannelConnected;
        }
    }
}
