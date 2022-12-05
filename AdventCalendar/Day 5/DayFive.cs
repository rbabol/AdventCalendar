using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Day_1
{
    internal static class DayFive
    {
        public static void PuzzleOne()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 5\\Input.txt");

            string output = "";
            List<List<string>> boxes = new List<List<string>>();

            for (int i = 0; i < 9; i++)
            {
                List<string> row = new List<string>();
                boxes.Add(row);
            }

            for (int i = 7; i >= 0; i--)
            {
                for (int j = 0; j < 9; j++)
                {
                    boxes[j].Add(file[i].Substring(j + 1 + (j * 3), 1));
                }
            }

            boxes.Select(x => x.RemoveAll(string.IsNullOrWhiteSpace));
            
            for (int i = 10; i < file.Length; i++)
            {
                char[] chars = file[i].Where(x => char.IsDigit(x) || x == ' ').ToArray();
                int[] orders = Array.ConvertAll(new string(chars).Substring(0, chars.Length).Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray(), int.Parse);

                for (int j = 0; j < orders[0]; j++)
                {
                    var removeColumn = boxes[orders[1] - 1];
                    var addColumn = boxes[orders[2] - 1];

                    var boxToRemove = removeColumn.Last();
                    removeColumn.RemoveAt(removeColumn.Count - 1);
                    addColumn.Add(boxToRemove);
                    
                }
            }

            Console.WriteLine("Puzzle One: " + output);
        }

        public static void PuzzleTwo()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 5\\Input.txt");
            string output = "";

            Console.WriteLine("Puzzle Two: " + output);
        }
    }
}
