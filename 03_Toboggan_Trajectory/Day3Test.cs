using FluentAssertions;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _03_Toboggan_Trajectory
{
    public class Day3Test : BaseTest<Day3>
    {
        private const string exampleInput = @"..##.......
#...#...#..
.#....#..#.
..#.#...#.#
.#...##..#.
..#.##.....
.#.#.#....#
.#........#
#.##...#...
#...##....#
.#..#...#.#";

        public Day3Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Part1_Example()
        {
            subject.Input = exampleInput;

            subject.Run1();

            subject.EncounteredTrees.Should().Be(7);
        }

        [Fact]
        public void Part2_Example_Slope1()
        {
            subject.Input = exampleInput;

            subject.CountTreesForSlope(1, 1).Should().Be(2);
        }

        [Fact]
        public void Part2_Example_Slope2()
        {
            subject.Input = exampleInput;

            subject.CountTreesForSlope(3, 1).Should().Be(7);
        }

        [Fact]
        public void Part2_Example_Slope3()
        {
            subject.Input = exampleInput;

            subject.CountTreesForSlope(5, 1).Should().Be(3);
        }

        [Fact]
        public void Part2_Example_Slope4()
        {
            subject.Input = exampleInput;

            subject.CountTreesForSlope(7, 1).Should().Be(4);
        }

        [Fact]
        public void Part2_Example_Slope5()
        {
            subject.Input = exampleInput;

            subject.CountTreesForSlope(1, 2).Should().Be(2);
        }


        [Fact]
        public void Part2_Example_Run()
        {
            subject.Input = exampleInput;

            subject.Run2();

            subject.EncounteredTrees.Should().Be(336);
        }
    }
}
