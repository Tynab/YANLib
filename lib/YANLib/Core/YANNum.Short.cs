using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static short ToShort(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt16(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToShort();
        }
    }

    public static IEnumerable<short>? ToShorts(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToShort(dfltVal));

    public static IEnumerable<short>? ToShorts(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToShort(dfltVal));

    public static IEnumerable<short>? ToShorts(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToShort(dfltVal));

    public static short GenerateRandomShort(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? short.MinValue : min.ToShort();
        var maxValue = max.IsNull() ? short.MaxValue : max.ToShort();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToShort();
    }

    public static IEnumerable<short> GenerateRandomShorts(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomShort(min, max));
}
