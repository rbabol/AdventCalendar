using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace AdventCalendar.Day_1
{
    internal static class DayNine
    {
        public static void PuzzleOne()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 9\\Input.txt");

            Dictionary<string, Point> map = new Dictionary<string, Point>()
                {
                { "L", new Point(-1, 0)},
                { "U", new Point(0, -1)},
                { "R", new Point(1, 0)},
                { "D", new Point(0, 1)}
            };

            Point head = new Point(0, 0);
            Point tail = new Point(0, 0);

            List<Point> visitedPoints = new List<Point>();

            foreach (string cmd in file)
            {
                string[] parts = cmd.Split(' ');
                string direction = parts[0];
                int distance = int.Parse(parts[1]);

                for (int i = 0; i < distance; i++)
                {
                    head.Offset(map[direction]);

                    if (!IsAdjacent(head, tail))
                    {
                        Point offset = Point.Subtract(head, new Size(tail));

                        offset.X = Math.Sign(offset.X);
                        offset.Y = Math.Sign(offset.Y);

                        tail.Offset(offset);
                    }

                    if (!visitedPoints.Contains(tail))
                    {
                        visitedPoints.Add(tail);
                    }
                }
            }
            Console.WriteLine("Puzzle One: " + visitedPoints.Count);
        }

        public static void PuzzleTwo()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 9\\Input.txt");

            Dictionary<string, Point> map = new Dictionary<string, Point>()
            {
                { "L", new Point(-1, 0)},
                { "U", new Point(0, -1)},
                { "R", new Point(1, 0)},
                { "D", new Point(0, 1)}
            };

            Point[] knots = new Point[10];

            List<Point> visistedPoints = new List<Point>();

            foreach (string cmd in file)
            {
                string[] parts = cmd.Split(' ');
                string direction = parts[0];
                int distance = int.Parse(parts[1]);

                for (int i = 0; i < distance; i++)
                {
                    knots[0].Offset(map[direction]);

                    for (int j = 1; j < knots.Length; j++)
                    {
                        if (!IsAdjacent(knots[j-1], knots[j]))
                        {
                            Point offset = Point.Subtract(knots[j-1], new Size(knots[j]));

                            offset.X = Math.Sign(offset.X);
                            offset.Y = Math.Sign(offset.Y);

                            knots[j].Offset(offset);
                        }

                        if (!visistedPoints.Contains(knots[j]) && j == knots.Length - 1)
                        {
                            visistedPoints.Add(knots[j]);
                        }
                    }
                }

            }
            Console.WriteLine("Puzzle Two: " + visistedPoints.Count);
        }

        public static bool IsAdjacent(Point head, Point tail)
        {
            if (head.X - 1 <= tail.X && tail.X <= head.X + 1
                && head.Y - 1 <= tail.Y && tail.Y <= head.Y + 1)
            {
                return true;
            }

            return false;
        }
    }
}
