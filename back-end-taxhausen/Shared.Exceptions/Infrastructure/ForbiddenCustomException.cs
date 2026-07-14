using Microsoft.AspNetCore.Http;

namespace Shared.Exceptions.Infrastructure;

/// <summary>
/// Represents an exception that is thrown when the authenticated user does not have permission to access the requested resource.
/// </summary>
/// <remarks>
/// This exception corresponds to the HTTP 403 (Forbidden) status code.
/// It is typically thrown when the user's identity has been authenticated,
/// but the user does not have the required authorization to perform the requested operation.
/// </remarks>
[Serializable]
public sealed class ForbiddenCustomException : BaseCustomException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ForbiddenException"/> class.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    /// <param name="description">
    /// A detailed description of the exception.
    /// </param>
    /// <param name="customCode">
    /// A custom application-specific error code used to uniquely identify the exception.
    /// </param>
    public ForbiddenCustomException(
        string message,
        string description,
        string customCode)
        : base(
            message,
            description,
            StatusCodes.Status403Forbidden,
            customCode)
    {
    }
}