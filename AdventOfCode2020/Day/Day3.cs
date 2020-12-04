using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day3
    {
        public static void Main()
        {
            var lines = File.ReadLines(@"..\..\..\Data\day3.txt").ToArray();
            var numOfColumns = lines[0].Length;

            Console.WriteLine("Commencing Day3 A...");
            var treeCount = TraverseMap(lines,numOfColumns, 3, 1);
            Console.WriteLine(treeCount);

            Console.WriteLine("Commencing Day3 B...");
            var c1 = TraverseMap(lines, numOfColumns, 1, 1);
            var c2 = TraverseMap(lines, numOfColumns, 3, 1);
            var c3 = TraverseMap(lines, numOfColumns, 5, 1);
            var c4 = TraverseMap(lines, numOfColumns, 7, 1);
            var c5 = TraverseMap(lines, numOfColumns, 1, 2);
            double answer = c1 * c2 * c3 * c4 * c5;
            Console.WriteLine(answer);
        }
        private static int TraverseMap(string[] lines, int numOfColumns, int rightSteps, int downSteps)
        {
            var row = 0;
            var column = 0;
            var treeCount = 0;
            while (true)
            {
                row += downSteps;
                if (row >= lines.Length) { 
                    return treeCount; 
                }
                column = (column + rightSteps) % numOfColumns;
                if (lines[row][column] == '#')
                {
                    treeCount++;
                }
            }
        }
    }
}
