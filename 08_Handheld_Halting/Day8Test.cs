using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _08_Handheld_Halting
{
    public class Day8Test : BaseTest<Day8>
    {
        public Day8Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Part1_Example()
        {
            string input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";
            subject.Input = input;

            subject.Run1();

            subject.Acc.Should().Be(5);
        }

        [Fact]
        public void Part2_Example()
        {
            string input = @"nop +0
acc +1
jmp +4
acc +3
jmp -3
acc -99
acc +1
jmp -4
acc +6";
            subject.Input = input;

            subject.Run2();

            subject.Acc.Should().Be(8);
        }
    }
}
