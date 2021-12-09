using core;
using System.Collections.Generic;

public class Puzzle6bSolver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        string[] timers = data[0].Split(',');
        Dictionary<int, int> fishies = new Dictionary<int, int>();
        foreach (string timer in timers)
        {
            int intTimer = int.Parse(timer);
            if (fishies.ContainsKey(intTimer))
            {
                fishies[intTimer]++;
            } else
            {
                fishies.Add(intTimer, 1);
            }
        }

        for (int i = 0; i < 256; i++)
        {
            Dictionary<int, int> newFishies = new Dictionary<int, int>();
            foreach (KeyValuePair<int, int> valuePair in fishies)
            {
                if (valuePair.Key == 0)
                {
                    newFishies.Add(8, valuePair.Value);
                    if (newFishies.ContainsKey(6))
                    {
                        newFishies[6] = newFishies[6] + valuePair.Value;
                    } else
                    {
                        newFishies.Add(6, valuePair.Value);
                    }
                } else
                {
                    if (newFishies.ContainsKey(valuePair.Key - 1))
                    {
                        newFishies[valuePair.Key - 1] = newFishies[valuePair.Key - 1] + valuePair.Value;
                    }
                    else
                    {
                        newFishies.Add(valuePair.Key - 1, valuePair.Value);
                    }
                }
            }
            fishies = newFishies;
            System.GC.Collect();
        }

        int fishSum = 0;
        foreach(KeyValuePair<int,int> fishCategory in fishies)
        {
            fishSum += fishCategory.Value;
        }
        return fishSum.ToString();
    }
}