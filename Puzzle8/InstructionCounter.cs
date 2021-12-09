using System;
using System.Collections.Generic;

public class InstructionCounter
{
    List<KeyValuePair<int, Instruction>> instructions;
    List<int> instructionIdsRan;
    int accumulatorValue;

    public InstructionCounter(string[] data)
    {
        instructions = new List<KeyValuePair<int, Instruction>>();
        instructionIdsRan = new List<int>();

        int index = 0;
        foreach(string line in data)
        {
            string[] info = line.Split(' ');
            Instruction instruction = new Instruction(info[0], info[1]);
            instructions.Add(new KeyValuePair<int, Instruction>(index, instruction));
            index++;
        }

        this.accumulatorValue = 0;
    }

    public int Computeb()
    {
        try
        {
            int index = 0;
            while (index < instructions.Count)
            {
                index = runInstruction(instructions[index]);
            }
        } catch (InfiniteLoopException exception)
        {
            string path = @"C:\Users\nat_h\Desktop\AdventOfCode\puzzle8debug.txt";
            System.IO.StreamWriter writer = new System.IO.StreamWriter(path, false);
            foreach (int id in instructionIdsRan)
            {
                if(instructions[id].Value.instructionType == InstructionType.nop && instructions[id].Value.value + id > 642)
                {
                    Console.WriteLine("EasyFix");
                }

                if (instructions[id].Value.instructionType == InstructionType.jmp && id > 640)
                {
                    Console.WriteLine("EasyFix");
                }
            }
        }

        return accumulatorValue;
    }

    public int Compute()
    {
        try
        {
            int index = 0;
            while (index < instructions.Count)
            {
                index = runInstruction(instructions[index]);
            }
        }
        catch (InfiniteLoopException exception)
        {
            return accumulatorValue;
        }

        return 0;
    }

    /**
     * Runs the instruction and returns the next instruction index.
     * */
    private int runInstruction(KeyValuePair<int, Instruction> currentLine)
    {
        int nextInstructionIndex = 0;
        switch(currentLine.Value.instructionType)
        {
            case InstructionType.nop:
                nextInstructionIndex = currentLine.Key + 1;
                break;
            case InstructionType.acc:
                accumulatorValue += currentLine.Value.value;
                nextInstructionIndex = currentLine.Key + 1;
                break;
            case InstructionType.jmp:
                nextInstructionIndex = currentLine.Key + currentLine.Value.value;
                break;
        }
        instructionIdsRan.Add(currentLine.Key);
        if (instructionIdsRan.Contains(nextInstructionIndex))
        {
            throw new InfiniteLoopException();
        }

        return nextInstructionIndex;
    }


    private class Instruction
    {
        public InstructionType instructionType;
        public int value;

        public Instruction(string inputInstructionType, string inputValue)
        {
            int.TryParse(inputValue, out value);
            switch (inputInstructionType)
            {
                case "acc":
                    instructionType = InstructionType.acc;
                    break;
                case "nop":
                    instructionType = InstructionType.nop;
                    break;
                case "jmp":
                    instructionType = InstructionType.jmp;
                    break;
            }
        }

        public override string ToString()
        {
            return instructionType.ToString() + ": " + value.ToString();
        }
    }

    private enum InstructionType
    {
        nop,
        acc,
        jmp
    }
    
    private class InfiniteLoopException : Exception
    {

    }


}