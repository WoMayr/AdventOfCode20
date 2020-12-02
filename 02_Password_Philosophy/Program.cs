using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Utils;

namespace _02_Password_Philosophy
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = Setup.SetupDependencyInjection<Day2>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            var day = services.GetRequiredService<Day2>();
            day.Input = File.ReadAllText("input.txt");
            day.Run();

            logger.LogInformation("\r\nResult: {result}", day.ValidPasswords);
        }
    }
}
