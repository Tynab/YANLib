using System.Diagnostics;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANProcess
{
    // A null, empty or white-space name is skipped; it no longer cancels the other names.
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static async Task KillAllProcessesByNamesImplement(this IEnumerable<string?>? names)
    {
        if (names is null)
        {
            return;
        }

        await WhenAll(names.Select(KillAndDisposeAsync)).ConfigureAwait(false);
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAllProcessesByNamesImplement(params string?[]? names) => names.KillAllProcessesByNamesImplement();
}
