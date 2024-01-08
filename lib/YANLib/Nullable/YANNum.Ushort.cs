using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static ushort? ToUshort(this object? val, object? dfltVal = null)
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

    public static IEnumerable<ushort?>? ToUshorts(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUshort(dfltVal));

    public static IEnumerable<ushort?>? ToUshorts(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUshort(dfltVal));

    public static IEnumerable<ushort?>? ToUshorts(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToUshort(dfltVal));
}
