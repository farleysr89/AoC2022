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
            var X = 1;
            var CycleCounter = 0;
            var SignalStrengths = new int[221];
            SignalStrengths[0] = 1;
            foreach(var entry in entries)
            {
                if(CycleCounter >= 220) break;
                var parts = entry.Split(" ");
                switch (parts[0])
                {
                    case "addx":
                        CycleCounter++;
                        SignalStrengths[CycleCounter] = X;
                        CycleCounter++;
                        SignalStrengths[CycleCounter] = X;
                        X += int.Parse(parts[1]);
                        break;
                    case "noop":
                        CycleCounter++;
                        SignalStrengths[CycleCounter] = X;
                        break;
                    default:
                        Console.WriteLine("Something broke!");
                        return;
                }
            }
            Console.WriteLine("Solution = {0}", (20 * SignalStrengths[20] + 60 * SignalStrengths[60] + 100 * SignalStrengths[100] + 140 * SignalStrengths[140] + 180 * SignalStrengths[180] + 220 * SignalStrengths[220]));
        }

        static void Part2()
        {
        }
    }
}
