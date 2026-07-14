using Microsoft.AspNetCore.Http;

namespace Shared.Exceptions.Infrastructure;

/// <summary>
/// Represents an exception that is thrown when an unexpected error occurs while processing a request.
/// </summary>
/// <remarks>
/// This exception corresponds to the HTTP 500 status code. It is typically used when an unhandled or unexpected
/// server-side error prevents the request from being completed.
/// </remarks>
[Serializable]
public sealed class InternalServerCustomException : BaseCustomException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InternalServerException"/> class.
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
    public InternalServerCustomException(
        string message,
        string description,
        string customCode)
        : base(
            message,
            description,
            StatusCodes.Status500InternalServerError,
            customCode)
    {
    }
}