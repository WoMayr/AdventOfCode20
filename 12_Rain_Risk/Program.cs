using Microsoft.Extensions.Logging;
using System;
using Utils;

namespace _12_Rain_Risk
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseProgram.BaseMain<Day12, Program>(DayMain);
        }

        private static void DayMain(Day12 day, IServiceProvider services, ILogger<Program> logger)
        {
            day.Run1();
            logger.LogInformation("\nShip is now at: \n\tX: \n\t{X} \n\tY: {Y} \n\tFacing: {Direction}\n\n\tDistance from start: {DistanceFromStart}", day.Ship.X, day.Ship.Y, day.Ship.Direction, day.DistanceFromStart);

            day.Run2();
            logger.LogInformation("\nShip is now at: \n\tX: \n\t{X} \n\tY: {Y} \n\tFacing: {Direction}\n\n\tDistance from start: {DistanceFromStart}", day.Ship.X, day.Ship.Y, day.Ship.Direction, day.DistanceFromStart);
        }
    }
}
