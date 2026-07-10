using Shared.Logger.Extension;

namespace CalculationService.API.Extension;

/// <summary>
/// Provides extension methods for registering application services
/// required by the Calculation Service.
/// </summary>
public static class ServiceExtension
{
    /// <summary>
    /// Registers the shared logging services for the Calculation Service.
    /// </summary>
    /// <param name="builder">
    /// The <see cref="WebApplicationBuilder"/> used to access the application
    /// configuration.
    /// </param>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> used to register application services.
    /// </param>
    public static void ConfigureSharedLoggerService(
        this WebApplicationBuilder builder,
        IServiceCollection services)
    {
        services.AddSharedLogger(builder.Configuration, "CalculationService");
    }
}