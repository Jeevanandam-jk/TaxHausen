using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace Shared.Logger.Infrastructure;

/// <summary>
/// Provides methods for configuring and creating a shared Serilog logger
/// instance that can be used across all microservices.
/// </summary>
public static class SharedLoggerConfiguration
{
    /// <summary>
    /// Creates and configures a Serilog logger using the application's
    /// configuration settings and the specified service name.
    /// </summary>
    /// <param name="configuration">
    /// The application configuration containing the Serilog settings,
    /// such as the minimum log level and other logging options.
    /// </param>
    /// <param name="serviceName">
    /// The name of the microservice. This value is added to each log entry
    /// to identify the service that generated the log.
    /// </param>
    /// <returns>
    /// A configured <see cref="ILogger"/> instance.
    /// </returns>
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
            .Enrich.With<SourceContextEnricher>()
            .Enrich.With<MethodNameEnricher>()
            .WriteTo.Console(
                theme: SystemConsoleTheme.Colored,
                outputTemplate:
                "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level}] [{ServiceName}] [{ClassName}] [{MethodName}] {Message:lj}{NewLine}{Exception}")
            .WriteTo.File(
                path: $"logs/{serviceName}/log-.txt",
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: 30,
                shared: true,
                outputTemplate:
                "[{Timestamp:yyyy-MM-dd HH:mm:ss}] [{Level}] [{ServiceName}] [{ClassName}] [{MethodName}] {Message:lj}{NewLine}{Exception}")
            .CreateLogger();
    }
}