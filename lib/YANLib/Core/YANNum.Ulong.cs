using System.Numerics;
using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static ulong ToUlong(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt64(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToUlong();
        }
    }

    public static IEnumerable<ulong>? ToUlongs(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUlong(dfltVal));

    public static IEnumerable<ulong>? ToUlongs(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUlong(dfltVal));

    public static IEnumerable<ulong>? ToUlongs(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUlong(dfltVal));

    public static ulong GenerateRandomUlong(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? ulong.MinValue : min.ToUlong();
        var maxValue = max.IsNull() ? ulong.MaxValue : max.ToUlong();

        return minValue > maxValue ? default : (new Random().NextInt64(long.MinValue, (long)(maxValue - (minValue - (BigInteger)long.MinValue))) - long.MinValue).ToUlong() + minValue;
    }

    public static IEnumerable<ulong> GenerateRandomUlongs(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomUlong(min, max));
}
