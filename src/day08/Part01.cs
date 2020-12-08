using System;
using AOC.Tools;

namespace AOC.Day08
{
    public static class Part01
    {
        public static void Run()
        {
            var relPath = "./day08/input.txt";
            var comp = new Computer();
            comp.Load(relPath);
            var res = comp.Run();
            Console.WriteLine(comp.Accumulator);
        }
    }
}