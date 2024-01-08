using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static short? ToShort(this object? val, object? dfltVal = null)
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

    public static IEnumerable<short?>? ToShorts(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToShort(dfltVal));

    public static IEnumerable<short?>? ToShorts(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToShort(dfltVal));

    public static IEnumerable<short?>? ToShorts(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToShort(dfltVal));
}
