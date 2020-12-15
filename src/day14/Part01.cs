using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using AOC.Tools;

namespace AOC.Day14
{
    public static class Part01
    {
        static long GetMask(string str, char replace)
        {
            var val = str.Replace('X', replace);
            return Convert.ToInt64(val, 2);
        }

        static (long, long) Masks(string strMask)
        {
            var oneMask = GetMask(strMask, '0');
            var zeroMask = GetMask(strMask, '1');
            return (oneMask, zeroMask);
        }

        static long Calc(long value, long zeroMask, long oneMask)
        {
            var tmp = value | oneMask;
            return tmp & zeroMask;
        }

        static void Docker(List<string> data)
        {
            var mem = new long[100000];
            for (long i = 0; i < mem.Length; i++)
            {
                mem[i] = 0;
            }

            var mask = "";
            (long, long) coef = (0, 0);

            foreach(var it in data)
            {
                if (it.StartsWith("mask"))
                {
                    mask = it.Replace("mask = ", "");
                    coef = Masks(mask);
                }
                else if (it.StartsWith("mem"))
                {
                    var iBgn = it.IndexOf("[");
                    var iEnd = it.IndexOf("]");
                    var sIndx = it.Substring(iBgn+1, iEnd - (iBgn + 1));
                    long index = Convert.ToInt64(sIndx);

                    iBgn = it.IndexOf("=") + 2;
                    var sVal = it.Substring(iBgn);
                    long value = Convert.ToInt64(sVal);

                    mem[index] = Calc(value, coef.Item2, coef.Item1);
                }
                else 
                {
                    throw new NotImplementedException();
                }
            }

            long sum = 0;
            foreach(var it in mem)
            {
                sum += it;
            }

            Console.WriteLine(sum);
        }

        public static void Run()
        {
            var reader = FileIO.CreateProjFilePath("./day14/input.txt");
            var data = reader.ReadAll();

            Docker(data);
        }
    }
}