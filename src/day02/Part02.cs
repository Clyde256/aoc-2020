using System;
using AOC.Tools;

namespace AOC.Day02
{
    public static class Part02
    {
        private static bool CheckPassword(string passwordLine)
        {
            var tmp = passwordLine.Split('-', ' ', ':', ' ');
            var min = Int32.Parse(tmp[0]) - 1;
            var max = Int32.Parse(tmp[1]) - 1;
            var letter = tmp[2].ToCharArray()[0];
            var password = tmp[4];

            if (min >= password.Length) return false;
            if (max >= password.Length) return false;

            var ltA = password[min];
            var ltB = password[max];

            var minCheck = password[min] == letter;
            var maxCheck = password[max] == letter;
            var res = minCheck && !maxCheck || !minCheck && maxCheck;

            return res;
        }

        public static void Run()
        {
            var reader = FileIO.CreateProjFilePath("./day_02/input.txt");
            var list = reader.ReadAll();
            
            int cnt = 0;

            foreach(var it in list)
            {
                var res = CheckPassword(it);
                if (res) cnt++;
            }

            Console.WriteLine(cnt);
        }
    }
}