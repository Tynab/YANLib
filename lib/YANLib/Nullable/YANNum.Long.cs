using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static long? ToLong(this object? val, object? dfltVal = null)
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

    public static IEnumerable<long?>? ToLongs(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToLong(dfltVal));

    public static IEnumerable<long?>? ToLongs(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToLong(dfltVal));

    public static IEnumerable<long?>? ToLongs(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToLong(dfltVal));
}
