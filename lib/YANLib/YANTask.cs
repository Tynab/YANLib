using static System.Threading.Tasks.Task;

namespace YANLib;

public static partial class YANTask
{

    public static async ValueTask<T?> WaitAnyWithCondition<T>(T goodRslt, params ValueTask<T>[] tasks) where T : IComparable<T> => await tasks.WaitAnyWithCondition(goodRslt);

    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IEnumerable<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var cmplTask = await WhenAny(tasks.Select(x => x.AsTask()).ToList()).ConfigureAwait(false);

            if (cmplTask.IsCompletedSuccessfully && typeof(T).IsValueType && cmplTask.Result.Equals(goodRslt))
            {
                return cmplTask.Result;
            }
        }

        return default;
    }

    public static async ValueTask<T?> WaitAnyWithCondition<T>(T goodRslt, params Task<T>[] tasks) where T : IComparable<T> => await tasks.WaitAnyWithCondition(goodRslt);

    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var valueTasks = tasks.Select(x => new ValueTask<T>(x));

            return await valueTasks.WaitAnyWithCondition(goodRslt);
        }

        return default;
    }

    public static async ValueTask<T?> WhenAnyWithCondition<T>(T goodRslt, params ValueTask<T>[] tasks) where T : IComparable<T> => await tasks.WhenAnyWithCondition(goodRslt);

    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IEnumerable<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var taskSet = tasks.Select(x => x.AsTask()).ToHashSet();

            while (taskSet.Count is not 0)
            {
                var cmplTask = await WhenAny(taskSet).ConfigureAwait(false);

                _ = taskSet.Remove(cmplTask);

                var rslt = await cmplTask.ConfigureAwait(false);

                if (typeof(T).IsValueType && rslt.Equals(goodRslt))
                {
                    return rslt;
                }
            }
        }

        return default;
    }

    public static async ValueTask<T?> WhenAnyWithCondition<T>(T goodRslt, params Task<T>[] tasks) where T : IComparable<T> => await tasks.WhenAnyWithCondition(goodRslt);

    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks.IsNotEmptyAndNull())
        {
            var valueTasks = tasks.Select(x => new ValueTask<T>(x));

            return await valueTasks.WhenAnyWithCondition(goodRslt);
        }

        return default;
    }
}
