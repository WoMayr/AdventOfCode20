using Microsoft.Extensions.Logging;
using System;
using Utils;

namespace _11_Seating_System
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseProgram.BaseMain<Day11, Program>(DayMain);
        }

        private static void DayMain(Day11 day, IServiceProvider services, ILogger<Program> logger)
        {
            day.Run1();
            logger.LogInformation("\nOccupied Seats after {Iterations} iterations: {CountSeats}", day.Iterations, day.OccupiedSeats);

            day.Run2();
            logger.LogInformation("\nOccupied Seats after {Iterations} iterations (visible rule): {CountSeats}", day.Iterations, day.OccupiedSeats);
        }
    }
}
