using System.ComponentModel.DataAnnotations;
using Shared.Common.Model;

namespace IdentityService.Domain.Model;

/// <summary>
/// Represents a user within the TaxHausen application.Thi s entity stores the user's personal information and authentication details.
/// </summary>
public class User : BaseModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the user.
    /// </summary>
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user.
    /// </summary>
    public string FirstName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the last name of the user.
    /// </summary>
    public string LastName { get; set; } = default!;

    /// <summary>
    /// Gets or sets the email address of the user. This value is used as the user's unique login identifier.
    /// </summary>
    public string Email { get; set; } = default!;

    /// <summary>
    /// Gets or sets the hashed password of the user. The plain-text password is never stored in the database.
    /// </summary>
    public string Password { get; set; } = default!;
}