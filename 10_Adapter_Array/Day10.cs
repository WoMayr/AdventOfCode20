using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace _10_Adapter_Array
{
    public class Day10 : BaseDay
    {
        private readonly ILogger<Day10> logger;

        public int DeviceJoltage { get; set; }
        public int[] JoltDifferenceCount { get; set; }
        public List<int[]> PossibleAdapterConfigurations { get; set; }
        public long PossibilityCount { get; set; }
        public Dictionary<int, int[]> PossibleAdapters { get; set; }
        public bool TrackPossibilities { get; internal set; }

        private Dictionary<int, List<int[]>> subLists;

        public Day10(ILogger<Day10> logger)
        {
            this.logger = logger;
        }

        private int[] ReadInput()
        {
            Input = Input.Replace("\r", "");
            var adapters = Input
                .Split('\n')
                .Select(int.Parse)
                .OrderBy(x => x)
                .ToArray();

            DeviceJoltage = adapters[adapters.Length - 1] + 3;
            return adapters;
        }

        public void Run1()
        {
            int[] adapters = ReadInput();

            JoltDifferenceCount = new int[4];

            int currentJolts = 0;
            foreach (var joltage in adapters)
            {
                logger.LogInformation("Step up from {CurrentJoltage} to {NewJoltage}; Difference: {Difference}", currentJolts, joltage, joltage - currentJolts);
                JoltDifferenceCount[joltage - currentJolts]++;
                currentJolts = joltage;
            }
            JoltDifferenceCount[3]++;
        }

        private int[] GetPossibleAdapters(int currentJoltage, int[] adapters)
        {
            if (PossibleAdapters.TryGetValue(currentJoltage, out var resultArr))
            {
                return resultArr;
            }

            List<int> result = new();
            foreach (var adapter in adapters)
            {
                if (adapter > currentJoltage + 3)
                {
                    break;
                } 
                else if (adapter > currentJoltage && adapter <= currentJoltage + 3)
                {
                    result.Add(adapter);
                }
            }

            resultArr = result.ToArray();
            PossibleAdapters[currentJoltage] = resultArr;
            return resultArr;
        }

        private List<int[]> GetAdapterConfigurations(int currentJoltage, int[] adapters)
        {
            if (subLists.TryGetValue(currentJoltage, out var result))
            {
                logger.LogInformation("Could reuse result from {Joltage}", currentJoltage);
                return result;
            }
            logger.LogInformation("Cache miss for joltage {Joltage}", currentJoltage);
            var backupJoltage = currentJoltage;

            var currentList = new List<int>();
            while (currentJoltage < DeviceJoltage - 3)
            {
                var possibleAdapters = GetPossibleAdapters(currentJoltage, adapters);

                // easy for single adapter
                if (possibleAdapters.Length == 1)
                {
                    var adapter = possibleAdapters[0];
                    currentList.Add(adapter);
                    currentJoltage = adapter;
                }
                else if (possibleAdapters.Length > 1)
                {
                    result = new List<int[]>();
                    subLists[currentJoltage] = result;
                    foreach (var adapter in possibleAdapters)
                    {
                        // Calculate sublists
                        var adapterPossibleConfigurations = GetAdapterConfigurations(adapter, adapters);

                        // Append sublists to result list
                        foreach (var possibleConfig in adapterPossibleConfigurations)
                        {
                            if (TrackPossibilities)
                            {
                                result.Add(currentList.Concat(new[] { adapter }).Concat(possibleConfig).ToArray());
                            }

                            if (backupJoltage == 0)
                            {
                                PossibilityCount++;
                            }
                        }
                    }
                    return result;
                }
                else
                {
                    throw new Exception("No other Adapter to try ...");
                }
            }

            // Boring single choice route
            logger.LogInformation("Finished adapter selection to end from branch {JoltBranch}: {AdapterList}", backupJoltage, currentList);
            return new List<int[]> { currentList.ToArray() };
        }

        public void Run2()
        {
            int[] adapters = ReadInput();

            // Reset memoized properties
            subLists = new();
            PossibleAdapters = new();
            PossibilityCount = 0;

            PossibleAdapterConfigurations = GetAdapterConfigurations(0, adapters);
        }
    }
}
