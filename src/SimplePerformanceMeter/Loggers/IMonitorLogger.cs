using System.Diagnostics;

namespace SimplePerformanceMeter.Loggers
{
    public interface IMonitorLogger
    {
        void Log(Process process);
    }
}