using System.ComponentModel.DataAnnotations;
using Shared.Common.Model;

namespace IdentityService.Domain.Model;

/// <summary>
/// Represents the mapping between a role and a feature. This entity determines which features are assigned to a specific role.
/// </summary>
public class RoleFeature : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the role-feature mapping.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated role.
    /// </summary>
    public Guid RoleId { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the associated feature.
    /// </summary>
    public Guid FeatureId { get; set; }

    /// <summary>
    /// Gets or sets the role associated with this mapping.
    /// </summary>
    public Role? Role { get; set; }

    /// <summary>
    /// Gets or sets the feature associated with this mapping.
    /// </summary>
    public Feature? Feature { get; set; }
}