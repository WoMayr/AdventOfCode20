using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace _11_Seating_System
{
    public class Day11 : BaseDay
    {
        public static SeatState[,] ParseFloor(string input)
        {
            input = input.Replace("\r", "");

            var lines = input.Split('\n');
            int width = lines[0].Length;
            int height = lines.Length;

            var result = new SeatState[width, height];
            for (var i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    result[j, i] = lines[i][j] switch
                    {
                        '.' => SeatState.Floor,
                        'L' => SeatState.Empty,
                        '#' => SeatState.Occupied,
                        var x => throw new Exception($"Unknown seat type '{x}'")
                    };
                }
            }

            return result;
        }

        public int Iterations { get; set; }
        public int OccupiedSeats { get; set; }

        public SeatState[,] ParseFloor()
        {
            return ParseFloor(Input);
        }

        private List<SeatState> GetNeighbors(SeatState[,] field, int x, int y)
        {
            int width = field.GetLength(0);
            int height = field.GetLength(1);

            var result = new List<SeatState>();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    if ((i != 0 || j != 0) &&
                        x + i >= 0 && x + i < width &&
                        y + j >= 0 && y + j < height)
                    {
                        result.Add(field[x + i, y + j]);
                    }
                }
            }
            return result;
        }

        private List<SeatState> GetVisibleNeighbors(SeatState[,] field, int x, int y)
        {
            int width = field.GetLength(0);
            int height = field.GetLength(1);

            var result = new List<SeatState>();
            for (int dX = -1; dX <= 1; dX++)
            {
                for (int dY = -1; dY <= 1; dY++)
                {
                    if (dX == 0 && dY == 0)
                    {
                        continue;
                    }

                    int curX = x + dX;
                    int curY = y + dY;

                    while (
                        curX >= 0 && curX < width &&
                        curY >= 0 && curY < height
                    )
                    {
                        if (field[curX, curY] != SeatState.Floor)
                        {
                            result.Add(field[curX, curY]);
                            break;
                        }
                        curX += dX;
                        curY += dY;
                    }
                }
            }
            return result;
        }

        public int Step1(SeatState[,] input, SeatState[,] output)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output), "An output array must be given!");
            }

            int width = input.GetLength(0);
            int height = input.GetLength(1);

            int changes = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var currentState = input[x, y];
                    if (currentState == SeatState.Floor)
                    {
                        continue;
                    }

                    var neighbours = GetNeighbors(input, x, y);
                    int occupiedSeats = neighbours.Count(x => x == SeatState.Occupied);
                    if (currentState == SeatState.Empty &&
                        occupiedSeats == 0)
                    {
                        output[x, y] = SeatState.Occupied;
                        changes++;
                    }
                    else if (currentState == SeatState.Occupied &&
                        occupiedSeats >= 4)
                    {
                        output[x, y] = SeatState.Empty;
                        changes++;
                    }
                    else
                    {
                        output[x, y] = input[x, y];
                    }
                }
            }

            return changes;
        }

        private int CountOccupiedSeats(SeatState[,] floor)
        {
            int width = floor.GetLength(0);
            int height = floor.GetLength(1);

            int count = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (floor[x,y] == SeatState.Occupied)
                    {
                        count++;
                    }
                }
            }

            return count;
        }

        public void Run1()
        {
            var floor = ParseFloor();

            var nextIteration = new SeatState[floor.GetLength(0), floor.GetLength(1)];
            var iterations = 0;

            while (true)
            {
                var changes = Step1(floor, nextIteration);

                // Seating pattern converged
                if (changes == 0)
                {
                    break;
                }

                // The new iteration will be the floor for the next iteraton
                // the old array will be the working place for the next iteration
                var temp = floor;
                floor = nextIteration;
                nextIteration = temp;

                iterations++;
            }

            Iterations = iterations;
            OccupiedSeats = CountOccupiedSeats(floor);
        }


        public int Step2(SeatState[,] input, SeatState[,] output)
        {
            if (output == null)
            {
                throw new ArgumentNullException(nameof(output), "An output array must be given!");
            }

            int width = input.GetLength(0);
            int height = input.GetLength(1);

            int changes = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var currentState = input[x, y];
                    if (currentState == SeatState.Floor)
                    {
                        continue;
                    }

                    var neighbours = GetVisibleNeighbors(input, x, y);
                    int occupiedSeats = neighbours.Count(x => x == SeatState.Occupied);
                    if (currentState == SeatState.Empty &&
                        occupiedSeats == 0)
                    {
                        output[x, y] = SeatState.Occupied;
                        changes++;
                    }
                    else if (currentState == SeatState.Occupied &&
                        occupiedSeats >= 5)
                    {
                        output[x, y] = SeatState.Empty;
                        changes++;
                    }
                    else
                    {
                        output[x, y] = input[x, y];
                    }
                }
            }

            return changes;
        }

        public void Run2()
        {
            var floor = ParseFloor();

            var nextIteration = new SeatState[floor.GetLength(0), floor.GetLength(1)];
            var iterations = 0;

            while (true)
            {
                var changes = Step2(floor, nextIteration);

                // Seating pattern converged
                if (changes == 0)
                {
                    break;
                }

                // The new iteration will be the floor for the next iteraton
                // the old array will be the working place for the next iteration
                var temp = floor;
                floor = nextIteration;
                nextIteration = temp;

                iterations++;
            }

            Iterations = iterations;
            OccupiedSeats = CountOccupiedSeats(floor);
        }
    }
}
