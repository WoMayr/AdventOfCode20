using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Rain_Risk
{
    public enum NavigationCommandType
    {
        MoveNorth,
        MoveEast,
        MoveSouth,
        MoveWest,
        TurnLeft,
        TurnRight,
        MoveForward
    }

    public record NavigationCommand(NavigationCommandType Type, int Amount)
    {
        public static NavigationCommand FromString(string input)
        {
            var type = TypeFromString(input[0]);
            var amount = int.Parse(input.Substring(1));
            return new NavigationCommand(type, amount);
        }

        public static NavigationCommandType TypeFromString(string s) => TypeFromString(s[0]);
        public static NavigationCommandType TypeFromString(char s) => s switch
        {
            'N' => NavigationCommandType.MoveNorth,
            'E' => NavigationCommandType.MoveEast,
            'S' => NavigationCommandType.MoveSouth,
            'W' => NavigationCommandType.MoveWest,
            'L' => NavigationCommandType.TurnLeft,
            'R' => NavigationCommandType.TurnRight,
            'F' => NavigationCommandType.MoveForward,
            _ => throw new ArgumentException($"'{s}' is not a valid navigation command type!", nameof(s))
        };
    }
}
