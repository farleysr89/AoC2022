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
            locations = new()
            {
                new Location
                {
                    X = 0,
                    Y = 0
                }
            };
            var tailCount = 9;
            var head = new Knot();
            var tmp = head;
            for(int i = 0; i < tailCount; i++)
            {
                var tmpNew = new Knot
                {
                    Parent= tmp,
                    Index = i + 1
                };
                tmp.Child = tmpNew;
                tmp = tmpNew;
            }

            foreach(var entry in entries)
            {
                var parts = entry.Split(" ");
                var moves = int.Parse(parts[1]);
                switch (parts[0][0])
                {
                    case 'R':
                        break;
                    case 'L':
                        break;
                    case 'U':
                        break;
                    case 'D':
                        break;
                    default:
                        Console.Error.WriteLine("Something Broke!");
                        return;
                }
            }
        }
    }

    internal class Location
    {
        public int X;
        public int Y;
        public int VisitCount = 1;
    }
    internal class Knot
    {
        public int X = 0;
        public int Y = 0;
        public Knot? Parent = null;
        public Knot? Child = null;
        public int Index = 0;

        public Location Move(int x, int y)
        {
            X += x;
            Y += y;
            return Child?.Follow();
        }
        public Location Follow()
        {
            if(Math.Abs(Parent.X - X) + Math.Abs(Parent.Y - Y) > 1)
            {
                if(Parent.X - X == 2)
                {
                    X++;
                }
                else if(Parent.Y - Y == 2)
                {
                    Y++;
                }
                else if(X - Parent.X == 2)
                {
                    X--;
                }
                else if(Y - Parent.Y == 2)
                {
                    Y--;
                }
                else
                {
                    if(X > Parent.X) X--;
                    else X++;
                    if(Y > Parent.Y) Y--;
                    else Y++;
                }
                if(Child != null) return Child.Follow();
            }
            return null;
        }
    }
}
