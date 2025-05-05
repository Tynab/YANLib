using System.Diagnostics;
using static System.Diagnostics.Process;
using static System.IO.Path;

namespace YANLib.Implementation;

internal static partial class YANProcess
{
    #region Private

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async Task KillAndDisposeAsync(string? processNameOrPath)
    {
        if (processNameOrPath.IsNullWhiteSpaceImplement())
        {
            return;
        }

        var processes = GetProcessesByName(GetFileNameWithoutExtension(GetFileName(processNameOrPath)));

        foreach (var process in processes)
        {
            try
            {
                process.Kill(true);
                await process.WaitForExitAsync();
            }
            finally
            {
                process.Dispose();
            }
        }
    }

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAllProcessesByNameImplement(this string? name) => new[] { name }.KillAllProcessesByNamesImplement();
}
