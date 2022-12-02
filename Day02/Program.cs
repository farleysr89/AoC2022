namespace AoC2022
{
    class Program
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
            int score = 0;
            foreach(var l in entries)
            {
                var moves = l.Split(" ");
                switch (moves[1]) {
                    case "X":
                        score+=1;
                        break;
                    case "Y":
                        score+=2;
                        break;
                    case "Z":
                        score+=3;
                        break;
                    default:
                        Console.WriteLine("Something Broke! moves[1] = " + moves[1]);
                        break;
                }
                if (moves[0] == "A")
                    if (moves[1] == "X") score += 3;
                    else if (moves[1] == "Y") score += 6;
                    else if (moves[1] == "Z") continue;
                    else Console.WriteLine("Something Broke!");
                else if (moves[0] == "B")
                    if (moves[1] == "Y") score += 3;
                    else if (moves[1] == "Z") score += 6;
                    else if (moves[1] == "X") continue;
                    else Console.WriteLine("Something Broke!");
                else if (moves[0] == "C")
                    if (moves[1] == "Z") score += 3;
                    else if (moves[1] == "X") score += 6;
                    else if (moves[1] == "Y") continue;
                    else Console.WriteLine("Something Broke!");
                else Console.WriteLine("Something Broke!");
            }
            Console.WriteLine("Final score is " + score);
        }

        static void Part2()
        {
            int score = 0;
            foreach (var l in entries)
            {
                var moves = l.Split(" ");
                if (moves[0] == "A")
                    if (moves[1] == "X") score += 3;
                    else if (moves[1] == "Y") score += 4;
                    else if (moves[1] == "Z") score += 8;
                    else Console.WriteLine("Something Broke!");
                else if (moves[0] == "B")
                    if (moves[1] == "X") score += 1;
                    else if (moves[1] == "Y") score += 5;
                    else if (moves[1] == "Z") score += 9;
                    else Console.WriteLine("Something Broke!");
                else if (moves[0] == "C")
                    if (moves[1] == "X") score += 2;
                    else if (moves[1] == "Y") score += 6;
                    else if (moves[1] == "Z") score += 7;
                    else Console.WriteLine("Something Broke!");
                else Console.WriteLine("Something Broke!");
            }
            Console.WriteLine("Final score is " + score);
        }
    }
}
