using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Toboggan_Trajectory
{
    public class Day3
    {
        public string Input { get; set; }
        public long EncounteredTrees { get; internal set; }

        private Forest forest;
        private readonly ILogger<Day3> logger;

        private Forest Forest { get => forest ?? (forest = Forest.ParseForest(Input)); }

        public Day3(ILogger<Day3> logger)
        {
            this.logger = logger;
        }

        public long CountTreesForSlope(int xSlope, int ySlope)
        {
            var x = 0;
            var y = 0;

            var count = 0l;
            while (y < Forest.Height)
            {
                if (Forest.IsTree(x, y))
                {
                    count++;
                }

                x += xSlope;
                y += ySlope;
            }

            return count;
        }

        public void Run1()
        {
            EncounteredTrees = CountTreesForSlope(3, 1);
        }

        public void Run2()
        {
            var slopes = new[]
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2),
            };

            EncounteredTrees = 1;
            foreach (var (xSlope, ySlope) in slopes)
            {
                var encounteredTreesOnSlope = CountTreesForSlope(xSlope, ySlope);
                logger.LogInformation("Found {trees} in slope ({x}, {y})", encounteredTreesOnSlope, xSlope, ySlope);
                EncounteredTrees *= encounteredTreesOnSlope;
            }
        }
    }
}
