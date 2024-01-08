using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static uint? ToUint(this object? val, object? dfltVal = null)
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

    public static IEnumerable<uint?>? ToUints(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUint(dfltVal));

    public static IEnumerable<uint?>? ToUints(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUint(dfltVal));

    public static IEnumerable<uint?>? ToUints(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUint(dfltVal));
}
