using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Shared.Logger.Contract;
using Shared.Logger.Infrastructure;

namespace Shared.Logger.Extension;

/// <summary>
/// Provides extension methods for registering and configuring
/// the shared logging infrastructure.
/// </summary>
public static class LoggingExtension
{
    /// <summary>
    /// Registers the shared Serilog logger and related logging services
    /// into the application's dependency injection container.
    /// </summary>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> used to register application services.
    /// </param>
    /// <param name="configuration">
    /// The application configuration containing the Serilog settings.
    /// </param>
    /// <param name="serviceName">
    /// The name of the microservice to be included in every log entry.
    /// </param>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection AddSharedLogger(
        this IServiceCollection services,
        IConfiguration configuration,
        string serviceName)
    {
        Log.Logger = SharedLoggerConfiguration.CreateLogger(
            configuration,
            serviceName);

        services.AddSingleton<ILogger>(Log.Logger);
        services.AddScoped(typeof(ILoggerManager<>), typeof(LoggerManager<>));
        services.AddSingleton<ICustomLogFactory, CustomLogFactory>();

        return services;
    }
}