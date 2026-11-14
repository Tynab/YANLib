using System.Diagnostics;
using System.Runtime.ExceptionServices;
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

        await processNameOrPath.GetProcessesByFileNameImplement().KillAndDisposeImplement().ConfigureAwait(false);
    }

    #endregion

    // The file name (any directory removed) is looked up as given, so a process whose name contains a dot can be targeted.
    // Only when nothing matches and the name has an extension ("notepad.exe", "MyApp.dll") is the lookup repeated without
    // it. A name that is empty after this (a directory path, ".exe") matches nothing: Process.GetProcessesByName("") would
    // return every process.
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Process[] GetProcessesByFileNameImplement(this string? processNameOrPath)
    {
        var fileName = GetFileName(processNameOrPath);

        if (fileName.IsNullWhiteSpaceImplement())
        {
            return [];
        }

        var processes = GetProcessesByName(fileName);

        if (processes.Length > 0 || !HasExtension(fileName))
        {
            return processes;
        }

        var fileNameWithoutExtension = GetFileNameWithoutExtension(fileName);

        return fileNameWithoutExtension.IsNullWhiteSpaceImplement() ? [] : GetProcessesByName(fileNameWithoutExtension);
    }

    // Tries every process and disposes every handle; the first failure is rethrown afterwards with its original type and
    // stack trace. The calling process is skipped: Kill(entireProcessTree: true) always refuses a tree that contains it.
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static async Task KillAndDisposeImplement(this IEnumerable<Process> processes)
    {
        var currentProcessId = Environment.ProcessId;
        ExceptionDispatchInfo? firstFailure = null;

        foreach (var process in processes)
        {
            try
            {
                if (process.Id != currentProcessId)
                {
                    process.Kill(entireProcessTree: true);
                    await process.WaitForExitAsync().ConfigureAwait(false);
                }
            }
            catch (Exception exception)
            {
                firstFailure ??= ExceptionDispatchInfo.Capture(exception);
            }
            finally
            {
                process.Dispose();
            }
        }

        firstFailure?.Throw();
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAllProcessesByNameImplement(this string? name) => new[] { name }.KillAllProcessesByNamesImplement();
}
