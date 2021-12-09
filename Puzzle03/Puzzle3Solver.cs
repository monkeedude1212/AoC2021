using core;
using System.Collections.Generic;

public class Puzzle3Solver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        string gammaRate = "";
        string epsilonRate = "";
        int oneCounter = 0;
        int zeroCounter = 0;
        int length = data[0].Length;
        for (int i = 0; i < length; i++)
        {
            foreach (string line in data)
            {
                if (line[i] == '1')
                {
                    oneCounter++;
                } else if (line[i] == '0')
                {
                    zeroCounter++;
                }
            }
            char commonBit = oneCounter > zeroCounter ? '1' : '0';
            char uncommonBit = oneCounter < zeroCounter ? '1' : '0';
            gammaRate += commonBit;
            epsilonRate += uncommonBit;
            oneCounter = 0;
            zeroCounter = 0;
        }

        decimal gamma = System.Convert.ToInt32(gammaRate, 2);
        decimal epsilon = System.Convert.ToInt32(epsilonRate, 2);
        return (gamma * epsilon).ToString();
    }
}