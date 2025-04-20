using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANTask
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Task<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellation = default) => tasks.WaitAnyWithConditionImplement(predicate, cancellation);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Task<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellation = default) => tasks.WhenAnyWithConditionImplement(predicate, cancellation);
}
