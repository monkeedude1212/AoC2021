using AdventofCode.Puzzle04;
using core;
using System;
using System.Linq;
using System.Collections.Generic;

public class Puzzle4Solver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        List<int> marks = new List<int>((data[0].Split(',')).Select((s, i) => int.TryParse(s, out i) ? i : 0 )).ToList<int>();
        List<Board> players = new List<Board>();

        int[,] boardData= new int[5,5];
        int currentRow = 0;
        
        // Build the boards
        for (int i = 1; i < data.Length; i++)
        {
            // Skip empty lines. 
            if (data[i].Length < 2)
            {
                players.Add(new Board(boardData));
                currentRow = 0;
                continue;
            } else
            {
                string[] currentRowString = data[i].Split(' ');
                int currentColumn = 0;
                foreach (string number in currentRowString)
                {
                    if (number.Length == 0)
                    {
                        continue; // skip empty string
                    }

                    int value = int.Parse(number);
                    boardData[currentRow, currentColumn] = value;
                    currentColumn++;
                }
                currentRow++;
            }
        }
        foreach (Board player in players)
        {
            Console.WriteLine("Players:");
            player.printBoard();
        }

        foreach(int numberDrawn in marks)
        {
            Console.WriteLine(numberDrawn);
            foreach (Board player in players)
            {
                player.MarkBoard(numberDrawn);
                if (player.checkWin())
                {
                    Console.WriteLine("Winner!");
                    player.printBoard();
                    int unmarkedSum = player.getUnmarkedSum();
                    Console.WriteLine("Sum: " + unmarkedSum);
                    Console.WriteLine("Drawn: " + numberDrawn);
                    return (unmarkedSum * numberDrawn).ToString();
                }
            }
        }
        return "No Winner Found";
    }
}