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
    /// This method will stop waiting as soon as it finds a task that satisfies the condition.
    /// If the cancellation token is canceled, the returned task will be canceled.
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
    /// Unlike <see cref="WaitAnyWithCondition{T}"/>, this method will continue to wait for tasks to complete until it finds one that satisfies the condition or all tasks have completed.
    /// If the cancellation token is canceled, the returned task will be canceled.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Task<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellation = default) => tasks.WhenAnyWithConditionImplement(predicate, cancellation);
}
