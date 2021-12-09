using core;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle7
{
    public class Puzzle7Solver : PuzzleSolver
    {
        public string SolvePuzzle(string[] data)
        {
            Dictionary<string, Bag> rules = RulesParser.Parse(data);
            HashSet<string> outerBags = new HashSet<string>();

            outerBags = calculateTotalContainerBags("shiny gold", outerBags, rules);

            return outerBags.Count().ToString();
        }

        private static HashSet<string> calculateTotalContainerBags(string searchBag, HashSet<string> outerBags, Dictionary<string, Bag> rules)
        {
            int previousBags = outerBags.Count;
            foreach (KeyValuePair<string, Bag> rule in rules)
            {
                if (rule.Value.contents.Any(x =>
                {
                    return x.Item1.color == searchBag;
                }))
                {
                    outerBags.Add(rule.Key);
                }
            }

            if (previousBags < outerBags.Count)
            {
                HashSet<string> outerBagReference = new HashSet<string>(outerBags);
                foreach (string bag in outerBagReference)
                {
                    outerBagReference = calculateTotalContainerBags(bag, outerBags, rules);
                }
            }

            return outerBags;
        }
    }
}
