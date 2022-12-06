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
            var buffer = entries[0];
            var result = 0;
            for(var i = 0; i < buffer.Length - 3; i++)
            {
                var marker = buffer[i..(i+4)];
                if(marker.Distinct().Count() == 4)
                {
                    result = i + 4;
                    break;
                }
            }
            Console.WriteLine("Marker ends at " + result);
        }

        static void Part2()
        {
            var buffer = entries[0];
            var result = 0;
            for (var i = 0; i < buffer.Length - 13; i++)
            {
                var marker = buffer[i..(i + 14)];
                if (marker.Distinct().Count() == 14)
                {
                    result = i + 14;
                    break;
                }
            }
            Console.WriteLine("Marker ends at " + result);
        }
    }
}
