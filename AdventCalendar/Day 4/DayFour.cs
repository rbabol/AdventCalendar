using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Day_1
{
    internal static class DayFour
    {
        public static void PuzzleOne()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 4\\Input.txt");

            int count = 0;

            foreach (string sectionAssignmentPairs in file)
            {
                string[] pairs = sectionAssignmentPairs.Split(',');
                string[][] pairsTest = sectionAssignmentPairs.Split(',').Select(x => x.Split('-')).ToArray();

                int[][] pair = Array.ConvertAll(pairsTest, x => Array.ConvertAll(x, int.Parse));

                if ((pair[0][0] <= pair[1][0] && pair[0][1] >= pair[1][1]) || pair[0][0] >= pair[1][0] && pair[0][1] <= pair[1][1])
                {
                    count++;
                }
            }

            Console.WriteLine("Puzzle One: " + count);
        }

        public static void PuzzleTwo()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 4\\Input.txt");

            int count = 0;

            foreach (string sectionAssignmentPairs in file)
            {
                string[] pairs = sectionAssignmentPairs.Split(',');
                string[][] pairsTest = sectionAssignmentPairs.Split(',').Select(x => x.Split('-')).ToArray();

                int[][] pair = Array.ConvertAll(pairsTest, x => Array.ConvertAll(x, int.Parse));

                if (pair[0][0] <= pair[1][1] && pair[0][1] >= pair[1][0])
                {
                    count++;
                }
            }

            Console.WriteLine("Puzzle Two: " + count);

        }
    }
}
