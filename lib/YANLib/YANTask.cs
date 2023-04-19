using static System.Environment;
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
}
