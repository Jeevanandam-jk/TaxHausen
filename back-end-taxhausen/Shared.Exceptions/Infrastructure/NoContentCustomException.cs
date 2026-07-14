using Microsoft.AspNetCore.Http;

namespace Shared.Exceptions.Infrastructure;

/// <summary>
/// Represents an exception that is thrown when a request is processed successfully but there is no content to return.
/// </summary>
/// <remarks>
/// This exception corresponds to the HTTP 204 status code. It is typically used when an operation completes successfully and
/// the response does not contain any data.
/// </remarks>
[Serializable]
public sealed class NoContentCustomException : BaseCustomException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoContentException"/> class.
    /// </summary>
    /// <param name="message">
    /// The message that describes the reason for the exception.
    /// </param>
    /// <param name="description">
    /// A detailed description of the exception.
    /// </param>
    /// <param name="customCode">
    /// A custom application-specific error code used to uniquely identify the exception.
    /// </param>
    public NoContentCustomException(
        string message,
        string description,
        string customCode)
        : base(
            message,
            description,
            StatusCodes.Status204NoContent,
            customCode)
    {
    }
}