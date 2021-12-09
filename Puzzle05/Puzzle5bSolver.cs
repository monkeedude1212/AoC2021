using AdventofCode.Puzzle05;
using core;
using System;
using System.Collections.Generic;

public class Puzzle5bSolver : PuzzleSolver
{
    private int[,] terrain;
    public string SolvePuzzle(string[] data)
    {
        terrain = new int[1000, 1000];
        List<Line> lines = new List<Line>();
        foreach (string line in data)
        {
            string start = line.Split(new char[] { '-', '>' }, System.StringSplitOptions.RemoveEmptyEntries)[0];
            string end = line.Split(new char[] { '-', '>' }, System.StringSplitOptions.RemoveEmptyEntries)[1];
            int startX = int.Parse(start.Split(',')[0]);
            int startY = int.Parse(start.Split(',')[1]);
            int endX = int.Parse(end.Split(',')[0]);
            int endY = int.Parse(end.Split(',')[1]);
            lines.Add(new Line(startX, endX, startY, endY));
        }

        foreach (Line line in lines)
        {
            List<Tuple<int, int>> coordinates = line.getAffectedCoordinates();
            foreach (Tuple<int, int> coordinate in coordinates)
            {
                Console.WriteLine("Coordinate:" + coordinate.Item1 + "," + coordinate.Item2);
                terrain[coordinate.Item2, coordinate.Item1]++;
            }
            Console.WriteLine("---");
        }

        int points = 0;
        for (int i = 0; i < terrain.GetLength(0); i++)
        {
            for (int j = 0; j < terrain.GetLength(1); j++)
            {
                Console.Write(terrain[i, j]);
                if (terrain[i, j] > 1)
                {
                    points++;
                }
            }
            Console.WriteLine();
        }


        return points.ToString();
    }
}