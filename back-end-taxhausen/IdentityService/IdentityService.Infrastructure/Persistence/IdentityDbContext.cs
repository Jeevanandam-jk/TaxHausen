using Microsoft.EntityFrameworkCore;

namespace IdentityService.Infrastructure.Persistence;

/// <summary>
/// Represents the Entity Framework Core database context for the Identity Service.
/// </summary>
/// <remarks>
/// This context is responsible for managing the persistence of all identity-related entities, including users, roles, permissions,
/// refresh tokens, and other authentication and authorization data.
/// It also serves as the primary entry point for interacting with the Identity Service database.
/// </remarks>
public class IdentityDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="IdentityDbContext"/> class.
    /// </summary>
    /// <param name="options">
    /// The options to be used by the database context.
    /// </param>
    public IdentityDbContext(DbContextOptions<IdentityDbContext> options)
        : base(options)
    {
    }
}