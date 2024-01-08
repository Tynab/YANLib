using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANNum
{
    public static IEnumerable<double> ToDoubles(this IEnumerable<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToDouble(dfltVal);
        }
    }

    public static IEnumerable<double> ToDoubles(this ICollection<object?>? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToDouble(dfltVal);
        }
    }

    public static IEnumerable<double> ToDoubles(this object?[]? vals, object? dfltVal = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToDouble(dfltVal);
        }
    }

    public static IEnumerable<double> GenerateRandomDoubles(object? min = null, object? max = null, object? size = null)
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return YANLib.Core.YANNum.GenerateRandomDouble(min, max);
        }
    }
}
