using System;
using System.Linq;
using NLog;
using SimplePerformanceMeter.Configuration;
using SimplePerformanceMeter.Loggers;

namespace SimplePerformanceMeter
{
    public class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            try
            {
                Configuration.NLog.Configure();
                Logger.Info("Welcome");
                if (args.Length <= 0)
                {
                    Logger.Error("Use: MemoryMeter.exe <appName>");
                    return;
                }
                var monitors = args.Select(CreateMonitor).ToList();
                monitors.AsParallel().ForAll(m => m.Start());

                Console.ReadLine();

                monitors.AsParallel().ForAll(m => m.Stop());
                Logger.Info("Exit");
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex,$"An unhandled exception occured with message: {ex.Message}");
            }
        }

        private static Monitor CreateMonitor(string applicationName)
        {
            var settings = new Settings();
            var loggers = LoggersFactory.GetActiveLoggers(new Settings());
            return new Monitor(applicationName, settings.Delay, loggers);
        }
    }
}
