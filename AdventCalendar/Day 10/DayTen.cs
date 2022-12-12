using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Day_1
{
    internal static class DayTen
    {
        public static void PuzzleOne()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 10\\Input.txt");

            int cycle = 1;
            int signalSum = 0;
            int registerValue = 1;

            Dictionary<int, int> cmdQueue = new Dictionary<int, int>();

            for (int i = 0; i < file.Length; i++)
            {
                int runToCycle = 0;

                if (file[i].Contains("add"))
                {
                    runToCycle = cycle + 2;
                    int amount = Convert.ToInt32(file[i].Split(' ')[1]);

                    cmdQueue.Add(runToCycle, amount);
                }
                else
                {
                    runToCycle = cycle + 1;
                }

                while (cycle < runToCycle)
                {
                    if ((cycle - 20) % 40 == 0)
                    {
                        signalSum += registerValue * cycle;
                    }
                    cycle++;

                    if (cmdQueue.ContainsKey(cycle))
                    {
                        registerValue += cmdQueue[cycle];
                        cmdQueue.Remove(cycle);
                    }
                }
            }
            Console.WriteLine("Puzzle One: " + signalSum);
        }

        public static void PuzzleTwo()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 10\\Input.txt");

            int cycle = 1;
            int currentPosition = 0;
            int registerValue = 1;

            Dictionary<int, int> cmdQueue = new Dictionary<int, int>();

            for (int i = 0; i < file.Length; i++)
            {
                int runToCycle = 0;

                if (file[i].Contains("add"))
                {
                    runToCycle = cycle + 2;
                    int amount = Convert.ToInt32(file[i].Split(' ')[1]);

                    cmdQueue.Add(cycle + 1, amount);
                }
                else
                {
                    runToCycle = cycle + 1;
                }

                while (cycle < runToCycle)
                {
                    char pixel = '.';

                    if (registerValue - 1 <= currentPosition && currentPosition <= registerValue + 1)
                    {
                        pixel = '#';
                    }

                    Console.Write(pixel);

                    if (cmdQueue.ContainsKey(cycle))
                    {
                        registerValue += cmdQueue[cycle];
                        cmdQueue.Remove(cycle);
                        //Console.WriteLine(" Cycle: " + cycle + " Register: " + registerValue);
                    }

                    cycle++;
                    currentPosition++;

                    if (currentPosition % 40 == 0)
                    {
                        //New Line
                        Console.Write("\n");
                        currentPosition = 0;
                    }
                }
            }
            //Console.WriteLine("Puzzle One: " + signalSum);
        }
    }
}
