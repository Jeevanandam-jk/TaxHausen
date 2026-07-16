using Shared.Authorization.Contract;
using Shared.Common.Constant;

namespace Shared.Authorization.Infrastructure;

/// <summary>
/// Provides an in-memory implementation of <see cref="IUserContext"/> for storing information about the current authenticated user during
/// the lifetime of an HTTP request.
/// </summary>
public class UserContext : IUserContext
{
    private Guid _userId = Guid.Empty;
    private Guid _roleId = Guid.Empty;
    private string _roleName = string.Empty;
    private string _userName = string.Empty;
    private string _applicationName = string.Empty;
    private string _token = string.Empty;
    private int _taxYearId = Constants.Numbers.NUM_ONE;
    private Guid _tenantId = Guid.Empty;
    private List<string> _permission = new();

    /// <summary>
    /// Stores the unique identifier of the current user.
    /// </summary>
    /// <param name="userId">The unique identifier of the authenticated user.</param>
    public void SetUserId(Guid userId) => _userId = userId;

    /// <summary>
    /// Stores the unique identifier of the user's role.
    /// </summary>
    /// <param name="roleId">The unique identifier of the user's role.</param>
    public void SetRoleId(Guid roleId) => _roleId = roleId;

    /// <summary>
    /// Stores the name of the user's role.
    /// </summary>
    /// <param name="roleName">The name of the user's role.</param>
    public void SetRoleName(string roleName) => _roleName = roleName;

    /// <summary>
    /// Stores the username of the authenticated user.
    /// </summary>
    /// <param name="userName">The username of the authenticated user.</param>
    public void SetUserName(string userName) => _userName = userName;

    /// <summary>
    /// Stores the name of the application associated with the current request.
    /// </summary>
    /// <param name="applicationName">The application name.</param>
    public void SetApplicationName(string applicationName) => _applicationName = applicationName;

    /// <summary>
    /// Retrieves the unique identifier of the current user.
    /// </summary>
    /// <returns>The unique identifier of the authenticated user.</returns>
    public Guid GetUserId() => _userId;

    /// <summary>
    /// Retrieves the unique identifier of the user's role.
    /// </summary>
    /// <returns>The unique identifier of the user's role.</returns>
    public Guid GetRoleId() => _roleId;

    /// <summary>
    /// Retrieves the name of the user's role.
    /// </summary>
    /// <returns>The name of the user's role.</returns>
    public string GetRoleName() => _roleName;

    /// <summary>
    /// Retrieves the username of the authenticated user.
    /// </summary>
    /// <returns>The username of the authenticated user.</returns>
    public string GetUserName() => _userName;

    /// <summary>
    /// Retrieves the application name associated with the current request.
    /// </summary>
    /// <returns>The application name.</returns>
    public string GetApplicationName() => _applicationName;

    /// <summary>
    /// Retrieves the tax year identifier associated with the current request.
    /// </summary>
    /// <returns>The tax year identifier.</returns>
    public int GetTaxYearId()
    {
        return _taxYearId;
    }

    /// <summary>
    /// Stores the tax year identifier associated with the current request.
    /// </summary>
    /// <param name="taxYearId">The tax year identifier.</param>
    public void SetTaxYearId(int taxYearId)
    {
        _taxYearId = taxYearId;
    }

    /// <summary>
    /// Stores the authentication token of the current user.
    /// </summary>
    /// <param name="token">The authentication token.</param>
    public void SetToken(string token)
    {
        _token = token;
    }

    /// <summary>
    /// Retrieves the authentication token of the current user.
    /// </summary>
    /// <returns>The authentication token.</returns>
    public string GetToken()
    {
        return _token;
    }

    /// <summary>
    /// Stores the tenant identifier associated with the current user.
    /// </summary>
    /// <param name="tenantId">The tenant identifier.</param>
    public void SetTenantId(Guid tenantId)
    {
        _tenantId = tenantId;
    }

    /// <summary>
    /// Retrieves the tenant identifier associated with the current user.
    /// </summary>
    /// <returns>The tenant identifier.</returns>
    public Guid GetTenantId()
    {
        return _tenantId;
    }

    /// <summary>
    /// Stores the permissions assigned to the current user.
    /// </summary>
    /// <param name="permissions">
    /// A collection of permissions assigned to the authenticated user.
    /// </param>
    public void SetPermission(List<string> permissions)
    {
        _permission = permissions;
    }

    /// <summary>
    /// Retrieves the permissions assigned to the current user.
    /// </summary>
    /// <returns>
    /// A collection of permissions assigned to the authenticated user.
    /// </returns>
    public List<string> GetPermission()
    {
        return _permission;
    }
}