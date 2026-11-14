using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANTask
{
    #region Private

    // Returns null instead of throwing when the token is cancelled, so the caller can end its enumeration quietly.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async ValueTask<Task<T>?> ReadOrNullAsync<T>(ChannelReader<Task<T>> reader, CancellationToken cancellationToken)
    {
        try
        {
            return await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
            return null;
        }
    }

    // A cancelled token (already cancelled, passed later through WithCancellation, or cancelled while waiting or while
    // the consumer handles an item) ends the enumeration without an exception. Exceptions thrown by the predicate
    // propagate to the consumer.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async IAsyncEnumerable<T> AnyWithConditions<T>(IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, [EnumeratorCancellation] CancellationToken cancellationToken = default)
    {
        await Yield();

        if (tasks is null || cancellationToken.IsCancellationRequested)
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

        // Tasks that are already complete come first, in collection order, without registering anything.
        foreach (var task in pending)
        {
            if (!task.IsCompleted)
            {
                (incomplete ??= []).Add(task);

                continue;
            }

            if (cancellationToken.IsCancellationRequested)
            {
                yield break;
            }

            if (IsSuccessful(task) && predicate(task.Result))
            {
                yield return task.Result;

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
                var completed = await ReadOrNullAsync(completions, cancellationToken).ConfigureAwait(false);

                if (completed is null)
                {
                    yield break;
                }

                if (IsSuccessful(completed) && predicate(completed.Result))
                {
                    yield return completed.Result;

                    if (++emitted >= maxToEmit)
                    {
                        yield break;
                    }
                }
            }
        }
        finally
        {
            stop.Cancel();
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
