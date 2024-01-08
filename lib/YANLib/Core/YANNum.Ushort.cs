using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static ushort ToUshort(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt16(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToUshort();
        }
    }

    public static IEnumerable<ushort>? ToUshorts(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUshort(dfltVal));

    public static IEnumerable<ushort>? ToUshorts(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUshort(dfltVal));

    public static IEnumerable<ushort>? ToUshorts(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUshort(dfltVal));

    public static ushort GenerateRandomUshort(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? ushort.MinValue : min.ToUshort();
        var maxValue = max.IsNull() ? ushort.MaxValue : max.ToUshort();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToUshort();
    }

    public static IEnumerable<ushort> GenerateRandomUshorts(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomUshort(min, max));
}
