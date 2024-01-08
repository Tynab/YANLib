using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static int? ToInt(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt32(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToInt();
        }
    }

    public static IEnumerable<int?>? ToInts(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToInt(dfltVal));

    public static IEnumerable<int?>? ToInts(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToInt(dfltVal));

    public static IEnumerable<int?>? ToInts(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToInt(dfltVal));
}
