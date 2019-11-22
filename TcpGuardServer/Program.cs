using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace TcpGuardServer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Arg[0]: Listen port;Arg[1]: Password.");
                return;
            }
            var port = int.Parse(args[0]);
            var password = args[1];
            var manager = new QpManager(port, password);
            manager.Start();
            Console.WriteLine("TcpGuard started.");
            while (true)
            {
                //如果输入被重定向，则不调用ReadLine
                if (Console.IsInputRedirected)
                {
                    Thread.Sleep(5000);
                    continue;
                }
                Console.Write(">");
                var line = Console.ReadLine()?.Trim();
                if (line == "exit")
                    break;
            }
            manager.Stop();
            Environment.Exit(0);
        }
    }
}
