using System.ComponentModel.DataAnnotations;
using Shared.Common.Model;

namespace IdentityService.Domain.Model;

/// <summary>
/// Represents the mapping between a user and a role. This entity determines which roles are assigned to a specific user.
/// </summary>
public class UserRole : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the user-role mapping.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated user.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated role.
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// Gets or sets the user associated with this mapping.
    /// </summary>
    public User? User { get; set; }

    /// <summary>
    /// Gets or sets the role associated with this mapping.
    /// </summary>
    public Role? Role { get; set; }
}