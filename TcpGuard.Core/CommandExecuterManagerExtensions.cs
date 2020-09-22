using System;
using System.Collections.Generic;
using System.Text;
using TcpGuard.Core.Protocol.V1.Commands;

namespace Quick.Protocol.Commands
{
    public static class CommandExecuterManagerExtensions
    {
        public static void UseTcpGuardServer(this CommandExecuterManager commandExecuterManager)
        {
            commandExecuterManager.Add<GetVersionCommand>(new TcpGuard.Core.CommandExecuters.GetVersion());
            commandExecuterManager.Add<ConnectCommand>(new TcpGuard.Core.CommandExecuters.Connect());
        }
    }
}
