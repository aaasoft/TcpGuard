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
            var appSettingsModel = Quick.Fields.AppSettings.Model.Load();
            var configModel = appSettingsModel.Convert<ConfigModel>();

            var manager = new QpManager(configModel);
            manager.Start();
            Console.WriteLine("TcpGuard started.");

            bool shouldReadLine = true;
            while (true)
            {
                //如果不读输出的行
                if (!shouldReadLine)
                {
                    Thread.Sleep(10 * 1000);
                    continue;
                }
                try
                {
                    Console.Write(">");
                    var line = Console.ReadLine();
                    if (line == "exit")
                        break;
                }
                catch
                {
                    shouldReadLine = false;
                }
            }
            manager.Stop();
            Environment.Exit(0);
        }
    }
}
