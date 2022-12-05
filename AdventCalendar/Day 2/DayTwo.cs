using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AdventCalendar.Day_1
{
    internal static class DayTwo
    {
        public static void PuzzleOne()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 2\\Input.txt");

            int score = 0;
            int lossScore = 0;
            int drawScore = 3;
            int winScore = 6;

            foreach (string game in file)
            {
                string[] letters = game.Split(' ');
                if (letters[1] == "X")
                {
                    int shapeScore = 1;

                    if (letters[0] == "A")
                    {
                        score += drawScore + shapeScore;
                    }
                    else if (letters[0] == "B")
                    {
                        score += lossScore + shapeScore;
                    }
                    else if (letters[0] == "C")
                    {
                        score += winScore + shapeScore;
                    }
                }
                else if (letters[1] == "Y")
                {
                    int shapeScore = 2;

                    if (letters[0] == "A")
                    {
                        score += winScore + shapeScore;
                    }
                    else if (letters[0] == "B")
                    {
                        score += drawScore + shapeScore;
                    }
                    else if (letters[0] == "C")
                    {
                        score += lossScore + shapeScore;
                    }

                }
                else if (letters[1] == "Z")
                {
                    int shapeScore = 3;

                    if (letters[0] == "A")
                    {
                        score += lossScore + shapeScore;

                    }
                    else if (letters[0] == "B")
                    {
                        score += winScore + shapeScore;
                    }
                    else if (letters[0] == "C")
                    {
                        score += drawScore + shapeScore;
                    }
                }
            }

            Console.WriteLine("Puzzle One: " + score);
        }

        public static void PuzzleTwo()
        {
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 2\\Input.txt");

            int score = 0;
            int lossScore = 0;
            int drawScore = 3;
            int winScore = 6;

            int rockScore = 1;
            int paperScore= 2;
            int scissorsScore = 3;

            foreach (string game in file)
            {
                string[] letters = game.Split(' ');
                if (letters[0] == "A")
                {
                    if (letters[1] == "X")
                    {
                        score += lossScore + scissorsScore;
                    }
                    else if (letters[1] == "Y")
                    {
                        score += drawScore + rockScore;
                    }
                    else if (letters[1] == "Z")
                    {
                        score += winScore + paperScore;
                    }
                }
                else if (letters[0] == "B")
                {
                    if (letters[1] == "X")
                    {
                        score += lossScore + rockScore;
                    }
                    else if (letters[1] == "Y")
                    {
                        score += drawScore + paperScore;
                    }
                    else if (letters[1] == "Z")
                    {
                        score += winScore + scissorsScore;
                    }

                }
                else if (letters[0] == "C")
                {
                    if (letters[1] == "X")
                    {
                        score += lossScore + paperScore;
                    }
                    else if (letters[1] == "Y")
                    {
                        score += drawScore + scissorsScore;
                    }
                    else if (letters[1] == "Z")
                    {
                        score += winScore + rockScore;
                    }
                }
            }
            Console.WriteLine("Puzzle Two: " + score);
        }
    }
}
