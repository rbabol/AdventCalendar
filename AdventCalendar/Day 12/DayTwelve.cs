using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Day_1
{
    internal static class DayTwelve
    {
        public static void PuzzleOne()
        {
            string output = "";
            List<string> map = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 12\\Input.txt").ToList();

            var start = new Tile();
            start.Y = map.FindIndex(x => x.Contains('S'));
            start.X = map[start.Y].IndexOf('S');
            start.Height = 200;

            var finish = new Tile();
            finish.Y = map.FindIndex(x => x.Contains('E'));
            finish.X = map[finish.Y].IndexOf('E');

            start.SetDistance(finish.X, finish.Y);

            var activeTiles = new List<Tile>();
            activeTiles.Add(start);
            var visitedTiles = new List<Tile>();

            while (activeTiles.Count > 0)
            {
                var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

                if (checkTile.X == finish.X && checkTile.Y == finish.Y)
                {
                    Console.WriteLine("Puzzle One: " + checkTile.Cost);
                }

                visitedTiles.Add(checkTile);
                activeTiles.Remove(checkTile);

                var walkableTiles = GetWalkableTiles(map, checkTile, finish);

                foreach (var walkableTile in walkableTiles)
                {
                    //We have already visited this tile so we don't need to do so again!
                    if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                        continue;

                    //It's already in the active list, but that's OK, maybe this new tile has a better value (e.g. We might zigzag earlier but this is now straighter). 
                    if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                    {
                        var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                        if (existingTile.CostDistance > checkTile.CostDistance)
                        {
                            activeTiles.Remove(existingTile);
                            activeTiles.Add(walkableTile);
                        }
                    }
                    else
                    {
                        //We've never seen this tile before so add it to the list. 
                        activeTiles.Add(walkableTile);
                    }
                }
            }

            Console.WriteLine("Puzzle One: " + output);
        }

        public static void PuzzleTwo()
        {
            List<string> map = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 12\\Input.txt").ToList();

            var end = new Tile();
            end.Y = map.FindIndex(x => x.Contains('E'));
            end.X = map[end.Y].IndexOf('E');

            List<Tile> startTiles = new List<Tile>();
            List<int> cost = new List<int>();

            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[i].Length; j++)
                {
                    var start = new Tile();
                    start.Y = i;
                    start.X = j;
                    start.Height = map[i][j];

                    if (map[i][j] == 'a' && GetWalkableTiles(map, start, end).Count > 0)
                    {
                        startTiles.Add(start);
                    }
                }
            }
            foreach (Tile start in startTiles)
            {

                start.SetDistance(end.X, end.Y);

                var visitedTiles = new List<Tile>();
                var activeTiles = new List<Tile>();
                activeTiles.Add(start);

                while (activeTiles.Count > 0)
                {
                    var checkTile = activeTiles.OrderBy(x => x.CostDistance).First();

                    if (checkTile.X == end.X && checkTile.Y == end.Y)
                    {
                        cost.Add(checkTile.Cost);
                    }

                    visitedTiles.Add(checkTile);
                    activeTiles.Remove(checkTile);

                    var walkableTiles = GetWalkableTiles(map, checkTile, end);

                    foreach (var walkableTile in walkableTiles)
                    {
                        if (visitedTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                            continue;

                        if (activeTiles.Any(x => x.X == walkableTile.X && x.Y == walkableTile.Y))
                        {
                            var existingTile = activeTiles.First(x => x.X == walkableTile.X && x.Y == walkableTile.Y);
                            if (existingTile.CostDistance > checkTile.CostDistance)
                            {
                                activeTiles.Remove(existingTile);
                                activeTiles.Add(walkableTile);
                            }
                        }
                        else
                        {
                            activeTiles.Add(walkableTile);
                        }
                    }
                }
            }

            Console.WriteLine("Puzzle Two: " + cost.Min());
        }

        private static List<Tile> GetWalkableTiles(List<string> map, Tile currentTile, Tile targetTile)
        {
            var possibleTiles = new List<Tile>()
             {
                 new Tile { X = currentTile.X, Y = currentTile.Y - 1, Parent = currentTile, Cost = currentTile.Cost + 1 },
                 new Tile { X = currentTile.X, Y = currentTile.Y + 1, Parent = currentTile, Cost = currentTile.Cost + 1},
                 new Tile { X = currentTile.X - 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
                 new Tile { X = currentTile.X + 1, Y = currentTile.Y, Parent = currentTile, Cost = currentTile.Cost + 1 },
             };


            var maxX = map.First().Length - 1;
            var maxY = map.Count - 1;

            possibleTiles = possibleTiles
                    .Where(tile => tile.X >= 0 && tile.X <= maxX)
                    .Where(tile => tile.Y >= 0 && tile.Y <= maxY).ToList();

            possibleTiles.ForEach(tile => tile.SetDistance(targetTile.X, targetTile.Y));
            possibleTiles.ForEach(tile => tile.Height = map[tile.Y][tile.X]); //Convert alphabet to height


            return possibleTiles
                    .Where(tile => tile.Height <= currentTile.Height + 1 || map[tile.Y][tile.X] == 'B')
                    .ToList();
        }
    }

    public class Tile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Cost { get; set; }
        public int Distance { get; set; }
        public int Height { get; set; }
        public int CostDistance => Cost + Distance;
        public Tile Parent { get; set; }

        public void SetDistance(int targetX, int targetY)
        {
            this.Distance = Math.Abs(targetX - X) + Math.Abs(targetY - Y);
        }
    }
}
