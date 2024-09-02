using System.Diagnostics;

namespace Cwd.Extensions;

public static class ProcessExtensions
{
    // Issue workaround
    // https://github.com/dotnet/runtime/issues/27128
    public static bool DoubleWaitForExit(this Process process)
    {
        const int waitTimeMs = 250;
        
        var exit = process.WaitForExit(waitTimeMs * 2);
        if (exit) process.WaitForExit(waitTimeMs);

        return exit;
    }
}
