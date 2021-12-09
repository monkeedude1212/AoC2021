using FileIO;
using Puzzle7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace core
{
    public class AdventOfCode
    {
        const int PUZZLE_NUMBER = 6;
        const bool PART_B = true;

        public static void Main()
        {
            string puzzle = PART_B ? PUZZLE_NUMBER.ToString() + "b" : PUZZLE_NUMBER.ToString();
            PuzzleSolverFactory factory = new PuzzleSolverFactory();
            PuzzleSolver solver = factory.create(puzzle);

            string[] data = FileIO.PuzzleDataReader.ReadData(PUZZLE_NUMBER);

            Console.WriteLine(solver.SolvePuzzle(data));
        }
    }
}

