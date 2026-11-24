using System.Diagnostics;
using System.Runtime.ExceptionServices;
using static System.Diagnostics.Process;
using static System.IO.Path;

namespace YANLib.Implementation;

internal static partial class YANProcess
{
    #region Private

    private static async Task KillAndDisposeAsync(string? processNameOrPath, bool entireProcessTree, CancellationToken cancellationToken)
    {
        if (processNameOrPath.IsNullWhiteSpaceImplement())
        {
            return;
        }

        await processNameOrPath.GetProcessesByFileNameImplement().KillAndDisposeImplement(entireProcessTree, cancellationToken).ConfigureAwait(false);
    }

    #endregion

    // The file name (any directory removed) is looked up as given, so a process whose name contains a dot can be targeted.
    // Only when nothing matches and the name has an extension ("notepad.exe", "MyApp.dll") is the lookup repeated without
    // it. A name that is empty after this (a directory path, ".exe") matches nothing: Process.GetProcessesByName("") would
    // return every process.
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

    // Signals every process first, then waits for each to exit, so a process that does not exit (or a cancelled wait)
    // never keeps the others from being killed. Every handle is disposed and the first failure is rethrown afterwards
    // with its original type and stack trace; a cancelled wait comes after every kill, so a failure to kill wins over it.
    // A token that is already cancelled kills nothing; a token cancelled later only stops the waiting (the processes stay
    // signalled). The calling process is skipped: Kill(entireProcessTree: true) always refuses a tree that contains it,
    // and Kill() would kill the caller itself.
    internal static async Task KillAndDisposeImplement(this IEnumerable<Process> processes, bool entireProcessTree = true, CancellationToken cancellationToken = default)
    {
        var currentProcessId = Environment.ProcessId;
        Process[] all = [.. processes];
        List<Process>? signalled = null;
        ExceptionDispatchInfo? firstFailure = null;

        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            foreach (var process in all)
            {
                try
                {
                    if (process.Id != currentProcessId)
                    {
                        process.Kill(entireProcessTree);
                        (signalled ??= []).Add(process);
                    }
                }
                catch (Exception exception)
                {
                    firstFailure ??= ExceptionDispatchInfo.Capture(exception);
                }
            }

            foreach (var process in signalled ?? [])
            {
                try
                {
                    await process.WaitForExitAsync(cancellationToken).ConfigureAwait(false);
                }
                catch (OperationCanceledException exception) when (cancellationToken.IsCancellationRequested)
                {
                    firstFailure ??= ExceptionDispatchInfo.Capture(exception);

                    break;
                }
                catch (Exception exception)
                {
                    firstFailure ??= ExceptionDispatchInfo.Capture(exception);
                }
            }
        }
        finally
        {
            foreach (var process in all)
            {
                process.Dispose();
            }
        }

        firstFailure?.Throw();
    }

    internal static Task KillAllProcessesByNameImplement(this string? name, bool entireProcessTree = true, CancellationToken cancellationToken = default)
        => new[] { name }.KillAllProcessesByNamesImplement(entireProcessTree, cancellationToken);
}
