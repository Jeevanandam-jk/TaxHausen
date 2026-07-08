using Serilog.Core;
using Serilog.Events;

namespace Shared.Logger.Infrastructure;

public class SourceContextEnricher : ILogEventEnricher
{
    private const string PropertyName = "SourceContext";

    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        if (logEvent.Properties.TryGetValue(PropertyName, out var sourceContext))
        {
            logEvent.AddPropertyIfAbsent(
                propertyFactory.CreateProperty("ClassName", sourceContext.ToString().Split(".")[^1].Split("\"")[0]));
        }
        else
        {
            logEvent.AddPropertyIfAbsent(
                propertyFactory.CreateProperty("ClassName", "Unknown"));
        }
    }
}