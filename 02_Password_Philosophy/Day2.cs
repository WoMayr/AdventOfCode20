using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Password_Philosophy
{
    public class Day2
    {
        private readonly ILogger<Day2> logger;

        public string Input { get; set; }

        public int ValidPasswords { get; private set; }

        public Day2(ILogger<Day2> logger)
        {
            this.logger = logger;
        }

        private void Run(Predicate<InputLine> validCall)
        {
            var inputLines = Input.Split('\n').Select(s => InputLine.FromInputLine(s.Trim())).ToList();

            int count = 0;
            foreach (var line in inputLines)
            {
                if (validCall(line))
                {
                    logger.LogInformation("{line} is valid", line.Raw);
                    count++;
                }
                else
                {
                    logger.LogInformation("{line} is not valid", line.Raw);
                }
            }

            ValidPasswords = count;
        }

        public void Run1()
        {
            Run(line => line.IsValidRule1());
        }
        public void Run2()
        {
            Run(line => line.IsValidRule2());
        }
    }
}
