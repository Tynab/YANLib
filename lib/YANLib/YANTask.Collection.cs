using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANTask
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static IAsyncEnumerable<T> AsyncEnumerableEmpty<T>() => AsyncEnumerableEmpty<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IAsyncEnumerable<T> WaitAnyWithConditions<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => tasks.WaitAnyWithConditionsImplement(predicate, taken, cancellationToken);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IAsyncEnumerable<T> WhenAnyWithConditions<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => tasks.WhenAnyWithConditionsImplement(predicate, taken, cancellationToken);
}
