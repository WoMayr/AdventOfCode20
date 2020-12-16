using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace _13_Shuttle_Search
{
    public class Day13 : BaseDay
    {
        public int BusId { get; set; }
        public int WaitTime { get; set; }
        public int Part1Check => BusId * WaitTime;

        public long EarliestCascadeTimestamp { get; set; }
        public long? MaxTimestampCheck { get; set; }

        private (int, List<int>) ParseInput1()
        {
            var (earliestStart, busIds) = ParseInput2();
            return (earliestStart, busIds.Where(x => x > 0).OrderBy(x => x).ToList());
        }
        private (int, List<int>) ParseInput2()
        {
            Input = Input.Replace("\r", "");

            var parts = Input.Split('\n');

            var earliestStart = int.Parse(parts[0]);
            var availableBusIds = parts[1]
                .Split(',')
                .Select(s => s == "x" ? -1 : int.Parse(s))
                .ToList();

            return (earliestStart, availableBusIds);
        }

        public void Run1()
        {
            var (earliestStart, busIds) = ParseInput1();

            var minWaitTime = int.MaxValue;
            var minIdx = -1;
            for (int i = 0; i < busIds.Count; i++)
            {
                var bus = busIds[i];

                var waitTime = bus - (earliestStart % bus);
                if (waitTime < minWaitTime)
                {
                    minIdx = i;
                    minWaitTime = waitTime;
                }
            }

            BusId = busIds[minIdx];
            WaitTime = minWaitTime;
        }

        private bool CheckPattern(long timestamp, List<(int, int)> offsetList)
        {


            return true;
        }

        public void Run2()
        {
            Run2_BruteForce();
        }

        private static long ModularMultiplicativeInverse(long number, long modulus)
        {
            var y = number % modulus;

            for (long x = 1; x < modulus; x++)
            {
                if (y * x % modulus == 1)
                {
                    return x;
                }
            }

            return 1;
        }

        private void Run2_BruteForce()
        {
            var (_, busIds) = ParseInput2();

            var offsetList = busIds.Select((busId, i) => (busId, i)).Where(x => x.busId > 0).Skip(1).ToList();

            int stepSize = busIds.First();
            long currentTimestamp = stepSize;
            while (true)
            {
                // Check if offsets match
                var foundError = false;
                foreach (var (busId, offset) in offsetList)
                {
                    var waitTime = busId - currentTimestamp % busId;
                    if (waitTime != offset)
                    {
                        foundError = true;
                        break;
                    }
                }

                // We found a match!
                if (!foundError)
                {
                    break;
                }

                currentTimestamp += stepSize;
                if (MaxTimestampCheck != null && currentTimestamp > MaxTimestampCheck)
                {
                    return;
                }
            }

            EarliestCascadeTimestamp = currentTimestamp;
        }
    }
}
