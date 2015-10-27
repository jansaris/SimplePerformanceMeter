using System;
using System.Diagnostics;

namespace SimplePerformanceMeter.Loggers
{
    public class MemoryLogger : NLogger
    {
        public override void Log(Process process)
        {
            if (!ValidateProcess(process)) return;
            var memory = process.PrivateMemorySize64 / 1024 / 1024;
            Logger.Info($"{process.ProcessName} uses {memory}MB");
        }
    }
}
