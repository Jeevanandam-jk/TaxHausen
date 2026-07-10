using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Shared.Authorization.Contract;

namespace Shared.Authorization.Attribute;

/// <summary>
/// Represents a custom authorization attribute that performs permission-based authorization for APIs.
///
/// This attribute validates whether the current authenticated user has the required permission before allowing the request to execute.
/// If the required permission is not granted, the request is terminated
/// with a <see cref="ForbidResult"/> (HTTP 403 Forbidden).
///
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public sealed class CustomAuthorizeAttribute : System.Attribute, IAsyncAuthorizationFilter
{
    private readonly string _permission;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomAuthorizeAttribute"/> class.
    /// </summary>
    /// <param name="permission">
    /// The permission required to access the decorated controller or action.
    /// </param>
    public CustomAuthorizeAttribute(string permission)
    {
        _permission = permission;
    }

    /// <summary>
    /// Executes the authorization logic asynchronously.
    /// </summary>
    /// <param name="context">
    /// The authorization filter context containing the current HTTP request, route data, and action information.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous authorization operation.
    /// </returns>
    /// <remarks>
    /// This method resolves <see cref="IAuthorizationService"/> from the
    /// dependency injection container and checks whether the current user has the required API permission.
    ///
    /// If the permission check fails, the request is short-circuited by
    /// assigning a <see cref="ForbidResult"/> to
    /// <see cref="AuthorizationFilterContext.Result"/>.
    /// </remarks>
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        IAuthorizationService authorizationService =
            context.HttpContext.RequestServices.GetRequiredService<IAuthorizationService>();

        bool hasPermission =
            await authorizationService.HasApiPermissionAsync(_permission);

        if (!hasPermission)
        {
            context.Result = new ForbidResult();
        }
    }
}