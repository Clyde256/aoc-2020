using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using AOC.Tools;

namespace AOC.Day05
{
    public static class Part01
    {
        public static (int, int) BinPart((int, int) range, bool left)
        {
            var cnt = ((range.Item2 - range.Item1) + 1) / 2;
            var mid = range.Item1 + cnt;
            if (left) return (range.Item1, mid - 1);
            else return (mid, range.Item2);
        }

        public static (int, int) BinPart((int, int) range, char loc)
        {
            return BinPart(range, loc == 'F');
        }

        public static int Locate(string code, char left, char right, (int, int) range)
        {
            Regex reg = new Regex(string.Format("({0}|{1})+", left, right));
            var match = reg.Matches(code);
            if (match.Count <= 0) return -1;
            var str = match[0].Value;

            foreach(var loc in str)
            {
                range = BinPart(range, loc == left);
            }

            if (range.Item1 != range.Item2) return -1;

            return range.Item1;
        }

        public static int Locate(string code)
        {
            var row = Locate(code, 'F', 'B', (0, 127));
            var col = Locate(code, 'L', 'R', (0, 7));
            return row * 8 + col;
        }

        public static void Run()
        {
            var reader = FileIO.CreateProjFilePath("./day05/input.txt");
            var list = reader.ReadAll();

            var maxId = int.MinValue;
            var ids = new SortedSet<int>();

            foreach(var code in list)
            {
                var id = Locate(code);
                ids.Add(id);
                if (id > maxId) maxId = id;
            }

            Console.WriteLine(maxId);

            var miss = new List<int>();
            for (var i = 0; i < 1024; i++)
            {
                if (!ids.Contains(i)) miss.Add(i);
            }

            for (var i = 0; i < miss.Count; i++)
            {
                if (i == miss.First()) continue;
                if (i == miss.Last()) continue;

                var prev = miss[i] - miss[i-1];
                var next = miss[i+1] - miss[i];

                if (prev > 1 && next > 1)
                {
                    Console.WriteLine(miss[i]);
                    return;
                }
            }
        }
    }
}