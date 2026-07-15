using System.ComponentModel.DataAnnotations;
using Shared.Common.Model;

namespace IdentityService.Domain.Model;

/// <summary>
/// Represents a feature that defines a specific action or permission available within the TaxHausen application.
/// </summary>
public class Feature : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the feature.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique key that identifies the feature.
    /// </summary>
    public string FeatureKey { get; set; } = default!;

    /// <summary>
    /// Gets or sets the description of the feature. This field provides additional information about the feature's purpose.
    /// </summary>
    public string Description { get; set; } = default!;
}