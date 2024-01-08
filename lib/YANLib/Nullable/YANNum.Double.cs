using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static double? ToDouble(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToDouble(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToDouble();
        }
    }

    public static IEnumerable<double?>? ToDoubles(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDouble(dfltVal));

    public static IEnumerable<double?>? ToDoubles(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDouble(dfltVal));

    public static IEnumerable<double?>? ToDoubles(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDouble(dfltVal));
}
