using static System.Threading.Tasks.Task;
using static System.Threading.Tasks.TaskStatus;

namespace YANLib;

public static partial class YANTask
{
    /// <summary>
    /// Waits for any of the provided <see cref="Task"/> objects to complete execution with condition.
    /// </summary>
    /// <typeparam name="T">Object type.</typeparam>
    /// <param name="tasks">Input tasks.</param>
    /// <param name="goodRslt">Good result.</param>
    /// <returns>First task completed result.</returns>
    public static async Task<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>> tasks, T goodRslt)
    {
        var taskList = new List<Task<T>>(tasks);
        var fstCmpl = default(Task<T>);
        while (taskList.Count > 0)
        {
            var curCmpl = await WhenAny(taskList);
            var rslt = curCmpl.Result;
            if (curCmpl.Status == RanToCompletion && rslt != null && rslt.Equals(goodRslt))
            {
                fstCmpl = curCmpl;
                break;
            }
            else
            {
                taskList.Remove(curCmpl);
            }
        }
        return (fstCmpl != default(Task<T>)) ? fstCmpl.Result : default;
    }
}
