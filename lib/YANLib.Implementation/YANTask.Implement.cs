using System.Diagnostics;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANTask
{
    #region Private
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async Task<T?> AnyWithCondition<T>(IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, bool firstOnly, CancellationToken cancellationToken)
    {
        if (tasks.IsNullEmptyImplement())
        {
            return default;
        }

        var pending = tasks.ToHashSet();

        if (firstOnly)
        {
            var completed = await WhenAny(pending).ConfigureAwait(false);

            try
            {
                var result = await completed.ConfigureAwait(false);

                return predicate(result) ? result : default;
            }
            catch
            {
                return default;
            }
        }

        while (pending.Count > 0)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var completed = await WhenAny(pending).ConfigureAwait(false);

            _ = pending.Remove(completed);

            T result;

            try
            {
                result = await completed.ConfigureAwait(false);
            }
            catch
            {
                continue;
            }

            if (predicate(result))
            {
                return result;
            }
        }

        return default;
    }
    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task<T?> WaitAnyWithConditionImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellationToken = default)
        => AnyWithCondition(tasks, predicate, firstOnly: true, cancellationToken);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task<T?> WhenAnyWithConditionImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellationToken = default)
        => AnyWithCondition(tasks, predicate, firstOnly: false, cancellationToken);
}
