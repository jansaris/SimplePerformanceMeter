using System.Diagnostics;

namespace SimplePerformanceMeter.Loggers
{
    public class ProcessorLogger : NLogger
    {
        public override void Log(Process process)
        {
            if (!ValidateProcess(process)) return;
            Logger.Info($"{process.ProcessName} uses 1%");
        }
    }
}