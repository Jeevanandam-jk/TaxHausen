using Microsoft.AspNetCore.Http;

namespace Shared.Exceptions.Infrastructure;

/// <summary>
/// Represents an exception that is thrown when authentication is required or the provided authentication credentials are invalid.
/// </summary>
/// <remarks>
/// This exception corresponds to the HTTP 401 (Unauthorized) status code.
/// It is typically thrown when a request does not contain a valid access token or the user's identity cannot be authenticated.
/// </remarks>
[Serializable]
public sealed class UnAuthorizedCustomException : BaseCustomException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UnAuthorizedException"/> class.
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
    public UnAuthorizedCustomException(
        string message,
        string description,
        string customCode)
        : base(
            message,
            description,
            StatusCodes.Status401Unauthorized,
            customCode)
    {
    }
}