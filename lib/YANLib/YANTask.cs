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
    /// <param name="tasks">The collection of tasks to wait on. If <c>null</c> or empty, returns a default value. The collection is enumerated once; duplicate task instances are checked once.</param>
    /// <param name="predicate">The condition that the task result must satisfy.</param>
    /// <param name="cancellation">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the result of the first task that completes and satisfies the condition, or <c>default(T)</c> if no task satisfies the condition.
    /// For a value type such as <see cref="int"/>, <c>default(T)</c> is <c>0</c> (not <c>null</c>) and cannot be told apart from a matching <c>0</c>; use tasks of a nullable type (for example <c>Task&lt;int?&gt;</c>) when that matters.
    /// </returns>
    /// <exception cref="OperationCanceledException">
    /// The returned task is canceled when <paramref name="cancellation"/> is canceled before a matching task is found: awaiting it throws <see cref="TaskCanceledException"/> if the token was already canceled when the method was called,
    /// or <see cref="OperationCanceledException"/> if it was canceled while waiting. Catch <see cref="OperationCanceledException"/> to handle both.
    /// </exception>
    /// <exception cref="ArgumentException">The returned task faults when <paramref name="tasks"/> contains a <c>null</c> task.</exception>
    /// <remarks>
    /// This method will stop waiting as soon as it finds a task that satisfies the condition; the other tasks keep running.
    /// Tasks are checked in the order they complete; tasks that are already complete are checked in collection order.
    /// Tasks that fault or are canceled are skipped, and an exception thrown by <paramref name="predicate"/> is ignored and counts as no match.
    /// Cancellation is observed while waiting, not only between completions.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Task<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellation = default) => tasks.WaitAnyWithConditionImplement(predicate, cancellation);

    /// <summary>
    /// Asynchronously waits for any task in the collection to complete and meet the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">The collection of tasks to wait on. If <c>null</c> or empty, returns a default value. The collection is enumerated once; duplicate task instances are checked once.</param>
    /// <param name="predicate">The condition that the task result must satisfy.</param>
    /// <param name="cancellation">A cancellation token that can be used to cancel the operation.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the result of the first task that completes and satisfies the condition, or <c>default(T)</c> if no task satisfies the condition.
    /// For a value type such as <see cref="int"/>, <c>default(T)</c> is <c>0</c> (not <c>null</c>) and cannot be told apart from a matching <c>0</c>; use tasks of a nullable type (for example <c>Task&lt;int?&gt;</c>) when that matters.
    /// </returns>
    /// <exception cref="OperationCanceledException">
    /// The returned task is canceled when <paramref name="cancellation"/> is canceled before a matching task is found: awaiting it throws <see cref="TaskCanceledException"/> if the token was already canceled when the method was called,
    /// or <see cref="OperationCanceledException"/> if it was canceled while waiting. Catch <see cref="OperationCanceledException"/> to handle both.
    /// </exception>
    /// <exception cref="ArgumentException">The returned task faults when <paramref name="tasks"/> contains a <c>null</c> task.</exception>
    /// <remarks>
    /// This method currently behaves exactly like <see cref="WaitAnyWithCondition{T}"/>: it waits until a task satisfies the condition or all tasks have completed,
    /// and stops waiting as soon as it finds a match; the other tasks keep running.
    /// Tasks are checked in the order they complete; tasks that are already complete are checked in collection order.
    /// Tasks that fault or are canceled are skipped, and an exception thrown by <paramref name="predicate"/> is ignored and counts as no match.
    /// Cancellation is observed while waiting, not only between completions.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Task<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellation = default) => tasks.WhenAnyWithConditionImplement(predicate, cancellation);
}
