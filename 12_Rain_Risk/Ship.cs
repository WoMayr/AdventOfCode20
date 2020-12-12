using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Rain_Risk
{
    public class Ship
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public Direction Direction { get; set; } = Direction.East;

        public Waypoint Waypoint { get; set; } = new Waypoint { X = 10, Y = 1 };

        public void ProcessCommand(NavigationCommand command)
        {
            switch (command)
            {
                case (NavigationCommandType.MoveNorth, int amount):
                    Y += amount;
                    break;
                case (NavigationCommandType.MoveEast, int amount):
                    X += amount;
                    break;
                case (NavigationCommandType.MoveSouth, int amount):
                    Y -= amount;
                    break;
                case (NavigationCommandType.MoveWest, int amount):
                    X -= amount;
                    break;
                case (NavigationCommandType.TurnLeft, int amount):
                    {
                        int stepAmount = amount / 90;
                        Direction = (Direction)(((int)Direction + 4 - stepAmount) % 4);
                        break;
                    }
                case (NavigationCommandType.TurnRight, int amount):
                    {
                        int stepAmount = amount / 90;
                        Direction = (Direction)(((int)Direction + stepAmount) % 4);
                        break;
                    }
                case (NavigationCommandType.MoveForward, int amount):
                    switch (Direction)
                    {
                        case Direction.North: Y += amount; break;
                        case Direction.East: X += amount; break;
                        case Direction.South: Y -= amount; break;
                        case Direction.West: X -= amount; break;
                    }
                    break;
            }
        }

        private static int CheapCos(int degree) => (degree % 360) switch
        {
            0 => 1,
            90 => 0,
            180 => -1,
            270 => 0,
            _ => throw new ArgumentException("CheapCos only works with 0, 90, 180 and 270", nameof(degree))
        };

        private static int CheapSin(int degree) => (degree % 360) switch
        {
            0 => 0,
            90 => 1,
            180 => 0,
            270 => -1,
            _ => throw new ArgumentException("CheapSin only works with 0, 90, 180 and 270", nameof(degree))
        };

        public void ProcessWaypointCommand(NavigationCommand command)
        {
            switch (command)
            {
                case (NavigationCommandType.MoveNorth, int amount):
                    Waypoint.Y += amount;
                    break;
                case (NavigationCommandType.MoveEast, int amount):
                    Waypoint.X += amount;
                    break;
                case (NavigationCommandType.MoveSouth, int amount):
                    Waypoint.Y -= amount;
                    break;
                case (NavigationCommandType.MoveWest, int amount):
                    Waypoint.X -= amount;
                    break;
                case (NavigationCommandType.TurnLeft, int amount):
                    {
                        var newX = Waypoint.X * CheapCos(amount) - Waypoint.Y * CheapSin(amount);
                        var newY = Waypoint.X * CheapSin(amount) + Waypoint.Y * CheapCos(amount);
                        Waypoint.X = newX;
                        Waypoint.Y = newY;
                        break;
                    }
                case (NavigationCommandType.TurnRight, int amount):
                    {
                        amount = 360 - amount;
                        var newX = Waypoint.X * CheapCos(amount) - Waypoint.Y * CheapSin(amount);
                        var newY = Waypoint.X * CheapSin(amount) + Waypoint.Y * CheapCos(amount);
                        Waypoint.X = newX;
                        Waypoint.Y = newY;
                        break;
                    }
                case (NavigationCommandType.MoveForward, int amount):
                    X += Waypoint.X * amount;
                    Y += Waypoint.Y * amount;
                    break;
            }
        }
    }
}
