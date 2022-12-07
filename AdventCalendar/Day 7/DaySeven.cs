using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventCalendar.Day_1
{
    internal static class DaySeven
    {
        static int totalSum = 0;
        static List<Folder> folders = new List<Folder>();

        public static void PuzzleOne()
        {
            string output = "";
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 7\\Input.txt");

            Folder? currentDirectory = new Folder("/", null);
            currentDirectory = ParseFile(file, currentDirectory);

            RecurseFolder(currentDirectory);

            Console.WriteLine("Puzzle One: " + totalSum);
        }

        public static void PuzzleTwo()
        {
            string output = "";
            string[] file = File.ReadAllLines("C:\\Users\\rbabol\\source\\repos\\AdventCalendar\\AdventCalendar\\Day 7\\Input.txt");

            Folder? currentDirectory = new Folder("/", null);
            currentDirectory = ParseFile(file, currentDirectory);

            RecurseFolder(currentDirectory);

            int availableSpace = 70000000 - currentDirectory.Size;

            Folder folder = folders.Where(x => x.Size > 30000000 - availableSpace).OrderBy(x => x.Size).First();

            Console.WriteLine("Puzzle Two: " + folder.Size);

        }

        private static Folder? ParseFile(string[] file, Folder? currentDirectory)
        {
            for (int i = 0; i < file.Length; i++)
            {
                if (file[i].Contains("cd"))
                {
                    if (file[i].Contains(".."))
                    {//Out one level
                        if (currentDirectory.Parent != null)
                        {
                            currentDirectory = currentDirectory.Parent;
                        }
                    }
                    else if (file[i].Contains('/'))
                    {//outermost dir

                        while (currentDirectory.Parent != null)
                        {
                            currentDirectory = currentDirectory.Parent;
                        }
                    }
                    else
                    {//in one level to X directory
                        currentDirectory = currentDirectory.Children.FirstOrDefault(x => x.Directory == file[i].Split(' ')[2]);
                    }
                }
                else if (file[i].Contains("ls"))
                {
                    i++;

                    for (; i < file.Length; i++)
                    {
                        string[] cmd = file[i].Split(' ');
                        if (cmd[0].Contains('$'))
                        {
                            i--;
                            break;
                        }

                        if (file[i].Contains("dir"))
                        {
                            Folder f = new Folder(cmd[1], currentDirectory);
                            currentDirectory.Children.Add(f);
                        }
                        else
                        {
                            AFile f = new AFile(cmd[1], int.Parse(cmd[0]));
                            currentDirectory.Files.Add(f);
                        }
                    }
                }
            }

            //Reset to top
            while (currentDirectory.Parent != null)
            {
                currentDirectory = currentDirectory.Parent;
            }

            return currentDirectory;
        }

        public static int RecurseFolder(Folder topFolder)
        {
            int folderSum = 0;

            foreach (AFile file in topFolder.Files)
            {
                topFolder.Size += file.Size;
                folderSum += file.Size;
            }

            foreach (Folder folder in topFolder.Children)
            {
                folderSum += RecurseFolder(folder);
                topFolder.Size += folder.Size;
            }

            if (folderSum < 100000)
            {
                totalSum += folderSum;
            }

            folders.Add(topFolder);
            return folderSum;
        }
    }

    internal class Folder
    {
        public string Directory { get; set; }
        public List<Folder>? Children { get; set; }
        public Folder? Parent { get; set; }
        public List<AFile> Files { get; set; }
        public int Size { get; set; }

        public Folder(string directory, Folder? parent)
        {
            Directory = directory;
            Children = new List<Folder>();
            Parent = parent;

            Files = new List<AFile>();
            Size = 0;
        }
    }

    internal class AFile
    {
        public string Name { get; set; }
        public int Size { get; set; }

        public AFile(string name, int size)
        {
            Name = name;
            Size = size;
        }
    }
}
