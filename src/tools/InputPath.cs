using System.IO;
using System.Reflection;

namespace AOC.Tools
{
    public static class InputPath
    {
        public static string ForExe(string inSrcPath)
        {
            var exeDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var srcDir = Path.Combine(exeDir, "../../../src/");
            var res = Path.Combine(srcDir, inSrcPath);
            res = Path.GetFullPath(res);
            return res;
        }
    }
}