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
        public override void Execute(QpCommandHandler handler, ConnectCommand cmd)
        {
            _ = doExecute(handler, cmd);
        }

        private async Task doExecute(QpCommandHandler handler, ConnectCommand cmd)
        {
            var commandContent = cmd.ContentT;
            var tcpClient = new TcpClient();
            try
            {
                await tcpClient.ConnectAsync(commandContent.Host, commandContent.Port);
                var portal = new Portal(handler, tcpClient.GetStream());
                portal.Stoped += (sender, e) =>
                  {
                      tcpClient.Close();
                      var channel = handler as QpServerChannel;
                      channel?.Stop();
                  };
                portal.Start();
                await handler.SendCommandResponse(cmd, 0, null);
            }
            catch (Exception ex)
            {
                await handler.SendCommandResponse(cmd, -1, ex.Message);
            }
        }
    }
}
