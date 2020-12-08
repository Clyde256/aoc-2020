using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using AOC.Tools;

namespace AOC.Day08
{
    public static class Part02
    {
        public static void Run()
        {
            var relPath = "./day08/input.txt";
            
            var comp = new Computer();
            comp.Load(relPath);

            var res = comp.FindBug();
            
            Console.WriteLine(res);
            Console.WriteLine(comp.Accumulator);
        }
    }
}