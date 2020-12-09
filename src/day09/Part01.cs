using System;
using System.Linq;
using System.Collections.Generic;
using AOC.Tools;

namespace AOC.Day09
{
    public static class Part01
    {
        static Dictionary<(long, long), long> PairCombs(List<long> data)
        {
            var dic = new Dictionary<(long, long), long>();

            for (var i = 0; i < data.Count; i++)
            {
                for (var i2 = 0; i2 < data.Count; i2++)
                {
                    if (i == i2) continue;
                    var min = Math.Min(data[i], data[i2]);
                    var max = Math.Max(data[i], data[i2]);

                    if (dic.ContainsKey((min, max))) continue;

                    dic.Add((min, max), min + max);
                }
            }

            return dic;
        }

        static bool Check(List<long> data, long value)
        {
            var combs = PairCombs(data);

            foreach(var it in combs)
            {
                if (it.Value == value) return true;
            }

            return false;
        }

        static List<long> FindSumRange(List<long> data, long value)
        {
            for (var i = 0; i < data.Count; i++)
            {
                long sum = 0;
                var list = new List<long>();

                for (var i2 = i; i2 < data.Count; i2++)
                {
                    list.Add(data[i2]);
                    sum += data[i2];
                    if (sum == value) return list;
                    if (sum > value) break;
                }
            }

            return null;
        }

        public static void Run()
        {
            var reader = FileIO.CreateProjFilePath("./day09/input.txt");
            var data = reader.ReadAllLong();
            var preambule = 25;

            long res = -1;

            for (var i = preambule; i < data.Count; i++)
            {
                var start = i - preambule;
                var pram = data.GetRange(start, preambule);
                
                if (!Check(pram, data[i]))
                {
                    Console.WriteLine(data[i]);
                    res = data[i];
                    break;
                }
            }

            var range = FindSumRange(data, res);
            // Console.WriteLine(range);

            var min = range.Min();
            var max = range.Max();

            Console.WriteLine(min + max);
        }
    }
}