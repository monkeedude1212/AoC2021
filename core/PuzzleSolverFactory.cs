
using Puzzle9;
using Puzzle7;
using Puzzle13;

namespace core
{
    public class PuzzleSolverFactory
    {
        public PuzzleSolver create(string puzzle)
        {
            switch (puzzle)
            {
                case "1":
                    return new Puzzle1aSolver();
                    break;
                case "1b":
                    return new Puzzle1bSolver();
                    break;
                case "2":
                    return new Puzzle2Solver();
                    break;
                case "2b":
                    return new Puzzle2bSolver();
                    break;
                case "3":
                    return new Puzzle3Solver();
                    break;
                case "3b":
                    return new Puzzle3bSolver();
                    break;
                case "4":
                    return new Puzzle4Solver();
                    break;
                case "4b":
                    return new Puzzle4bSolver();
                    break;
                case "5":
                    return new Puzzle5Solver();
                    break;
                case "5b":
                    return new Puzzle5bSolver();
                    break;
                case "6":
                    return new Puzzle6Solver();
                    break;
                case "6b":
                    return new Puzzle6bSolver();
                    break;
                case "7":
                    return new Puzzle7Solver();
                    break;
                case "7b":
                    return new Puzzle7bSolver();
                    break;
                case "8":
                    return new Puzzle8Solver();
                    break;
                case "8b":
                    return new Puzzle8bSolver();
                    break;
                case "9":
                    return new Puzzle9Solver();
                    break;
                case "9b":
                    return new Puzzle9bSolver();
                    break;
                case "10":
                    return new Puzzle10Solver();
                    break;
                case "10b":
                    return new Puzzle10bSolver();
                    break;
                case "11":
                    return new Puzzle11Solver();
                    break;
                case "11b":
                    return new Puzzle11bSolver();
                    break;
                case "12":
                    return new Puzzle12Solver();
                    break;
                case "12b":
                    return new Puzzle12bSolver();
                    break;
                case "13":
                    return new Puzzle13Solver();
                    break;
                case "13b":
                    return new Puzzle13bSolver();
                    break;
                default:
                    throw new System.Exception("Invalid Arguments");
                    break;
            }
        }
    }
}