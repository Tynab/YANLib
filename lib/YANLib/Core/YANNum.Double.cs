using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static double ToDouble(this object? val, object? dfltVal = null)
    {
        try
        {
            return Convert.ToDouble(val);
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToDouble();
        }
    }

    public static IEnumerable<double>? ToDoubles(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDouble(dfltVal));

    public static IEnumerable<double>? ToDoubles(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDouble(dfltVal));

    public static IEnumerable<double>? ToDoubles(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToDouble(dfltVal));

    public static double GenerateRandomDouble(object? min = null, object? max = null) => new Random().NextDouble(min, max);

    public static IEnumerable<double> GenerateRandomDoubles(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDouble(min, max));
}
