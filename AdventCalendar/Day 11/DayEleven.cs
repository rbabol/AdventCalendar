using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Day_1
{
    internal static class DayEleven
    {
        public static void PuzzleOne()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 11\\Input.txt");

            List<Monkey> monkeys = new List<Monkey>();
            int monkeyIndex = -1;

            for (long i = 0; i < file.Length; i++)
            {
                if (file[i].StartsWith("Monkey")) //New Monkey
                {
                    monkeys.Add(new Monkey());
                    monkeyIndex++;
                }
                else if (file[i].Trim().StartsWith("Starting items"))
                {
                    List<long> items = Array.ConvertAll(file[i].Split(':')[1].Split(','), long.Parse).ToList();

                    monkeys[monkeyIndex].Items = items;
                }
                else if (file[i].Trim().StartsWith("Operation"))
                {
                    monkeys[monkeyIndex].Operator = file[i].Trim().Split(':')[1].Trim();
                }
                else if (file[i].Trim().StartsWith("Test"))
                {
                    monkeys[monkeyIndex].Test = long.Parse(file[i].Trim().Split(' ')[3]);
                }
                else if (file[i].Trim().StartsWith("If true"))
                {
                    monkeys[monkeyIndex].TrueMonkey = int.Parse(file[i].Trim().Split(' ')[5]);
                }
                else if (file[i].Trim().StartsWith("If false"))
                {
                    monkeys[monkeyIndex].FalseMonkey = int.Parse(file[i].Trim().Split(' ')[5]);
                }
            }

            for (long i = 0; i < 20; i++)
            {
                foreach (Monkey monkey in monkeys)
                {
                    while(monkey.Items.Count > 0)
                    {
                        long newWorry = monkey.CalculateOperator() / 3;

                        monkey.Items.RemoveAt(0);

                        if (newWorry % monkey.Test == 0)
                        {
                            monkeys[monkey.TrueMonkey].Items.Add(newWorry);
                        }
                        else
                        {
                            monkeys[monkey.FalseMonkey].Items.Add(newWorry);
                        }

                        monkey.InspectionCount++;
                    }
                }
            }

            var monkeyBusiness = monkeys.OrderByDescending(x => x.InspectionCount).Take(2).ToArray();
            Console.WriteLine("Puzzle One: " + monkeyBusiness[0].InspectionCount * monkeyBusiness[1].InspectionCount);
        }

        public static void PuzzleTwo()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 11\\Input.txt");

            List<Monkey> monkeys = new List<Monkey>();
            int monkeyIndex = -1;

            for (long i = 0; i < file.Length; i++)
            {
                if (file[i].StartsWith("Monkey")) //New Monkey
                {
                    monkeys.Add(new Monkey());
                    monkeyIndex++;
                }
                else if (file[i].Trim().StartsWith("Starting items"))
                {
                    List<long> items = Array.ConvertAll(file[i].Split(':')[1].Split(','), long.Parse).ToList();

                    monkeys[monkeyIndex].Items = items;
                }
                else if (file[i].Trim().StartsWith("Operation"))
                {
                    monkeys[monkeyIndex].Operator = file[i].Trim().Split(':')[1].Trim();
                }
                else if (file[i].Trim().StartsWith("Test"))
                {
                    monkeys[monkeyIndex].Test = long.Parse(file[i].Trim().Split(' ')[3]);
                }
                else if (file[i].Trim().StartsWith("If true"))
                {
                    monkeys[monkeyIndex].TrueMonkey = int.Parse(file[i].Trim().Split(' ')[5]);
                }
                else if (file[i].Trim().StartsWith("If false"))
                {
                    monkeys[monkeyIndex].FalseMonkey = int.Parse(file[i].Trim().Split(' ')[5]);
                }
            }

            for (long i = 0; i < 10000; i++)
            {
                foreach (Monkey monkey in monkeys)
                {
                    while (monkey.Items.Count > 0)
                    {
                        long newWorry = monkey.CalculateOperator();

                        monkey.Items.RemoveAt(0);

                        newWorry %= monkeys.Aggregate(1, (long x, Monkey monkey) => x * monkey.Test);

                        if (newWorry % monkey.Test == 0)
                        {
                            monkeys[monkey.TrueMonkey].Items.Add(newWorry);
                        }
                        else
                        {
                            monkeys[monkey.FalseMonkey].Items.Add(newWorry);
                        }

                        monkey.InspectionCount++;
                    }
                }
            }

            var monkeyBusiness = monkeys.OrderByDescending(x => x.InspectionCount).Take(2).ToArray();
            Console.WriteLine("Puzzle Two: " + monkeyBusiness[0].InspectionCount * monkeyBusiness[1].InspectionCount);
        }
    }

    public class Monkey
    {
        public List<long> Items { get; set; } = new List<long>();
        public string Operator { get; set; } = "";
        public long Test { get; set; } = 0;
        public int TrueMonkey { get; set; } = 0;
        public int FalseMonkey { get; set; } = 0;
        public long InspectionCount { get; set; } = 0;
        public Monkey(List<long> items, string op, long test, int trueMonkey, int falseMonkey)
        {
            Items = items;
            Operator = op;
            Test = test;
            TrueMonkey = trueMonkey;
            FalseMonkey = falseMonkey;
        }

        public Monkey()
        {

        }

        public long CalculateOperator()
        {
            string[] cmd = Operator.Split(' ');
            long variableOne = Items[0];
            long variableTwo = Items[0];

            if (cmd[4] != "old")
            {
                variableTwo = long.Parse(cmd[4]);
            }

            //Structure: new = old + 3
            switch (cmd[3])
            {
                case "*": return variableOne * variableTwo;
                case "-": return variableOne - variableTwo;
                case "+": return variableOne + variableTwo;
                case "/": return variableOne / variableTwo;

                default: throw new Exception("invalid logic");
            }
        }
    }
}
