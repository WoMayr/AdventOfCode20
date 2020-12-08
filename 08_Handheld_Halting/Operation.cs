using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08_Handheld_Halting
{
    public record Operation(OperationType Type, int Value)
    {
        private static readonly Regex parseOperationRegex = new Regex(@"^(\w+) ([+-]?\d+)$");
        public static Operation Parse(string input)
        {
            var match = parseOperationRegex.Match(input);

            if (!match.Success)
            {
                throw new ArgumentException($"\"{input}\" is not a valid operation expression!", nameof(input));
            }

            var operation = match.Groups[1].Value;

            var value = int.Parse(match.Groups[2].Value);

            return new Operation(OperationTypeHelper.FromString(operation), value);
        }
    }
}
