using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace _08_Handheld_Halting
{
    public class Day8 : BaseDay
    {
        public Operation[] Program { get; set; }

        /// <summary>
        /// Instruction Poniter
        /// </summary>
        public int IP { get; set; }

        public int Acc { get; set; }

        private void ParseProgram()
        {
            if (Program != null)
            {
                return;
            }

            Input = Input.Replace("\r", "");
            Program = Input
                .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(s => Operation.Parse(s))
                .ToArray();
        }

        private void Step()
        {
            var instruction = Program[IP];

            bool shouldIncrementIp = true;

            switch (instruction.Type)
            {
                case OperationType.Jump:
                    shouldIncrementIp = false;
                    IP += instruction.Value;
                    break;
                case OperationType.Accumulator:
                    Acc += instruction.Value;
                    break;
                case OperationType.Noop:
                    break;
                default:
                    break;
            }

            if (shouldIncrementIp)
            {
                IP++;
            }
        }

        public void Run1()
        {
            ParseProgram();

            var visitedInstructions = new HashSet<int>();

            while (true)
            {
                if (visitedInstructions.Contains(IP))
                {
                    break;
                }

                visitedInstructions.Add(IP);
                Step();
            }
        }


        public void Run2()
        {
            ParseProgram();
            var backupProgram = Program;

            var indizesToChange = backupProgram
                .Select((o, i) => new { Operation = o, Index = i })
                .ToList();

            bool terminatedCorrectly = false;
            foreach (var item in indizesToChange)
            {
                // Apply change to program
                Program = backupProgram
                    .ToArray();
                Program[item.Index] = item.Operation with { Type = item.Operation.Type == OperationType.Jump ? OperationType.Noop : OperationType.Jump };

                // Reset variables
                IP = 0;
                Acc = 0;
                var visitedInstructions = new HashSet<int>();

                // Try if it worked
                while (true)
                {
                    if (IP < 0)
                    {
                        // Trying to execute instruction outside of program range
                        break;
                    }
                    if (IP >= Program.Length)
                    {
                        terminatedCorrectly = true;
                        break;
                    }
                    if (visitedInstructions.Contains(IP))
                    {
                        // Found Loop
                        break;
                    }

                    visitedInstructions.Add(IP);
                    Step();
                }

                if (terminatedCorrectly)
                {
                    break;
                }
            }
        }
    }
}
