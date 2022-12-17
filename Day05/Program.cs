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
            var length = entries[0].Length + 1;
            var stacks = new List<Stack<char>>();
            var j = 0;
            foreach (var l in entries)
            {
                if (!l.Contains('[')) break;
                j = 0;
                for (var i = 0; i < length; i += 4)
                {
                    if (stacks.Count <= j) stacks.Add(new Stack<char>());
                    if (l[i + 1] != ' ') stacks[j].Push(l[i + 1]);
                    j++;
                }
            }
            for (var i = 0; i < stacks.Count; i++)
            {
                stacks[i] = reverseStack(stacks[i]);
            }
            foreach (var l in entries.Skip(j + 1))
            {
                var parts = l.Split(" ");
                var count = int.Parse(parts[1]);
                var from = int.Parse(parts[3]) - 1;
                var to = int.Parse(parts[5]) - 1;
                for (var i = 0; i < count; i++)
                {
                    stacks[to].Push(stacks[from].Pop());
                }
            }
            var topCrates = "";
            foreach (var s in stacks)
            {
                topCrates += s.Pop();
            }
            Console.WriteLine("Top crates are " + topCrates);
        }

        static void Part2()
        {
            var length = entries[0].Length + 1;
            var stacks = new List<Stack<char>>();
            var j = 0;
            foreach (var l in entries)
            {
                if (!l.Contains('[')) break;
                j = 0;
                for (var i = 0; i < length; i += 4)
                {
                    if (stacks.Count <= j) stacks.Add(new Stack<char>());
                    if (l[i + 1] != ' ') stacks[j].Push(l[i + 1]);
                    j++;
                }
            }
            for (var i = 0; i < stacks.Count; i++)
            {
                stacks[i] = reverseStack(stacks[i]);
            }
            foreach (var l in entries.Skip(j + 1))
            {
                var parts = l.Split(" ");
                var count = int.Parse(parts[1]);
                var from = int.Parse(parts[3]) - 1;
                var to = int.Parse(parts[5]) - 1;
                var tempStack = new Stack<char>();
                for (var i = 0; i < count; i++)
                {
                    tempStack.Push(stacks[from].Pop());
                }
                while(tempStack.Count > 0)
                {
                    stacks[to].Push(tempStack.Pop());
                }
            }
            var topCrates = "";
            foreach (var s in stacks)
            {
                topCrates += s.Pop();
            }
            Console.WriteLine("Top crates are " + topCrates);
        }

        static Stack<char> reverseStack(Stack<char> stack)
        {
            var reverse = new Stack<char>();
            while (stack.Count > 0) reverse.Push(stack.Pop());
            return reverse;
        }
    }
}