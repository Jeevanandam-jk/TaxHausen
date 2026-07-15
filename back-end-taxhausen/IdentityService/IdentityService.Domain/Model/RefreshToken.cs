using System.ComponentModel.DataAnnotations;
using Shared.Common.Model;

namespace IdentityService.Domain.Model;

/// <summary>
/// Represents a refresh token issued to a user for obtaining a new access token without requiring the user to log in again.
/// </summary>
public class RefreshToken : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the refresh token.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the user to whom the refresh token belongs.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the hashed value of the refresh token. The actual token is never stored in the database for security reasons.
    /// </summary>
    public string TokenHash { get; set; } = default!;

    /// <summary>
    /// Gets or sets the date and time when the refresh token expires. After this time, the token is no longer valid.
    /// </summary>
    public DateTime ExpiresAt { get; set; }

    /// <summary>
    /// Gets or sets the user associated with this refresh token.
    /// </summary>
    public User? User { get; set; }
}