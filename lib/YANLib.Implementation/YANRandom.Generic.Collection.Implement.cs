using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Linq.Enumerable;
using static System.Math;

namespace YANLib.Implementation;

internal static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T> GenerateRandomsImplement<T>(this IEnumerable<object?>? input, object? size = null, bool allowDuplicates = true) where T : unmanaged
    {
        var n = size.ParseImplement<uint>().ParseImplement<int>();

        if (input.IsNullEmptyImplement() || n.IsDefaultImplement())
        {
            yield break;
        }

        var list = input as IList<object?> ?? [.. input];

        if (allowDuplicates)
        {
            if (n < 1000)
            {
                for (var i = 0; i < n; i++)
                {
                    yield return list.GenerateRandomImplement<T>();
                }
            }
            else
            {
                foreach (var x in Range(0, n).AsParallel().Select(_ => list.GenerateRandomImplement<T>()))
                {
                    yield return x;
                }
            }
        }
        else
        {
            var m = Min(n, list.Count);
            var pool = list.ToList<T>();

            for (var i = 0; i < m; i++)
            {
                var idx = GenerateRandomImplement<int>(0, pool.Count);

                yield return pool[idx];

                pool.RemoveAt(idx);
            }
        }
    }
}
