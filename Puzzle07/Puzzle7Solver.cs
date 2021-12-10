using core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Puzzle7
{
    public class Puzzle7Solver : PuzzleSolver
    {
        public string SolvePuzzle(string[] data)
        {
            string[] input = data[0].Split(',');
            List<int> crabs = new List<int>();
            foreach (string s in input)
            {
                crabs.Add(int.Parse(s));
            }
            int lowest = 1000000000;
            foreach (int position in crabs)
            {
                int totalDistance = 0;
                foreach(int individualCrabDistance in crabs)
                {
                    totalDistance += Math.Abs(individualCrabDistance - position);
                }
                lowest = totalDistance < lowest ? totalDistance : lowest;
            }

            return lowest.ToString();
        }
    }
}
