using System.Diagnostics;
using SimplePerformanceMeter.Environment;

namespace SimplePerformanceMeter.Loggers
{
    public class ProcessorLogger : NLogger
    {
        public ProcessorLogger(ISettings settings) : base(settings.Processor)
        {

        }

        protected override void LogOnValidatedProcess(Process process)
        {
            Logger.Info($"{process.ProcessName} uses 1%");
        }
    }
}