using core;
using System.Collections.Generic;

namespace Puzzle13
{

    public class Puzzle13Solver : PuzzleSolver
    {
        public string SolvePuzzle(string[] data)
        {
            List<int> busIds = new List<int>();
            int earliestDeparture;
            int.TryParse(data[0], out earliestDeparture);
            string[] ids = data[1].Split(',');
            foreach (string id in ids)
            {
                int value;
                bool converted = int.TryParse(id, out value);
                if (converted)
                {
                    busIds.Add(value);
                }
            }

            int minRemainder = int.MaxValue;
            int bestBusId = 0;
            foreach (int number in busIds)
            {
                int nextBus = number;
                while (nextBus < earliestDeparture)
                {
                    nextBus += number;
                }
                int remainder = nextBus % earliestDeparture;
                if (remainder < minRemainder)
                {
                    minRemainder = remainder;
                    bestBusId = number;
                }


            }
            return (minRemainder * bestBusId).ToString();
        }
    }
}