using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Shared.Authorization.Contract;
using Shared.Comon.Constant;
using Shared.Logger.Contract;

namespace Shared.Authorization.Middleware;

/// <summary>
/// Middleware responsible for populating the <see cref="IUserContext"/> with request-specific and authenticated user information.
/// </summary>
/// <remarks>
/// This middleware extracts:
/// <list type="bullet">
/// <item>
/// <description>Authentication token from the <c>Authorization</c> header.</description>
/// </item>
/// <item>
/// <description>Tenant identifier from the <c>tenant-id</c> request header.</description>
/// </item>
/// <item>
/// <description>Tax year identifier from the <c>tax-year-id</c> request header.</description>
/// </item>
/// <item>
/// <description>User information and permissions from JWT claims when the user is authenticated.</description>
/// </item>
/// </list>
/// </remarks>
public class UserContextMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ILoggerManager<UserContextMiddleware> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserContextMiddleware"/> class.
    /// </summary>
    /// <param name="next">
    /// The next middleware in the HTTP request pipeline.
    /// </param>
    public UserContextMiddleware(RequestDelegate next, ILoggerManager<UserContextMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    /// <summary>
    /// Processes the current HTTP request and populates the
    /// <see cref="IUserContext"/> with request and user information.
    /// </summary>
    /// <param name="context">
    /// The current HTTP context.
    /// </param>
    /// <param name="userContext">
    /// The user context used to store request and authentication information.
    /// </param>
    /// <returns>
    /// A task representing the asynchronous middleware operation.
    /// </returns>
    public async Task InvokeAsync(HttpContext context, IUserContext userContext)
    {
        HydrateRequestContext(context, userContext);

        if (context.User.Identity?.IsAuthenticated == true && context.User.Claims.Any())
        {
            HydrateUserContext(context, userContext);
        }

        await _next(context);
    }

    /// <summary>
    /// Populates the <see cref="IUserContext"/> using claims from the
    /// authenticated user's identity.
    /// </summary>
    /// <param name="context">
    /// The current HTTP context.
    /// </param>
    /// <param name="userContext">
    /// The user context to populate.
    /// </param>
    /// <remarks>
    /// This method extracts the following information from the user's claims:
    /// <list type="bullet">
    /// <item><description>User identifier.</description></item>
    /// <item><description>Role identifier.</description></item>
    /// <item><description>Role name.</description></item>
    /// <item><description>Username.</description></item>
    /// <item><description>Application name.</description></item>
    /// <item><description>User permissions.</description></item>
    /// </list>
    /// Missing or invalid values are replaced with sensible defaults where applicable.
    /// </remarks>
    private void HydrateUserContext(HttpContext context, IUserContext userContext)
    {
        try
        {
            ClaimsPrincipal user = context.User;

            string? userIdRaw =
                user.FindFirstValue(ClaimTypes.NameIdentifier)
                ?? user.FindFirstValue(Constants.USER_ID);

            Guid userId = Guid.TryParse(userIdRaw, out Guid parsedUserId)
                ? parsedUserId
                : Guid.Empty;

            userContext.SetUserId(userId);

            string? roleIdRaw = user.FindFirstValue(Constants.ROLE_ID);

            Guid roleId = Guid.TryParse(roleIdRaw, out Guid parsedRoleId)
                ? parsedRoleId
                : Guid.Empty;

            userContext.SetRoleId(roleId);

            string roleName = user.FindFirstValue(Constants.ROLE_NAME) ?? Constants.UNKNOWN;
            userContext.SetRoleName(roleName);

            string userName =
                user.FindFirstValue(ClaimTypes.Name)
                ?? user.FindFirstValue(Constants.USER_NAME)
                ?? Constants.ANONYMOUS;

            userContext.SetUserName(userName);

            string applicationName =
                user.FindFirstValue(Constants.APPLICATION_NAME)
                ?? Constants.UNKNOWN;

            userContext.SetApplicationName(applicationName);

            List<string> permissions = user
                .FindAll(x => x.Type == Constants.PERMISSION)
                .Select(x => x.Value)
                .ToList();

            userContext.SetPermission(permissions);
        }
        catch (Exception ex)
        {
            _logger.LogError("Unhandled exception while hydrating user context", ex);
        }
    }

    /// <summary>
    /// Populates the <see cref="IUserContext"/> using values
    /// extracted from the current HTTP request.
    /// </summary>
    /// <param name="context">
    /// The current HTTP context.
    /// </param>
    /// <param name="userContext">
    /// The user context to populate.
    /// </param>
    /// <remarks>
    /// This method extracts:
    /// <list type="bullet">
    /// <item><description>JWT bearer token from the <c>Authorization</c> header.</description></item>
    /// <item><description>Tenant identifier from the <c>tenant-id</c> header.</description></item>
    /// <item><description>Tax year identifier from the <c>tax-year-id</c> header.</description></item>
    /// </list>
    /// </remarks>
    private void HydrateRequestContext(HttpContext context, IUserContext userContext)
    {
        string? authorization = context.Request.Headers[Constants.AUTHORIZATION].FirstOrDefault();

        if (!string.IsNullOrWhiteSpace(authorization))
        {
            userContext.SetToken(
                authorization.StartsWith(Constants.BEARER, StringComparison.OrdinalIgnoreCase)
                    ? authorization[Constants.BEARER.Length..].Trim()
                    : authorization);
        }

        string? tenantIdRaw = context.Request.Headers[Constants.TENANT_ID].FirstOrDefault();
        string? taxYearIdRaw = context.Request.Headers[Constants.TAX_YEAR_ID].FirstOrDefault();

        if (Guid.TryParse(tenantIdRaw, out Guid tenantId))
            userContext.SetTenantId(tenantId);

        if (int.TryParse(taxYearIdRaw, out int taxYearId))
            userContext.SetTaxYearId(taxYearId);
    }
}