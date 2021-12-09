using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventofCode.Puzzle05
{
    class Line
    {
        public int startX;
        public int startY;
        public int endX;
        public int endY;

        public Line(int x1, int x2, int y1, int y2)
        {
            startX = x1;
            endX = x2;
            startY = y1;
            endY = y2;
        }

        public List<Tuple<int,int>> getAffectedCoordinates()
        {
            List<Tuple<int, int>> finalCoordinates = new List<Tuple<int, int>>();

            if (startX != endX && startY != endY)
            {
                //Diagonal Line.
                int horizontalDirection = startX < endX ? 1 : -1;
                int verticalDirection = startY < endY ? 1 : -1;
                Console.WriteLine("horizontal:" + horizontalDirection);
                Console.WriteLine("vertical:" + verticalDirection);

                for (int position = startX; position != endX + horizontalDirection; position += horizontalDirection)
                {
                    finalCoordinates.Add(new Tuple<int, int>(position, startY + ((position - startX) * (verticalDirection * horizontalDirection))));
                }

            } else
            {
                bool horizontal = (startY == endY);
                if (horizontal)
                {
                    int start = (startX > endX) ? endX : startX;
                    int distance = Math.Abs(startX - endX) + 1;
                    int[] xCoords = Enumerable.Range(start, distance).ToArray<int>();
                    foreach (int xCoordinate in xCoords)
                    {
                        finalCoordinates.Add(new Tuple<int, int>(xCoordinate, startY));
                    }
                }
                else
                {
                    int start = (startY > endY) ? endY : startY;
                    int distance = Math.Abs(startY - endY) + 1;
                    int[] yCoords = Enumerable.Range(start, distance).ToArray<int>();
                    foreach (int yCoordinate in yCoords)
                    {
                        finalCoordinates.Add(new Tuple<int, int>(startX, yCoordinate));
                    }
                }
            }

            return finalCoordinates;
        }
    }
}
