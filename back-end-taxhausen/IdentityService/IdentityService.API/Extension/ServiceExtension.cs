using Shared.Cryptography.Contract;
using Shared.Cryptography.Service;
using Shared.Logger.Extension;

namespace IdentityService.API.Extension;

/// <summary>
/// Provides extension methods for registering application services
/// required by the Identity Service.
/// </summary>
public static class ServiceExtension
{
    /// <summary>
    /// Registers the shared logging services for the Identity Service.
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
        services.AddSharedLogger(builder.Configuration, "IdentityService");
    }

    /// <summary>
    /// Registers the shared cryptography services with the dependency injection container.
    /// </summary>
    /// <param name="services">
    /// The service collection to which the cryptography services will be added.
    /// </param>
    /// <returns>
    /// The updated <see cref="IServiceCollection"/> instance.
    /// </returns>
    public static IServiceCollection ConfigureCryptographyServices(
        this IServiceCollection services)
    {
        services.AddScoped<IHashService, HashService>();

        return services;
    }
}