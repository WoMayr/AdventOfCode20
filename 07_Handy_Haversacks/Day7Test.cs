using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _07_Handy_Haversacks
{
    public class Day7Test : BaseTest<Day7>
    {
        public Day7Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Part1_Example_ParseRule1()
        {
            string input = "light red bags contain 1 bright white bag, 2 muted yellow bags.";

            var rule = BagRule.FromInput(input);


            rule.Container.Should().Be("light red");
            rule.ContainRulesRaw.Should().ContainEquivalentOf(("bright white", 1));
            rule.ContainRulesRaw.Should().ContainEquivalentOf(("muted yellow", 2));
        }

        [Fact]
        public void Part1_Example_ParseRule2()
        {
            string input = "dark orange bags contain 3 bright white bags, 4 muted yellow bags.";

            var rule = BagRule.FromInput(input);


            rule.Container.Should().Be("dark orange");
            rule.ContainRulesRaw.Should().ContainEquivalentOf(("bright white", 3));
            rule.ContainRulesRaw.Should().ContainEquivalentOf(("muted yellow", 4));
        }

        [Fact]
        public void Part1_Example_ParseRules()
        {
            var input = new[] {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags.",
            };

            var rules = input.Select(s => BagRule.FromInput(s)).ToList();
            var dict = BagRule.LinkRules(rules);

            dict.Should().ContainKeys(
                "light red",
                "dark orange",
                "bright white",
                "muted yellow",
                "shiny gold",
                "dark olive",
                "vibrant plum",
                "faded blue",
                "dotted black");

            dict["light red"].ContainRules.Should().BeEquivalentTo((dict["bright white"], 1), (dict["muted yellow"], 2));
        }

        [Fact]
        public void Part1_Example()
        {
            subject.Input = @"light red bags contain 1 bright white bag, 2 muted yellow bags.
dark orange bags contain 3 bright white bags, 4 muted yellow bags.
bright white bags contain 1 shiny gold bag.
muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.
shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.
dark olive bags contain 3 faded blue bags, 4 dotted black bags.
vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.
faded blue bags contain no other bags.
dotted black bags contain no other bags.";

            subject.Run1();

            subject.Possibilities.Should().Be(4);
        }
    }
}
