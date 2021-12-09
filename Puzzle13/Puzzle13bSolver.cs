using core;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Puzzle13
{
    public class Puzzle13bSolver : PuzzleSolver
    {
        private const long iterations = 10000000000;
        public string SolvePuzzle(string[] data)
        {
            Dictionary<int, int> busIdOffsets = new Dictionary<int, int>();
            List<int> busIds = new List<int>();
            string[] ids = data[1].Split(',');
            int index = 0;
            foreach (string id in ids)
            {
                int value;
                bool converted = int.TryParse(id, out value);
                if (converted)
                {
                    busIds.Add(value);
                    busIdOffsets.Add(value, index);
                }
                index++;
            }

            int threadcount = Environment.ProcessorCount;
            List<Task> tasks = new List<Task>();

            for(int i = 0; i < threadcount; i++)
            {
                Task<string> task = Task.Factory.StartNew<string>(() =>
                {
                    return RunTask(iterations * i, busIdOffsets);
                });
                tasks.Add(task);
            }

            bool finished = false;
            string result = "No Result";
            while(!finished)
            {
                foreach (Task<string> task in tasks)
                {
                    if (task.IsCompleted)
                    {
                        result = task.Result;
                        finished = true;
                        break;
                    }
                }
            }
            return result;
        }

        private static string RunTask(long timestamp, Dictionary<int, int> busIdOffsets)
        {
            bool success = false;
            while (!success)
            {
                foreach (KeyValuePair<int, int> record in busIdOffsets)
                {
                    if ((timestamp + record.Value) % record.Key == 0) // If timestamp + offset mod the minute value is 0, as in, BUS DEPARTS NOW
                    {
                        success = true;
                    }
                    else
                    {
                        success = false;
                        break;
                    }
                }
                if (timestamp > long.MaxValue)
                {
                    return "I CAN'T";
                }
                if (success)
                {
                    return timestamp.ToString();
                }
                timestamp++;
            }
            return "ERROR";
        }
    }
}