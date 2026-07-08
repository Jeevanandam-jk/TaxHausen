using Shared.Logger.Extension;

namespace ClientService.API.Extension;

/// <summary>
/// Provides extension methods for registering application services
/// required by the Client Service.
/// </summary>
public static class ServiceExtension
{
    /// <summary>
    /// Registers the shared logging services for the Client Service.
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
        services.AddSharedLogger(builder.Configuration, "ClientService");
    }
}