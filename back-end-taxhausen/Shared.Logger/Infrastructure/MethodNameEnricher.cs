using System.Diagnostics;
using Serilog.Core;
using Serilog.Events;

namespace Shared.Logger.Infrastructure;

public class MethodNameEnricher : ILogEventEnricher
{
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

            string methodName = method.DeclaringType?.Name ?? "Unknown";
            if (methodName.Contains("<") && methodName.Contains(">"))
            {
                methodName = methodName.Substring(methodName.IndexOf('<') + 1, methodName.IndexOf('>') - methodName.IndexOf('<') - 1);
            }

            string classMethodName = $"{methodName}";
            LogEventProperty property = propertyFactory.CreateProperty("MethodName", classMethodName);
            logEvent.AddPropertyIfAbsent(property);
            break;
        }
    }
}