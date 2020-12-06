using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using Utils;

namespace _06_Custom_Customs
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = Setup.SetupDependencyInjection<Day6>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            var day = services.GetRequiredService<Day6>();
            day.Input = File.ReadAllText("input.txt");

            day.Run1();

            logger.LogInformation("\r\nCount: {CountAllYesAnswersAny}", day.CountOfAllYesAnswers);

            day.Run2();
            logger.LogInformation("\r\nCount: {CountAllYesAnswersAll}", day.CountOfAllYesAnswers);
        }
    }
}
