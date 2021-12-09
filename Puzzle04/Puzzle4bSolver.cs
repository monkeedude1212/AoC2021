using AdventofCode.Puzzle04;
using core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Puzzle4bSolver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        List<int> marks = new List<int>((data[0].Split(',')).Select((s, i) => int.TryParse(s, out i) ? i : 0)).ToList<int>();
        List<Board> players = new List<Board>();

        int[,] boardData = new int[5, 5];
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
            }
            else
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

        Board lastWinner = null;
        int lastScore = 0;
        foreach (int numberDrawn in marks)
        {
            Console.WriteLine(numberDrawn);
            foreach (Board player in players)
            {
                if (player.hasWon)
                {
                    continue;
                }
                player.MarkBoard(numberDrawn);
                if (player.checkWin())
                {
                    player.hasWon = true;
                    lastWinner = player;
                    Console.WriteLine("Winner!");
                    player.printBoard();
                    int unmarkedSum = lastWinner.getUnmarkedSum();
                    Console.WriteLine("Sum: " + unmarkedSum);
                    Console.WriteLine("Drawn: " + numberDrawn);
                    lastScore = (unmarkedSum * numberDrawn);
                    Console.WriteLine("Score: " + lastScore);
                }
            }
        }
        return lastScore.ToString();
    }
}