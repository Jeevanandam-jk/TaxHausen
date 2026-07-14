using Microsoft.AspNetCore.Http;

namespace Shared.Exceptions.Infrastructure;

/// <summary>
/// Represents an exception that is thrown when a request cannot be completed because it conflicts with the current state of the resource.
/// </summary>
/// <remarks>
/// This exception corresponds to the HTTP 409 (Conflict) status code.
/// It is typically thrown when an operation would result in a duplicate resource or when the current state of the resource prevents the
/// requested operation from being completed.
/// </remarks>
[Serializable]
public sealed class ConflictCustomException : BaseCustomException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ConflictException"/> class.
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
    public ConflictCustomException(
        string message,
        string description,
        string customCode)
        : base(
            message,
            description,
            StatusCodes.Status409Conflict,
            customCode)
    {
    }
}