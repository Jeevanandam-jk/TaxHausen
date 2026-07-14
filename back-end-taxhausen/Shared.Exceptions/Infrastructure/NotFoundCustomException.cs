using Microsoft.AspNetCore.Http;

namespace Shared.Exceptions.Infrastructure;

/// <summary>
/// Represents an exception that is thrown when the requested resource cannot be found.
/// </summary>
/// <remarks>
/// This exception corresponds to the HTTP 404 (Not Found) status code.
/// It is typically thrown when a requested entity or resource does not exist in the system.
/// </remarks>
[Serializable]
public sealed class NotFoundCustomException : BaseCustomException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotFoundException"/> class.
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
    public NotFoundCustomException(
        string message,
        string description,
        string customCode)
        : base(
            message,
            description,
            StatusCodes.Status404NotFound,
            customCode)
    {
    }
}