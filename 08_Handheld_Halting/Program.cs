using Microsoft.Extensions.Logging;
using System;
using Utils;

namespace _08_Handheld_Halting
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseProgram.BaseMain<Day8, Program>(DayMain);
        }

        private static void DayMain(Day8 day, IServiceProvider services, ILogger<Program> logger)
        {
            day.Run1();
            logger.LogWarning("\nAcc before first second execution: {Acc}", day.Acc);
            
            day.Run2();
            logger.LogWarning("\nAcc on successful termination: {Acc}", day.Acc);
        }
    }
}
