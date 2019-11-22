using Quick.Protocol.Commands;
using Quick.Protocol.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TcpGuard.Core.Protocol.V1.Commands;

namespace TcpGuardServer.CommandExecuters
{
    public class AddPortal : AbstractCommandExecuter<AddPortalCommand>
    {
        private QpManager qpManager;
        public AddPortal(QpManager qpManager)
        {
            this.qpManager = qpManager;
        }

        public override void Execute(QpCommandHandler handler, AddPortalCommand cmd)
        {
            qpManager.AddPortal(cmd.ContentT);
            handler.SendCommandResponse(cmd, 0, null);
        }
    }
}
