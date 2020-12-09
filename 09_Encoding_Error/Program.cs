using Microsoft.Extensions.Logging;
using System;
using Utils;

namespace _09_Encoding_Error
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseProgram.BaseMain<Day9, Program>(DayMain);
        }

        private static void DayMain(Day9 day, IServiceProvider services, ILogger<Program> logger)
        {
            day.Run1();
            logger.LogWarning("\nFirst one out: {FirstOneOut}", day.FirstOneOut);

            day.Run2();
            logger.LogWarning("\nWeakness Checksum: {Checksumm}", day.WeaknessChecksum);
        }
    }
}
