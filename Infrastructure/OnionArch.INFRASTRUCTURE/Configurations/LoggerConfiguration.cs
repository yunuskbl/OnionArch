using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

namespace OnionArch.INFRASTRUCTURE.Configurations
{
    public static class LoggerConfiguration
    {
        public static IHostBuilder AddLoggerConfiguration(this IHostBuilder host, IConfiguration configuration)
        {
            var seqUrl = configuration["Seq:Url"];
            var apiKey = configuration["Seq:ApiKey"];
            var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
            Directory.CreateDirectory(logDirectory);            

            host.UseSerilog((context, services, config) =>
            {
                config
                    .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)

                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(logDirectory, "log.txt"),
                    rollingInterval: RollingInterval.Day,
                    outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [LOG-{Level}] {Message}{NewLine}",
                    rollOnFileSizeLimit: true)
                .WriteTo.Seq(seqUrl)
                .Enrich.FromLogContext();
            });

            return host;
        }
    }
}
