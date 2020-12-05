using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Passport_Processing
{
    public class Day4
    {
        private readonly ILogger<Day4> logger;

        public string Input { get; set; }

        public int ValidPassports { get; set; }

        public Day4(ILogger<Day4> logger)
        {
            this.logger = logger;
        }

        public void Run1()
        {
            // Normalize line endings
            Input = Input.Replace("\r", "");
            var passports = Input.Split("\n\n");

            ValidPassports = 0;
            for (var i = 0; i < passports.Length; i++)
            {
                var pString = passports[i];
                try
                {
                    var passport = Passport.FromInput(pString);
                    if (passport.HasRequiredFields)
                    {
                        ValidPassports++;
                    }
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Could not process passport {passportIndex}. \"{rawPassport}\"", i, pString);
                }
            }
        }

        public void Run2()
        {
            // Normalize line endings
            Input = Input.Replace("\r", "");
            var passports = Input.Split("\n\n");

            ValidPassports = 0;
            for (var i = 0; i < passports.Length; i++)
            {
                var pString = passports[i];
                try
                {
                    var passport = Passport.FromInput(pString);
                    if (passport.IsValid)
                    {
                        ValidPassports++;
                    }
                }
                catch (Exception e)
                {
                    logger.LogError(e, "Could not process passport {passportIndex}. \"{rawPassport}\"", i, pString);
                }
            }
        }
    }
}
