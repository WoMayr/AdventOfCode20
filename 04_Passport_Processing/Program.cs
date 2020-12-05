using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Utils;

namespace _04_Passport_Processing
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = Setup.SetupDependencyInjection<Day4>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            var day = services.GetRequiredService<Day4>();
            day.Input = File.ReadAllText("input.txt");

            //day.Run1();
            day.Run2();

            logger.LogInformation("\r\nResult: {result}", day.ValidPassports);
        }
    }
}
