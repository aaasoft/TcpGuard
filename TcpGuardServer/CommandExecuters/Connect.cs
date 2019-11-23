using Quick.Protocol.Commands;
using Quick.Protocol.Core;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TcpGuard.Core;
using TcpGuard.Core.Protocol.V1.Commands;

namespace TcpGuardServer.CommandExecuters
{
    public class Connect : AbstractCommandExecuter<ConnectCommand>
    {
        private List<Portal> portalList = new List<Portal>();

        public override void Execute(QpCommandHandler handler, ConnectCommand cmd)
        {
            _ = doExecute(handler, cmd);
        }

        private async Task doExecute(QpCommandHandler handler, ConnectCommand cmd)
        {
            var commandContent = cmd.ContentT;
            var tcpClient = new TcpClient();
            Portal portal = null;
            try
            {
                await tcpClient.ConnectAsync(commandContent.Host, commandContent.Port);
                portal = new Portal(handler, tcpClient);
                portal.Stoped += (sender, e) =>
                  {
                      tcpClient.Close();
                      var channel = handler as QpServerChannel;
                      channel?.Stop();
                  };
                portal.Start();
                lock (portalList)
                    portalList.Add(portal);
                await handler.SendCommandResponse(cmd, 0, null);
            }
            catch (Exception ex)
            {
                if (portal != null)
                    lock (portalList)
                        if (portalList.Contains(portal))
                            portalList.Remove(portal);
                await handler.SendCommandResponse(cmd, -1, ex.Message);
            }
        }
    }
}
