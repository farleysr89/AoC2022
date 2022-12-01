using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC2022
{
    class Program
    {
        public static string? _input;
        public static List<string>? entries;
        static void Main(string[] args)
        {
            _input = File.ReadAllText("Input.txt");
            entries = _input.Split("\r\n").ToList();
            Part1();
            Part2();
        }

        static void Part1()
        {
            int id = 1;
            int calories = 0;
            var elves = new List<Elf>();
            var elf = new Elf
            {
                Id = id
            };
            foreach (var s in entries)
            {
                if (s == "")
                {
                    elf.Calories = calories;
                    elves.Add(elf);
                    id++;
                    calories = 0;
                    elf = new Elf
                    {
                        Id = id
                    };
                    continue;
                }
                var i = int.Parse(s);
                calories += i;
            }
            elf.Calories = calories;
            elves.Add(elf);
            id++;
            calories = 0;
            elf = new Elf
            {
                Id = id
            };
            var maxElf = elves.OrderByDescending(e => e.Calories).First();
            Console.WriteLine("Elf " + maxElf.Id + " is carrying " + maxElf.Calories + " calories.");
        }

        static void Part2()
        {
            int id = 1;
            int calories = 0;
            var elves = new List<Elf>();
            var elf = new Elf
            {
                Id = id
            };
            foreach (var s in entries)
            {
                if (s == "")
                {
                    elf.Calories = calories;
                    elves.Add(elf);
                    id++;
                    calories = 0;
                    elf = new Elf
                    {
                        Id = id
                    };
                    continue;
                }
                var i = int.Parse(s);
                calories += i;
            }
            elf.Calories = calories;
            elves.Add(elf);
            id++;
            calories = 0;
            elf = new Elf
            {
                Id = id
            };
            var top3Elves = elves.OrderByDescending(e => e.Calories).Take(3);
            Console.WriteLine("Elves " + top3Elves.Select(e => e.Id.ToString()).Aggregate((s, i) => s + ", " + i) + " are carrying " + top3Elves.Select(e => e.Calories).Aggregate((t, i) => t + i) + " calories.");
        }
    }
    class Elf
    {
        public int Id;
        public int Calories;
    }
}
