using Quick.Protocol.Commands;
using Quick.Protocol.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TcpGuard.Core.Protocol.V1.Commands;

namespace TcpGuardSite.CommandExecuters
{
    public class GetVersion : AbstractCommandExecuter<GetVersionCommand>
    {
        public override void Execute(QpCommandHandler handler, GetVersionCommand cmd)
        {
            handler.SendCommandResponse(cmd, 0, this.GetType().Assembly.GetName().Version);
        }
    }
}
