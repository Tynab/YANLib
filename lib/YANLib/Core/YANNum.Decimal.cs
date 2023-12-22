using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static decimal ToDecimal(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToDecimal(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToDecimal();
        }
    }

    public static IEnumerable<decimal>? ToDecimals(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDecimal(dfltVal));

    public static IEnumerable<decimal>? ToDecimals(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDecimal(dfltVal));

    public static IEnumerable<decimal>? ToDecimals(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDecimal(dfltVal));

    public static decimal GenerateRandomDecimal(object? min = null, object? max = null) => new Random().NextDecimal(min, max);

    public static IEnumerable<decimal> GenerateRandomDecimals(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDecimal(min, max));
}
