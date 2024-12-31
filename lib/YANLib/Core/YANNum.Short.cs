using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANUnmanaged
{
    public static short GenerateRandomShort(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? short.MinValue : min.ToShort();
        var maxValue = max.IsNull() ? short.MaxValue : max.ToShort();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToShort();
    }

    public static IEnumerable<short> GenerateRandomShorts(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomShort(min, max));
}
