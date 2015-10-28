using System.Diagnostics;
using SimplePerformanceMeter.Environment;

namespace SimplePerformanceMeter.Loggers
{
    public class MemoryLogger : NLogger
    {
        public MemoryLogger(ISettings settings) : base(settings.Memory)
        {

        }

        protected override void LogOnValidatedProcess(Process process)
        {
            var memory = process.PrivateMemorySize64 / 1024 / 1024;
            Logger.Info($"{process.ProcessName} uses {memory}MB");
        }
    }
}
