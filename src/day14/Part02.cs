using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using AOC.Tools;

namespace AOC.Day14
{
    public static class Part02
    {
        static string Calc(string address, string mask)
        {
            if (address.Length != mask.Length) throw new NotImplementedException();

            var result = mask.ToArray();

            for (var i = 0; i < mask.Length; i++)
            {
                if (mask[i] == 'X') result[i] = 'X';
                else if (address[i] == mask[i] && mask[i] == '0') result[i] = '0';
                else if (address[i] == '1' || mask[i] == '1') result[i] = '1';
                else throw new NotImplementedException();
            }

            var str = new string(result);
            return str;
        }

        static List<string> Temp(string value)
        {
            long count = value.Count(f => f == 'X');
            long num = (long)Math.Pow(2, count);

            var res = new List<string>();

            var regex = new Regex(Regex.Escape("X"));

            for (long i = 0; i < num; i++)
            {
                var str = Convert.ToString(i, 2).PadLeft((int)count, '0');

                var copy = value;
                
                foreach(var it in str)
                {
                    copy = regex.Replace(copy, it.ToString(), 1);
                }

                res.Add(copy);
            }

            return res;
        }

        static void WriteToMem(string mask, long address, long value, Dictionary<long, long> mem)
        {
            var strAddr = Convert.ToString(address, 2);

            var zeros = Math.Max(mask.Length, strAddr.Length);
            mask = mask.PadLeft(zeros, '0');
            strAddr = strAddr.PadLeft(zeros, '0');

            var addrMask = Calc(strAddr, mask);
            var addresses = Temp(addrMask);

            foreach(var it in addresses)
            {
                var index = Convert.ToInt64(it, 2);

                if (mem.ContainsKey(index)) mem[index] = value;
                else mem.Add(index, value);
            }
        }

        static void Docker(List<string> data)
        {
            var mem = new Dictionary<long, long>();

            var mask = "";

            foreach(var it in data)
            {
                if (it.StartsWith("mask"))
                {
                    mask = it.Replace("mask = ", "");
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

                    WriteToMem(mask, index, value, mem);
                }
                else 
                {
                    throw new NotImplementedException();
                }
            }

            long sum = 0;
            foreach(var it in mem)
            {
                sum += it.Value;
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