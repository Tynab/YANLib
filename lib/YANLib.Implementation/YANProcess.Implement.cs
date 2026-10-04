using System.Diagnostics;
using static System.Diagnostics.Process;
using static System.IO.Path;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANProcess
{
    #region Private

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async Task KillAndDisposeProcessAsync(Process process)
    {
        try
        {
            process.Kill(true);
            await process.WaitForExitAsync().ConfigureAwait(false);
        }
        finally
        {
            process.Dispose();
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async Task KillAndDisposeAsync(string? processNameOrPath)
    {
        var processName = GetFileNameWithoutExtension(GetFileName(processNameOrPath));

        // On Unix an empty name (e.g. from ".exe" or "dir/") matches every process
        if (processName.IsNullWhiteSpaceImplement())
        {
            return;
        }

        await WhenAll(GetProcessesByName(processName).Select(KillAndDisposeProcessAsync)).ConfigureAwait(false);
    }

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAllProcessesByNameImplement(this string? name) => new[] { name }.KillAllProcessesByNamesImplement();
}
