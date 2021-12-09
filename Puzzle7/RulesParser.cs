using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle7
{
    public static class RulesParser
    {
        public static Dictionary<string, Bag> Parse(string[] data)
        {
            Dictionary<string, Bag> rules = new Dictionary<string, Bag>();
            foreach(string line in data)
            {
                if (line != string.Empty)
                {
                    string rootColor = line.Substring(0, line.IndexOf(" bags"));
                    Bag bag = new Bag(rootColor);

                    string[] contents = line.Substring(line.IndexOf("contain") + "contain".Length).Split(',');
                    foreach (string content in contents)
                    {
                        int numberOfBags;
                        int.TryParse(content.Trim().Split(' ')[0], out numberOfBags);

                        string bagColor = content.Trim().Replace("bags", "").Replace("bag", "").Replace(".", "");
                        bagColor = bagColor.Substring(bagColor.IndexOf(" ")).Trim();
                        Bag contentBag = new Bag(bagColor);
                        bag.addBags(contentBag, numberOfBags);
                    }

                    rules.Add(rootColor, bag);
                }
            }


            return rules;
        }
    }
}