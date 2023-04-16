using static System.Environment;
using static System.Threading.Tasks.Parallel;
using static System.Threading.Tasks.Task;

namespace YANLib;

public static partial class YANTask
{
    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(T goodRslt, params ValueTask<T>[] tasks) where T : IComparable<T> => await tasks.WaitAnyWithCondition(goodRslt);

    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IEnumerable<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Any())
        {
            var cmplTask = await WhenAny(tasks.Select(t => t.AsTask()).ToList()).ConfigureAwait(false);
            if (cmplTask.IsCompletedSuccessfully && typeof(T).IsValueType && cmplTask.Result.Equals(goodRslt))
            {
                return cmplTask.Result;
            }
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IReadOnlyCollection<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var cmplTask = await WhenAny(tasks.Select(t => t.AsTask()).ToList()).ConfigureAwait(false);
            if (cmplTask.IsCompletedSuccessfully && typeof(T).IsValueType && cmplTask.Result.Equals(goodRslt))
            {
                return cmplTask.Result;
            }
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IReadOnlyList<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var cmplTask = await WhenAny(tasks.Select(t => t.AsTask()).ToList()).ConfigureAwait(false);
            if (cmplTask.IsCompletedSuccessfully && typeof(T).IsValueType && cmplTask.Result.Equals(goodRslt))
            {
                return cmplTask.Result;
            }
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IReadOnlySet<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var cmplTask = await WhenAny(tasks.Select(t => t.AsTask()).ToList()).ConfigureAwait(false);
            if (cmplTask.IsCompletedSuccessfully && typeof(T).IsValueType && cmplTask.Result.Equals(goodRslt))
            {
                return cmplTask.Result;
            }
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(T goodRslt, params Task<T>[] tasks) where T : IComparable<T> => await tasks.WaitAnyWithCondition(goodRslt);

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IEnumerable<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Any())
        {
            var valueTasks = tasks.Select(t => new ValueTask<T>(t));
            return await valueTasks.WaitAnyWithCondition(goodRslt);
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IReadOnlyCollection<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var valueTasks = tasks.Select(t => new ValueTask<T>(t));
            return await valueTasks.WaitAnyWithCondition(goodRslt);
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IReadOnlyList<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var valueTasks = tasks.Select(t => new ValueTask<T>(t));
            return await valueTasks.WaitAnyWithCondition(goodRslt);
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WaitAnyWithCondition<T>(this IReadOnlySet<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var valueTasks = tasks.Select(t => new ValueTask<T>(t));
            return await valueTasks.WaitAnyWithCondition(goodRslt);
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(T goodRslt, params ValueTask<T>[] tasks) where T : IComparable<T> => await tasks.WhenAnyWithCondition(goodRslt);

    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IEnumerable<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Any())
        {
            var taskSet = tasks.Select(t => t.AsTask()).ToHashSet();
            while (taskSet.Count > 0)
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

    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IReadOnlyCollection<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var taskSet = tasks.Select(t => t.AsTask()).ToHashSet();
            while (taskSet.Count > 0)
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

    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IReadOnlyList<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var taskSet = tasks.Select(t => t.AsTask()).ToHashSet();
            while (taskSet.Count > 0)
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

    /// <summary>
    /// Waits for any of the specified <see cref="ValueTask{TResult}"/> objects in an enumerable of <see cref="ValueTask{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="ValueTask{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IReadOnlySet<ValueTask<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var taskSet = tasks.Select(t => t.AsTask()).ToHashSet();
            while (taskSet.Count > 0)
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

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(T goodRslt, params Task<T>[] tasks) where T : IComparable<T> => await tasks.WhenAnyWithCondition(goodRslt);

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IEnumerable<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Any())
        {
            var valueTasks = tasks.Select(t => new ValueTask<T>(t));
            return await valueTasks.WhenAnyWithCondition(goodRslt);
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IReadOnlyCollection<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var valueTasks = tasks.Select(t => new ValueTask<T>(t));
            return await valueTasks.WhenAnyWithCondition(goodRslt);
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IReadOnlyList<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var valueTasks = tasks.Select(t => new ValueTask<T>(t));
            return await valueTasks.WhenAnyWithCondition(goodRslt);
        }
        return default;
    }

    /// <summary>
    /// Waits for any of the specified <see cref="Task{TResult}"/> objects in an enumerable of <see cref="Task{T}"/> to complete and returns a nullable <typeparamref name="T"/> result that matches the specified condition.
    /// </summary>
    /// <typeparam name="T">The type of the value to be returned, which must be a value type.</typeparam>
    /// <param name="goodRslt">The value that the result of the completed task should match in order to be considered valid.</param>
    /// <param name="tasks">An enumerable of <see cref="Task{T}"/> objects to wait for.</param>
    /// <returns>
    /// A <see cref="ValueTask{TResult}"/> that represents the asynchronous operation.
    /// The result of the operation is the <typeparamref name="T"/> value of the completed task that matches the specified condition, or <see langword="default"/> if no such task completed successfully.
    /// </returns>
    public static async ValueTask<T?> WhenAnyWithCondition<T>(this IReadOnlySet<Task<T>> tasks, T goodRslt) where T : IComparable<T>
    {
        if (tasks is not null && tasks.Count > 0)
        {
            var valueTasks = tasks.Select(t => new ValueTask<T>(t));
            return await valueTasks.WhenAnyWithCondition(goodRslt);
        }
        return default;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, TResult> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, TResult> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, TResult> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, TResult> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, ValueTask<TResult>> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, ValueTask<TResult>> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, ValueTask<TResult>> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, ValueTask<TResult>> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, Task<TResult>> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, Task<TResult>> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, Task<TResult>> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, TResult>(Func<T, Task<TResult>> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsConcurrentlyAsync<T, Ts, TResult>(Func<T, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        var tasks = args.Select(async arg =>
        {
            await semSlim.WaitAsync();
            try
            {
                rslts.Add(await func(arg, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        await WhenAll(tasks);
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, TResult> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, TResult> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, TResult> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, TResult> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, TResult> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, ValueTask<TResult>> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, ValueTask<TResult>> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, ValueTask<TResult>> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, ValueTask<TResult>> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, ValueTask<TResult>> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, Task<TResult>> func, IEnumerable<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IEnumerable<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, Task<TResult>> func, IReadOnlyCollection<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyCollection<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, Task<TResult>> func, IReadOnlyList<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlyList<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, TResult>(Func<T, CancellationToken, Task<TResult>> func, IReadOnlySet<T> args)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, params Ts[] coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IEnumerable<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IReadOnlyCollection<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IReadOnlyList<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }

    public static async ValueTask<List<TResult>> ExecuteFunctionsParallelAsync<T, Ts, TResult>(Func<T, CancellationToken, IEnumerable<Ts>, Task<TResult>> func, IReadOnlySet<T> args, IReadOnlySet<Ts> coll)
    {
        var rslts = new List<TResult>();
        var semSlim = new SemaphoreSlim(ProcessorCount);
        await ForEachAsync(args, new ParallelOptions()
        {
            MaxDegreeOfParallelism = ProcessorCount
        }, async (arg, cancellationToken) =>
        {
            await semSlim.WaitAsync(cancellationToken);
            try
            {
                rslts.Add(await func(arg, cancellationToken, coll));
            }
            finally
            {
                _ = semSlim.Release();
            }
        });
        return rslts;
    }
}
