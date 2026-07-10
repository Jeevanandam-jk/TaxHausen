namespace Shared.Authorization.Contract;

/// <summary>
/// Defines methods for performing authorization checks for the current user.
/// </summary>
public interface IAuthorizationService
{
    /// <summary>
    /// Determines whether the current authenticated user is authorized to access the specified API.
    /// </summary>
    /// <param name="apiKey">The unique identifier or key of the API whose access permission is being validated.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous authorization operation.
    /// The task result is <see langword="true"/> if the user has permission
    /// to access the specified API; otherwise, <see langword="false"/>.
    /// </returns>
    Task<bool> HasApiPermissionAsync(string apiKey);
}