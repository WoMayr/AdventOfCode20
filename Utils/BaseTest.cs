using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit.Abstractions;

namespace Utils
{
    public abstract class BaseTest<T> where T : class
    {
        protected T subject;
        protected IServiceProvider services;

        public BaseTest(ITestOutputHelper output)
        {
            services = Setup.SetupDependencyInjection<T>(output, ConfigureServices);
            subject = services.GetRequiredService<T>();
        }

        protected virtual void ConfigureServices(IServiceCollection services) { }
    }
}
