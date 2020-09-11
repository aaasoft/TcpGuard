using Quick.Protocol.Commands;
using Quick.Protocol.WebSocket.Server.AspNetCore;
using System;
using System.Runtime.CompilerServices;
using TcpGuard.Core.Protocol.V1.Commands;

namespace Microsoft.AspNetCore.Builder
{
    public static class TcpGuardServerMiddlewareExtensions
    {
        public static IApplicationBuilder UseTcpGuardServer(this IApplicationBuilder app, QpWebSocketServerOptions options)
        {
            if (string.IsNullOrEmpty(options.ServerProgram))
                options.ServerProgram = typeof(TcpGuardServerMiddlewareExtensions).Assembly.GetName().Name;

            if (string.IsNullOrEmpty(options.Path))
                options.Path = "/";
            if (options.InstructionSet == null
                || options.InstructionSet.Length == 0)
                options.InstructionSet = new[] { TcpGuard.Core.Protocol.V1.Instruction.Instance };

            QpWebSocketServer server = null;
            app.UseQuickProtocol(options, out server);
            server.Start();

            var commandExecuterManager = new CommandExecuterManager();
            commandExecuterManager.Add<GetVersionCommand>(new TcpGuard.Core.CommandExecuters.GetVersion());
            commandExecuterManager.Add<ConnectCommand>(new TcpGuard.Core.CommandExecuters.Connect());

            server.ChannelConnected += (sender, e) => e.CommandExecuter = commandExecuterManager;            
            return app;
        }
    }
}
