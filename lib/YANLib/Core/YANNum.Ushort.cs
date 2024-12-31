using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    public static ushort GenerateRandomUshort(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? ushort.MinValue : min.ToUshort();
        var maxValue = max.IsNull() ? ushort.MaxValue : max.ToUshort();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToUshort();
    }

    public static IEnumerable<ushort> GenerateRandomUshorts(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomUshort(min, max));
}
