using Shared.Authorization.Contract;

namespace Shared.Authorization.Service;

/// <summary>
/// Provides authorization functionality by validating whether the current user has access to a specific API or permission.
/// </summary>
/// <remarks>
/// This implementation uses the permissions stored in
/// <see cref="IUserContext"/> to determine whether the current authenticated user is authorized to access a requested resource.
/// </remarks>
public class AuthorizationService : IAuthorizationService
{
    private readonly IUserContext _userContext;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthorizationService"/> class.
    /// </summary>
    /// <param name="userContext">
    /// The user context containing information about the current user, including assigned permissions.
    /// </param>
    public AuthorizationService(IUserContext userContext)
    {
        _userContext = userContext;
    }

    /// <summary>
    /// Determines whether the current user has permission to access the specified API.
    /// </summary>
    /// <param name="apiKey">
    /// The API identifier or permission key to validate.
    /// </param>
    /// <returns>
    /// A task containing <see langword="true"/> if the user has the required permission; otherwise, <see langword="false"/>.
    /// </returns>
    /// <remarks>
    /// The authorization check is performed against the collection of permissions available in the current <see cref="IUserContext"/>.
    /// </remarks>
    public Task<bool> HasApiPermissionAsync(string apiKey)
    {
        bool hasApiPermission = _userContext
            .GetPermission()
            .Contains(apiKey, StringComparer.OrdinalIgnoreCase);

        return Task.FromResult(hasApiPermission);
    }
}