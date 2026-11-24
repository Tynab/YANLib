using System.Runtime.CompilerServices;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANTask
{
    #region Private

    // Every cancellation throws OperationCanceledException, as ChannelReader.ReadAllAsync does: a token that is already
    // cancelled when the enumeration starts (also for null or empty tasks), cancelled while waiting for a task, or
    // cancelled while the consumer handles an item (checked when the consumer asks for the next one, before the taken
    // limit ends the enumeration). [EnumeratorCancellation] combines the method's token with a token passed through
    // WithCancellation, so both are observed. Exceptions thrown by the predicate propagate to the consumer.
    private static async IAsyncEnumerable<T> AnyWithConditions<T>(IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await Yield();

        cancellationToken.ThrowIfCancellationRequested();
        ArgumentNullException.ThrowIfNull(predicate);

        if (tasks is null)
        {
            yield break;
        }

        var pending = Materialize(tasks);

        if (pending.Count is 0)
        {
            yield break;
        }

        var maxToEmit = taken.IsDefaultImplement() ? (uint)pending.Count : taken;
        var emitted = 0u;
        List<Task<T>>? incomplete = null;

        // The tasks are checked in collection order, without registering anything: each task that is complete when it is
        // reached (also one that completed while the consumer handled an earlier result) is yielded at once. The others are
        // registered afterwards, in collection order, so those that have completed by then come first, in that order.
        foreach (var task in pending)
        {
            if (!task.IsCompleted)
            {
                (incomplete ??= []).Add(task);

                continue;
            }

            cancellationToken.ThrowIfCancellationRequested();

            if (IsSuccessful(task) && predicate(task.Result))
            {
                yield return task.Result;

                cancellationToken.ThrowIfCancellationRequested();

                if (++emitted >= maxToEmit)
                {
                    yield break;
                }
            }
        }

        if (incomplete is null)
        {
            yield break;
        }

        using var stop = new CancellationTokenSource();

        try
        {
            var completions = InCompletionOrder(incomplete, stop.Token);

            for (var remaining = incomplete.Count; remaining > 0; remaining--)
            {
                var completed = await completions.ReadAsync(cancellationToken).ConfigureAwait(false);

                if (IsSuccessful(completed) && predicate(completed.Result))
                {
                    yield return completed.Result;

                    cancellationToken.ThrowIfCancellationRequested();

                    if (++emitted >= maxToEmit)
                    {
                        yield break;
                    }
                }
            }
        }
        finally
        {
            // Removes the continuations from the tasks that are still running, however the enumeration ends.
            stop.Cancel();
        }
    }

    #endregion

    internal static async IAsyncEnumerable<T> AsyncEnumerableEmptyImplement<T>()
    {
        await Yield();

        yield break;
    }

    internal static IAsyncEnumerable<T> WaitAnyWithConditionsImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => AnyWithConditions(tasks, predicate, taken, cancellationToken);

    internal static IAsyncEnumerable<T> WhenAnyWithConditionsImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => AnyWithConditions(tasks, predicate, taken, cancellationToken);
}
