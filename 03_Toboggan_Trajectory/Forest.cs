using System;
using System.Linq;

namespace _03_Toboggan_Trajectory
{
    public class Forest
    {
        public int Width { get; init; }
        public int Height { get; init; }
        public bool[,] Field { get; init; }

        public static Forest ParseForest(string input)
        {
            var lines = input.Split('\n').Select(s => s.Trim()).ToArray();

            if (lines.Select(s => s.Length).ToHashSet().Count > 1)
            {
                throw new ArgumentException("Input contains lines of different length!");
            }

            var width = lines[0].Length;
            var height = lines.Length;
            var forest = new Forest()
            {
                Width = width,
                Height = height,
                Field = new bool[width, height]
            };

            for (int y = 0; y < height; y++)
            {
                var line = lines[y];
                for (int x = 0; x < width; x++)
                {
                    forest.Field[x, y] = line[x] == '#';
                }
            }

            return forest;
        }

        public bool IsTree(int x, int y)
        {
            var actualX = x % Width;

            return Field[actualX, y];
        }
    }
}
