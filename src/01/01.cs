using System;

namespace AOC
{
    public static class Quest1A
    {
        public static void Run()
        {
            var reader = FileIO.CreateProjFilePath("./01/01input.txt");
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