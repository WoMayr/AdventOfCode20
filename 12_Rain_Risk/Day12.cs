using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace _12_Rain_Risk
{
    public class Day12 : BaseDay
    {
        public Ship Ship { get; set; }
        public object DistanceFromStart => Math.Abs(Ship.X) + Math.Abs(Ship.Y);

        public void Run1()
        {
            Input = Input.Replace("\r", "");
            var commands = Input.Split('\n').Select(NavigationCommand.FromString).ToList();

            Ship = new Ship();

            foreach (var command in commands)
            {
                Ship.ProcessCommand(command);
            }
        }

        public void Run2()
        {
            Input = Input.Replace("\r", "");
            var commands = Input.Split('\n').Select(NavigationCommand.FromString).ToList();

            Ship = new Ship();

            foreach (var command in commands)
            {
                Ship.ProcessWaypointCommand(command);
            }
        }
    }
}
