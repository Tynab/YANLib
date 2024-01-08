using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANNum
{
    public static IEnumerable<float> ToNints(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToNint(dfltVal);
        }
    }

    public static IEnumerable<float> ToNints(this ICollection<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToNint(dfltVal);
        }
    }

    public static IEnumerable<float> ToNints(this object?[]? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToNint(dfltVal);
        }
    }

    public static IEnumerable<float> GenerateRandomNints(object? min = null, object? max = null, object? size = null)
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.Core.YANNum.GenerateRandomNint(min, max);
        }
    }
}
