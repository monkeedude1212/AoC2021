using core;
using System.Linq;

public class Puzzle2Solver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        int depth = 0;
        int distance = 0;
        foreach (string line in data)
        {
            string[] tokens = line.Split(' ');
            int value = int.Parse(tokens[1]);
            switch (tokens[0])
            {
                case "forward":
                    distance += value;
                    break;
                case "down":
                    depth += value;
                    break;
                case "up":
                    depth -= value;
                    break;
            }
        }

        return (depth * distance).ToString();
    }
}