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
            var priorities = (from s in entries let l = s.Length / 2 select s[0..l].Intersect(s[l..]).First() into c select GetPriority(c)).Sum();
            Console.WriteLine("Sum of priorities is " + priorities);
        }

        static void Part2()
        {
            var priorities = 0;
            var l = entries.Count;
            for (var i = 0; i < l; i += 3)
            {
                var c = entries[i].Intersect(entries[i + 1]).Intersect(entries[i + 2]).First();
                priorities += GetPriority(c);
            }
            Console.WriteLine("Sum of priorities is " + priorities);
        }

        static int GetPriority(char c)
        {
            var i = (int)c - 64;
            return i + (i <= 26 ? 26 : -32);
        }
    }
}
