using System.Diagnostics;
using NLog;

namespace SimplePerformanceMeter.Loggers
{
    public abstract class NLogger : IMonitorLogger
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly bool _enabled;

        protected NLogger(bool enabled)
        {
            _enabled = enabled;
        }

        protected bool ValidateProcess(Process process)
        {
            if (process != null) return true;

            Logger.Warn("Failed to log because the process is NULL");
            return false;
        }

        public void Log(Process process)
        {
            if (!_enabled) return;
            if (!ValidateProcess(process)) return;
            LogOnValidatedProcess(process);
        }

        protected abstract void LogOnValidatedProcess(Process process);
    }
}