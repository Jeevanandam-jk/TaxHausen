namespace Shared.Logger.Contract;

/// <summary>
/// Defines a factory for creating strongly typed logger instances.
/// </summary>
public interface ICustomLogFactory
{
    /// <summary>
    /// Creates a logger for the specified type.
    /// </summary>
    /// <typeparam name="T">
    /// The type for which the logger is created. This type is used to populate
    /// the log context, such as the class name (<c>SourceContext</c>).
    /// </typeparam>
    /// <returns>
    /// An <see cref="ILoggerManager{T}"/> instance for the specified type.
    /// </returns>
    ILoggerManager<T> CreateLogger<T>();
}