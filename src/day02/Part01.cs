using System;
using AOC.Tools;

namespace AOC.Day02
{
    public static class Part01
    {
        private static bool CheckPassword(string passwordLine)
        {
            var tmp = passwordLine.Split('-', ' ', ':');
            var min = Int32.Parse(tmp[0]);
            var max = Int32.Parse(tmp[1]);
            var letter = tmp[2].ToCharArray()[0];
            var password = tmp[4];

            var cnt = 0;

            foreach(var lt in password)
            {
                if (lt == letter) cnt++;
            }

            var res = cnt >= min && cnt <= max;
            return res;
        }

        public static void Run()
        {
            var reader = FileIO.CreateProjFilePath("./day02/input.txt");
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