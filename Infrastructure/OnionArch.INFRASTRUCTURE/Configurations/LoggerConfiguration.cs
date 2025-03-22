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
            var logDirectory = Path.Combine(Directory.GetCurrentDirectory(), "logs");
            Directory.CreateDirectory(logDirectory);

            host.UseSerilog((context, services, config) =>
            {
                config
                    .MinimumLevel.Information()
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .WriteTo.File(
                    Path.Combine(logDirectory, "log.txt"),
                    rollingInterval: RollingInterval.Day,
                    rollOnFileSizeLimit: true);
            });
            return host;
        }
    }
}
