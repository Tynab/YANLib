using System.Diagnostics;
using System.Runtime.CompilerServices;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANTask
{
    #region Private

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async IAsyncEnumerable<T> AnyWithConditions<T>(IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await Yield();

        if (tasks.IsNullEmptyImplement())
        {
            yield break;
        }

        cancellationToken.ThrowIfCancellationRequested();

        var pending = new HashSet<Task<T>>(tasks);
        var emitted = 0;
        var maxToEmit = taken.IsDefaultImplement() ? pending.Count.ParseImplement<uint>() : taken;

        while (pending.Count > 0 && emitted < maxToEmit)
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
                emitted++;

                yield return result;
            }
        }
    }

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static async IAsyncEnumerable<T> AsyncEnumerableEmptyImplement<T>()
    {
        await Yield();

        yield break;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IAsyncEnumerable<T> WaitAnyWithConditionsImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested ? AsyncEnumerableEmptyImplement<T>() : AnyWithConditions(tasks, predicate, taken, cancellationToken);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IAsyncEnumerable<T> WhenAnyWithConditionsImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested ? AsyncEnumerableEmptyImplement<T>() : AnyWithConditions(tasks, predicate, taken, cancellationToken);
}
