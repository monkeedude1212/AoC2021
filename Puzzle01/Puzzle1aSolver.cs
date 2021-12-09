using core;
using System;
using System.Collections.Generic;

public class Puzzle1aSolver : PuzzleSolver
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

        short previousNumber = numbers[0];
        int incrementCounter = 0;
        for (int i = 0; i < numbers.Count; i++)
        {
            if (numbers[i] > previousNumber)
            {
                incrementCounter++;
            }
            previousNumber = numbers[i];
        }
        return incrementCounter.ToString();
        
        throw new Exception("Bad Data maybe?");
    }
}