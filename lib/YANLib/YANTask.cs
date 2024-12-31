using YANLib.Core;
using static System.Threading.Tasks.Task;

namespace YANLib;

public static partial class YANTask
{
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IEnumerable<ValueTask<T>>? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var completeTask = await WhenAny(tasks.Select(x => x.AsTask())).ConfigureAwait(false);
            var result = await completeTask;

            if (completeTask.IsCompletedSuccessfully && result.Equals(goodResult))
            {
                return result;
            }
        }

        return default;
    }

    public static async ValueTask<T?> WaitAnyWithCondition<T>(this ICollection<ValueTask<T>>? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var completeTask = await WhenAny(tasks.Select(x => x.AsTask())).ConfigureAwait(false);
            var result = await completeTask;

            if (completeTask.IsCompletedSuccessfully && result.Equals(goodResult))
            {
                return result;
            }
        }

        return default;
    }

    public static async ValueTask<T?> WaitAnyWithCondition<T>(this ValueTask<T>[]? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var completeTask = await WhenAny(tasks.Select(x => x.AsTask())).ConfigureAwait(false);
            var result = await completeTask;

            if (completeTask.IsCompletedSuccessfully && result.Equals(goodResult))
            {
                return result;
            }
        }

        return default;
    }

    public static async Task<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var completeTask = await WhenAny(tasks).ConfigureAwait(false);
            var result = await completeTask;

            if (completeTask.IsCompletedSuccessfully && result.Equals(goodResult))
            {
                return result;
            }
        }

        return default;
    }

    public static async Task<T?> WaitAnyWithCondition<T>(this ICollection<Task<T>>? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var completeTask = await WhenAny(tasks).ConfigureAwait(false);
            var result = await completeTask;

            if (completeTask.IsCompletedSuccessfully && result.Equals(goodResult))
            {
                return result;
            }
        }

        return default;
    }

    public static async Task<T?> WaitAnyWithCondition<T>(this Task<T>[]? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var completeTask = await WhenAny(tasks).ConfigureAwait(false);
            var result = await completeTask;

            if (completeTask.IsCompletedSuccessfully && result.Equals(goodResult))
            {
                return result;
            }
        }

        return default;
    }

    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IEnumerable<ValueTask<T>>? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.Select(x => x.AsTask()).ToHashSet();

            while (taskSet.Count > 0)
            {
                var completeTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(completeTask);

                var result = await completeTask.ConfigureAwait(false);

                if (result.Equals(goodResult))
                {
                    return result;
                }
            }
        }

        return default;
    }

    public static async ValueTask<T?> WhenAnyWithCondition<T>(this ICollection<ValueTask<T>>? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.Select(x => x.AsTask()).ToHashSet();

            while (taskSet.Count > 0)
            {
                var completeTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(completeTask);

                var result = await completeTask.ConfigureAwait(false);

                if (result.Equals(goodResult))
                {
                    return result;
                }
            }
        }

        return default;
    }

    public static async ValueTask<T?> WhenAnyWithCondition<T>(this ValueTask<T>[]? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.Select(x => x.AsTask()).ToHashSet();

            while (taskSet.Count > 0)
            {
                var completeTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(completeTask);

                var result = await completeTask.ConfigureAwait(false);

                if (result.Equals(goodResult))
                {
                    return result;
                }
            }
        }

        return default;
    }

    public static async Task<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.ToHashSet();

            while (taskSet.Count > 0)
            {
                var completeTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(completeTask);

                var result = await completeTask.ConfigureAwait(false);

                if (result.Equals(goodResult))
                {
                    return result;
                }
            }
        }

        return default;
    }

    public static async Task<T?> WhenAnyWithCondition<T>(this ICollection<Task<T>>? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.ToHashSet();

            while (taskSet.Count > 0)
            {
                var completeTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(completeTask);

                var result = await completeTask.ConfigureAwait(false);

                if (result.Equals(goodResult))
                {
                    return result;
                }
            }
        }

        return default;
    }

    public static async Task<T?> WhenAnyWithCondition<T>(this Task<T>[]? tasks, T goodResult) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.ToHashSet();

            while (taskSet.Count > 0)
            {
                var completeTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(completeTask);

                var result = await completeTask.ConfigureAwait(false);

                if (result.Equals(goodResult))
                {
                    return result;
                }
            }
        }

        return default;
    }
}
