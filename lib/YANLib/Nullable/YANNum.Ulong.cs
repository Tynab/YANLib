using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static ulong? ToUlong(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToUInt64(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToUlong();
        }
    }

    public static IEnumerable<ulong?>? ToUlongs(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUlong(dfltVal));

    public static IEnumerable<ulong?>? ToUlongs(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUlong(dfltVal));

    public static IEnumerable<ulong?>? ToUlongs(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUlong(dfltVal));
}
