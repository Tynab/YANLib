using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANTask;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with collections of asynchronous tasks, particularly for filtering and processing task results based on conditions.
/// </summary>
/// <remarks>
/// This partial class holds the streaming variants, <see cref="WaitAnyWithConditions{T}"/> and <see cref="WhenAnyWithConditions{T}"/>, which enumerate every matching task
/// result asynchronously, as the tasks complete, with an optional limit and cancellation.
/// </remarks>
public static partial class YANTask
{
    /// <summary>
    /// Returns an empty asynchronous enumerable sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements in the sequence.</typeparam>
    /// <returns>An empty asynchronous enumerable sequence.</returns>
    /// <remarks>
    /// This method is useful for returning an empty sequence in scenarios where an asynchronous enumerable is expected
    /// but no elements need to be produced.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IAsyncEnumerable<T> AsyncEnumerableEmpty<T>() => AsyncEnumerableEmptyImplement<T>();

    /// <summary>
    /// Asynchronously enumerates the results of the tasks that complete successfully and satisfy the specified condition, as the tasks complete,
    /// until all tasks have completed or <paramref name="taken"/> results have been yielded.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">
    /// The collection of tasks to wait on. If <c>null</c> or empty, the enumeration is empty. The collection is enumerated once each time the result is enumerated,
    /// when that enumeration starts; a task that appears more than once is checked once.
    /// </param>
    /// <param name="predicate">
    /// The condition that a task result must satisfy. An exception it throws ends the enumeration and propagates to the consumer, unlike
    /// <see cref="WaitAnyWithCondition{T}"/>, which treats it as no match.
    /// </param>
    /// <param name="taken">The maximum number of matching results to yield. If 0 (the default), every matching result is yielded.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the enumeration. A token passed with <c>WithCancellation</c> is observed too.</param>
    /// <returns>
    /// An asynchronous enumerable that yields the results of the tasks that satisfy the condition as the tasks complete (the exact order is described in the remarks),
    /// up to <paramref name="taken"/> results. Nothing runs until it is enumerated.
    /// </returns>
    /// <exception cref="OperationCanceledException">
    /// Thrown by the enumeration (by <c>MoveNextAsync</c>) when <paramref name="cancellationToken"/>, or a token passed with <c>WithCancellation</c>, is canceled:
    /// already canceled when the enumeration starts, canceled while it waits for a task, or canceled while the consumer handles an item (thrown by the next
    /// <c>MoveNextAsync</c>, even when no item is left).
    /// </exception>
    /// <exception cref="ArgumentException">Thrown by the enumeration when <paramref name="tasks"/> contains a <c>null</c> task.</exception>
    /// <remarks>
    /// <para>
    /// Order: the tasks are checked in collection order, and each task that is complete when it is reached is yielded at once, including a task that completed
    /// while the consumer handled an earlier result. The tasks that were still running when they were reached are then yielded in the order they complete, except
    /// that those that have completed by the time the enumeration starts waiting for them come first, in collection order.
    /// </para>
    /// <para>
    /// Results are yielded as soon as their tasks complete, without waiting for the other tasks; the enumeration stops waiting after <paramref name="taken"/> results,
    /// when it is canceled, or when the consumer stops enumerating, and the other tasks keep running.
    /// Tasks that fault or are canceled are skipped (their exceptions are observed) and do not count toward <paramref name="taken"/>.
    /// </para>
    /// <para>
    /// Each running task is observed through one continuation, which is removed as soon as the enumeration ends, however it ends (all tasks checked, limit reached,
    /// exception, cancellation, or a consumer that stops early and disposes the enumerator, as <c>await foreach</c> does).
    /// </para>
    /// <para>
    /// This method currently behaves exactly like <see cref="WhenAnyWithConditions{T}"/>.
    /// </para>
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IAsyncEnumerable<T> WaitAnyWithConditions<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => tasks.WaitAnyWithConditionsImplement(predicate, taken, cancellationToken);

    /// <summary>
    /// Asynchronously enumerates the results of the tasks that complete successfully and satisfy the specified condition, as the tasks complete,
    /// until all tasks have completed or <paramref name="taken"/> results have been yielded.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">
    /// The collection of tasks to wait on. If <c>null</c> or empty, the enumeration is empty. The collection is enumerated once each time the result is enumerated,
    /// when that enumeration starts; a task that appears more than once is checked once.
    /// </param>
    /// <param name="predicate">
    /// The condition that a task result must satisfy. An exception it throws ends the enumeration and propagates to the consumer, unlike
    /// <see cref="WhenAnyWithCondition{T}"/>, which treats it as no match.
    /// </param>
    /// <param name="taken">The maximum number of matching results to yield. If 0 (the default), every matching result is yielded.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the enumeration. A token passed with <c>WithCancellation</c> is observed too.</param>
    /// <returns>
    /// An asynchronous enumerable that yields the results of the tasks that satisfy the condition as the tasks complete (the exact order is described in the remarks),
    /// up to <paramref name="taken"/> results. Nothing runs until it is enumerated.
    /// </returns>
    /// <exception cref="OperationCanceledException">
    /// Thrown by the enumeration (by <c>MoveNextAsync</c>) when <paramref name="cancellationToken"/>, or a token passed with <c>WithCancellation</c>, is canceled:
    /// already canceled when the enumeration starts, canceled while it waits for a task, or canceled while the consumer handles an item (thrown by the next
    /// <c>MoveNextAsync</c>, even when no item is left).
    /// </exception>
    /// <exception cref="ArgumentException">Thrown by the enumeration when <paramref name="tasks"/> contains a <c>null</c> task.</exception>
    /// <remarks>
    /// <para>
    /// Order: the tasks are checked in collection order, and each task that is complete when it is reached is yielded at once, including a task that completed
    /// while the consumer handled an earlier result. The tasks that were still running when they were reached are then yielded in the order they complete, except
    /// that those that have completed by the time the enumeration starts waiting for them come first, in collection order.
    /// </para>
    /// <para>
    /// This method currently behaves exactly like <see cref="WaitAnyWithConditions{T}"/>: results are yielded as soon as their tasks complete, and the enumeration
    /// stops waiting after <paramref name="taken"/> results, when it is canceled, or when the consumer stops enumerating; the other tasks keep running.
    /// Tasks that fault or are canceled are skipped (their exceptions are observed) and do not count toward <paramref name="taken"/>.
    /// </para>
    /// <para>
    /// Each running task is observed through one continuation, which is removed as soon as the enumeration ends, however it ends (all tasks checked, limit reached,
    /// exception, cancellation, or a consumer that stops early and disposes the enumerator, as <c>await foreach</c> does).
    /// </para>
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IAsyncEnumerable<T> WhenAnyWithConditions<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => tasks.WhenAnyWithConditionsImplement(predicate, taken, cancellationToken);
}
