using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Day_1
{
    internal static class DayOne
    {
        public static void PuzzleOne()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 1\\Input.txt");

            int currentTotal = 0;
            int highest = 0;

            foreach (string line in file)
            {
                if (line.Length == 0)
                {
                    if (currentTotal > highest)
                    {
                        highest = currentTotal;
                    }
                    currentTotal = 0;
                }
                else
                {
                    int i = int.Parse(line);

                    currentTotal += i;
                }
            }
        }

        public static void PuzzleTwo()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 1\\Input.txt");

            List<int> totals = new List<int>();
            int currentTotal = 0;
            int topThreeTotal = 0;

            foreach (string line in file)
            {
                if (line.Length == 0)
                {
                    totals.Add(currentTotal);
                    currentTotal = 0;
                }
                else
                {
                    int i = int.Parse(line);

                    currentTotal += i;
                }
            }

            topThreeTotal = totals.OrderDescending().Take(3).Sum();
        }
    }
}
