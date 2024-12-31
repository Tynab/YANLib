using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    public static uint GenerateRandomUint(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? uint.MinValue : min.ToUint();
        var maxValue = max.IsNull() ? uint.MaxValue : max.ToUint();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToUint();
    }

    public static IEnumerable<uint> GenerateRandomUints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomUint(min, max));
}
