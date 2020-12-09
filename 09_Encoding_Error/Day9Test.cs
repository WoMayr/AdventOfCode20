using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _09_Encoding_Error
{
    public class Day9Test : BaseTest<Day9>
    {
        public Day9Test(ITestOutputHelper output) : base(output)
        {
        }


        private long[] BuildTestPreamble(int size = 25)
        {
            Random rnd = new Random(1);
            return Enumerable.Range(1, 25)
                .Select(x => (long)x)
                .ToArray();
        }

        [Fact]
        public void Part1_Example_Valid1()
        {
            var numbers = Enumerable.Concat(
                BuildTestPreamble(),
                new[] { 26L }
            ).ToArray();

            subject.CheckValid(numbers, 25).Should().BeTrue();
        }

        [Fact]
        public void Part1_Example_Valid2()
        {
            var numbers = Enumerable.Concat(
                BuildTestPreamble(),
                new[] { 49L }
            ).ToArray();

            subject.CheckValid(numbers, 25).Should().BeTrue();
        }

        [Fact]
        public void Part1_Example_Valid3()
        {
            var numbers = Enumerable.Concat(
                BuildTestPreamble(),
                new[] { 100L }
            ).ToArray();

            subject.CheckValid(numbers, 25).Should().BeFalse();
        }

        [Fact]
        public void Part1_Example_Valid4()
        {
            var numbers = Enumerable.Concat(
                BuildTestPreamble(),
                new[] { 50L }
            ).ToArray();

            subject.CheckValid(numbers, 25).Should().BeFalse();
        }

        [Fact]
        public void Part1_Example_Valid5()
        {
            var numbers = Enumerable.Concat(
                BuildTestPreamble(),
                new[] { 45L, 26L }
            ).ToArray();
            numbers[0] = 20;
            numbers[19] = 1;

            subject.CheckValid(numbers, 26).Should().BeTrue();
        }

        [Fact]
        public void Part1_Example_Valid6()
        {
            var numbers = Enumerable.Concat(
                BuildTestPreamble(),
                new[] { 45L, 65L }
            ).ToArray();
            numbers[0] = 20;
            numbers[19] = 1;

            subject.CheckValid(numbers, 26).Should().BeFalse();
        }

        [Fact]
        public void Part1_Example_Valid7()
        {
            var numbers = Enumerable.Concat(
                BuildTestPreamble(),
                new[] { 45L, 64L }
            ).ToArray();
            numbers[0] = 20;
            numbers[19] = 1;

            subject.CheckValid(numbers, 26).Should().BeTrue();
        }

        [Fact]
        public void Part1_Example_Valid8()
        {
            var numbers = Enumerable.Concat(
                BuildTestPreamble(),
                new[] { 45L, 66L }
            ).ToArray();
            numbers[0] = 20;
            numbers[19] = 1;

            subject.CheckValid(numbers, 26).Should().BeTrue();
        }


        [Fact]
        public void Part1_Example_Run()
        {
            subject.Input = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";
            subject.PreambleSize = 5;

            subject.Run1();

            subject.FirstOneOut.Should().Be(127);
        }


        [Fact]
        public void Part2_Example_Run()
        {
            subject.Input = @"35
20
15
25
47
40
62
55
65
95
102
117
150
182
127
219
299
277
309
576";
            subject.PreambleSize = 5;

            subject.Run2();

            subject.EncryptionWeakness.Should().ContainInOrder(15, 25, 47, 40);
            subject.WeaknessChecksum.Should().Be(62);
        }
    }
}
