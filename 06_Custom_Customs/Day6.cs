using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_Custom_Customs
{
    public class Day6
    {
        public string Input { get; set; }

        public int CountOfAllYesAnswers { get; set; }

        public HashSet<char> ProcessGroupAny(string group)
        {
            return group
                .Where(c => c is >= 'a' and <= 'z')
                .ToHashSet();
        }

        public HashSet<char> ProcessGroupAll(string group)
        {
            var members = group.Split('\n');

            var result = members.First().ToHashSet();
            foreach (var mem in members.Skip(1))
            {
                result.IntersectWith(mem);
            }
            return result;
        }

        public void Run1()
        {
            Input = Input.Replace("\r", "");
            var groups = Input.Split("\n\n");

            CountOfAllYesAnswers = 0;

            foreach (var g in groups)
            {
                var answeredQuestions = ProcessGroupAny(g);
                CountOfAllYesAnswers += answeredQuestions.Count;
            }
        }

        public void Run2()
        {
            Input = Input.Replace("\r", "");
            var groups = Input.Split("\n\n");

            CountOfAllYesAnswers = 0;

            foreach (var g in groups)
            {
                var answeredQuestions = ProcessGroupAll(g);
                CountOfAllYesAnswers += answeredQuestions.Count;
            }
        }
    }
}
