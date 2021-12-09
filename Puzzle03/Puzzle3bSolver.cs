using core;
using System;
using System.Collections.Generic;

public class Puzzle3bSolver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        List<string> listData = new List<string>(data);
        string oxygenString = filterToMostCommon(listData, 0)[0];
        string carbonDioxideString = filterToLeastCommon(listData, 0)[0];
        decimal oxygenGenerator = System.Convert.ToInt32(oxygenString, 2);
        decimal C02Scrubber = System.Convert.ToInt32(carbonDioxideString, 2);

        return (oxygenGenerator * C02Scrubber).ToString();
    }

    private List<string> filterToMostCommon(List<string> data, int position)
    {
        List<string> ones = new List<string>();
        List<string> zeroes = new List<string>();
        while (data.Count > 1)
        {
            foreach (string line in data)
            {
                if (line[position] == '1')
                {
                    ones.Add(line);
                } else if (line[position] == '0')
                {
                    zeroes.Add(line);
                }
            }
            position++;
            data = (ones.Count >= zeroes.Count) ? ones : zeroes;

            data = filterToMostCommon(data, position);
        }
        return data;
    }

    private List<string> filterToLeastCommon(List<string> data, int position)
    {
        List<string> ones = new List<string>();
        List<string> zeroes = new List<string>();
        while (data.Count > 1)
        {
            foreach (string line in data)
            {
                if (line[position] == '1')
                {
                    ones.Add(line);
                }
                else if (line[position] == '0')
                {
                    zeroes.Add(line);
                }
            }
            position++;
            data = (zeroes.Count <= ones.Count) ? zeroes : ones;

            data = filterToLeastCommon(data, position);
        }
        return data;
    }
}