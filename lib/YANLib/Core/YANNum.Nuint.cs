using System.Numerics;
using static System.Linq.Enumerable;

namespace YANLib.Core;

public static partial class YANNum
{
    public static nuint ToNuint(this object? val, object? dfltVal = null)
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(val));
        }
        catch
        {
            return dfltVal.IsNull() ? default : dfltVal.ToNuint();
        }
    }

    public static IEnumerable<nuint>? ToNuints(this IEnumerable<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNuint(dfltVal));

    public static IEnumerable<nuint>? ToNuints(this ICollection<object?>? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNuint(dfltVal));

    public static IEnumerable<nuint>? ToNuints(this object?[]? vals, object? dfltVal = null) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToNuint(dfltVal));

    public static nuint GenerateRandomNuint(object? min = null, object? max = null)
    {
        var minValue = min.IsNull() ? nuint.MinValue : min.ToNuint();
        var maxValue = max.IsNull() ? nuint.MaxValue : max.ToNuint();

        return minValue > maxValue ? default : (new Random().NextInt64(nint.MinValue, (long)(maxValue - (minValue - (BigInteger)nint.MinValue))) - nint.MinValue).ToNuint() + minValue;
    }

    public static IEnumerable<nuint> GenerateRandomNuints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomNuint(min, max));
}
