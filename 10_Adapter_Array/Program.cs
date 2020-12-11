using Microsoft.Extensions.Logging;
using System;
using Utils;

namespace _10_Adapter_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseProgram.BaseMain<Day10, Program>(DayMain);
        }

        private static void DayMain(Day10 day, IServiceProvider services, ILogger<Program> logger)
        {
            day.Run1();
            logger.LogInformation("\n1-Jolt * 3-Jolt: {Result}", day.JoltDifferenceCount[1] * day.JoltDifferenceCount[3]);

            day.Run2();
            logger.LogInformation("\nWay to arrange adapters: {CountPossibilities}", day.PossibleAdapterConfigurations.Count);
        }
    }
}
