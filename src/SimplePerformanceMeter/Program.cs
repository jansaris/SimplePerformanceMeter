using System;
using System.Linq;
using Autofac;
using NLog;
using SimplePerformanceMeter.Environment;

namespace SimplePerformanceMeter
{
    public class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static IContainer _container;

        static void Main(string[] args)
        {
            try
            {
                _container = Bootstrapper.InitializeContainer();
                Logger.Info("Welcome");
                if (args.Length <= 0)
                {
                    Logger.Error("Use: MemoryMeter.exe <appName>");
                    return;
                }
                var monitors = args
                    .Select(CreateMonitor)
                    .Select(ActivateMonitor)
                    .ToList();

                Console.ReadLine();

                monitors.AsParallel().ForAll(m => m.Stop());
                Logger.Info("Exit");
            }
            catch (Exception ex)
            {
                Logger.Fatal(ex,$"An unhandled exception occured with message: {ex.Message}");
            }
        }

        private static Monitor ActivateMonitor(Monitor monitor)
        {
            monitor.Start();
            return monitor;
        }

        private static Monitor CreateMonitor(string app)
        {
            var monitor = _container.Resolve<Monitor>(new NamedParameter("application", app));
            return monitor;
        }
    }
}
