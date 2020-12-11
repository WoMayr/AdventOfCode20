using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _11_Seating_System
{
    public class Day11Test : BaseTest<Day11>
    {
        private readonly ILogger<Day11Test> logger;

        public Day11Test(ITestOutputHelper output) : base(output)
        {
            logger = services.GetRequiredService<ILogger<Day11Test>>();
        }

        [Fact]
        public void Part1_Example_Step1()
        {
            // Arrange
            var input = Day11.ParseFloor(@"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL");

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step1(input, output);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##");
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part1_Example_Step2()
        {
            // Arrange
            var input = Day11.ParseFloor(@"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##");
            logger.LogInformation("Input:");
            input.PrintField(logger);

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step1(input, output);
            logger.LogInformation("\n\nOutput:");
            output.PrintField(logger);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.LL.L#.##
#LLLLLL.L#
L.L.L..L..
#LLL.LL.L#
#.LL.LL.LL
#.LLLL#.##
..L.L.....
#LLLLLLLL#
#.LLLLLL.L
#.#LLLL.##");
            logger.LogInformation("\n\nExpectedOutput:");
            expectedOutput.PrintField(logger);
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part1_Example_Step3()
        {
            // Arrange
            var input = Day11.ParseFloor(@"#.LL.L#.##
#LLLLLL.L#
L.L.L..L..
#LLL.LL.L#
#.LL.LL.LL
#.LLLL#.##
..L.L.....
#LLLLLLLL#
#.LLLLLL.L
#.#LLLL.##");

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step1(input, output);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.##.L#.##
#L###LL.L#
L.#.#..#..
#L##.##.L#
#.##.LL.LL
#.###L#.##
..#.#.....
#L######L#
#.LL###L.L
#.#L###.##");
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part1_Example_Step4()
        {
            // Arrange
            var input = Day11.ParseFloor(@"#.##.L#.##
#L###LL.L#
L.#.#..#..
#L##.##.L#
#.##.LL.LL
#.###L#.##
..#.#.....
#L######L#
#.LL###L.L
#.#L###.##");

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step1(input, output);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.#L.L#.##
#LLL#LL.L#
L.L.L..#..
#LLL.##.L#
#.LL.LL.LL
#.LL#L#.##
..L.L.....
#L#LLLL#L#
#.LLLLLL.L
#.#L#L#.##");
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part1_Example_Step5()
        {
            // Arrange
            var input = Day11.ParseFloor(@"#.#L.L#.##
#LLL#LL.L#
L.L.L..#..
#LLL.##.L#
#.LL.LL.LL
#.LL#L#.##
..L.L.....
#L#LLLL#L#
#.LLLLLL.L
#.#L#L#.##");

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step1(input, output);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.#L.L#.##
#LLL#LL.L#
L.#.L..#..
#L##.##.L#
#.#L.LL.LL
#.#L#L#.##
..L.L.....
#L#L##L#L#
#.LLLLLL.L
#.#L#L#.##");
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part1_Example_Run()
        {
            // Arrange
            subject.Input = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

            // Act
            subject.Run1();

            // Assert
            subject.Iterations.Should().Be(5);
            subject.OccupiedSeats.Should().Be(37);
        }

        // Part2

        [Fact]
        public void Part2_Example_Step1()
        {
            // Arrange
            var input = Day11.ParseFloor(@"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL");

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step2(input, output);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##");
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part2_Example_Step2()
        {
            // Arrange
            var input = Day11.ParseFloor(@"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL");
            logger.LogInformation("Input:");
            input.PrintField(logger);

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step2(input, output);
            logger.LogInformation("\n\nOutput:");
            output.PrintField(logger);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##");
            logger.LogInformation("\n\nExpectedOutput:");
            expectedOutput.PrintField(logger);
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part2_Example_Step3()
        {
            // Arrange
            var input = Day11.ParseFloor(@"#.##.##.##
#######.##
#.#.#..#..
####.##.##
#.##.##.##
#.#####.##
..#.#.....
##########
#.######.#
#.#####.##");
            logger.LogInformation("Input:");
            input.PrintField(logger);

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step2(input, output);
            logger.LogInformation("\n\nOutput:");
            output.PrintField(logger);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.LL.LL.L#
#LLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLLL.L
#.LLLLL.L#");
            logger.LogInformation("\n\nExpectedOutput:");
            expectedOutput.PrintField(logger);
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part2_Example_Step4()
        {
            // Arrange
            var input = Day11.ParseFloor(@"#.LL.LL.L#
#LLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLLL.L
#.LLLLL.L#");
            logger.LogInformation("Input:");
            input.PrintField(logger);

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step2(input, output);
            logger.LogInformation("\n\nOutput:");
            output.PrintField(logger);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.L#.##.L#
#L#####.LL
L.#.#..#..
##L#.##.##
#.##.#L.##
#.#####.#L
..#.#.....
LLL####LL#
#.L#####.L
#.L####.L#");
            logger.LogInformation("\n\nExpectedOutput:");
            expectedOutput.PrintField(logger);
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part2_Example_Step5()
        {
            // Arrange
            var input = Day11.ParseFloor(@"#.L#.##.L#
#L#####.LL
L.#.#..#..
##L#.##.##
#.##.#L.##
#.#####.#L
..#.#.....
LLL####LL#
#.L#####.L
#.L####.L#");
            logger.LogInformation("Input:");
            input.PrintField(logger);

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step2(input, output);
            logger.LogInformation("\n\nOutput:");
            output.PrintField(logger);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##LL.LL.L#
L.LL.LL.L#
#.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLL#.L
#.L#LL#.L#");
            logger.LogInformation("\n\nExpectedOutput:");
            expectedOutput.PrintField(logger);
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part2_Example_Step6()
        {
            // Arrange
            var input = Day11.ParseFloor(@"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##LL.LL.L#
L.LL.LL.L#
#.LLLLL.LL
..L.L.....
LLLLLLLLL#
#.LLLLL#.L
#.L#LL#.L#");
            logger.LogInformation("Input:");
            input.PrintField(logger);

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step2(input, output);
            logger.LogInformation("\n\nOutput:");
            output.PrintField(logger);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##L#.#L.L#
L.L#.#L.L#
#.L####.LL
..#.#.....
LLL###LLL#
#.LLLLL#.L
#.L#LL#.L#");
            logger.LogInformation("\n\nExpectedOutput:");
            expectedOutput.PrintField(logger);
            output.Should().BeEquivalentTo(expectedOutput);
        }

        [Fact]
        public void Part2_Example_Step7()
        {
            // Arrange
            var input = Day11.ParseFloor(@"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##L#.#L.L#
L.L#.#L.L#
#.L####.LL
..#.#.....
LLL###LLL#
#.LLLLL#.L
#.L#LL#.L#");
            logger.LogInformation("Input:");
            input.PrintField(logger);

            var output = new SeatState[input.GetLength(0), input.GetLength(1)];

            // Act
            subject.Step2(input, output);
            logger.LogInformation("\n\nOutput:");
            output.PrintField(logger);

            // Assert
            var expectedOutput = Day11.ParseFloor(@"#.L#.L#.L#
#LLLLLL.LL
L.L.L..#..
##L#.#L.L#
L.L#.LL.L#
#.LLLL#.LL
..#.L.....
LLL###LLL#
#.LLLLL#.L
#.L#LL#.L#");
            logger.LogInformation("\n\nExpectedOutput:");
            expectedOutput.PrintField(logger);
            output.Should().BeEquivalentTo(expectedOutput);
        }


        [Fact]
        public void Part2_Example_Run()
        {
            // Arrange
            subject.Input = @"L.LL.LL.LL
LLLLLLL.LL
L.L.L..L..
LLLL.LL.LL
L.LL.LL.LL
L.LLLLL.LL
..L.L.....
LLLLLLLLLL
L.LLLLLL.L
L.LLLLL.LL";

            // Act
            subject.Run2();

            // Assert
            subject.Iterations.Should().Be(6);
            subject.OccupiedSeats.Should().Be(26);
        }
    }
}
