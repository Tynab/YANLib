using YANLib.Core;

namespace YANLib.Ultimate.Nullable;

public static partial class YANNum
{
    public static IEnumerable<short?> ToShorts(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToShort(val, dfltVal);
        }
    }

    public static IEnumerable<short?> ToShorts(this ICollection<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToShort(val, dfltVal);
        }
    }

    public static IEnumerable<short?> ToShorts(this object?[]? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToShort(val, dfltVal);
        }
    }
}
