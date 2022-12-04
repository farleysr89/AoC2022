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
            var overlaps = 0;
            foreach(var l in entries)
            {
                if(IsFullOverlap(l)) overlaps++;
            }
            Console.WriteLine("Count of overlapping assignments is " + overlaps);
        }

        static void Part2()
        {
            var overlaps = 0;
            foreach(var l in entries)
            {
                if(IsPartialOverlap(l)) overlaps++;
            }
            Console.WriteLine("Count of overlapping assignments is " + overlaps);
        }
        static bool IsFullOverlap(string l)
        {
            var assignments = l.Split(",");
            var sections1 = assignments[0].Split("-").Select(s => int.Parse(s)).ToList();
            var sections2 = assignments[1].Split("-").Select(s => int.Parse(s)).ToList();
            return (sections1[0] >= sections2[0] && sections1[1] <= sections2[1])
                || (sections2[0] >= sections1[0] && sections2[1] <= sections1[1]);
        }
        static bool IsPartialOverlap(string l)
        {
            var assignments = l.Split(",");
            var sections1 = assignments[0].Split("-").Select(s => int.Parse(s)).ToList();
            var sections2 = assignments[1].Split("-").Select(s => int.Parse(s)).ToList();
            return (sections1[1] >= sections2[0] && sections1[1] <= sections2[1])
                || (sections1[0] >= sections2[0] && sections1[0] <= sections2[1])
                || (sections2[1] >= sections1[0] && sections2[1] <= sections1[1])
                || (sections2[0] >= sections1[0] && sections2[0] <= sections1[1]);
        }

    }
}