using System.Diagnostics;

namespace YANLib;

public static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T> GenerateRandoms<T>(object? min = null, object? max = null, object? size = null) where T : unmanaged => Implementation.YANRandom.GenerateRandomsImplement<T>(min, max, size);
}
