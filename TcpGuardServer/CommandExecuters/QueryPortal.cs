using Quick.Protocol.Commands;
using Quick.Protocol.Core;
using System;
using System.Collections.Generic;
using System.Text;
using TcpGuard.Core.Protocol.V1.Commands;

namespace TcpGuardServer.CommandExecuters
{
    public class QueryPortal : AbstractCommandExecuter<QueryPortalCommand>
    {
        private QpManager qpManager;
        public QueryPortal(QpManager qpManager)
        {
            this.qpManager = qpManager;
        }
        public override void Execute(QpCommandHandler handler, QueryPortalCommand cmd)
        {

            handler.SendCommandResponse(cmd, 0, qpManager.QueryPortal());
        }
    }
}
