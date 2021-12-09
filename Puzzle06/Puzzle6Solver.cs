using AdventofCode.Puzzle06;
using core;
using System;
using System.Collections.Generic;
using System.Linq;

public class Puzzle6Solver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        string[] timers = data[0].Split(',');
        List<Fish> fishies = new List<Fish>();
        foreach (string timer in timers)
        {
            fishies.Add(new Fish(int.Parse(timer)));
        }

        for (int i = 0; i < 80; i++)
        {
            List<Fish> fishToAdd = new List<Fish>();
            foreach (Fish fish in fishies)
            {
                if(fish.spawnTimer > 0)
                {
                    fish.spawnTimer--;
                } else
                {
                    fishToAdd.Add(new Fish(8));
                    fish.spawnTimer = 6;
                }
            }
            foreach (Fish fish in fishToAdd)
            {
                fishies.Add(fish);
            }
        }


        return fishies.Count.ToString();
    }
}