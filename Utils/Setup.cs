using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Xunit.Abstractions;

namespace Utils
{
    public static class Setup
    {
        public static IServiceProvider SetupDependencyInjection<T>(ITestOutputHelper output, Action<IServiceCollection> customServices = null) where T : class
        {
            return SetupDependencyInjection<T>(services =>
            {
                services.AddLogging(builder => builder.AddProvider(new XUnitLoggerProvider(output)));

                if (customServices != null)
                {
                    customServices(services);
                }
            });
        }

        public static IServiceProvider SetupDependencyInjection<T>(Action<IServiceCollection> customServices = null) where T : class
        {
            var services = new ServiceCollection();

            services.AddLogging(builder => builder
                .AddProvider(new MyConsoleLoggerProvider())
                .AddDebug());

            if (customServices != null)
            {
                customServices(services);
            }

            services.AddTransient<T>();

            return services.BuildServiceProvider();
        }
    }
}
