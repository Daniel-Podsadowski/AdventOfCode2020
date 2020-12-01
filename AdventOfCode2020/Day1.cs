using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public static class Day1
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\day1.txt";
            List<int> list = new List<int>();
            var lines = File.ReadAllLines(fileInput);

            for (var i=0; i < lines.Length; i++)
            {
                list.Add(int.Parse(lines[i]));
            }

            Console.WriteLine("Commencing Day1 A...");
            for (var j=0; j<list.Count; j++)
            {
                for (var k = 0; k < list.Count; k++)
                {
                    if ((list[j] != list[k]) && (list[j] + list[k] == 2020))
                    {
                        Console.WriteLine("Value1 = " + list[j]);
                        Console.WriteLine("Value2 = " + list[k]);
                        Console.WriteLine("Value1 * Value2 = " + list[j] * list[k]);
                    }
                }
            }

            Console.WriteLine("\nCommencing Day1 B...");
            for (var a = 0; a < list.Count; a++)
            {
                for (var b = 0; b < list.Count; b++)
                {
                    for (var c = 0; c < list.Count; c++)
                    {
                        if ((list[a] != list[b]) && (list[a] != list[c]) && (list[b] != list[c]) && (list[a] + list[b] +list[c] == 2020)){
                            Console.WriteLine("Value1 = " + list[a]);
                            Console.WriteLine("Value2 = " + list[b]);
                            Console.WriteLine("Value3 = " + list[c]);
                            Console.WriteLine("Value1 * Value2 * Value3= " + list[a] * list[b] * list[c]);
                        }
                    }
                }
            }
        }
    }
}
