using core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle7
{
    public class Puzzle7bSolver : PuzzleSolver
    {
        public string SolvePuzzle(string[] data)
        {
            Dictionary<string, Bag> rules = RulesParser.Parse(data);
            KeyValuePair<string, Bag> myBag = rules.First(x =>
            {
                return x.Key == "shiny gold";
            });

            int bagsINeedToBuy = 0;
            bagsINeedToBuy = calculateTotalInnerBags(bagsINeedToBuy, myBag.Value, rules);

            return bagsINeedToBuy.ToString();
        }

        private static int calculateTotalInnerBags(int bagCount, Bag currentBag, Dictionary<string, Bag> rules)
        {
            if (currentBag.contents.Count > 0)
            {
                foreach (Tuple<Bag, int> content in currentBag.contents)
                {
                    for (int i = 0; i < content.Item2; i++)
                    {
                        bagCount++;
                        bagCount = calculateTotalInnerBags(bagCount, content.Item1, rules);
                    }

                }
            }
            else // Probably didn't load the inner bag's data, lets retrieve it and check if it has any contents
            {
                List<Tuple<Bag, int>> actualContents = rules.First(x => x.Key == currentBag.color).Value.contents;
                if (actualContents.Count != 0)
                {
                    currentBag.contents = actualContents;
                    bagCount = calculateTotalInnerBags(bagCount, currentBag, rules);
                }
            }
            return bagCount;
        }
    }
}