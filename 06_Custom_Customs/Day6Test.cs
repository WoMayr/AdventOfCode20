using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _06_Custom_Customs
{
    public class Day6Test : BaseTest<Day6>
    {
        public Day6Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Part1_Example_Group1()
        {
            var input = @"abcx
abcy
abcz";
            subject.ProcessGroupAny(input).Should().Contain(new[] { 'a', 'b', 'c', 'x', 'y', 'z' });
        }

        [Fact]
        public void Part1_Example_Group2()
        {
            var input = @"abc";
            subject.ProcessGroupAny(input).Should().Contain(new[] { 'a', 'b', 'c' });
        }

        [Fact]
        public void Part1_Example_Group3()
        {
            var input = @"a
b
c";
            subject.ProcessGroupAny(input).Should().Contain(new[] { 'a', 'b', 'c' });
        }

        [Fact]
        public void Part1_Example_Group4()
        {
            var input = @"ab
ac";
            subject.ProcessGroupAny(input).Should().Contain(new[] { 'a', 'b', 'c' });
        }

        [Fact]
        public void Part1_Example_Group5()
        {
            var input = @"a
a
a
a";
            subject.ProcessGroupAny(input).Should().Contain(new[] { 'a' });
        }

        [Fact]
        public void Part1_Example_Group6()
        {
            var input = @"b";
            subject.ProcessGroupAny(input).Should().Contain(new[] { 'b' });
        }

        [Fact]
        public void Part1_Example_Run()
        {
            var input = @"abc

a
b
c

ab
ac

a
a
a
a

b";
            subject.Input = input;

            subject.Run1();

            subject.CountOfAllYesAnswers.Should().Be(11);
        }

        [Fact]
        public void Part2_Example_Group1()
        {
            var input = @"abcx
abcy
abcz";
            subject.ProcessGroupAll(input).Should().Contain(new[] { 'a', 'b', 'c' });
        }

        [Fact]
        public void Part2_Example_Group2()
        {
            var input = @"abc";
            subject.ProcessGroupAll(input).Should().Contain(new[] { 'a', 'b', 'c' });
        }

        [Fact]
        public void Part2_Example_Group3()
        {
            var input = @"a
b
c";
            subject.ProcessGroupAll(input).Should().BeEmpty();
        }

        [Fact]
        public void Part2_Example_Group4()
        {
            var input = @"ab
ac";
            subject.ProcessGroupAll(input).Should().Contain(new[] { 'a' });
        }

        [Fact]
        public void Part2_Example_Group5()
        {
            var input = @"a
a
a
a";
            subject.ProcessGroupAll(input).Should().Contain(new[] { 'a' });
        }

        [Fact]
        public void Part2_Example_Group6()
        {
            var input = @"b";
            subject.ProcessGroupAll(input).Should().Contain(new[] { 'b' });
        }

        [Fact]
        public void Part2_Example_Run()
        {
            var input = @"abc

a
b
c

ab
ac

a
a
a
a

b";
            subject.Input = input;

            subject.Run2();

            subject.CountOfAllYesAnswers.Should().Be(6);
        }
    }
}
