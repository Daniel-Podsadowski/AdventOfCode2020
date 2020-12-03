using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode2020
{
    public class Day2
    {
        public static void Main()
        {
            var fileInput = @"..\..\..\Data\day2.txt";
            List<String> list = new List<String>();
            var lines = File.ReadAllLines(fileInput);

            for (var i = 0; i < lines.Length; i++)
            {
                list.Add(lines[i]);
            }

            Console.WriteLine("Commencing Day2 A...");

            var numOfValidPasswords = 0;
            foreach (var line in list)
            {
                var constraint = line.Split(" ")[0];
                var minNum = int.Parse(constraint.Split("-")[0]);
                var maxNum = int.Parse(constraint.Split("-")[1]);
                var letter = char.Parse(line.Split(" ")[1].Remove(1));
                var password = line.Split(" ")[2];

                var numOfLetters = 0;
                for (var i = 0; i < password.Length; i++) {
                    if (password[i] == letter)
                    {
                        numOfLetters++;
                    }
                }

                if (numOfLetters <= maxNum && numOfLetters >= minNum)
                {
                    numOfValidPasswords++;
                }
            }
            Console.WriteLine(numOfValidPasswords);

            Console.WriteLine("Commencing Day1 A...");

            var numOfValidPasswordsB = 0;
            foreach (var line in list)
            {
                var constraint = line.Split(" ")[0];
                var pos1 = int.Parse(constraint.Split("-")[0]);
                var pos2 = int.Parse(constraint.Split("-")[1]);
                var letter = char.Parse(line.Split(" ")[1].Remove(1));
                var password = line.Split(" ")[2];

                var passPos1 = password[pos1 - 1];
                var passPos2 = password[pos2 - 1];

                if ((password[pos1-1] == letter && password[pos2-1] != letter) || (password[pos1 - 1] != letter && password[pos2 - 1] == letter)) 
                {
                    numOfValidPasswordsB++;
                }
            }
            Console.WriteLine(numOfValidPasswordsB);

        }
    }
}
