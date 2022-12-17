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
            var monkeys = new List<Monkey>();
            var monkey = new Monkey();
            /* Build monkeys from input */
            foreach (var entry in entries)
            {
                var formattedEntry = entry.Trim();
                //formattedEntry = formattedEntry.Remove(':');
                var parts = formattedEntry.Split(" ");
                switch (parts[0])
                {
                    case "Monkey":
                        monkey.ID = int.Parse(parts[1][..(parts[1].Length - 1)]);
                        break;
                    case "Starting":
                        var items = formattedEntry[16..];
                        //items = items.Remove(',');
                        monkey.CarriedItems = items.Split(", ").Select(i => long.Parse(i)).ToList();
                        break;
                    case "Operation:":
                        var sub = formattedEntry[21..];
                        monkey.Operation = sub[0];
                        monkey.OperationValue = sub[2..];
                        break;
                    case "Test:":
                        monkey.TestDivisor = int.Parse(formattedEntry[19..]);
                        break;
                    case "If":
                        switch (parts[1])
                        {
                            case "true:":
                                monkey.TrueTarget = int.Parse(formattedEntry[25..]);
                                break;
                            case "false:":
                                monkey.FalseTarget = int.Parse(formattedEntry[26..]);
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }
                        break;
                    case "":
                        monkeys.Add(monkey);
                        monkey = new Monkey();
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
            }
            monkeys.Add(monkey);
            for (var i = 0; i < 20; i++)
            {
                foreach (var m in monkeys.OrderBy(x => x.ID))
                {
                    foreach (var item in m.CarriedItems)
                    {
                        var newVal = item;
                        var operand = int.TryParse(m.OperationValue, out int o) ? o : item;
                        switch (m.Operation)
                        {
                            case '+':
                                newVal = newVal += operand;
                                break;
                            case '-':
                                newVal = newVal -= operand;
                                break;
                            case '/':
                                newVal = newVal /= operand;
                                break;
                            case '*':
                                newVal = newVal *= operand;
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }
                        newVal /= 3;
                        int TestResult;
                        if (newVal % m.TestDivisor == 0) TestResult = m.TrueTarget; else TestResult = m.FalseTarget;
                        monkeys.First(mm => mm.ID == TestResult).CarriedItems.Add(newVal);
                        m.Inspections++;
                    }
                    m.CarriedItems = new();
                }
            }
            monkeys = monkeys.OrderByDescending(m => m.Inspections).ToList();
            Console.WriteLine("Solution is " + monkeys[0].Inspections * monkeys[1].Inspections);
        }

        static void Part2()
        {
            var monkeys = new List<Monkey>();
            var monkey = new Monkey();
            /* Build monkeys from input */
            foreach (var entry in entries)
            {
                var formattedEntry = entry.Trim();
                var parts = formattedEntry.Split(" ");
                switch (parts[0])
                {
                    case "Monkey":
                        monkey.ID = int.Parse(parts[1][..(parts[1].Length - 1)]);
                        break;
                    case "Starting":
                        var items = formattedEntry[16..];
                        //items = items.Remove(',');
                        monkey.CarriedItems = items.Split(", ").Select(i => long.Parse(i)).ToList();
                        break;
                    case "Operation:":
                        var sub = formattedEntry[21..];
                        monkey.Operation = sub[0];
                        monkey.OperationValue = sub[2..];
                        break;
                    case "Test:":
                        monkey.TestDivisor = int.Parse(formattedEntry[19..]);
                        break;
                    case "If":
                        switch (parts[1])
                        {
                            case "true:":
                                monkey.TrueTarget = int.Parse(formattedEntry[25..]);
                                break;
                            case "false:":
                                monkey.FalseTarget = int.Parse(formattedEntry[26..]);
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }
                        break;
                    case "":
                        monkeys.Add(monkey);
                        monkey = new Monkey();
                        break;
                    default:
                        Console.WriteLine("Something Broke!");
                        break;
                }
            }
            monkeys.Add(monkey);
            var divisor = 1;
            foreach(var m in monkeys)
            {
                divisor *= m.TestDivisor;
            }
            for (var i = 0; i < 10000; i++)
            {
                foreach (var m in monkeys.OrderBy(x => x.ID))
                {
                    foreach (var item in m.CarriedItems)
                    {
                        var newVal = item;
                        var operand = int.TryParse(m.OperationValue, out int o) ? o : item;
                        switch (m.Operation)
                        {
                            case '+':
                                newVal = newVal += operand;
                                break;
                            case '-':
                                newVal = newVal -= operand;
                                break;
                            case '/':
                                newVal = newVal /= operand;
                                break;
                            case '*':
                                newVal = newVal *= operand;
                                break;
                            default:
                                Console.WriteLine("Something Broke!");
                                break;
                        }
                        //newVal \= 3;
                        int TestResult;
                        if (newVal % m.TestDivisor == 0) TestResult = m.TrueTarget; else TestResult = m.FalseTarget;
                        newVal = newVal % divisor;
                        monkeys.First(mm => mm.ID == TestResult).CarriedItems.Add(newVal);
                        m.Inspections++;
                    }
                    m.CarriedItems = new();
                }
            }
            monkeys = monkeys.OrderByDescending(m => m.Inspections).ToList();
            long result = (long)monkeys[0].Inspections * (long)monkeys[1].Inspections;
            Console.WriteLine("Solution is " + result);
        }
    }
    internal class Monkey
    {
        public int ID;
        public List<long> CarriedItems;
        public int TrueTarget;
        public int FalseTarget;
        public char Operation;
        public string OperationValue;
        public int TestDivisor;
        public int Inspections = 0;
    }
}
