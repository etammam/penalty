using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Penalty.APIs.Setups.Models;
using Serilog;

namespace Penalty.APIs
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((context, configuration) =>
                {
                    var loggingSettings = new LoggingSettings();
                    context.Configuration.Bind(nameof(loggingSettings), loggingSettings);
                    configuration.Enrich.FromLogContext()
                        .Enrich.WithAssemblyInformationalVersion()
                        .Enrich.WithEnvironmentUserName()
                        .Enrich.WithProcessId()
                        .Enrich.WithProcessName()
                        .Enrich.WithThreadId()
                        .Enrich.WithEnvironmentUserName()
                        .WriteTo.Console()
                        .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                        .ReadFrom.Configuration(context.Configuration);

                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
