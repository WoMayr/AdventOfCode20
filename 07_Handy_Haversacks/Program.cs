using Microsoft.Extensions.Logging;
using System;
using Utils;

namespace _07_Handy_Haversacks
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseProgram.BaseMain<Day7, Program>(DayMain);
        }

        private static void DayMain(Day7 day, IServiceProvider services, ILogger<Program> logger)
        {
            day.Target = "shiny gold";
            day.TargetQuantity = 1;
        }
    }
}
