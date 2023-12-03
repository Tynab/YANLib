using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static ushort ToUshort(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt16(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToUshort();
        }
    }

    public static IEnumerable<ushort>? ToUshort(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToUshort(dfltVal));

    public static ushort GenerateRandomUshort(object? min = null, object? max = null)
    {
        var minValue = min is null ? ushort.MinValue : min.ToUshort();
        var maxValue = max is null ? ushort.MaxValue : max.ToUshort();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToUshort();
    }

    public static IEnumerable<ushort> GenerateRandomUshorts(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomUshort(min, max));
}
