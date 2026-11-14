using System.Diagnostics;
using System.Threading.Channels;
using static System.Threading.Tasks.Task;
using static System.Threading.Tasks.TaskContinuationOptions;

namespace YANLib.Implementation;

internal static partial class YANTask
{
    #region Private

    // Enumerates the source once (a lazy sequence such as tasks.Select(StartAsync) would otherwise start its tasks again)
    // and drops duplicate task instances.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static HashSet<Task<T>> Materialize<T>(IEnumerable<Task<T>> tasks)
    {
        var pending = new HashSet<Task<T>>(tasks);

        return pending.Contains(null!) ? throw new ArgumentException("The tasks argument included a null value.", nameof(tasks)) : pending;
    }

    // Writes each task to the returned reader when it completes, using one continuation per task (Task.WhenAny over the
    // pending set in a loop costs O(n²) time and allocations). Cancelling stopToken removes the continuations from the
    // tasks that are still pending: callers must cancel it as soon as they stop reading (match found, cancellation,
    // abandoned enumeration), otherwise every call that shares a long-lived task leaves a continuation, and the channel it
    // holds, attached to that task.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static ChannelReader<Task<T>> InCompletionOrder<T>(List<Task<T>> tasks, CancellationToken stopToken)
    {
        var channel = Channel.CreateUnbounded<Task<T>>(new UnboundedChannelOptions
        {
            SingleReader = true
        });

        foreach (var task in tasks)
        {
            _ = task.ContinueWith(static (completed, writer) => _ = ((ChannelWriter<Task<T>>)writer!).TryWrite(completed), channel.Writer, stopToken, ExecuteSynchronously, TaskScheduler.Default);
        }

        return channel.Reader;
    }

    // Marks the exception of a faulted task as observed, as awaiting it did before.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool IsSuccessful<T>(Task<T> task)
    {
        if (task.IsCompletedSuccessfully)
        {
            return true;
        }

        _ = task.Exception;

        return false;
    }

    // An exception thrown by the predicate counts as no match.
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static bool Matches<T>(Task<T> task, Func<T, bool> predicate)
    {
        if (!IsSuccessful(task))
        {
            return false;
        }

        try
        {
            return predicate(task.Result);
        }
        catch
        {
            return false;
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async Task<T?> AnyWithCondition<T>(IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellationToken = default)
    {
        await Yield();

        if (tasks is null)
        {
            return default;
        }

        var pending = Materialize(tasks);

        if (pending.Count is 0)
        {
            return default;
        }

        cancellationToken.ThrowIfCancellationRequested();

        List<Task<T>>? incomplete = null;

        // Tasks that are already complete are checked first, in collection order, without registering anything.
        foreach (var task in pending)
        {
            if (!task.IsCompleted)
            {
                (incomplete ??= []).Add(task);
            }
            else if (Matches(task, predicate))
            {
                return task.Result;
            }
        }

        if (incomplete is null)
        {
            return default;
        }

        using var stop = new CancellationTokenSource();

        try
        {
            var completions = InCompletionOrder(incomplete, stop.Token);

            for (var remaining = incomplete.Count; remaining > 0; remaining--)
            {
                var completed = await completions.ReadAsync(cancellationToken).ConfigureAwait(false);

                if (Matches(completed, predicate))
                {
                    return completed.Result;
                }
            }

            return default;
        }
        finally
        {
            stop.Cancel();
        }
    }

    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task<T?> WaitAnyWithConditionImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested ? FromCanceled<T?>(cancellationToken) : AnyWithCondition(tasks, predicate, cancellationToken);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task<T?> WhenAnyWithConditionImplement<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellationToken = default)
        => cancellationToken.IsCancellationRequested ? FromCanceled<T?>(cancellationToken) : AnyWithCondition(tasks, predicate, cancellationToken);
}
