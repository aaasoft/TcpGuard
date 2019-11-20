using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace TcpGuardServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, 8100);
            listener.Start();
            beginListen(listener);
            Console.WriteLine("TcpGuardServer");
            Console.ReadLine();
        }

        private static void beginListen(TcpListener listener)
        {
            while (true)
            {
                var tcpClient = listener.AcceptTcpClient();
                Task.Run(() => beginTransfer(tcpClient));
            }
        }

        private static void beginTransfer(TcpClient tcpGuardClient)
        {
            Console.WriteLine("Connected: "+ tcpGuardClient.Client.RemoteEndPoint.ToString());

            byte[] tcpGuardBuffer = new byte[1 * 1024 * 1024];
            byte[] tcpTargetBuffer = new byte[1 * 1024 * 1024];

            TcpClient tcpTargetClient = new TcpClient();
            tcpTargetClient.Connect(IPAddress.Parse("20.20.24.167"), 80);

            var tcpGuardStream = tcpGuardClient.GetStream();
            var tcpTargetStream = tcpTargetClient.GetStream();

            Task.Run(() =>
            {
                while (true)
                {
                    var ret = tcpGuardStream.Read(tcpGuardBuffer, 0, tcpGuardBuffer.Length);
                    if (ret <= 0)
                        break;
                    Console.WriteLine("tcpGuardStream.Read: " + ret);
                    for (var i = 0; i < ret / 2; i++)
                    {
                        var a = tcpGuardBuffer[i];
                        tcpGuardBuffer[i] = tcpGuardBuffer[ret - 1 - i];
                        tcpGuardBuffer[ret - 1 - i] = a;
                    }
                    tcpTargetStream.Write(tcpGuardBuffer, 0, ret);
                    tcpTargetStream.Flush();
                }
            });


            Task.Run(() =>
            {
                while (true)
                {
                    var ret = tcpTargetStream.Read(tcpTargetBuffer, 0, tcpTargetBuffer.Length);
                    if (ret <= 0)
                        break;
                    Console.WriteLine("tcpTargetStream.Read: " + ret);
                    for (var i = 0; i < ret / 2; i++)
                    {
                        var a = tcpTargetBuffer[i];
                        tcpTargetBuffer[i] = tcpTargetBuffer[ret - 1 - i];
                        tcpTargetBuffer[ret - 1 - i] = a;
                    }
                    tcpGuardStream.Write(tcpTargetBuffer, 0, ret);
                    tcpGuardStream.Flush();
                }
            });
        }
    }
}
