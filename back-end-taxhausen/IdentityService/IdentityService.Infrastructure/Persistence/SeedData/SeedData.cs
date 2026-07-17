using System.Reflection;
using IdentityService.Infrastructure.Persistence.ApplicationContext;
using Microsoft.Extensions.DependencyInjection;
using Shared.Common.SeedDataHelper;

namespace IdentityService.Infrastructure.Persistence.SeedData;

/// <summary>
/// Provides functionality for seeding the default data required by the Identity Service.
/// </summary>
/// <remarks>
/// This class initializes the master data required by the Identity Service, including features, roles, and role-feature mappings. Each entity is seeded
/// only if its corresponding table does not already contain data.
/// </remarks>
public static class SeedData
{
    /// <summary>
    /// Initializes the default seed data for the Identity Service database.
    /// </summary>
    /// <param name="serviceProvider">
    /// The application's service provider used to resolve the required services for database seeding.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous seed initialization operation.
    /// </returns>
    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        IServiceScope scope = serviceProvider.CreateScope();

        IdentityDbContext dbContext = scope.ServiceProvider.GetRequiredService<IdentityDbContext>();

        Assembly assembly = Assembly.GetExecutingAssembly();

        await SeedHelper.SeedAsync(
            dbContext,
            dbContext.Feature,
            assembly,
            "IdentityService.Infrastructure.Persistence.SeedData.DataFile.Feature.csv");

        await SeedHelper.SeedAsync(
            dbContext,
            dbContext.Role,
            assembly,
            "IdentityService.Infrastructure.Persistence.SeedData.DataFile.Role.csv");

        await SeedHelper.SeedAsync(
            dbContext,
            dbContext.RoleFeature,
            assembly,
            "IdentityService.Infrastructure.Persistence.SeedData.DataFile.RoleFeature.csv");
    }
}