using System.Runtime.CompilerServices;

namespace YANLib.Tests.Extensions;

internal static class YANTaskTestExtensions
{
    public static IAsyncEnumerable<T> WaitAnyWithConditionsTest<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => ConvertToAsyncEnumerable(tasks, predicate, taken, cancellationToken);

    public static IAsyncEnumerable<T> WhenAnyWithConditionsTest<T>(this IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken = 0, CancellationToken cancellationToken = default)
        => ConvertToAsyncEnumerable(tasks, predicate, taken, cancellationToken);

    private static async IAsyncEnumerable<T> ConvertToAsyncEnumerable<T>(IEnumerable<Task<T>>? tasks, Func<T, bool> predicate, uint taken, [EnumeratorCancellation] CancellationToken cancellationToken)
    {
        if (tasks is null)
        {
            yield break;
        }

        var taskList = new List<Task<T>>(tasks);

        if (taskList.IsNullEmpty())
        {
            yield break;
        }

        var count = 0u;
        var maxCount = taken == 0 ? uint.MaxValue : taken;

        foreach (var task in taskList)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                yield break;
            }

            T? result = default;
            var success = false;

            try
            {
                result = await task.ConfigureAwait(false);
                success = true;
            }
            catch
            {
                success = false;
            }

            if (success && predicate(result!))
            {
                yield return result!;

                count++;

                if (count >= maxCount)
                {
                    yield break;
                }
            }
        }
    }

    public static IAsyncEnumerable<T> AsyncEnumerableEmptyTest<T>() => EmptyAsyncEnumerable<T>();

    private static async IAsyncEnumerable<T> EmptyAsyncEnumerable<T>()
    {
        await Task.Yield();

        yield break;
    }
}
