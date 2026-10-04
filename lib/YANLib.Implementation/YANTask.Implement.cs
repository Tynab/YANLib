using System.Diagnostics;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANTask
{
    #region Private

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async Task<T?> AnyWithCondition<T>(IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellationToken = default)
    {
        await Yield();

        if (tasks is null)
        {
            return default;
        }

        var pending = new HashSet<Task<T>>(tasks);

        if (pending.Count is 0)
        {
            return default;
        }

        while (pending.Count > 0)
        {
            cancellationToken.ThrowIfCancellationRequested();

            var completed = await WhenAny(pending).WaitAsync(cancellationToken).ConfigureAwait(false);

            _ = pending.Remove(completed);

            try
            {
                var result = await completed.ConfigureAwait(false);

                if (predicate(result))
                {
                    return result;
                }
            }
            catch { }
        }

        return default;
    }

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task<T?> WaitAnyWithConditionImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested ? FromCanceled<T?>(cancellationToken) : AnyWithCondition(tasks, predicate, cancellationToken);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task<T?> WhenAnyWithConditionImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellationToken = default)
        => tasks.WaitAnyWithConditionImplement(predicate, cancellationToken);
}
