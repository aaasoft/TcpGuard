using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TcpGuardSite
{
    public class Program
    {
        public static ConfigModel ConfigModel { get; private set; }

        public static void Main()
        {
            var appSettingsModel = Quick.Fields.AppSettings.Model.Load();
            ConfigModel = appSettingsModel.Convert<ConfigModel>();

            CreateHostBuilder().Build().Run();
        }

        public static IHostBuilder CreateHostBuilder() =>
            Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls(ConfigModel.Urls.Split(new char[] { ';', ',' }));
                    webBuilder.UseStartup<Startup>();
                });
    }
}
