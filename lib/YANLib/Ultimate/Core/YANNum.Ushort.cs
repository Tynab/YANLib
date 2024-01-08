using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANNum
{
    public static IEnumerable<float> ToUshorts(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToUshort(dfltVal);
        }
    }

    public static IEnumerable<float> ToUshorts(this ICollection<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToUshort(dfltVal);
        }
    }

    public static IEnumerable<float> ToUshorts(this object?[]? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToUshort(dfltVal);
        }
    }

    public static IEnumerable<float> GenerateRandomUshorts(object? min = null, object? max = null, object? size = null)
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.Core.YANNum.GenerateRandomUshort(min, max);
        }
    }
}
