using Serilog;
using Shared.Logger.Contract;

namespace Shared.Logger.Infrastructure;

public class CustomLogFactory : ICustomLogFactory
{
    private readonly ILogger _logger;

    public CustomLogFactory(ILogger logger)
    {
        _logger = logger;
    }

    public ILoggerManager<T> CreateLogger<T>()
    {
        return new LoggerManager<T>(_logger);
    }
}