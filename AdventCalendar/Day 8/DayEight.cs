using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Day_1
{
    internal static class DayEight
    {
        public static void PuzzleOne()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 8\\Input.txt");

            List<List<int>> trees = new();

            foreach (string tree in file)
            {
                List<int> treeRow = Array.ConvertAll(tree.ToCharArray(), c => (int)char.GetNumericValue(c)).ToList();
                trees.Add(treeRow);
            }

            int visibleTrees = 0;

            for (int i = 0; i < trees.Count; i++)
            {
                for (int j = 0; j < trees[i].Count; j++)
                {
                    var row = trees[i];
                    var column = trees.Select(x => x[j]);

                    var rowLeft = row.Take(j).DefaultIfEmpty(-1).Max();
                    var rowRight = row.Skip(j + 1).DefaultIfEmpty(-1).Max();
                    var columnUp = column.Take(i).DefaultIfEmpty(-1).Max();
                    var columnDown = column.Skip(i + 1).DefaultIfEmpty(-1).Max();

                    if (trees[i][j] > rowLeft
                     || trees[i][j] > rowRight
                     || trees[i][j] > columnUp
                     || trees[i][j] > columnDown)
                    {
                        visibleTrees++;
                    }
                }
            }
            Console.WriteLine("Puzzle One: " + visibleTrees);
        }

        public static void PuzzleTwo()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 8\\Input.txt");

            List<List<int>> trees = new();

            foreach (string tree in file)
            {
                List<int> treeRow = Array.ConvertAll(tree.ToCharArray(), c => (int)char.GetNumericValue(c)).ToList();
                trees.Add(treeRow);
            }

            int bestScenicScore = 0;

            for (int i = 0; i < trees.Count; i++)
            {
                for (int j = 0; j < trees[i].Count; j++)
                {
                    var row = trees[i];
                    var column = trees.Select(x => x[j]);

                    var rowLeft = row.Take(j).Reverse().ToArray();
                    var rowRight = row.Skip(j + 1).ToArray();
                    var columnUp = column.Take(i).Reverse().ToArray();
                    var columnDown = column.Skip(i + 1).ToArray();

                    var leftScore = CountVisibleTrees(trees[i][j], rowLeft);
                    var rightScore = CountVisibleTrees(trees[i][j], rowRight);
                    var upScore = CountVisibleTrees(trees[i][j], columnUp);
                    var downScore = CountVisibleTrees(trees[i][j], columnDown);

                    int scenicScore = leftScore * rightScore * upScore * downScore;

                    if (scenicScore > bestScenicScore)
                    {
                        bestScenicScore = scenicScore;
                    }
                }
            }
            Console.WriteLine("Puzzle Two: " + bestScenicScore);
        }

        private static int CountVisibleTrees(int treeHouseValue, int[] treeArray)
        {
            int count = 0;

            for (int i = 0; i < treeArray.Length; i++)
            {
                if (treeHouseValue > treeArray[i])
                {
                    count++;
                }
                else
                {
                    return count + 1;
                }
            }
            return count;
        }
    }
}
