using YANLib.Core;
using static System.Threading.Tasks.Task;

namespace YANLib;

public static partial class YANTask
{
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IEnumerable<ValueTask<T>>? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var cmplTask = await WhenAny(tasks.Select(x => x.AsTask())).ConfigureAwait(false);
            var rslt = await cmplTask;

            if (cmplTask.IsCompletedSuccessfully && rslt.Equals(goodRslt))
            {
                return rslt;
            }
        }

        return default;
    }

    public static async ValueTask<T?> WaitAnyWithCondition<T>(this ICollection<ValueTask<T>>? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var cmplTask = await WhenAny(tasks.Select(x => x.AsTask())).ConfigureAwait(false);
            var rslt = await cmplTask;

            if (cmplTask.IsCompletedSuccessfully && rslt.Equals(goodRslt))
            {
                return rslt;
            }
        }

        return default;
    }

    public static async ValueTask<T?> WaitAnyWithCondition<T>(this ValueTask<T>[]? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var cmplTask = await WhenAny(tasks.Select(x => x.AsTask())).ConfigureAwait(false);
            var rslt = await cmplTask;

            if (cmplTask.IsCompletedSuccessfully && rslt.Equals(goodRslt))
            {
                return rslt;
            }
        }

        return default;
    }

    public static async Task<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var cmplTask = await WhenAny(tasks).ConfigureAwait(false);
            var rslt = await cmplTask;

            if (cmplTask.IsCompletedSuccessfully && rslt.Equals(goodRslt))
            {
                return rslt;
            }
        }

        return default;
    }

    public static async Task<T?> WaitAnyWithCondition<T>(this ICollection<Task<T>>? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var cmplTask = await WhenAny(tasks).ConfigureAwait(false);
            var rslt = await cmplTask;

            if (cmplTask.IsCompletedSuccessfully && rslt.Equals(goodRslt))
            {
                return rslt;
            }
        }

        return default;
    }

    public static async Task<T?> WaitAnyWithCondition<T>(this Task<T>[]? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var cmplTask = await WhenAny(tasks).ConfigureAwait(false);
            var rslt = await cmplTask;

            if (cmplTask.IsCompletedSuccessfully && rslt.Equals(goodRslt))
            {
                return rslt;
            }
        }

        return default;
    }

    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IEnumerable<ValueTask<T>>? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.Select(x => x.AsTask()).ToHashSet();

            while (taskSet.Count > 0)
            {
                var cmplTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(cmplTask);

                var rslt = await cmplTask.ConfigureAwait(false);

                if (rslt.Equals(goodRslt))
                {
                    return rslt;
                }
            }
        }

        return default;
    }

    public static async ValueTask<T?> WhenAnyWithCondition<T>(this ICollection<ValueTask<T>>? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.Select(x => x.AsTask()).ToHashSet();

            while (taskSet.Count > 0)
            {
                var cmplTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(cmplTask);

                var rslt = await cmplTask.ConfigureAwait(false);

                if (rslt.Equals(goodRslt))
                {
                    return rslt;
                }
            }
        }

        return default;
    }

    public static async ValueTask<T?> WhenAnyWithCondition<T>(this ValueTask<T>[]? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.Select(x => x.AsTask()).ToHashSet();

            while (taskSet.Count > 0)
            {
                var cmplTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(cmplTask);

                var rslt = await cmplTask.ConfigureAwait(false);

                if (rslt.Equals(goodRslt))
                {
                    return rslt;
                }
            }
        }

        return default;
    }

    public static async Task<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>>? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.ToHashSet();

            while (taskSet.Count > 0)
            {
                var cmplTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(cmplTask);

                var rslt = await cmplTask.ConfigureAwait(false);

                if (rslt.Equals(goodRslt))
                {
                    return rslt;
                }
            }
        }

        return default;
    }

    public static async Task<T?> WhenAnyWithCondition<T>(this ICollection<Task<T>>? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.ToHashSet();

            while (taskSet.Count > 0)
            {
                var cmplTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(cmplTask);

                var rslt = await cmplTask.ConfigureAwait(false);

                if (rslt.Equals(goodRslt))
                {
                    return rslt;
                }
            }
        }

        return default;
    }

    public static async Task<T?> WhenAnyWithCondition<T>(this Task<T>[]? tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.ToHashSet();

            while (taskSet.Count > 0)
            {
                var cmplTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(cmplTask);

                var rslt = await cmplTask.ConfigureAwait(false);

                if (rslt.Equals(goodRslt))
                {
                    return rslt;
                }
            }
        }

        return default;
    }
}
