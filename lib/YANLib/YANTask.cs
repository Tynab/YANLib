using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANTask
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, T goodResult, CancellationToken cancellation = default) where T : IComparable<T> => await tasks.WaitAnyWithConditionImplement(goodResult, cancellation);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static async Task<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, T goodResult, CancellationToken cancellation = default) where T : IComparable<T> => await tasks.WhenAnyWithConditionImplement(goodResult, cancellation);
}
