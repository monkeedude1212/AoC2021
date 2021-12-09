using core;

public class Puzzle8Solver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        InstructionCounter computer = new InstructionCounter(data);
        return computer.Compute().ToString();
    }
}