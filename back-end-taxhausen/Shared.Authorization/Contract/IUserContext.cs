namespace Shared.Authorization.Contract;

/// <summary>
/// Defines methods for storing and retrieving information about the current authenticated user within the request context.
/// </summary>
public interface IUserContext
{
    /// <summary>
    /// Sets the username of the current user.
    /// </summary>
    /// <param name="username">The username of the authenticated user.</param>
    void SetUserName(string username);

    /// <summary>
    /// Gets the username of the current user.
    /// </summary>
    /// <returns>The username of the authenticated user.</returns>
    string GetUserName();

    /// <summary>
    /// Sets the unique identifier of the current user.
    /// </summary>
    /// <param name="userId">The unique identifier of the authenticated user.</param>
    void SetUserId(Guid userId);

    /// <summary>
    /// Gets the unique identifier of the current user.
    /// </summary>
    /// <returns>The unique identifier of the authenticated user.</returns>
    Guid GetUserId();

    /// <summary>
    /// Sets the role name assigned to the current user.
    /// </summary>
    /// <param name="roleName">The name of the user's role.</param>
    void SetRoleName(string roleName);

    /// <summary>
    /// Gets the role name assigned to the current user.
    /// </summary>
    /// <returns>The name of the user's role.</returns>
    string GetRoleName();

    /// <summary>
    /// Sets the unique identifier of the user's role.
    /// </summary>
    /// <param name="roleId">The unique identifier of the role.</param>
    void SetRoleId(Guid roleId);

    /// <summary>
    /// Gets the unique identifier of the user's role.
    /// </summary>
    /// <returns>The unique identifier of the role.</returns>
    Guid GetRoleId();

    /// <summary>
    /// Sets the name of the application associated with the current request.
    /// </summary>
    /// <param name="applicationName">The application name.</param>
    void SetApplicationName(string applicationName);

    /// <summary>
    /// Gets the name of the application associated with the current request.
    /// </summary>
    /// <returns>The application name.</returns>
    string GetApplicationName();

    /// <summary>
    /// Sets the tenant identifier for the current user.
    /// </summary>
    /// <param name="tenantId">The tenant identifier.</param>
    void SetTenantId(Guid tenantId);

    /// <summary>
    /// Gets the tenant identifier for the current user.
    /// </summary>
    /// <returns>The tenant identifier.</returns>
    Guid GetTenantId();

    /// <summary>
    /// Sets the tax year identifier for the current request.
    /// </summary>
    /// <param name="taxYearId">The tax year identifier.</param>
    void SetTaxYearId(int taxYearId);

    /// <summary>
    /// Gets the tax year identifier for the current request.
    /// </summary>
    /// <returns>The tax year identifier.</returns>
    int GetTaxYearId();

    /// <summary>
    /// Sets the permissions assigned to the current user.
    /// </summary>
    /// <param name="permission">The collection of permissions assigned to the user.</param>
    void SetPermission(List<string> permission);

    /// <summary>
    /// Gets the permissions assigned to the current user.
    /// </summary>
    /// <returns>A collection of permissions assigned to the user.</returns>
    List<string> GetPermission();

    /// <summary>
    /// Sets the authentication token for the current user.
    /// </summary>
    /// <param name="token">The authentication token.</param>
    void SetToken(string token);

    /// <summary>
    /// Gets the authentication token for the current user.
    /// </summary>
    /// <returns>The authentication token.</returns>
    string GetToken();
}