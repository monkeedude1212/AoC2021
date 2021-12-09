using core;
using System;
using System.Collections.Generic;

public class Puzzle1bSolver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        List<short> numbers = new List<short>();
        foreach (string line in data)
        {
            short number;
            Int16.TryParse(line, out number);
            numbers.Add(number);
        }
        int i = 0;
        int previousSum = numbers[i] + numbers[i+1] + numbers[i + 2];
        int incrementCounter = 0;

        while (i + 2 < numbers.Count)
        {
            int newSum = numbers[i] + numbers[i + 1] + numbers[i + 2];
            if (newSum > previousSum)
            {
                incrementCounter++;
            }
            previousSum = newSum;
            i++;
        }


        return incrementCounter.ToString();

        throw new Exception("Bad Data maybe?");
    }
}