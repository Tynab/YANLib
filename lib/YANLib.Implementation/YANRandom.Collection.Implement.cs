using System.Diagnostics;
using static System.Linq.Enumerable;
using static System.Math;

namespace YANLib.Implementation;

internal static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T> GenerateRandomsImplement<T>(object? min = null, object? max = null, object? size = null) where T : unmanaged
    {
        var n = size.ParseImplement<uint>().ParseImplement<int>();
        var r = Range(0, n);

        return n < 1_000 ? r.Select(i => GenerateRandomImplement<T>(min, max)) : r.AsParallel().Select(i => GenerateRandomImplement<T>(min, max));
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T> GenerateRandomsImplement<T>(this IEnumerable<T>? input, object? size = null, bool allowDuplicates = true) where T : unmanaged
    {
        var n = size.ParseImplement<uint>().ParseImplement<int>();

        if (input.IsNullEmptyImplement() || n.IsDefaultImplement())
        {
            yield break;
        }

        var list = input as IList<T> ?? [.. input];

        if (allowDuplicates)
        {
            if (n < 1000)
            {
                for (var i = 0; i < n; i++)
                {
                    yield return list.GenerateRandomImplement();
                }
            }
            else
            {
                foreach (var x in Range(0, n).AsParallel().Select(_ => list.GenerateRandomImplement()))
                {
                    yield return x;
                }
            }
        }
        else
        {
            var m = Min(n, list.Count);
            var pool = list.ToList();

            for (var i = 0; i < m; i++)
            {
                var idx = GenerateRandomImplement<int>(0, pool.Count);

                yield return pool[idx];

                pool.RemoveAt(idx);
            }
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T> GenerateRandomsImplement<T>(this System.Collections.IEnumerable? input, object? size = null, bool allowDuplicates = true) where T : unmanaged
        => input is null ? [] : input.Cast<object?>().GenerateRandomsImplement<T>(size, allowDuplicates);
}
