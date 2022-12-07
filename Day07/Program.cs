using System.Drawing;
using System.Reflection.PortableExecutable;

namespace AoC2022
{
    internal class Program
    {
        public static string _input = "";
        public static List<string> entries = new();
        static void Main()
        {
            _input = File.ReadAllText("Input.txt");
            entries = _input.Split("\r\n").ToList();
            Part1();
            Part2();
        }

        static void Part1()
        {
            Directory currDir = null;
            Directory parent = null;
            var directories = new List<Directory>();
            for(var i = 0; i < entries.Count; i++)
            {
                var parts = entries[i].Split(" ");
                if (parts[0] == "$")
                {
                    if (parts[1] == "cd")
                    {
                        if (parts[2] == "..")
                        {
                            currDir = currDir.Parent;
                            continue;
                        }
                        Directory dir = new Directory { Name= parts[2] };
                        directories.Add(dir);
                        if (currDir != null)
                        {
                            dir.Parent= currDir;
                            currDir.Directories.Add(dir);
                        }
                        currDir = dir;
                    }
                    else if (parts[1] == "ls")
                    {
                        i++;
                        while (i < entries.Count)
                        {                      
                            var size = 0;
                            parts = entries[i].Split(" ");
                            if (parts[0] == "$")
                            {
                                i--;
                                break;
                            }
                            else if (parts[0] == "dir")
                            {

                            }
                            else if (int.TryParse(parts[0], out size))
                            {
                                currDir.Size += size;
                            }
                            else
                            {

                            }
                            i++;
                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            Console.WriteLine("Sum of sizes = " + directories.Where(d => d.TotalSize() < 100000).Sum(d => d.TotalSize()));
        }

        static void Part2()
        {
            Directory currDir = null;
            Directory parent = null;
            var directories = new List<Directory>();
            for (var i = 0; i < entries.Count; i++)
            {
                var parts = entries[i].Split(" ");
                if (parts[0] == "$")
                {
                    if (parts[1] == "cd")
                    {
                        if (parts[2] == "..")
                        {
                            currDir = currDir.Parent;
                            continue;
                        }
                        Directory dir = new Directory { Name = parts[2] };
                        directories.Add(dir);
                        if (currDir != null)
                        {
                            dir.Parent = currDir;
                            currDir.Directories.Add(dir);
                        }
                        currDir = dir;
                    }
                    else if (parts[1] == "ls")
                    {
                        i++;
                        while (i < entries.Count)
                        {
                            var size = 0;
                            parts = entries[i].Split(" ");
                            if (parts[0] == "$")
                            {
                                i--;
                                break;
                            }
                            else if (parts[0] == "dir")
                            {

                            }
                            else if (int.TryParse(parts[0], out size))
                            {
                                currDir.Size += size;
                            }
                            else
                            {

                            }
                            i++;
                        }
                    }
                    else
                    {

                    }
                }
                else
                {

                }
            }
            var space = 70000000 - directories[0].TotalSize();
            var neededSpace = 30000000 - space;
            Console.WriteLine("Size of deleted directory = " + directories.Where(d => d.TotalSize() > neededSpace).OrderBy(d => d.TotalSize()).First().TotalSize());
        }
    }

    internal class Directory
    {
        public string Name= "";
        public int Size = 0;
        public List<Directory> Directories = new();
        public Directory? Parent = null;

        public Directory()
        {

        }
        public int TotalSize()
        {
            return Size + Directories.Sum(d => d.TotalSize());
        }
    }
}
