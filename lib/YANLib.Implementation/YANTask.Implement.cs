using System.Diagnostics;
using YANLib.Implementation.Object;
using static System.Threading.Tasks.Task;

namespace YANLib.Implementation;

internal static partial class YANTask
{
    #region Private
    [DebuggerHidden]
    [DebuggerStepThrough]
    private static async Task<T?> AnyWithCondition<T>(IEnumerable<Task<T>>? tasks, T goodResult, bool firstOnly, CancellationToken cancellationToken) where T : IComparable<T>
    {
        if (tasks.IsNullEmptyImplement())
        {
            return default;
        }

        var pending = tasks.ToHashSet();

        if (pending.Count is 0)
        {
            return default;
        }

        while (pending.Count > 0)
        {
            cancellationToken.ThrowIfCancellationRequested();

            Task<T> completed;

            try
            {
                completed = await WhenAny(pending).ConfigureAwait(false);
            }
            catch
            {
                return default;
            }

            _ = pending.Remove(completed);

            T result;

            try
            {
                result = await completed.ConfigureAwait(false);
            }
            catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
            {
                throw;
            }
            catch
            {
                if (firstOnly)
                {
                    return default;
                }
                else
                {
                    continue;
                }
            }

            if (result.Equals(goodResult))
            {
                return result;
            }

            if (firstOnly)
            {
                return default;
            }
        }

        return default;
    }
    #endregion

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task<T?> WaitAnyWithConditionImplement<T>(this IEnumerable<Task<T>>? tasks, T goodResult, CancellationToken cancellationToken = default) where T : IComparable<T>
        => AnyWithCondition(tasks, goodResult, firstOnly: true, cancellationToken);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static Task<T?> WhenAnyWithConditionImplement<T>(this IEnumerable<Task<T>>? tasks, T goodResult, CancellationToken cancellationToken = default) where T : IComparable<T>
        => AnyWithCondition(tasks, goodResult, firstOnly: false, cancellationToken);
}
