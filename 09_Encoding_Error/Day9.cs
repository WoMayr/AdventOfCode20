using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace _09_Encoding_Error
{
    public class Day9 : BaseDay
    {
        public int PreambleSize { get; set; } = 25;


        public long FirstOneOut { get; set; }
        public long[] EncryptionWeakness { get; set; }
        public long WeaknessChecksum => EncryptionWeakness.Min() + EncryptionWeakness.Max();

        public bool CheckValid(long[] numbers, int indexToCheck)
        {
            var toCheck = numbers[indexToCheck];

            for (int i = indexToCheck - PreambleSize; i < indexToCheck; i++)
            {
                var searchValue = toCheck - numbers[i];
                for (int j = i + 1; j < indexToCheck; j++)
                {
                    if (numbers[j] == searchValue)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public void Run1()
        {
            Input = Input.Replace("\r", "");
            var numbers = Input
                .Split('\n')
                .Select(long.Parse)
                .ToArray();

            for (var i = PreambleSize; i < numbers.Length; i++)
            {
                if (!CheckValid(numbers, i))
                {
                    FirstOneOut = numbers[i];
                    break;
                }
            }
        }

        public void Run2()
        {
            // Part 1
            Input = Input.Replace("\r", "");
            var numbers = Input
                .Split('\n')
                .Select(long.Parse)
                .ToArray();

            int firstOneOutIndex = -1;
            for (var i = PreambleSize; i < numbers.Length; i++)
            {
                if (!CheckValid(numbers, i))
                {
                    FirstOneOut = numbers[i];
                    firstOneOutIndex = i;
                    break;
                }
            }

            // Part 2
            if (firstOneOutIndex < 0)
            {
                throw new ArgumentException("The numbers are all correct");
            }

            for (var i = 0; i < firstOneOutIndex && EncryptionWeakness == null; i++)
            {
                var sum = 0L;

                for (var j = i; j < firstOneOutIndex && sum < FirstOneOut; j++)
                {
                    sum += numbers[j];

                    if (sum == FirstOneOut)
                    {
                        var length = j - i + 1;
                        EncryptionWeakness = new long[length];
                        for (var k = 0; k < length; k++)
                        {
                            EncryptionWeakness[k] = numbers[i + k];
                        }
                    }
                }
            }
        }
    }
}
