using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AdventCalendar.Day_1
{
    internal static class DayThree
    {
        public static void PuzzleOne()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 3\\Input.txt");

            int total = 0;

            foreach (string rucksack in file)
            {
                int halfLength = (rucksack.Length / 2);

                string firstCompartment = rucksack.Substring(0, halfLength);
                string secondCompartment = rucksack.Substring(halfLength, halfLength);

                char[] intersect = firstCompartment.Intersect(secondCompartment).ToArray();
                total += GetPriority(intersect);
            }

            Console.WriteLine("Puzzle One: " + total);
        }

        public static void PuzzleTwo()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 3\\Input.txt");

            int total = 0;

            for (int i = 0; i < file.Length; i += 3)
            {
                char[] intersect = file[i].Intersect(file[i + 1]).Intersect(file[i + 2]).ToArray();
                total += GetPriority(intersect);
            }
            Console.WriteLine("Puzzle Two: " + total);
        }

        private static int GetPriority(char[] intersect)
        {
            int total = 0;

            foreach (char item in intersect)
            {
                int priorityValue = 0;

                if (char.IsUpper(item))
                {
                    priorityValue = item - 38;
                }
                else
                {
                    priorityValue = item - 96;
                }
                total += priorityValue;
            }

            return total;
        }
    }
}
