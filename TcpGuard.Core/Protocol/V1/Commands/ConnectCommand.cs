using Quick.Protocol.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace TcpGuard.Core.Protocol.V1.Commands
{
    public class ConnectCommand : AbstractCommand<ConnectCommand.CommandContent, object>
    {
        public class CommandContent
        {
            public string Host { get; set; }
            public int Port { get; set; }
        }

        public static ConnectCommand Create(CommandContent model)
        {
            return new ConnectCommand() { ContentT = model };
        }
    }
}
