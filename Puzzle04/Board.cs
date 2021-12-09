using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventofCode.Puzzle04
{
    class Board
    {
        private int[,] data;
        private bool[,] marks;
        public bool hasWon;

        public Board(int[,] data)
        {
            this.data = (int[,])data.Clone();

            marks = new bool[data.GetLength(0), data.GetLength(1)];
            for (int column = 0; column < marks.GetLength(0); column++)
            {
                for (int row = 0; row < marks.GetLength(1); row++)
                {
                    marks[column, row] = false;
                }
            }
        }

        public void MarkBoard(int number)
        {
            for(int column = 0; column < data.GetLength(0); column++)
            {
                for (int row = 0; row < data.GetLength(1); row++)
                {
                    if (data[column, row] == number)
                    {
                        marks[column, row] = true;
                    }
                }
            }
        }

        public bool checkWin()
        {
            //Check rows
            for (int column = 0; column < data.GetLength(0); column++)
            {
                bool allRows = true;
                for (int row = 0; row < data.GetLength(1); row++)
                {
                    if (!marks[column, row])
                    {
                        allRows = false;
                    }
                }
                if (allRows)
                {
                    return true;
                }
            }

            //Check columns
            for (int row = 0; row < data.GetLength(1); row++)
            {
                bool allColumns = true;
                for (int column = 0; column < data.GetLength(0); column++)
                {

                    if (!marks[column, row])
                    {
                        allColumns = false;
                    }
                }
                if (allColumns)
                {
                    return true;
                }
            }

            return false;
        }

        public int getUnmarkedSum()
        {
            int sum = 0;
            for (int column = 0; column < marks.GetLength(0); column++)
            {
                for (int row = 0; row < marks.GetLength(1); row++)
                {
                    if (marks[column, row] == false)
                    {
                        sum += data[column, row];
                    }
                }
            }
            return sum;
        }

        public void printBoard()
        {
            for (int column = 0; column < marks.GetLength(0); column++)
            {
                for (int row = 0; row < marks.GetLength(1); row++)
                {
                    if (marks[column, row])
                    {
                        Console.Write('x');
                    }
                    Console.Write(data[column, row] + " ");
                }
                Console.WriteLine("");
            }
        }
    }
}
