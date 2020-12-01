using System;

namespace AOC
{
    public static class Quest1B
    {
        public static void Run()
        {
            var reader = FileIO.CreateProjFilePath("./01/01input.txt");
            var list = reader.ReadAllInt();
            
            foreach(var it in list)
            {
                foreach(var it2 in list)
                {
                    foreach(var it3 in list)
                    {
                        if (it + it2 + it3 != 2020) continue;
                        Console.WriteLine(it * it2 * it3);
                        return;
                    }
                }
            }

            Console.WriteLine("No match!");
        }
    }
}