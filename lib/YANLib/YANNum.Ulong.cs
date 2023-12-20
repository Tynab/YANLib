using System.Numerics;
using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static ulong ToUlong(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt64(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToUlong();
        }
    }

    public static IEnumerable<ulong>? ToUlong(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToUlong(dfltVal));

    public static ulong GenerateRandomUlong(object? min = null, object? max = null)
    {
        var minValue = min is null ? ulong.MinValue : min.ToUlong();
        var maxValue = max is null ? ulong.MaxValue : max.ToUlong();

        return minValue > maxValue ? default : (new Random().NextInt64(long.MinValue, (long)(maxValue - (minValue - (BigInteger)long.MinValue))) - long.MinValue).ToUlong() + minValue;
    }

    public static IEnumerable<ulong> GenerateRandomUlongs(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomUlong(min, max));
}
