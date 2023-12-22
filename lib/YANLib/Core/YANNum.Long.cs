using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static long ToLong(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt64(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToLong();
        }
    }

    public static IEnumerable<long>? ToLongs(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToLong(dfltVal));

    public static IEnumerable<long>? ToLongs(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToLong(dfltVal));

    public static IEnumerable<long>? ToLongs(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToLong(dfltVal));

    public static long GenerateRandomLong(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? long.MinValue : min.ToLong();
        var maxValue = max.IsNull() ? long.MaxValue : max.ToLong();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue);
    }

    public static IEnumerable<long> GenerateRandomLongs(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomLong(min, max));
}
