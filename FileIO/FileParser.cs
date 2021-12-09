
namespace FileIO
{
    public static class PuzzleDataReader
    {
        public static string[] ReadData(int puzzle)
        {
            string path = @"C:\Users\nat_h\Desktop\AdventOfCode\puzzle" + puzzle.ToString() + ".txt";
            string[] lines = System.IO.File.ReadAllLines(path);
            return lines;
        }
    }
}