using System.Diagnostics;

namespace YANLib;

public static partial class YANRandom
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?> GenerateRandoms<T>(object? size = null) => Implementation.YANRandom.GenerateRandomsImplement<T>(size);
}
