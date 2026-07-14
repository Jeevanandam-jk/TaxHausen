namespace Shared.Exceptions.Infrastructure;

/// <summary>
/// Represents the base class for all custom application exceptions.
/// </summary>
/// <remarks>
/// This exception extends the standard <see cref="Exception"/> class by
/// providing additional information such as an HTTP status code, a custom application-specific error code, and a detailed description.
/// All custom exceptions in the application should inherit from this class.
/// </remarks>
[Serializable]
public class BaseCustomException : Exception
{
    /// <summary>
    /// Gets the HTTP status code associated with the exception.
    /// </summary>
    public int Code { get; }

    /// <summary>
    /// Gets the application-specific error code used to uniquely identify exception.
    /// </summary>
    public string CustomCode { get; }

    /// <summary>
    /// Gets a detailed description of the exception.
    /// </summary>
    public string Description { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseCustomException"/> class.
    /// </summary>
    /// <param name="message">
    /// The error message that explains the reason for the exception.
    /// </param>
    /// <param name="description">
    /// A detailed description of the exception.
    /// </param>
    /// <param name="code">
    /// The HTTP status code associated with the exception.
    /// </param>
    /// <param name="customCode">
    /// A custom application-specific error code used to uniquely identify the exception.
    /// </param>
    public BaseCustomException(
        string message,
        string description,
        int code,
        string customCode)
        : base(message)
    {
        Code = code;
        CustomCode = customCode;
        Description = description;
    }
}