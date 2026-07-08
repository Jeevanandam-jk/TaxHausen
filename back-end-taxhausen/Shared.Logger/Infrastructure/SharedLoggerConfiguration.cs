using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace Shared.Logger.Infrastructure;

public static class SharedLoggerConfiguration
{
    public static ILogger CreateLogger(
        IConfiguration configuration,
        string serviceName)
    {
        string minLevelString = configuration.GetValue<string>("Serilog:MinimumLevel:Default") ?? "Information";

        Enum.TryParse(minLevelString, true, out LogEventLevel logLevel);

        return new LoggerConfiguration()
            .MinimumLevel.Is(logLevel)
            .ReadFrom.Configuration(configuration)
            .Enrich.FromLogContext()
            .Enrich.WithProperty("ServiceName", serviceName)
            .WriteTo.Console(
                outputTemplate:
                "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level:u3}] [{ServiceName}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(
                path: $"logs/{serviceName}/log-.txt",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 30,
                shared: true,
                outputTemplate:
                "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level:u3}] [{ServiceName}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
    }
}