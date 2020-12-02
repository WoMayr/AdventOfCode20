using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02_Password_Philosophy
{
    public class InputLine
    {
        private static readonly Regex ParseRegex = new Regex(@"^(\d+)-(\d+) (\w): (\w+)$");

        public int Min { get; private set; }
        public int Max { get; private set; }
        public char Character { get; private set; }

        public string Password { get; private set; }
        public string Raw { get; private set; }

        public static InputLine FromInputLine(string line)
        {
            var match = ParseRegex.Match(line);
            if (!match.Success)
            {
                throw new ArgumentException($"Line: \"{line}\" is invalid! It does not match the parse rule!");
            }

            var min = int.Parse(match.Groups[1].Value);
            var max = int.Parse(match.Groups[2].Value);
            var characterStr = match.Groups[3].Value;
            if (characterStr.Length > 1)
            {
                throw new ArgumentException($"Line: \"{line}\" is invalid! Policycharacter is longer than 1");
            }
            var character = characterStr[0];
            var password = match.Groups[4].Value;

            return new InputLine
            {
                Raw = line,
                Min = min,
                Max = max,
                Character = character,
                Password = password
            };
        }


        public bool IsValid()
        {
            var charCount = Password.Count(c => c == Character);
            return charCount >= Min && charCount <= Max;
        }
    }
}
