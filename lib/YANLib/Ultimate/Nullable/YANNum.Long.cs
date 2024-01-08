using YANLib.Core;

namespace YANLib.Ultimate.Nullable;

public static partial class YANNum
{
    public static IEnumerable<long?> ToLongs(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToLong(val, dfltVal);
        }
    }

    public static IEnumerable<long?> ToLongs(this ICollection<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToLong(val, dfltVal);
        }
    }

    public static IEnumerable<long?> ToLongs(this object?[]? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToLong(val, dfltVal);
        }
    }
}
