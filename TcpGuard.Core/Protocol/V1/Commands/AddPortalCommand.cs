using Quick.Protocol.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using TcpGuard.Core.Protocol.V1.Model;

namespace TcpGuard.Core.Protocol.V1.Commands
{
    public class AddPortalCommand : AbstractCommand<Model.PortalModel, object>
    {
        public static AddPortalCommand Create(PortalModel model)
        {
            return new AddPortalCommand() { ContentT = model };
        }
    }
}
