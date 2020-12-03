using System;
using System.Collections.Generic;
using AOC.Tools;

namespace AOC.Day03
{
    public static class Part01
    {
        private static int CountTree(Map2D map, (int, int) slope)
        {
            var pos = (0, 0);
            var treeCnt = 0;

            while (true)
            {
                if (pos.Item1 >= map.Rows) break;
                var val = map.Value(pos.Item1, pos.Item2);
                //Console.WriteLine(string.Format("[{0}, {1}] {2}", pos.Item1, pos.Item2, val));
                if (val == '#') treeCnt++;
                pos.Item1 += slope.Item1;
                pos.Item2 += slope.Item2;
            }

            return treeCnt;
        }

        public static void Run()
        {
            var filePath = InputPath.ForExe("./day03/input.txt");
            var map = new Map2D();
            map.Load(filePath);
            map.Print();

            var slopes = new List<(int, int)>{ (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) };

            long res = 1;

            foreach (var it in slopes) 
            {
                var cnt = CountTree(map, it);
                res *= cnt;
                Console.WriteLine(cnt);
            }

            Console.WriteLine(res);
        }
    }
}