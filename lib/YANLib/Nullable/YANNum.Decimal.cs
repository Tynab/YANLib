using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static decimal? ToDecimal(this object? val, object? dfltVal = null)
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

    public static IEnumerable<decimal?>? ToDecimals(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDecimal(dfltVal));

    public static IEnumerable<decimal?>? ToDecimals(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDecimal(dfltVal));

    public static IEnumerable<decimal?>? ToDecimals(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDecimal(dfltVal));
}
