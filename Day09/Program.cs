namespace AoC2022
{
    internal class Program
    {
        public static string _input = "";
        public static List<string> entries = new();
        public static List<Location> locations = new();
        public static int headX;
        public static int tailX;
        public static int headY;
        public static int tailY;
        static void Main()
        {
            _input = File.ReadAllText("Input.txt");
            entries = _input.Split("\r\n").ToList();
            Part1();
            Part2();
        }

        static void Part1()
        {
            locations.Add(new Location
            {
                X = 0,
                Y = 0
            });
            headX = 0;
            tailX = 0;
            headY = 0;
            tailY = 0;
            foreach(var entry in entries)
            {
                var parts = entry.Split(" ");
                var moveCount = int.Parse(parts[1]);
                switch (parts[0][0]){
                    case 'R':
                        for(var i = 0; i < moveCount; i++)
                        {
                            headX++;
                            if(tailX < headX - 1) 
                            {
                                tailX++;
                                if(tailY < headY) tailY++;
                                else if(tailY > headY) tailY--;
                            }
                            if(locations.Any(x => x.X == tailX && x.Y == tailY)) locations.Find(x => x.X == tailX && x.Y == tailY).VisitCount++;
                            else locations.Add(new Location
                            {
                                X = tailX,
                                Y = tailY
                            });
                        }
                        break;
                    case 'L':
                        for(var i = 0; i < moveCount; i++)
                        {
                            headX--;
                            if(tailX > headX + 1) 
                            {
                                tailX--;
                                if(tailY < headY) tailY++;
                                else if(tailY > headY) tailY--;
                            }
                            if(locations.Any(x => x.X == tailX && x.Y == tailY)) locations.Find(x => x.X == tailX && x.Y == tailY).VisitCount++;
                            else locations.Add(new Location
                            {
                                X = tailX,
                                Y = tailY
                            });
                        }
                        break;
                    case 'U':
                        for(var i = 0; i < moveCount; i++)
                        {
                            headY++;
                            if(tailY < headY - 1) 
                            {
                                tailY++;
                                if(tailX < headX) tailX++;
                                else if(tailX > headX) tailX--;
                            }
                            if(locations.Any(x => x.X == tailX && x.Y == tailY)) locations.Find(x => x.X == tailX && x.Y == tailY).VisitCount++;
                            else locations.Add(new Location
                            {
                                X = tailX,
                                Y = tailY
                            });
                        }
                        break;
                    case 'D':
                        for(var i = 0; i < moveCount; i++)
                        {
                            headY--;
                            if(tailY > headY + 1) 
                            {
                                tailY--;
                                if(tailX < headX) tailX++;
                                else if(tailX > headX) tailX--;
                            }
                            if(locations.Any(x => x.X == tailX && x.Y == tailY)) locations.Find(x => x.X == tailX && x.Y == tailY).VisitCount++;
                            else locations.Add(new Location
                            {
                                X = tailX,
                                Y = tailY
                            });
                        }
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
            }
            Console.WriteLine("Visited Locations Count = " + locations.Count);
        }

        static void Part2()
        {
        }
    }

    internal class Location
    {
        public int X;
        public int Y;
        public int VisitCount = 1;
    }
}
