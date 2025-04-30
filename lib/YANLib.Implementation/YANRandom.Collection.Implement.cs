using System.Diagnostics;
using static System.Linq.Enumerable;

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
}
