using core;
using System.Collections.Generic;

namespace Puzzle9
{
    public class Puzzle9Solver : PuzzleSolver
    {
        public string SolvePuzzle(string[] data)
        {
            //Preload List;
            int index = 0;
            List<int> currentTwentyFive = new List<int>();
            while (index < 25)
            {
                int value;
                int.TryParse(data[index], out value);
                currentTwentyFive.Add(value);
                index++;
            }

            int nextValue;
            int.TryParse(data[index + 1], out nextValue);

            try
            {
                while (index < data.Length)
                {
                    bool summable = false;
                    while (!summable)
                    {
                        for (int i = 0; i < currentTwentyFive.Count; i++)
                        {
                            for (int j = 0; j < currentTwentyFive.Count; j++)
                            {
                                if (i != j)
                                {
                                    int sum = currentTwentyFive[i] + currentTwentyFive[j];
                                    if (sum == nextValue)
                                    {
                                        summable = true;
                                    }
                                }
                            }
                        }
                        if (summable)
                        {
                            break;
                        }
                        else
                        {
                            throw new NotSummableException();
                        }
                    }

                    // Testing logic complete. Start next iteration
                    currentTwentyFive.Remove(currentTwentyFive[0]);
                    int value;
                    int.TryParse(data[index], out value);
                    index++;
                    currentTwentyFive.Add(value);
                    int.TryParse(data[index], out nextValue);
                }
            }
            catch (NotSummableException exception)
            {
                return nextValue.ToString();
            }

            return "error";
        }
    }
}