using core;
using System;

public class Puzzle2bSolver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        int depth = 0;
        int distance = 0;
        int aim = 0;
        foreach (string line in data)
        {
            string[] tokens = line.Split(' ');
            int value = int.Parse(tokens[1]);
            switch (tokens[0])
            {
                case "forward":
                    distance += value;
                    depth = depth + (value * aim);
                    break;
                case "down":
                    aim += value;
                    break;
                case "up":
                    aim -= value;
                    break;
            }
        }

        return (depth * distance).ToString();
    }
}