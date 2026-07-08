using Serilog.Core;
using Serilog.Events;

namespace Shared.Logger.Infrastructure;

/// <summary>
/// Enriches log events with the name of the class that generated
/// the log entry by extracting it from the Serilog <c>SourceContext</c>
/// property.
/// </summary>
public class SourceContextEnricher : ILogEventEnricher
{
    private const string PropertyName = "SourceContext";

    /// <summary>
    /// Adds the <c>ClassName</c> property to the specified log event.
    /// If the <c>SourceContext</c> property is available, the class name
    /// is extracted from it; otherwise, the value <c>Unknown</c> is used.
    /// </summary>
    /// <param name="logEvent">
    /// The log event to enrich.
    /// </param>
    /// <param name="propertyFactory">
    /// The factory used to create log event properties.
    /// </param>
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        if (logEvent.Properties.TryGetValue(PropertyName, out var sourceContext))
        {
            logEvent.AddPropertyIfAbsent(
                propertyFactory.CreateProperty("ClassName", sourceContext.ToString().Trim('"').Split('.').Last()));
        }
        else
        {
            logEvent.AddPropertyIfAbsent(
                propertyFactory.CreateProperty("ClassName", "Unknown"));
        }
    }
}