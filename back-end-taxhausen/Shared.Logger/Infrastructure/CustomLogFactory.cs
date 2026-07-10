using Serilog;
using Shared.Logger.Contract;

namespace Shared.Logger.Infrastructure;

/// <summary>
/// Provides a factory for creating strongly typed logger instances.
/// </summary>
public class CustomLogFactory : ICustomLogFactory
{
    private readonly ILogger _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="CustomLogFactory"/> class.
    /// </summary>
    /// <param name="logger">
    /// The base Serilog logger used to create typed logger instances.
    /// </param>
    public CustomLogFactory(ILogger logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Creates a strongly typed logger for the specified type.
    /// </summary>
    /// <typeparam name="T">
    /// The type for which the logger is created. This type is used to
    /// provide contextual information, such as the class name, in log entries.
    /// </typeparam>
    /// <returns>
    /// An <see cref="ILoggerManager{T}"/> instance for the specified type.
    /// </returns>
    public ILoggerManager<T> CreateLogger<T>()
    {
        return new LoggerManager<T>(_logger);
    }
}