using System.Diagnostics;
using YANLib.Implementation;
using static YANLib.Implementation.YANTask;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with collections of asynchronous tasks, particularly for filtering and processing task results based on conditions.
/// </summary>
/// <remarks>
/// This partial class holds the streaming variants that enumerate every matching task result asynchronously, with a limit and cancellation
/// (<c>WaitAnyWithConditions</c> / <c>WhenAnyWithConditions</c>). They are internal: they are not part of the public API.
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
    /// Asynchronously enumerates tasks that complete and meet the specified condition, stopping after finding the specified number of matching tasks.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">The collection of tasks to wait on. If <c>null</c> or empty, returns an empty enumerable. The collection is enumerated once, when the enumeration starts; duplicate task instances are checked once.</param>
    /// <param name="predicate">The condition that the task result must satisfy. An exception it throws ends the enumeration and propagates to the consumer.</param>
    /// <param name="taken">The maximum number of matching results to take. If 0, all matching results are returned.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>An asynchronous enumerable that yields the results of tasks that satisfy the condition, in completion order, up to the specified limit.</returns>
    /// <exception cref="ArgumentException">Thrown by the enumeration when <paramref name="tasks"/> contains a <c>null</c> task.</exception>
    /// <remarks>
    /// This method will stop waiting as soon as it finds the specified number of tasks that satisfy the condition.
    /// If the cancellation token is canceled, before or during the enumeration (including a token passed with <c>WithCancellation</c>), the enumeration ends immediately without an exception.
    /// Tasks that throw exceptions are skipped and do not count toward the taken limit.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IAsyncEnumerable<T> WaitAnyWithConditions<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => tasks.WaitAnyWithConditionsImplement(predicate, taken, cancellationToken);

    /// <summary>
    /// Asynchronously enumerates tasks that complete and meet the specified condition, continuing until all tasks complete or the specified number of matching tasks is found.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">The collection of tasks to wait on. If <c>null</c> or empty, returns an empty enumerable. The collection is enumerated once, when the enumeration starts; duplicate task instances are checked once.</param>
    /// <param name="predicate">The condition that the task result must satisfy. An exception it throws ends the enumeration and propagates to the consumer.</param>
    /// <param name="taken">The maximum number of matching results to take. If 0, all matching results are returned.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>An asynchronous enumerable that yields the results of tasks that satisfy the condition, in completion order, up to the specified limit.</returns>
    /// <exception cref="ArgumentException">Thrown by the enumeration when <paramref name="tasks"/> contains a <c>null</c> task.</exception>
    /// <remarks>
    /// This method currently behaves exactly like <see cref="WaitAnyWithConditions{T}"/>: it waits until it finds the specified number of tasks that satisfy the condition or all tasks have completed.
    /// If the cancellation token is canceled, before or during the enumeration (including a token passed with <c>WithCancellation</c>), the enumeration ends immediately without an exception.
    /// Tasks that throw exceptions are skipped and do not count toward the taken limit.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IAsyncEnumerable<T> WhenAnyWithConditions<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => tasks.WhenAnyWithConditionsImplement(predicate, taken, cancellationToken);
}
