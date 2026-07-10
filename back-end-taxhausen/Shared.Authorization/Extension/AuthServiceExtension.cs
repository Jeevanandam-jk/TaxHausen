using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Authorization.Contract;
using Shared.Authorization.Infrastructure;
using Shared.Authorization.Service;

namespace Shared.Authorization.Extension;

/// <summary>
/// Provides extension methods for registering authorization-related services into the application's dependency injection container.
/// </summary>
public static class AuthServiceExtension
{
    /// <summary>
    /// Registers the services required by the shared authorization library.
    /// </summary>
    /// <param name="services">
    /// The <see cref="IServiceCollection"/> used to register application services.
    /// </param>
    /// <param name="configuration">
    /// The application configuration instance.
    /// </param>
    /// <returns>
    /// The same <see cref="IServiceCollection"/> instance so that additional service registrations can be chained.
    /// </returns>
    /// <remarks>
    /// This method registers the following services:
    /// <list type="bullet">
    /// <item>
    /// <description>
    /// <see cref="IUserContext"/> implemented by <see cref="UserContext"/>.
    /// </description>
    /// </item>
    /// <item>
    /// <description>
    /// <see cref="IAuthorizationService"/> implemented by
    /// <see cref="AuthorizationService"/>.
    /// </description>
    /// </item>
    /// </list>
    /// Both services are registered with a scoped lifetime, ensuring a separate instance is created for each HTTP request.
    /// </remarks>
    public static IServiceCollection ConfigureAuthorizationService(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddScoped<IUserContext, UserContext>();
        services.AddScoped<IAuthorizationService, AuthorizationService>();

        return services;
    }
}