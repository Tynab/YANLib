using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static nint? ToNint(this object? val, object? dfltVal = null)
    {
        try
        {
            return new IntPtr(Convert.ToInt64(val));
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToNint();
        }
    }

    public static IEnumerable<nint?>? ToNints(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNint(dfltVal));

    public static IEnumerable<nint?>? ToNints(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNint(dfltVal));

    public static IEnumerable<nint?>? ToNints(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNint(dfltVal));
}
