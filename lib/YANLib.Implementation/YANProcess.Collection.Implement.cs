using System.Diagnostics;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANProcess
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static async Task KillAllProcessesByNamesImplement(this IEnumerable<string?>? names)
    {
        if (names.IsNullEmptyImplement() || names.AnyNullWhiteSpaceImplement())
        {
            return;
        }

        await WhenAll(names.Select(KillAndDisposeAsync));
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task KillAllProcessesByNamesImplement(params string?[]? names) => names.KillAllProcessesByNamesImplement();
}
