using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Shared.Logger.Contract;
using Shared.Logger.Infrastructure;

namespace Shared.Logger.Extension;

public static class LoggingExtension
{
    public static IHostBuilder AddSharedLogger(
        this IHostBuilder hostBuilder,
        IConfiguration configuration,
        string serviceName)
    {
        Log.Logger = SharedLoggerConfiguration.CreateLogger(
            configuration,
            serviceName);

        hostBuilder.UseSerilog();

        hostBuilder.ConfigureServices((_, services) =>
        {
            services.AddSingleton<ILogger>(Log.Logger);
            services.AddScoped(typeof(ILoggerManager<>), typeof(LoggerManager<>));
            services.AddSingleton<ICustomLogFactory, CustomLogFactory>();
        });

        return hostBuilder;
    }
}