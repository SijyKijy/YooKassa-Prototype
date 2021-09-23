using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Web;

namespace YooKassa.Api
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            ILogger<IHost> logger = null;

            AppDomain.CurrentDomain.UnhandledException += (s, e) =>
            {
                if (e.ExceptionObject is Exception ex)
                {
                    if (logger is null)
                        Console.WriteLine(ex.ToString());
                    else
                        logger.LogCritical(ex, "Критическая ошибка");
                }
            };
            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
            {
                LogManager.Flush();
                LogManager.Shutdown();
            };

            using IHost host = CreateHostBuilder(args).Build();
            logger = host.Services.GetService<ILogger<IHost>>();

            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.Sources.Clear();
                    if (context.HostingEnvironment.IsDevelopment())
                        builder.AddJsonFile("appsettings.Development.json", false, true);
                    else
                        builder.AddJsonFile("appsettings.json", false, true);
                    builder.AddEnvironmentVariables();
                })
                .ConfigureLogging(logging => logging.ClearProviders())
                .UseNLog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        webBuilder.UseKestrel((context, options) => options.ListenUnixSocket(context.Configuration["UnixSocket"]));
                    else
                        webBuilder.UseKestrel((context, options) => options.ListenLocalhost(context.Configuration.GetValue("Port", 5001)));

                    webBuilder.UseStartup<Startup>();
                });
    }
}
