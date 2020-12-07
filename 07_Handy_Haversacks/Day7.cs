using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace _07_Handy_Haversacks
{
    public class Day7 : BaseDay
    {
        public string Target { get; set; }
        public int TargetQuantity { get; set; }

        public int Possibilities { get; set; }

        private void ParseBagRules()
        {
            Input = Input.Replace("\r", "").Trim();

            var bags = Input
                .Split('\n')
                .Select(l => BagRule.FromInput(l))
                .ToList();

            BagRule.LinkRules(bags);
        }

        public void Run1()
        {
            ParseBagRules();
        }
    }
}
