using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using AOC.Tools;

namespace AOC.Day12
{
    public static class Part01
    {
        static double ToRad(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        static void Move(ref (int, int) pos, ref int angle, string action)
        {
            var size = Convert.ToInt32(action.Substring(1));

            switch (action[0])
            {
                case 'N': pos.Item2 += size; break;
                case 'S': pos.Item2 -= size; break;
                case 'E': pos.Item1 += size; break;
                case 'W': pos.Item1 -= size; break;
                case 'L': angle += size; break;
                case 'R': angle -= size; break;
                case 'F':
                    {
                        pos.Item1 += (int)(Math.Cos(ToRad(angle)) * size);
                        pos.Item2 += (int)(Math.Sin(ToRad(angle)) * size);
                    }
                    break;
            }
        }

        public static void Run()
        {
            var reader = FileIO.CreateProjFilePath("./day12/input.txt");
            var list = reader.ReadAll();

            var pos = (0, 0);
            var angle = 0;

            foreach (var it in list)
            {
                Move(ref pos, ref angle, it);
            }

            Console.WriteLine(Math.Abs(pos.Item1) + Math.Abs(pos.Item2));
        }
    }
}