using IdentityService.Infrastructure.Persistence.ApplicationContext;
using IdentityService.Infrastructure.Persistence.SeedData;
using Microsoft.EntityFrameworkCore;
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

    /// <summary>
    /// Initializes the default seed data for the Identity Service database.
    /// </summary>
    /// <param name="serviceProvider">
    /// The application's service provider used to resolve the required services for database seeding.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous seed initialization operation.
    /// </returns>
    public static async Task InitializeSeedData(this IServiceProvider serviceProvider)
    {
        await SeedData.InitializeAsync(serviceProvider);
    }

    /// <summary>
    /// Applies all pending Entity Framework Core migrations to the Identity Service database.
    /// </summary>
    /// <param name="serviceProvider">
    /// The application's service provider used to resolve the database context.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous migration operation.
    /// </returns>
    public static async Task ApplyPendingMigrations(this IServiceProvider serviceProvider)
    {
        IServiceScope scope = serviceProvider.CreateScope();

        IdentityDbContext dbContext =
            scope.ServiceProvider.GetRequiredService<IdentityDbContext>();

        await dbContext.Database.MigrateAsync();
    }
}