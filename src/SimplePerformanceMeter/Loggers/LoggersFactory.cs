using System.Collections.Generic;
using SimplePerformanceMeter.Configuration;

namespace SimplePerformanceMeter.Loggers
{
    public static class LoggersFactory
    {
        public static IEnumerable<IMonitorLogger> GetActiveLoggers(ISettings settings)
        {
            if(settings.Memory) yield return new MemoryLogger();
            if (settings.Processor) yield return new ProcessorLogger();
        } 
    }
}