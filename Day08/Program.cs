namespace AoC2022
{
    internal class Program
    {
        public static string _input = "";
        public static List<string> entries = new();
        public static List<Tree> trees = new();
        static void Main()
        {
            _input = File.ReadAllText("Input.txt");
            entries = _input.Split("\r\n").ToList();
            Part1();
            Part2();
        }

        static void Part1()
        {
            var visibleTrees = 0;
            visibleTrees += entries.Count * 2;
            visibleTrees += (entries[0].Length - 2) * 2;
            for(var i = 0; i < entries.Count; i++)
            {
                for(var j = 0; j < entries[i].Length; j++)
                {
                    var tree = entries[i][j];
                    trees.Add(new Tree
                    {
                        X = j,
                        Y = i,
                        Height = int.Parse(tree.ToString())
                    });
                }
            }
            foreach(var tree in trees)
            {
                if(tree.X == 0 || tree.X == entries.Count - 1 || tree.Y == 0 || tree.Y == entries[0].Length - 1)
                {
                    continue;
                }
                if(!trees.Any(t => t.X == tree.X && t.Y < tree.Y && t.Height >= tree.Height)
                || !trees.Any(t => t.X < tree.X && t.Y == tree.Y && t.Height >= tree.Height)
                || !trees.Any(t => t.X == tree.X && t.Y > tree.Y && t.Height >= tree.Height)
                || !trees.Any(t => t.X > tree.X && t.Y == tree.Y && t.Height >= tree.Height))
                {
                    visibleTrees++;
                }
            }
            Console.WriteLine("There are " + visibleTrees + " visible trees.");
        }

        static void Part2()
        {
        }
    }

    internal class Tree
    {
        public int X;
        public int Y;
        public int Height;

    }
}
