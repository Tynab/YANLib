using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static sbyte? ToSbyte(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToSByte(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToSbyte();
        }
    }

    public static IEnumerable<sbyte?>? ToSbytes(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToSbyte(dfltVal));

    public static IEnumerable<sbyte?>? ToSbytes(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToSbyte(dfltVal));

    public static IEnumerable<sbyte?>? ToSbytes(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToSbyte(dfltVal));
}
