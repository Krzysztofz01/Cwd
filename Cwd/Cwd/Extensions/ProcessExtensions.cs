using System.Diagnostics;

namespace Cwd.Extensions
{
    public static class ProcessExtensions
    {
        // Workaround for https://github.com/dotnet/runtime/issues/27128
        // Solution found in https://github.com/CopyText/TextCopy
        public static bool DoubleWaitForExit(this Process process)
        {
            var exit = process.WaitForExit(500);
            if (exit) process.WaitForExit();

            return exit;
        }
    }
}
