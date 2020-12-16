using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Utils;

namespace _13_Shuttle_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseProgram.BaseMain<Day13, Program>(DayMain);
        }

        private static void DayMain(Day13 day, IServiceProvider services, ILogger<Program> logger)
        {
            day.Run1();
            logger.LogInformation("\nBus to take: {BusId} Waittime: {Waittime} Checksum: {Checksum}", day.BusId, day.BusId, day.Part1Check);

            day.Run2();
            logger.LogInformation("\nFirst cascading timestamp: {CascadingTimestamp}", day.EarliestCascadeTimestamp);
        }
    }
}
