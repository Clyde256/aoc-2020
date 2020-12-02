using System;
using AOC.Tools;

namespace AOC
{
    public static class Day01Part01
    {
        public static void Run()
        {
            var reader = FileIO.CreateProjFilePath("./day_01/input.txt");
            var list = reader.ReadAllInt();
            
            foreach(var it in list)
            {
                foreach(var sm in list)
                {
                    if (it + sm != 2020) continue;
                    Console.WriteLine(it * sm);
                    return;
                }
            }

            Console.WriteLine("No match!");
        }
    }
}