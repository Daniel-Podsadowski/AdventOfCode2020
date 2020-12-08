using System;
using System.IO;

namespace AdventOfCode2020
{
    public class Day5
    {
        public static void Main()
        {
            var seats = File.ReadAllLines(@"..\..\..\Data\day5.txt");

            int highestSeatId = 0;
            foreach (var seat in seats)
            {
                var seatId = BinarySearchTree(seat);
                if (seatId > highestSeatId)
                {
                    highestSeatId = seatId;
                }
            }
            Console.WriteLine("Highest SeatId = " + highestSeatId);

        }

        private static int BinarySearchTree(string seat)
        {
            int row = 0, column = 0, low = 0, mid = 63, high = 127, seatId = 0;
            for (int i = 0; i < 7; i++)
            {
                var letter = seat[i];
                if (letter == 'F')
                {
                    high = mid;
                }
                else {
                    low = mid;
                }
                mid = (low + high) / 2;
            }
            row = high;
            low = 0;
            mid = 4;
            high = 7;
            for (var i = 7; i < 10; i++)
            {
                var letter = seat[i];
                if (letter == 'L') { 
                    high = mid;
                }
                else {
                    low = mid;
                }
                mid = (low + high) / 2;
            }
            column = high;
            seatId = (row * 8) + column;
            return seatId;
        }
    }
}
