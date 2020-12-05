using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Utils;

namespace _05_Binary_Boarding
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = Setup.SetupDependencyInjection<Day5>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            var day = services.GetRequiredService<Day5>();
            day.Input = File.ReadAllText("input.txt");

            //day.Run1();
            day.Run2();

            logger.LogInformation("\r\nMax SeatId: {MaxSeatId}", day.MaxSeatId);
            logger.LogInformation("\r\nMy SeatId: {MySeatId}", day.MySeatId);
        }
    }
}
