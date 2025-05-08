using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with collections of asynchronous tasks, particularly for filtering and processing task results based on conditions.
/// </summary>
/// <remarks>
/// This partial class extends the functionality of the <see cref="YANTask"/> class with methods specifically designed for working with collections of tasks.
/// It provides capabilities for asynchronous enumeration of task results that satisfy specific conditions, with support for limiting the number of results
/// and cancellation. These methods are particularly useful for scenarios where you need to process multiple matching results from a set of concurrent operations.
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
    private static IAsyncEnumerable<T> AsyncEnumerableEmpty<T>() => AsyncEnumerableEmpty<T>();

    /// <summary>
    /// Asynchronously enumerates tasks that complete and meet the specified condition, stopping after finding the specified number of matching tasks.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">The collection of tasks to wait on. If <c>null</c> or empty, returns an empty enumerable.</param>
    /// <param name="predicate">The condition that the task result must satisfy.</param>
    /// <param name="taken">The maximum number of matching results to take. If 0, all matching results are returned.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>An asynchronous enumerable that yields the results of tasks that satisfy the condition, up to the specified limit.</returns>
    /// <remarks>
    /// This method will stop waiting as soon as it finds the specified number of tasks that satisfy the condition.
    /// If the cancellation token is canceled, the enumeration will stop immediately.
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
    /// <param name="tasks">The collection of tasks to wait on. If <c>null</c> or empty, returns an empty enumerable.</param>
    /// <param name="predicate">The condition that the task result must satisfy.</param>
    /// <param name="taken">The maximum number of matching results to take. If 0, all matching results are returned.</param>
    /// <param name="cancellationToken">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>An asynchronous enumerable that yields the results of tasks that satisfy the condition, up to the specified limit.</returns>
    /// <remarks>
    /// Unlike <see cref="WaitAnyWithConditions{T}"/>, this method will continue to wait for tasks to complete until it finds the specified number of tasks that satisfy the condition or all tasks have completed.
    /// If the cancellation token is canceled, the enumeration will stop immediately.
    /// Tasks that throw exceptions are skipped and do not count toward the taken limit.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IAsyncEnumerable<T> WhenAnyWithConditions<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => tasks.WhenAnyWithConditionsImplement(predicate, taken, cancellationToken);
}
