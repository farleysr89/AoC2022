using System.Net.WebSockets;

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
            var valid = new List<int>();
            var index = 0;
            while (true)
            {
                var line = index * 3;
                if(line > entries.Count()) break;
                var item1 = entries[line];
                var item2 = entries[line + 1];
                index++;
                
            }
        }

        static void Part2()
        {
        }

        static bool IsValid(string item1, string item2)
        {
            return true;
        }
    }
}
