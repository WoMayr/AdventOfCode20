using Microsoft.Extensions.Logging;
using System;
using Utils;

namespace _15_Rambunctious_Recitation
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseProgram.BaseMain<Day15, Program>(DayMain);
        }

        private static void DayMain(Day15 day, IServiceProvider services, ILogger<Program> logger)
        {
            //day.Run1();
            //logger.LogInformation("\nShip is now at: \n\tX: \n\t{X} \n\tY: {Y} \n\tFacing: {Direction}\n\n\tDistance from start: {DistanceFromStart}", day.Ship.X, day.Ship.Y, day.Ship.Direction, day.DistanceFromStart);

            //day.Run2();
            //logger.LogInformation("\nShip is now at: \n\tX: \n\t{X} \n\tY: {Y} \n\tFacing: {Direction}\n\n\tDistance from start: {DistanceFromStart}", day.Ship.X, day.Ship.Y, day.Ship.Direction, day.DistanceFromStart);
        }
    }
}
