using YANLib.Core;

namespace YANLib.Nullable;

public static partial class YANNum
{
    public static float? ToFloat(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToSingle(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToFloat();
        }
    }

    public static IEnumerable<float?>? ToFloats<T>(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToFloat(dfltVal));

    public static IEnumerable<float?>? ToFloats<T>(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToFloat(dfltVal));

    public static IEnumerable<float?>? ToFloats<T>(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToFloat(dfltVal));
}
