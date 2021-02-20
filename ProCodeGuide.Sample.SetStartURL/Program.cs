using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ProCodeGuide.Sample.SetStartURL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseKestrel(opts =>
                    {
                        opts.Listen(IPAddress.Loopback, port: 8501);
                        opts.ListenAnyIP(8502);
                        opts.ListenLocalhost(8503);
                        opts.ListenLocalhost(8504, opts => opts.UseHttps());
                    });

                    //webBuilder.UseUrls("http://*:5050", "https://*:5051");
                });
    }
}
