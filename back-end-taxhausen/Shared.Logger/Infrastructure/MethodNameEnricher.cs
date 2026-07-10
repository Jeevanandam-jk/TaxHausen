using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;

namespace Shared.Logger.Infrastructure;

/// <summary>
/// Enriches log events with the name of the application method
/// from which the log entry originated.
/// </summary>
public class MethodNameEnricher : ILogEventEnricher
{
    /// <summary>
    /// Adds the <c>MethodName</c> property to the log event by inspecting
    /// the current call stack and identifying the first application method.
    /// Framework and logging-related methods are ignored.
    /// </summary>
    /// <param name="logEvent">
    /// The log event to enrich.
    /// </param>
    /// <param name="propertyFactory">
    /// The factory used to create log event properties.
    /// </param>
    public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
    {
        int skipFrames = 2;
        StackTrace stack = new StackTrace();

        for (int i = skipFrames; i < stack.FrameCount; i++)
        {
            System.Reflection.MethodBase method = stack.GetFrame(i)?.GetMethod();
            if (method == null) continue;

            string declaringTypeName = method.DeclaringType?.FullName ?? string.Empty;

            if (declaringTypeName.Contains("Serilog") ||
                declaringTypeName.Contains("Microsoft.Extensions.Logging") ||
                declaringTypeName.Contains("LoggerManager"))
            {
                continue;
            }

            string methodName = method.Name ?? "Unknown";
            if (methodName.Contains("<") && methodName.Contains(">"))
            {
                methodName = methodName.Substring(
                    methodName.IndexOf('<') + 1,
                    methodName.IndexOf('>') - methodName.IndexOf('<') - 1);
            }

            LogEventProperty property =
                propertyFactory.CreateProperty("MethodName", methodName);

            logEvent.AddPropertyIfAbsent(property);
            break;
        }
    }
}