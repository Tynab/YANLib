using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static float ToFloat(this object? val, object? dfltVal = null)
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

    public static IEnumerable<float>? ToFloats(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToFloat(dfltVal));

    public static IEnumerable<float>? ToFloats(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToFloat(dfltVal));

    public static IEnumerable<float>? ToFloats(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToFloat(dfltVal));

    public static float GenerateRandomFloat(object? min = null, object? max = null) => new Random().NextSingle(min, max);

    public static IEnumerable<float> GenerateRandomFloats(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomFloat(min, max));
}
