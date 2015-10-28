using System;
using Autofac;
using Microsoft.Framework.Runtime;
using SimplePerformanceMeter.Loggers;

namespace SimplePerformanceMeter.Environment
{
    public static class Bootstrapper
    {
        private static IContainer _container = null;

        private static IContainer BuildContainer(IApplicationEnvironment environment)
        {
            NLog.Configure();
            var builder = new ContainerBuilder();
            builder.RegisterType<JsonSettings>().As<ISettings>();
            builder.RegisterType<Monitor>();
            builder.RegisterType<MemoryLogger>().As<IMonitorLogger>();
            builder.RegisterType<ProcessorLogger>().As<IMonitorLogger>();
            builder.RegisterInstance(environment);

            _container = builder.Build();
            return _container;
        }

        internal static IContainer InitializeContainer(IApplicationEnvironment environment)
        {
            return _container ?? (_container = BuildContainer(environment));
        }
    }
}