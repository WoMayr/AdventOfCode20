using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _05_Binary_Boarding
{
    public class Day5Test : BaseTest<Day5>
    {
        public Day5Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Part1_Example_BoardingPass1()
        {
            var bp = new BoardingPass { PositionString = "FBFBBFFRLR" };

            bp.Row.Should().Be(44);
            bp.Column.Should().Be(5);
            bp.SeatId.Should().Be(357);
        }

        [Fact]
        public void Part1_Example_BoardingPass2()
        {
            var bp = new BoardingPass { PositionString = "BFFFBBFRRR" };

            bp.Row.Should().Be(70);
            bp.Column.Should().Be(7);
            bp.SeatId.Should().Be(567);
        }

        [Fact]
        public void Part1_Example_BoardingPass3()
        {
            var bp = new BoardingPass { PositionString = "FFFBBBFRRR" };

            bp.Row.Should().Be(14);
            bp.Column.Should().Be(7);
            bp.SeatId.Should().Be(119);
        }

        [Fact]
        public void Part1_Example_BoardingPass4()
        {
            var bp = new BoardingPass { PositionString = "BBFFBBFRLL" };

            bp.Row.Should().Be(102);
            bp.Column.Should().Be(4);
            bp.SeatId.Should().Be(820);
        }
    }
}
