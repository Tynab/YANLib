using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static uint ToUint(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt32(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToUint();
        }
    }

    public static IEnumerable<uint>? ToUints(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUint(dfltVal));

    public static IEnumerable<uint>? ToUints(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUint(dfltVal));

    public static IEnumerable<uint>? ToUints(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUint(dfltVal));

    public static uint GenerateRandomUint(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? uint.MinValue : min.ToUint();
        var maxValue = max.IsNull() ? uint.MaxValue : max.ToUint();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToUint();
    }

    public static IEnumerable<uint> GenerateRandomUints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomUint(min, max));
}
