using System;
using System.Collections.Generic;

namespace Puzzle7
{
    public class Bag
    {
        public string color;
        public List<Tuple<Bag, int>> contents;

        public Bag(string color)
        {
            this.color = color;
            contents = new List<Tuple<Bag, int>>();
        }

        public void addBags(Bag bag, int number)
        {
            contents.Add(new Tuple<Bag, int>(bag, number));
        }
    }
}