using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Day_1
{
    internal static class DaySix
    {
        public static void PuzzleOne()
        {
            string output = "";
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 6\\Input.txt");

            Queue<char> queue = new Queue<char>();
            int count = 0;
            int distinctCount = 4;

            foreach (string dataStream in file)
            {
                foreach (char c in dataStream)
                {
                    queue.Enqueue(c);
                    count++;

                    if (queue.Count == distinctCount)
                    {
                        if (queue.Distinct().Count() == distinctCount)
                        {
                            output = count.ToString();
                            break;
                        }
                        else
                        {
                            queue.Dequeue();
                        }
                    }
                }
            }

            Console.WriteLine("Puzzle One: " + output);

        }

        public static void PuzzleTwo()
        {
            string output = "";
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 6\\Input.txt");

            Queue<char> queue = new Queue<char>();
            int count = 0;
            int distinctCount = 14;

            foreach (string dataStream in file)
            {
                foreach (char c in dataStream)
                {
                    queue.Enqueue(c);
                    count++;

                    if (queue.Count == distinctCount)
                    {
                        if (queue.Distinct().Count() == distinctCount)
                        {
                            output = count.ToString();
                            break;
                        }
                        else
                        {
                            queue.Dequeue();
                        }
                    }
                }
            }

            Console.WriteLine("Puzzle Two: " + output);
        }
    }
}
