using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _13_Shuttle_Search
{
    public class Day13Test : BaseTest<Day13>
    {
        public Day13Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Part1_Example()
        {
            subject.Input = @"939
7,13,x,x,59,x,31,19";

            subject.Run1();

            subject.BusId.Should().Be(59);
            subject.WaitTime.Should().Be(5);
        }

        [Fact(Timeout = 30 * 1000)]
        public void Part2_Example1()
        {
            subject.Input = @"0
7,13,x,x,59,x,31,19";
            subject.MaxTimestampCheck = 2000000;

            subject.Run2();

            subject.EarliestCascadeTimestamp.Should().Be(1068781);
        }

        [Fact(Timeout = 30 * 1000)]
        public void Part2_Example2()
        {
            subject.Input = @"0
17,x,13,19";
            subject.MaxTimestampCheck = 10000;

            subject.Run2();

            subject.EarliestCascadeTimestamp.Should().Be(3417);
        }

        [Fact(Timeout = 30 * 1000)]
        public void Part2_Example3()
        {
            subject.Input = @"0
67,7,59,61";
            subject.MaxTimestampCheck = 800000;

            subject.Run2();

            subject.EarliestCascadeTimestamp.Should().Be(754018);
        }

        [Fact(Timeout = 30 * 1000)]
        public void Part2_Example4()
        {
            subject.Input = @"0
67,x,7,59,61";
            subject.MaxTimestampCheck = 800000;

            subject.Run2();

            subject.EarliestCascadeTimestamp.Should().Be(779210);
        }

        [Fact(Timeout = 30 * 1000)]
        public void Part2_Example5()
        {
            subject.Input = @"0
67,7,x,59,61";
            subject.MaxTimestampCheck = 1500000;

            subject.Run2();

            subject.EarliestCascadeTimestamp.Should().Be(1261476);
        }

        [Fact(Timeout = 30*1000)]
        public void Part2_Example6()
        {
            subject.Input = @"0
1789,37,47,1889";
            subject.MaxTimestampCheck = 1300000000;

            subject.Run2();

            subject.EarliestCascadeTimestamp.Should().Be(1202161486);
        }
    }
}