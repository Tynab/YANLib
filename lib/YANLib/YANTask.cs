using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for working with asynchronous tasks, particularly for task collections with conditional processing.
/// </summary>
/// <remarks>
/// This class contains methods that extend the functionality of the <see cref="Task"/> class and related types,
/// allowing for more complex asynchronous operations such as waiting for tasks that satisfy specific conditions.
/// </remarks>
public static partial class YANTask
{
    /// <summary>
    /// Waits for any task in the collection to complete and meet the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">The collection of tasks to wait on. If <c>null</c> or empty, returns a default value.</param>
    /// <param name="predicate">The condition that the task result must satisfy.</param>
    /// <param name="cancellation">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the first task that completes and satisfies the condition, or <c>default(T)</c> if no task satisfies the condition.</returns>
    /// <remarks>
    /// Tasks are observed in completion order; faulted or canceled tasks are skipped. The method stops waiting as soon as a result satisfies the condition,
    /// and returns <c>default(T)</c> once every task has completed without a match.
    /// If <paramref name="cancellation"/> is canceled before a match is found, the returned task is canceled, even while tasks are still pending.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Task<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellation = default) => tasks.WaitAnyWithConditionImplement(predicate, cancellation);

    /// <summary>
    /// Asynchronously waits for any task in the collection to complete and meet the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">The collection of tasks to wait on. If <c>null</c> or empty, returns a default value.</param>
    /// <param name="predicate">The condition that the task result must satisfy.</param>
    /// <param name="cancellation">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>A task that represents the asynchronous operation. The task result contains the result of the first task that completes and satisfies the condition, or <c>default(T)</c> if no task satisfies the condition.</returns>
    /// <remarks>
    /// Alias of <see cref="WaitAnyWithCondition{T}"/> with identical semantics (provided for naming symmetry with <see cref="Task.WhenAny(Task[])"/>).
    /// If <paramref name="cancellation"/> is canceled before a match is found, the returned task is canceled, even while tasks are still pending.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Task<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellation = default) => tasks.WhenAnyWithConditionImplement(predicate, cancellation);
}
