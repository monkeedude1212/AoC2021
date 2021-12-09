using core;
using System.Collections.Generic;
namespace Puzzle9
{
    public class Puzzle9bSolver : PuzzleSolver
    {
        public string SolvePuzzle(string[] data)
        {
            int target = 23278925;
            List<int> numbers = new List<int>();
            foreach (string line in data)
            {
                int value;
                int.TryParse(line, out value);
                numbers.Add(value);
            }
            int currentSum = 0;
            int index = 0;
            List<int> contiguousSet = new List<int>();

            while (currentSum != target)
            {
                currentSum = 0;
                foreach (int number in contiguousSet)
                {
                    currentSum += number;
                }

                if (currentSum > target)
                {
                    contiguousSet.RemoveAt(0);
                }

                if (currentSum < target)
                {
                    contiguousSet.Add(numbers[index]);
                    index++;
                }
            }

            contiguousSet.Sort();
            //Found contiguous set
            int sum = contiguousSet[0] + contiguousSet[contiguousSet.Count - 1];
            return sum.ToString();
        }
    }
}
