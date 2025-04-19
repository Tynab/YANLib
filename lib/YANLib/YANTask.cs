using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods to await multiple tasks based on a user-defined condition.
/// </summary>
public static partial class YANTask
{
    /// <summary>
    /// Awaits the first task in <paramref name="tasks"/> to complete, returning its result if it satisfies
    /// the specified <paramref name="predicate"/>; otherwise returns <c>default</c>. If <paramref name="tasks"/>
    /// is <c>null</c> or empty, <c>default</c> is returned immediately.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">The collection of tasks to await.</param>
    /// <param name="predicate">A function to test each task result.</param>
    /// <param name="cancellation">Optional <see cref="CancellationToken"/> to cancel the operation.</param>
    /// <returns>
    /// A <typeparamref name="T"/> value wrapped in a <see cref="Task{TResult}"/> that completes
    /// when the first task finishes. If the result matches the predicate, that result is returned;
    /// otherwise <c>default</c> is returned.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Task<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellation = default) => tasks.WaitAnyWithConditionImplement(predicate, cancellation);

    /// <summary>
    /// Awaits tasks until one completes whose result satisfies the specified <paramref name="predicate"/>.
    /// All non-matching or faulted tasks are skipped. If <paramref name="tasks"/> is <c>null</c> or empty,
    /// or if no result matches, returns <c>default</c>.
    /// </summary>
    /// <typeparam name="T">The type of the task result.</typeparam>
    /// <param name="tasks">The collection of tasks to await.</param>
    /// <param name="predicate">A function to test each task result.</param>
    /// <param name="cancellation">Optional <see cref="CancellationToken"/> to cancel the operation.</param>
    /// <returns>
    /// A <typeparamref name="T"/> value wrapped in a <see cref="Task{TResult}"/> that completes
    /// when a matching result is found, or <c>default</c> if none match.
    /// </returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static Task<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, CancellationToken cancellation = default) => tasks.WhenAnyWithConditionImplement(predicate, cancellation);
}
