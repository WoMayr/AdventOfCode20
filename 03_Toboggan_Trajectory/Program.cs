using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Utils;

namespace _03_Toboggan_Trajectory
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = Setup.SetupDependencyInjection<Day3>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            var day = services.GetRequiredService<Day3>();
            day.Input = File.ReadAllText("input.txt");
            
            //day.Run1();
            day.Run2();

            logger.LogInformation("\r\nResult: {result}", day.EncounteredTrees);
        }
    }
}
