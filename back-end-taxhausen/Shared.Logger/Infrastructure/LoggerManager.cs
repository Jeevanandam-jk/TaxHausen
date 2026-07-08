using Serilog;
using Shared.Logger.Contract;

namespace Shared.Logger.Infrastructure;

/// <summary>
/// Provides a strongly typed logger implementation that wraps Serilog
/// and exposes methods for writing log entries at different severity levels.
/// </summary>
/// <typeparam name="T">
/// The type associated with the logger. This type is used to provide
/// contextual information, such as the class name, in log entries.
/// </typeparam>
public class LoggerManager<T> : ILoggerManager<T>
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoggerManager{T}"/> class.
    /// </summary>
    /// <param name="logger">
    /// The base Serilog logger used to create a logger instance with
    /// the context of the specified type.
    /// </param>
    public LoggerManager(ILogger logger)
    {
        _logger = logger.ForContext<T>();
    }

    public void LogInformation(string message, params object[] args)
        => _logger.Information(message, args);

    /// <inheritdoc/>
    public void LogWarning(string message, params object[] args)
        => _logger.Warning(message, args);

    /// <inheritdoc/>
    public void LogError(string message, Exception? exception = null, params object[] args)
    {
        if (exception != null)
            _logger.Error(exception, message, args);
        else
            _logger.Error(message, args);
    }

    /// <inheritdoc/>
    public void LogDebug(string message, params object[] args)
        => _logger.Debug(message, args);

    /// <inheritdoc/>
    public void LogCritical(string message, Exception? exception = null, params object[] args)
    {
        if (exception != null)
            _logger.Fatal(exception, message, args);
        else
            _logger.Fatal(message, args);
    }
}