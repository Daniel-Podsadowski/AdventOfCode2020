using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day8
    {
        public static void Main()
        {
            string[] instructions = File.ReadAllLines(@"..\..\..\Data\test.txt");

            var running = true;
            var i = 0;
            var accumulator = 0;
            string initialInstruction = instructions[i];
            var hasOccured = false;
            while (running)
            {
                string instruction = instructions[i];
                hasOccured = true;
                string operation = instruction.Substring(0, 3);
                string sign = instruction.Substring(4, 1);
                int value = int.Parse(instruction.Substring(5));
                if (sign == "-") { value = 0 - value; }
                
                if (instruction != initialInstruction)
                {
                    if (operation == "acc")
                    {
                        accumulator += value;
                        i++;
                    }
                    else if (operation == "jmp")
                    {
                        i += value;
                    }
                    else if (operation == "nop")
                    {
                        i++;
                    }
                }
                else
                {
                    running = false;
                }                
            }
            
        }
    }
}
