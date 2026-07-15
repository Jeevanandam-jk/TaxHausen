using System.ComponentModel.DataAnnotations;
using Shared.Common.Model;

namespace IdentityService.Domain.Model;

/// <summary>
/// Represents a role that defines a collection of features assigned to a user within the TaxHausen application.
/// </summary>
public class Role : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the role.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the role.
    /// </summary>
    public string RoleName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the description of the role. This field provides additional information about the role and its purpose.
    /// </summary>
    public string Description { get; set; } = default!;
}