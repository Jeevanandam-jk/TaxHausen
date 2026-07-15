using IdentityService.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Shared.Common.Extension;
using Shared.Comon.Constant;

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

    /// <summary>
    /// Gets or sets the feature entities.
    /// </summary>
    public DbSet<Feature> Feature { get; set; }

    /// <summary>
    /// Gets or sets the refresh token entities.
    /// </summary>
    public DbSet<RefreshToken> RefreshToken { get; set; }

    /// <summary>
    /// Gets or sets the role entities.
    /// </summary>
    public DbSet<Role> Role { get; set; }

    /// <summary>
    /// Gets or sets the role-feature mapping entities.
    /// </summary>
    public DbSet<RoleFeature> RoleFeature { get; set; }

    /// <summary>
    /// Gets or sets the user entities.
    /// </summary>
    public DbSet<User> User { get; set; }

    /// <summary>
    /// Gets or sets the user-role mapping entities.
    /// </summary>
    public DbSet<UserRole> UserRole { get; set; }

    /// <summary>
    /// Configures the entity model for the Identity Service.
    /// This method defines indexes, foreign key relationships, delete behaviors, and applies snake_case naming conventions for tables, columns, keys, foreign keys, and indexes.
    /// </summary>
    /// <param name="modelBuilder">
    /// The builder used to configure the entity model.
    /// </param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Feature>().HasIndex(x => x.FeatureKey).IsUnique();

        modelBuilder.Entity<RefreshToken>().HasIndex(x => x.TokenHash).IsUnique();

        modelBuilder.Entity<Role>().HasIndex(x => x.RoleName).IsUnique();

        modelBuilder.Entity<RoleFeature>().HasIndex(x => new
        {
            x.RoleId,
            x.FeatureId
        }).IsUnique();

        modelBuilder.Entity<User>().HasIndex(x => x.Email).IsUnique();

        modelBuilder.Entity<UserRole>().HasIndex(x => new { x.UserId, x.RoleId }).IsUnique();

        modelBuilder.Entity<RefreshToken>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserRole>()
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserRole>()
            .HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RoleFeature>()
            .HasOne(x => x.Role)
            .WithMany()
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RoleFeature>()
            .HasOne(x => x.Feature)
            .WithMany()
            .HasForeignKey(x => x.FeatureId)
            .OnDelete(DeleteBehavior.Restrict);

        foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
        {
            entity.SetTableName(entity.GetTableName()!.ConvertToSnakeCase());

            StoreObjectIdentifier storeObjectIdentifier = StoreObjectIdentifier.Table(entity.GetTableName()!, entity.GetSchema());
            foreach (IMutableProperty property in entity.GetProperties())
            {
                property.SetColumnName(property.GetColumnName(storeObjectIdentifier)!.ConvertToSnakeCase());
                if (property.ClrType == typeof(DateTime) || property.ClrType == typeof(DateTime?))
                {
                    property.SetColumnType(Constants.TIMESTAMP_WITHOUT_TIME_ZONE);
                }
            }

            foreach (IMutableKey primaryKey in entity.GetKeys())
            {
                primaryKey.SetName(primaryKey.GetName()!.ConvertToSnakeCase());
            }

            foreach (IMutableForeignKey foreignKey in entity.GetForeignKeys())
            {
                foreignKey.SetConstraintName(foreignKey.GetConstraintName()!.ConvertToSnakeCase());
            }

            foreach (IMutableIndex index in entity.GetIndexes())
            {
                index.SetDatabaseName(index.GetDatabaseName()!.ConvertToSnakeCase());
            }
        }
    }
}