using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static short ToShort(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt16(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToShort();
        }
    }

    public static IEnumerable<short>? ToShort(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToShort(dfltVal));

    public static short GenerateRandomShort(object? min = null, object? max = null)
    {
        var minValue = min is null ? short.MinValue : min.ToShort();
        var maxValue = max is null ? short.MaxValue : max.ToShort();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToShort();
    }

    public static IEnumerable<short> GenerateRandomShorts(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomShort(min, max));
}
