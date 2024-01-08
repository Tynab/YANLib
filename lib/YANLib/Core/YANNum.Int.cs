using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static int ToInt(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt32(val.ToDecimal());
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToInt();
        }
    }

    public static IEnumerable<int>? ToInts(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToInt(dfltVal));

    public static IEnumerable<int>? ToInts(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToInt(dfltVal));

    public static IEnumerable<int>? ToInts(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToInt(dfltVal));

    public static int GenerateRandomInt(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? int.MinValue : min.ToInt();
        var maxValue = max.IsNull() ? int.MaxValue : max.ToInt();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue);
    }

    public static IEnumerable<int> GenerateRandomInts(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomInt(min, max));
}
