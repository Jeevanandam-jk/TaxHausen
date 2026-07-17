using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Shared.Common.SeedDataHelper;

/// <summary>
/// Provides helper methods for seeding data into the database from embedded CSV resources.
/// </summary>
/// <remarks>
/// This helper reads data from embedded CSV files, maps the records to entity models,
/// and inserts them into the specified database table only if the table does not already contain data.
/// </remarks>
public static class SeedHelper
{
    /// <summary>
    /// Seeds the specified entity table with data from an embedded CSV resource.
    /// </summary>
    /// <typeparam name="TEntity">
    /// The type of entity to be seeded.
    /// </typeparam>
    /// <param name="dbContext">
    /// The database context used to persist the seeded data.
    /// </param>
    /// <param name="dbSet">
    /// The database set representing the entity table to seed.
    /// </param>
    /// <param name="assembly">
    /// The assembly containing the embedded CSV resource.
    /// </param>
    /// <param name="resourceName">
    /// The fully qualified name of the embedded CSV resource.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous seeding operation.
    /// </returns>
    public static async Task SeedAsync<TEntity>(
        DbContext dbContext,
        DbSet<TEntity> dbSet,
        Assembly assembly,
        string resourceName)
        where TEntity : class
    {
        if (await dbSet.AnyAsync())
        {
            return;
        }

        Stream stream = assembly.GetManifestResourceStream(resourceName)
            ?? throw new FileNotFoundException($"Embedded resource '{resourceName}' was not found.");

        IEnumerable<TEntity> data = CsvReaderHelper.ReadCsv<TEntity>(stream);

        await dbSet.AddRangeAsync(data);
        await dbContext.SaveChangesAsync();
    }
}