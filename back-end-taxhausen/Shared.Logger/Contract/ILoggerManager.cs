namespace Shared.Logger.Contract;

/// <summary>
/// Defines a contract for a strongly typed logger that provides
/// methods for writing application logs at different severity levels.
/// </summary>
/// <typeparam name="T">
/// The type associated with the logger. This type is used to provide
/// contextual information such as the class name in log entries.
/// </typeparam>
public interface ILoggerManager<T>
{
    /// <summary>
    /// Writes an informational log message.
    /// </summary>
    /// <param name="message">The message template describing the log entry.</param>
    /// <param name="args">The values to substitute into the message template.</param>
    void LogInformation(string message, params object[] args);

    /// <summary>
    /// Writes a warning log message.
    /// </summary>
    /// <param name="message">The message template describing the warning.</param>
    /// <param name="args">The values to substitute into the message template.</param>
    void LogWarning(string message, params object[] args);

    /// <summary>
    /// Writes a debug log message used during development and troubleshooting.
    /// </summary>
    /// <param name="message">The message template describing the debug information.</param>
    /// <param name="args">The values to substitute into the message template.</param>
    void LogDebug(string message, params object[] args);

    /// <summary>
    /// Writes an error log message. An exception can be provided to include
    /// stack trace and exception details in the log.
    /// </summary>
    /// <param name="message">The message template describing the error.</param>
    /// <param name="exception">The exception associated with the error, if any.</param>
    /// <param name="args">The values to substitute into the message template.</param>
    void LogError(string message, Exception? exception = null, params object[] args);

    /// <summary>
    /// Writes a critical log message indicating a severe application failure.
    /// An exception can be provided to include stack trace and exception details.
    /// </summary>
    /// <param name="message">The message template describing the critical failure.</param>
    /// <param name="exception">The exception associated with the critical failure, if any.</param>
    /// <param name="args">The values to substitute into the message template.</param>
    void LogCritical(string message, Exception? exception = null, params object[] args);
}