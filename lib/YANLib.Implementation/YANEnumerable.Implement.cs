using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Diagnostics;
using YANLib.Implementation.Object;
using YANLib.Implementation.Text;
using YANLib.Implementation.Unmanaged;
using static System.Math;
using static System.Nullable;
using static System.Threading.Tasks.Parallel;

namespace YANLib.Implementation;

internal static partial class YANEnumerable
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static int GetCountImplement(this IEnumerable? input) => input.IsNullImplement() ? 0
        : input is ICollection<object?> genericCollection
        ? genericCollection.Count
        : input is ICollection nonGenericCollection
        ? nonGenericCollection.Count
        : input is IReadOnlyCollection<object?> readOnlyCollection
        ? readOnlyCollection.Count
        : input is Array array
        ? array.Length
        : input is IImmutableList<object?> immutableList
        ? immutableList.Count
        : input is IImmutableQueue<object?> immutableQueue
        ? immutableQueue.Count()
        : input is IImmutableStack<object?> immutableStack
        ? immutableStack.Count()
        : input is IImmutableSet<object?> immutableSet
        ? immutableSet.Count
        : input is IImmutableDictionary<object, object?> immutableDictionary
        ? immutableDictionary.Count
        : input is ConcurrentBag<object?> concurrentBag
        ? concurrentBag.Count
        : input is ConcurrentQueue<object?> concurrentQueue
        ? concurrentQueue.Count
        : input is ConcurrentStack<object?> concurrentStack
        ? concurrentStack.Count
        : input is ConcurrentDictionary<object, object?> concurrentDictionary
        ? concurrentDictionary.Count
        : input is BlockingCollection<object?> blockingCollection
        ? blockingCollection.Count
        : input.Cast<object?>().Count();

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<List<T>> ChunkBySizeImplement<T>(this List<T>? input, object? chunkSize)
    {
        var size = chunkSize.ParseImplement<uint>().ParseImplement<int>();

        if (input.IsNullEmptyImplement() || size is 0)
        {
            yield break;
        }

        var count = input.Count;

        for (var i = 0; i < count; i += size)
        {
            yield return input.GetRange(i, Min(size, count - i));
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void CleanImplement<T>(this List<T>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        var type = typeof(T);

        if (type.IsClass || GetUnderlyingType(type).IsNotNullImplement())
        {
            _ = input.RemoveAll(x => x.IsNullImplement());
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T>? CleanImplement<T>(this IEnumerable<T>? input)
    {
        if (input.IsNullEmptyImplement())
        {
            return input;
        }

        var type = typeof(T);

        return type.IsClass || GetUnderlyingType(type).IsNotNullImplement() ? input.Where(x => x.IsNotNullImplement()) : input;
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void CleansImplement<T>(this List<IEnumerable<T>?>? input, bool? deepClean = null)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            if (input.Count < 1_000)
            {
                for (var i = 0; i < input.Count; i++)
                {
                    input[i] = input[i].CleanImplement();
                }
            }
            else
            {
                _ = For(0, input.Count, i => input[i] = input[i].CleanImplement());
            }
        }

        _ = input.RemoveAll(x => x.IsNullEmptyImplement());
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<IEnumerable<T>?>? CleansImplement<T>(this IEnumerable<IEnumerable<T>?>? input, bool? deepClean = null) => input.IsNullEmptyImplement()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.GetCountImplement() < 1_000 ? input.Select(x => x.CleanImplement()) : input.AsParallel().Select(x => x.CleanImplement()) : input).Where(x => x.IsNotNullEmptyImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? CleanImplement(this IEnumerable<string?>? input) => input.IsNullEmptyImplement() ? input : input.Where(x => x.IsNotNullWhiteSpaceImplement());

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static void CleansImplement(this List<IEnumerable<string?>?>? input, bool? deepClean = null)
    {
        if (input.IsNullEmptyImplement())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            if (input.Count < 1_000)
            {
                for (var i = 0; i < input.Count; i++)
                {
                    input[i] = input[i].CleanImplement();
                }
            }
            else
            {
                _ = For(0, input.Count, i => input[i] = input[i].CleanImplement());
            }
        }

        _ = input.RemoveAll(x => x.IsNullEmptyImplement());
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<IEnumerable<string?>?>? CleansImplement(this IEnumerable<IEnumerable<string?>?>? input, bool? deepClean = null) => input.IsNullEmptyImplement()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.GetCountImplement() < 1_000 ? input.Select(x => x.CleanImplement()) : input.AsParallel().Select(x => x.CleanImplement()) : input).Where(x => x.IsNotNullEmptyImplement());
}
