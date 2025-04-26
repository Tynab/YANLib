using System.Diagnostics;
using static System.Diagnostics.Process;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANProcess
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static async Task KillAllProcessesByNamesImplement(this IEnumerable<string?>? names, CancellationToken cancellation = default)
    {
        if (names.IsNullEmptyImplement() || names.AnyNullWhiteSpaceImplement())
        {
            return;
        }

        await WhenAll(names.SelectMany(GetProcessesByName).Select(p => KillAndDisposeAsync(p, cancellation)));
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAllProcessesByNamesImplement(params string?[]? names) => names.KillAllProcessesByNamesImplement();
}
