using static System.Threading.Tasks.Task;

namespace YANLib;

public static partial class YANTask
{
    /// <summary>
    /// Waits for any task in a collection of tasks to complete, and returns the result of the task that satisfies a specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the result produced by the tasks.</typeparam>
    /// <param name="tasks">A collection of tasks to wait for.</param>
    /// <param name="goodRslt">The result that the returned task must satisfy.</param>
    /// <returns>The result of the completed task that satisfies the specified condition, or <see langword="null"/> if no such task exists.</returns>
    /// <remarks>
    /// This method waits for any of the specified tasks to complete, and returns the result of the first completed task that satisfies the specified condition. The remaining tasks are not cancelled, but their results are ignored.
    /// </remarks>
    public static async Task<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>> tasks, T goodRslt) where T : struct
    {
        var cmplTask = await WhenAny(tasks);
        return cmplTask.IsCompletedSuccessfully && cmplTask.Result.Equals(goodRslt) ? cmplTask.Result : null;
    }

    /// <summary>
    /// Waits for any task in a collection of tasks to complete, and returns the result of the task that satisfies a specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the result produced by the tasks.</typeparam>
    /// <param name="tasks">A collection of tasks to wait for.</param>
    /// <param name="goodRslt">The result that the returned task must satisfy.</param>
    /// <returns>The result of the completed task that satisfies the specified condition, or <see langword="null"/> if no such task exists.</returns>
    /// <remarks>
    /// This method waits for any of the specified tasks to complete, and returns the result of the first completed task that satisfies the specified condition. The remaining tasks are not cancelled, but their results are ignored.
    /// </remarks>
    public static async Task<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>> tasks, T goodRslt) where T : struct
    {
        while (tasks.Any())
        {
            var cmplTask = await WhenAny(tasks);
            tasks = tasks.Except(new[]
            {
                cmplTask
            });
            var rslt = await cmplTask;
            if (rslt.Equals(goodRslt))
            {
                return rslt;
            }
        }
        return null;
    }
}
