using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using NLog;
using SimplePerformanceMeter.Loggers;

namespace SimplePerformanceMeter
{
    public class Monitor
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        private readonly string _application;
        private readonly IEnumerable<IMonitorLogger> _loggers;
        private readonly int _delay;

        private bool _stop;
        private Task _job;

        public Monitor(string application, int delay, IEnumerable<IMonitorLogger> loggers)
        {
            _application = application;
            _delay = delay;
            _loggers = loggers;
        }

        public void Start()
        {
            Logger.Info($"Start monitoring {_application}");
            if (_job != null)
            {
                Logger.Warn($"Job for {_application} is already running");
                return;
            }
            _job = Run();
        }

        public void Stop()
        {
            Logger.Info($"Stop monitoring {_application}");
            _stop = true;
            if (_job == null)
            {
                Logger.Warn($"No job is running for {_application}");
                return;
            }

            Logger.Info($"Wait for monitor job on {_application} to finish");
            _job.Wait();
            _job = null;
        }
        private async Task Run()
        {
            while (!_stop)
            {
                LogProcessProperties();
                await Task.Delay(_delay);
            }
        }

        private void LogProcessProperties()
        {
            var proccesses = Process.GetProcessesByName(_application);
            foreach (var proc in proccesses)
            foreach (var logger in _loggers)
            {
                logger.Log(proc);
            }
        }
    }
}