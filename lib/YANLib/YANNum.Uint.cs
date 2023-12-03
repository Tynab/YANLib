using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static uint ToUint(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt32(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToUint();
        }
    }

    public static IEnumerable<uint>? ToUint(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToUint(dfltVal));

    public static uint GenerateRandomUint(object? min = null, object? max = null)
    {
        var minValue = min is null ? uint.MinValue : min.ToUint();
        var maxValue = max is null ? uint.MaxValue : max.ToUint();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToUint();
    }

    public static IEnumerable<uint> GenerateRandomUints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomUint(min, max));
}
