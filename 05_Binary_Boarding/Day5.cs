using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Binary_Boarding
{
    public class Day5
    {
        public string Input { get; set; }

        public int MaxSeatId { get; set; }
        public int MySeatId { get; set; }

        public void Run1()
        {
            var boardingPasses = Input
                .Split('\n')
                .Select(s => new BoardingPass { PositionString = s.Trim() })
                .ToList();

            MaxSeatId = boardingPasses.Max(bp => bp.SeatId);
        }


        public void Run2()
        {
            var occupiedSeats = new bool[128 * 8];

            var boardingPasses = Input
                .Split('\n')
                .Select(s => new BoardingPass { PositionString = s.Trim() })
                .ToList();

            // Tick off occupied seats
            foreach (var bp in boardingPasses)
            {
                occupiedSeats[bp.SeatId] = true;
            }

            // Find my seat
            for (int i = 1; i < occupiedSeats.Length - 1; i++)
            {
                if (occupiedSeats[i - 1] && !occupiedSeats[i] && occupiedSeats[i + 1])
                {
                    MySeatId = i;
                    break;
                }
            }
        }
    }
}
