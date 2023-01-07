﻿namespace AoC2022
{
    internal class Program
    {
        public static string _input = "";
        public static List<string> entries = new();
        static void Main()
        {
            _input = File.ReadAllText("SampleInput.txt");
            // 1062

            // 5871
            entries = _input.Split("\r\n").ToList();
            Part1();
            Part2();
        }

        static void Part1()
        {
            var valid = new List<int>();
            var index = 0;
            List<object> data = new();
            while (true)
            {
                var line = index * 3;
                if (line > entries.Count) break;

                var item1 = entries[line];
                var item2 = entries[line + 1];
                //if (IsValid(item1[1..(item1.Length - 1)], item2[1..(item2.Length - 1)])) valid.Add(index + 1);
                var con1 = Convert(item1);
                var con2 = Convert(item2);
                if(IsValid(con1,con2) != Result.Invalid) valid.Add(index + 1);
                index++;

            }
            Console.WriteLine("Sum of valid indices = {0}", valid.Sum());
        }

        static void Part2()
        {
        }

        static bool IsValid(string item1, string item2)
        {
            var parts1 = item1.Split(",");
            var parts2 = item2.Split(",");
            for (var i = 0; i < parts1.Length; i++)
            {
                if (int.TryParse(parts1[i], out var value1))
                {
                    if (parts2.Length <= i) return false;
                    if (int.TryParse(parts2[i], out var value2))
                    {
                        if (value1 > value2) return false;
                    }
                    else if (parts2[i][0] == '[')
                    {
                        //var p2 = parts2[1..parts2.inde];
                        //if(!IsValid(parts1[i],p2[1..(p2.IndexOf(']') - 1)])) return false;
                    }
                    else
                    {
                        Console.WriteLine("Something Broke!");
                    }
                }

            }
            return true;
        }
        static Result IsValid(List<object> list1, List<object> list2)
        {
            for (var i = 0; i < list1.Count; i++)
            {
                if(i >= list2.Count) return Result.Invalid;
                if (list1[i].GetType() == typeof(int))
                {
                    if (list2[i].GetType() == typeof(int))
                    {
                        if ((int)list1[i] > (int)list2[i]) return Result.Invalid;
                        else if ((int)list1[i] < (int)list2[i]) return Result.Valid;
                    }
                    else if (list2[i].GetType() == typeof(List<object>))
                    {
                        var tmp = new List<object> { list1[i] };
                        var tmpR = IsValid(tmp, (List<object>)list2[i]);
                        if(tmpR == Result.Continue) continue;
                        return tmpR;
                    }
                    else
                    {
                        Console.WriteLine("Something Broke!");
                    }
                }
                else if (list1[i].GetType() == typeof(List<object>))
                {
                    if (list2[i].GetType() == typeof(int))
                    {
                        var tmp = new List<object> { list2[i] };
                        var tmpR = IsValid((List<object>)list1[i], tmp);
                        if(tmpR == Result.Continue) continue;
                        return tmpR;
                    }
                    else if (list2[i].GetType() == typeof(List<object>))
                    {
                        var tmpR = IsValid((List<object>)list1[i], (List<object>)list2[i]);
                        if(tmpR == Result.Continue) continue;
                        return tmpR;
                    }
                    else
                    {
                        Console.WriteLine("Something Broke!");
                    }
                }
                else
                {
                    Console.WriteLine("Something Broke!");
                }
            }
            return list1.Count == list2.Count ? Result.Continue : Result.Valid;
        }

        public static List<object> Convert(string list)
        {
            var objects = new List<object>();
            Stack<List<object>> s = new();
            var tmp = "";
            for (var i = 0; i < list.Length; i++)
            {
                if (list[i] == '[')
                {
                    s.Push(new List<object>());
                }
                else if (list[i] == ']')
                {
                    var l = s.Pop();
                    if (tmp != "") l.Add(int.Parse(tmp));
                    if (s.Count > 0) s.Peek().Add(l);
                    else objects.Add(l);
                    tmp = "";
                }
                else if (list[i] == ',')
                {
                    if (tmp != "")
                    {
                        s.Peek().Add(int.Parse(tmp));
                        tmp = "";
                    }
                }
                else
                {
                    tmp += list[i];
                }
            }
            if (tmp != "") objects.Add(int.Parse(tmp));
            return objects;
        }
    }

    internal enum Result
    {
        Valid,
        Invalid,
        Continue
    }
}
