using Quick.Protocol.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace TcpGuard.Core.Protocol.V1.Commands
{
    public class DeletePortalCommand : AbstractCommand<Model.PortalModel, object>
    {
        public static DeletePortalCommand Create(Model.PortalModel model)
        {
            return new DeletePortalCommand() { ContentT = model };
        }
    }
}
