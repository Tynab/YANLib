using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static nint ToNint(this object? val, object? dfltVal = null)
    {
        try
        {
            return new IntPtr(Convert.ToInt64(val));
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToNint();
        }
    }

    public static IEnumerable<nint>? ToNints(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNint(dfltVal));

    public static IEnumerable<nint>? ToNints(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNint(dfltVal));

    public static IEnumerable<nint>? ToNints(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNint(dfltVal));

    public static nint GenerateRandomNint(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? nint.MinValue : min.ToNint();
        var maxValue = max.IsNull() ? nint.MaxValue : max.ToNint();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToNint();
    }

    public static IEnumerable<nint> GenerateRandomNints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomNint(min, max));
}
