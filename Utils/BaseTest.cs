using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace Utils
{
    public abstract class BaseTest<T> where T : class
    {
        protected T subject;

        public BaseTest(ITestOutputHelper output)
        {
            var services = Setup.SetupDependencyInjection<T>(output, ConfigureServices);
            subject = services.GetRequiredService<T>();
        }

        protected virtual void ConfigureServices(IServiceCollection services) { }
    }
}
