using Quick.Protocol.Commands;
using Quick.Protocol.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TcpGuard.Core.Protocol.V1.Commands;

namespace TcpGuardServer.CommandExecuters
{
    public class DeletePortal : AbstractCommandExecuter<DeletePortalCommand>
    {
        private QpManager qpManager;
        public DeletePortal(QpManager qpManager)
        {
            this.qpManager = qpManager;
        }
        public override void Execute(QpCommandHandler handler, DeletePortalCommand cmd)
        {
            qpManager.DeletePortal(cmd.ContentT);
            handler.SendCommandResponse(cmd, 0, null);
        }
    }
}
