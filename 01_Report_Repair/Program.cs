using System;
using System.IO;
using System.Linq;

namespace _01_Report_Repair
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = File.ReadAllLines("input.txt").Select(int.Parse).ToArray();

            //for (var i = 0; i < input.Length; i++)
            //{
            //    var numA = input[i];
            //    for (var j = i + 1; j < input.Length; j++)
            //    {
            //        var numB = input[j];

            //        if (numA + numB == 2020)
            //        {
            //            Console.WriteLine($"Found numbers {numA} and {numB}: {numA * numB}");
            //            return;
            //        }
            //    }
            //}

            for (var i = 0; i < input.Length; i++)
            {
                var numA = input[i];
                for (var j = i + 1; j < input.Length; j++)
                {
                    var numB = input[j];

                    for (var k = j + 1; k < input.Length; k++)
                    {
                        var numC = input[k];
                        if (numA + numB + numC == 2020)
                        {
                            Console.WriteLine($"Found numbers {numA}, {numB} and {numC}: {numA * numB * numC}");
                            return;
                        }
                    }
                }
            }
        }
    }
}
