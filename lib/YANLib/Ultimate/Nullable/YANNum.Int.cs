using YANLib.Core;

namespace YANLib.Ultimate.Nullable;

public static partial class YANNum
{
    public static IEnumerable<int?> ToInts(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToInt(val, dfltVal);
        }
    }

    public static IEnumerable<int?> ToInts(this ICollection<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToInt(val, dfltVal);
        }
    }

    public static IEnumerable<int?> ToInts(this object?[]? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToInt(val, dfltVal);
        }
    }
}
