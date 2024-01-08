using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static nuint? ToNuint(this object? val, object? dfltVal = null)
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(val));
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToNuint();
        }
    }

    public static IEnumerable<nuint?>? ToNuints(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNuint(dfltVal));

    public static IEnumerable<nuint?>? ToNuints(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNuint(dfltVal));

    public static IEnumerable<nuint?>? ToNuints(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNuint(dfltVal));
}
