namespace Shared.Logger.Contract;

public interface ICustomLogFactory
{
    ILoggerManager<T> CreateLogger<T>();
}