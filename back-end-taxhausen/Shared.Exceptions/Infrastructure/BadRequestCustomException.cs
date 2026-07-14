using Microsoft.AspNetCore.Http;

namespace Shared.Exceptions.Infrastructure;

/// <summary>
/// Represents an exception that is thrown when a client sends an invalid or malformed request.
/// </summary>
/// <remarks>
/// This exception corresponds to the HTTP 400 (Bad Request) status code.
/// It is typically thrown when the request contains invalid data, missing required information, or fails business validation rules.
/// </remarks>
[Serializable]
public sealed class BadRequestCustomException : BaseCustomException
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestCustomException"/> class.
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
    public BadRequestCustomException(
        string message,
        string description,
        string customCode)
        : base(
            message,
            description,
            StatusCodes.Status400BadRequest,
            customCode)
    {
    }
}