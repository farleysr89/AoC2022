namespace AoC2022
{
    internal class Program
    {
        public static string _input = "";
        public static List<string> entries = new();
        public static List<Location> locations = new List<Location>();
        static void Main()
        {
            _input = File.ReadAllText("Input.txt");
            entries = _input.Split("\r\n").ToList();
            Part1();
            Part2();
        }

        static void Part1()
        {
            var pos = 'a';
            var dest = 'z';
            var y = 0;            
            foreach(var entry in entries)
            {
                var x = 0;
                foreach(var c in entry)
                {
                    locations.Add(new Location
                    {
                        X = x,
                        Y = y,
                        Height = c == 'S' ? 'a' : c == 'E' ? 'z' : c,
                        Start = c == 'S',
                        End = c == 'E'
                    });
                    x++;
                }
                y++;
            }
            var start = locations.First(l => l.Start);
            start.Move(0);
            var end = locations.First(l => l.End);
            Console.WriteLine("Shortest Distance = " + end.ShortestDistance);
        }

        static void Part2()
        {
        }

        internal class Location
        {
            public int X;
            public int Y;
            public char Height;
            public bool Start;
            public bool End;
            public int ShortestDistance = -1;

            public void Move(int moves)
            {
                if(ShortestDistance == -1 || moves < ShortestDistance) ShortestDistance = moves;
                else return;
                if(End) return;
                moves++;
                var loc = locations.FirstOrDefault(l => l.X == X - 1 && l.Y == Y);
                if(loc != null)
                {
                    if(loc.Height <= Height+ 1)
                        loc.Move(moves);
                }
                loc = locations.FirstOrDefault(l => l.X == X + 1 && l.Y == Y);
                if(loc != null)
                {
                    if(loc.Height <= Height+ 1)
                        loc.Move(moves);
                }
                loc = locations.FirstOrDefault(l => l.X == X && l.Y == Y - 1);
                if(loc != null)
                {
                    if(loc.Height <= Height+ 1)
                        loc.Move(moves);
                }
                loc = locations.FirstOrDefault(l => l.X == X && l.Y == Y + 1);
                if(loc != null)
                {
                    if(loc.Height <= Height+ 1)
                        loc.Move(moves);
                }
            }
        }
    }
}
