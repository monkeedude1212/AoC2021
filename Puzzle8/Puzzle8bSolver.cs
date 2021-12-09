using core;

public class Puzzle8bSolver : PuzzleSolver
{
    public string SolvePuzzle(string[] data)
    {
        InstructionCounter computer = new InstructionCounter(data);
        return computer.Computeb().ToString();
    }
}