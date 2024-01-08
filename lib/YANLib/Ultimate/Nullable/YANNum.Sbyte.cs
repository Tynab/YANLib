using YANLib.Core;

namespace YANLib.Ultimate.Nullable;

public static partial class YANNum
{
    public static IEnumerable<sbyte?> ToSbytes(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToSbyte(val, dfltVal);
        }
    }

    public static IEnumerable<sbyte?> ToSbytes(this ICollection<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToSbyte(val, dfltVal);
        }
    }

    public static IEnumerable<sbyte?> ToSbytes(this object?[]? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return YANLib.Nullable.YANNum.ToSbyte(val, dfltVal);
        }
    }
}
