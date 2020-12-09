using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day6
    {
        public static void Main()
        {
            var lines = File.ReadAllLines(@"..\..\..\Data\day6.txt");

            var sumOfCounts = 0;
            var sumOfEveryoneCounts = 0;
            var groupAnswers = "";
            var numOfPeopleInGroup = 0;
            List<char> groupAnswerList = new List<char>();
            foreach (var line in lines)
            {
                line.Trim();
                if (line == "")
                {
                    foreach (var character in groupAnswers)
                    {
                        if (!groupAnswerList.Contains(character))
                        {
                            groupAnswerList.Add(character);
                        }
                    }
                    sumOfCounts += groupAnswerList.Count();
                    
                    string distinctLetters = "";
                    foreach (var letter in groupAnswers)
                    {
                        if (!distinctLetters.Contains(letter))
                        {
                            distinctLetters += letter;
                        }
                    }

                    var numOfGroupCounts = 0;
                    foreach (var letter2 in distinctLetters)
                    {
                        if (groupAnswers.Count(x => x == letter2) == numOfPeopleInGroup)
                        {
                            numOfGroupCounts++;
                        }
                    }
                    sumOfEveryoneCounts += numOfGroupCounts;

                    groupAnswers = "";
                    numOfPeopleInGroup = 0;
                    groupAnswerList.RemoveRange(0, groupAnswerList.Count);
                }
                else
                {
                    if (groupAnswers == "") { groupAnswers = line; }
                    else { groupAnswers += line; }
                    numOfPeopleInGroup++;
                }
            }
            Console.WriteLine("Sum of questions which were answered yes = " + sumOfCounts);
            Console.WriteLine("Sum of questions which everyone answered = " + sumOfEveryoneCounts);
        }
    }
}
