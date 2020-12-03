using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class Day3
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\day3.txt";
            List<String> list = new List<String>();
            var lines = File.ReadAllLines(fileInput);

            for (var i = 0; i < lines.Length; i++)
            {
                list.Add(lines[i]);
            }

            Console.WriteLine("Commencing Day3 A...");
            //idk
        }
    }
}
