using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2020
{
    public class Day5
    {
        public static void Main()
        {
            var seats = File.ReadAllLines(@"..\..\..\Data\day5.txt");

            List<int> seatIds = new List<int>();
            foreach (var seat in seats)
            {
                seatIds.Add(BinarySearchTree(seat));
            }
            int highestSeatId = seatIds.Max();
            Console.WriteLine("Highest SeatId = " + highestSeatId); //it should be 704

            seatIds.Sort();
            int previous = seatIds[0];
            int mySeatId = 0;
            for(int i = 1; i < seatIds.Count(); i++)
            {
                if ((previous + 1) != seatIds[i])
                {
                    mySeatId = previous + 1;
                    break;
                }
                previous = seatIds[i];
            }
            Console.WriteLine("My Seat Id = " + mySeatId);
        }

        private static int BinarySearchTree(string seat)
        {
            var seatIdBinary = "";
            for(var i = 0; i < seat.Length; i++)
            {
                if (seat[i] == 'F') { seatIdBinary += '0'; }
                else if (seat[i] == 'B') { seatIdBinary += '1'; }
                else if (seat[i] == 'L') { seatIdBinary += '0'; }
                else if (seat[i] == 'R') { seatIdBinary += '1'; }
            }
            var row = Convert.ToInt32(seatIdBinary.Substring(0, 7), 2);
            var column = Convert.ToInt32(seatIdBinary.Substring(7, 3), 2);
            var seatId = row * 8 + column;
            return seatId;
        }
    }
}
