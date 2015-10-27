using System.Diagnostics;
using NLog;

namespace SimplePerformanceMeter.Loggers
{
    public abstract class NLogger : IMonitorLogger
    {
        protected static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        protected bool ValidateProcess(Process process)
        {
            if (process == null)
            {
                Logger.Warn("Failed to log because the process is NULL");
                return false;
            }
            return true;
        }

        public abstract void Log(Process process);
    }
}