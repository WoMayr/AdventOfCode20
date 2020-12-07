using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace _07_Handy_Haversacks
{
    public class Day7 : BaseDay
    {
        public string Target { get; set; }
        public int TargetQuantity { get; set; }

        public int Possibilities { get; set; }
        public int NeededBags { get; set; }

        private Dictionary<string, BagRule> ParseBagRules()
        {
            Input = Input.Replace("\r", "").Trim();

            var bags = Input
                .Split('\n')
                .Select(l => BagRule.FromInput(l))
                .ToList();

            return BagRule.LinkRules(bags);
        }

        private Dictionary<string, List<BagRule>> ReverseDictionary(Dictionary<string, BagRule> rules)
        {
            var result = new Dictionary<string, List<BagRule>>();

            foreach (var key in rules.Keys)
            {
                // Initialize list for current rule
                var containerList = new List<BagRule>();
                result[key] = containerList;

                foreach (var item in rules)
                {
                    // No recursive bags allowed
                    if (item.Key == key)
                    {
                        continue;
                    }

                    // Find all other rules, that contain this rule
                    foreach (var (rule,_) in item.Value.ContainRules)
                    {
                        if (rule.Container == key)
                        {
                            containerList.Add(item.Value);
                        }
                    }
                }
            }

            return result;
        }

        public void Run1()
        {
            var contentLookup = ParseBagRules();
            var containerLookup = ReverseDictionary(contentLookup);

            var start = contentLookup[Target];
            Queue<BagRule> toProcess = new Queue<BagRule>();
            toProcess.Enqueue(start);

            HashSet<BagRule> alreadyProcessed = new HashSet<BagRule>();
            alreadyProcessed.Add(start);

            while (toProcess.TryDequeue(out var item))
            {
                var possibleContainers = containerLookup[item.Container];
                foreach (var container in possibleContainers)
                {
                    if (!alreadyProcessed.Contains(container))
                    {
                        toProcess.Enqueue(container);
                        alreadyProcessed.Add(container);
                    }
                }
            }

            // Remove 1 as we don't want to carry our shiny bag on its own
            Possibilities = alreadyProcessed.Count() - 1;
        }

        public void Run2()
        {
            var contentLookup = ParseBagRules();

            var start = contentLookup[Target];
            Queue<(BagRule, int)> toProcess = new();
            toProcess.Enqueue((start, TargetQuantity));

            NeededBags = 0;
            while (toProcess.TryDequeue(out var item))
            {
                var (bag, count) = item;

                var contents = bag.ContainRules;
                foreach (var (subBag, subBagCount) in contents)
                {
                    var totalSubBagNeeded = subBagCount * count;
                    NeededBags += totalSubBagNeeded;
                    toProcess.Enqueue((subBag, totalSubBagNeeded));
                }
            }
        }
    }
}
