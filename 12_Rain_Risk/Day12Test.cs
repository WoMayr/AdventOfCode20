using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Xunit;
using Xunit.Abstractions;

namespace _12_Rain_Risk
{
    public class Day12Test : BaseTest<Day12>
    {
        public Day12Test(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Part1_Example_Step1()
        {
            var command = NavigationCommand.FromString("F10");

            var ship = new Ship();

            ship.ProcessCommand(command);

            ship.Direction.Should().Be(Direction.East);
            ship.X.Should().Be(10);
            ship.Y.Should().Be(0);
        }

        [Fact]
        public void Part1_Example_Step2()
        {
            var command = NavigationCommand.FromString("N3");

            var ship = new Ship() { X = 10, Y = 0 };

            ship.ProcessCommand(command);

            ship.Direction.Should().Be(Direction.East);
            ship.X.Should().Be(10);
            ship.Y.Should().Be(3);
        }

        [Fact]
        public void Part1_Example_Step3()
        {
            var command = NavigationCommand.FromString("F7");

            var ship = new Ship() { X = 10, Y = 3 };

            ship.ProcessCommand(command);

            ship.Direction.Should().Be(Direction.East);
            ship.X.Should().Be(17);
            ship.Y.Should().Be(3);
        }

        [Fact]
        public void Part1_Example_Step4()
        {
            var command = NavigationCommand.FromString("R90");

            var ship = new Ship() { X = 17, Y = 3 };

            ship.ProcessCommand(command);

            ship.Direction.Should().Be(Direction.South);
            ship.X.Should().Be(17);
            ship.Y.Should().Be(3);
        }

        [Fact]
        public void Part1_Example_Step5()
        {
            var command = NavigationCommand.FromString("F11");

            var ship = new Ship() { X = 17, Y = 3, Direction = Direction.South };

            ship.ProcessCommand(command);

            ship.Direction.Should().Be(Direction.South);
            ship.X.Should().Be(17);
            ship.Y.Should().Be(-8);
        }

        [Fact]
        public void Part1_Example_Run()
        {
            subject.Input = @"F10
N3
F7
R90
F11";

            subject.Run1();

            var ship = subject.Ship;
            ship.Direction.Should().Be(Direction.South);
            ship.X.Should().Be(17);
            ship.Y.Should().Be(-8);

            subject.DistanceFromStart.Should().Be(25);
        }

        [Fact]
        public void Part2_Example_Step1()
        {
            var ship = new Ship();
            var command = NavigationCommand.FromString("F10");

            ship.ProcessWaypointCommand(command);

            ship.X.Should().Be(100);
            ship.Y.Should().Be(10);
            ship.Waypoint.X.Should().Be(10);
            ship.Waypoint.Y.Should().Be(1);
        }

        [Fact]
        public void Part2_Example_Step2()
        {
            var ship = new Ship() { X = 100, Y = 10 };
            var command = NavigationCommand.FromString("N3");

            ship.ProcessWaypointCommand(command);

            ship.X.Should().Be(100);
            ship.Y.Should().Be(10);
            ship.Waypoint.X.Should().Be(10);
            ship.Waypoint.Y.Should().Be(4);
        }

        [Fact]
        public void Part2_Example_Step3()
        {
            var ship = new Ship()
            {
                X = 100,
                Y = 10,
                Waypoint = new Waypoint { X = 10, Y = 4 }
            };
            var command = NavigationCommand.FromString("F7");

            ship.ProcessWaypointCommand(command);

            ship.X.Should().Be(170);
            ship.Y.Should().Be(38);
            ship.Waypoint.X.Should().Be(10);
            ship.Waypoint.Y.Should().Be(4);
        }

        [Fact]
        public void Part2_Example_Step4()
        {
            var ship = new Ship()
            {
                X = 170,
                Y = 38,
                Waypoint = new Waypoint { X = 10, Y = 4 }
            };
            var command = NavigationCommand.FromString("R90");

            ship.ProcessWaypointCommand(command);

            ship.X.Should().Be(170);
            ship.Y.Should().Be(38);
            ship.Waypoint.X.Should().Be(4);
            ship.Waypoint.Y.Should().Be(-10);
        }

        [Fact]
        public void Part2_Example_Step5()
        {
            var ship = new Ship()
            {
                X = 170,
                Y = 38,
                Waypoint = new Waypoint { X = 4, Y = -10 }
            };
            var command = NavigationCommand.FromString("F11");

            ship.ProcessWaypointCommand(command);

            ship.X.Should().Be(214);
            ship.Y.Should().Be(-72);
            ship.Waypoint.X.Should().Be(4);
            ship.Waypoint.Y.Should().Be(-10);
        }

        [Fact]
        public void Part2_Example_Run()
        {
            subject.Input = @"F10
N3
F7
R90
F11";

            subject.Run2();

            var ship = subject.Ship;
            ship.X.Should().Be(214);
            ship.Y.Should().Be(-72);
            ship.Waypoint.X.Should().Be(4);
            ship.Waypoint.Y.Should().Be(-10);

            subject.DistanceFromStart.Should().Be(286);
        }
    }
}
