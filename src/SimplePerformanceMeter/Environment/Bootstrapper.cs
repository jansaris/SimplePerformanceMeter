using Autofac;
using SimplePerformanceMeter.Loggers;

namespace SimplePerformanceMeter.Environment
{
    public static class Bootstrapper
    {
        private static IContainer _container = null;

        public static IContainer InitializeContainer()
        {
            return _container ?? (_container = BuildContainer());
        }

        private static IContainer BuildContainer()
        {
            NLog.Configure();
            var builder = new ContainerBuilder();
            builder.RegisterType<Settings>().As<ISettings>();
            builder.RegisterType<Monitor>();
            builder.RegisterType<MemoryLogger>().As<IMonitorLogger>();
            builder.RegisterType<ProcessorLogger>().As<IMonitorLogger>();

            _container = builder.Build();
            return _container;
        }
    }
}