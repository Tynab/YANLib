using YANLib.Core;

namespace YANLib.Ultimate.Nullable;

public static partial class YANNum
{
    public static IEnumerable<decimal?> ToDecimals(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToDecimal(val, dfltVal);
        }
    }

    public static IEnumerable<decimal?> ToDecimals(this ICollection<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToDecimal(val, dfltVal);
        }
    }

    public static IEnumerable<decimal?> ToDecimals(this object?[]? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToDecimal(val, dfltVal);
        }
    }
}
