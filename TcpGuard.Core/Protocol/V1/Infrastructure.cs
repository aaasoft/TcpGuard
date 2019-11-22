using Quick.Protocol;
using System;
using System.Collections.Generic;
using System.Text;

namespace TcpGuard.Core.Protocol.V1
{
    public class Instruction : QpInstruction
    {
        public static QpInstruction Instance = new QpInstruction()
        {
            Id = typeof(Instruction).Namespace,
            Name = "TcpGuard Protocol V1",
            SupportCommands = new Quick.Protocol.Commands.ICommand[]
                    {
                        new Commands.AddPortalCommand(),
                        new Commands.DeletePortalCommand(),
                        new Commands.QueryPortalCommand()
                    }
        };
    }
}
