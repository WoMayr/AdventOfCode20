using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07_Handy_Haversacks
{
    public class BagRule
    {
        private static readonly Regex bagRuleParseRegex = new Regex(@"^([\w ]+) bags contain (.*)\.$");
        private static readonly Regex bagContainingParseRegex = new Regex(@"^(\d+) ([\w ]+) bags?$");

        public string Container { get; set; }

        public List<(string name, int count)> ContainRulesRaw { get; set; }
        public List<(BagRule bag, int count)> ContainRules { get; set; }


        public static BagRule FromInput(string input)
        {
            var outerMatch = bagRuleParseRegex.Match(input);
            if (!outerMatch.Success)
            {
                throw new ArgumentException($"Input is not a valid bagrule! \"{input}\"", nameof(input));
            }

            var bag = new BagRule();
            bag.Container = outerMatch.Groups[1].Value;
            bag.ContainRulesRaw = new();

            var contentsString = outerMatch.Groups[2].Value;
            if (contentsString != "no other bags")
            {
                var contents = contentsString.Split(",").Select(x => x.Trim()).ToList();
                foreach (var s in contents)
                {
                    var innerMatch = bagContainingParseRegex.Match(s);
                    if (!innerMatch.Success)
                    {
                        throw new Exception("Content expression of bag rule is malformed!");
                    }

                    var name = innerMatch.Groups[2].Value;
                    var count = int.Parse(innerMatch.Groups[1].Value);

                    bag.ContainRulesRaw.Add((name, count));
                }
            }

            return bag;
        }

        public static Dictionary<string, BagRule> LinkRules(List<BagRule> bags)
        {
            var dict = bags.ToDictionary(b => b.Container);

            foreach (var bag in bags)
            {
                bag.ContainRules = bag.ContainRulesRaw
                    .Select(x => (dict[x.name], x.count))
                    .ToList();
            }

            return dict;
        }
    }
}
