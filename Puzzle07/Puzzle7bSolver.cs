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
            string[] input = data[0].Split(',');
            List<int> crabs = new List<int>();
            foreach (string s in input)
            {
                crabs.Add(int.Parse(s));
            }
            int highest = 0;
            foreach (int crab in crabs)
            {
                highest = crab > highest ? crab : highest;
            }

            Int64 lowest = 1000000000;
            for (int targetPosition = 0; targetPosition < highest; targetPosition++)
            {
                Int64 totalDistance = 0;
                foreach (int individualCrab in crabs)
                {
                    for (int i = 0; ((individualCrab + i) != targetPosition && (individualCrab - i) != targetPosition); i++)
                    {
                        totalDistance += i + 1;
                    }
                }
                lowest = totalDistance < lowest ? totalDistance : lowest;
            }

            return lowest.ToString();
        }
    }
}