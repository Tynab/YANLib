using System.Numerics;
using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static nuint ToNuint(this object? num, object? dfltVal = null)
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(num));
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToNuint();
        }
    }

    public static IEnumerable<nuint>? ToNuint(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToNuint(dfltVal));

    public static nuint GenerateRandomNuint(object? min = null, object? max = null)
    {
        var minValue = min is null ? nuint.MinValue : min.ToNuint();
        var maxValue = max is null ? nuint.MaxValue : max.ToNuint();

        return minValue > maxValue ? default : (new Random().NextInt64(nint.MinValue, (long)(maxValue - (minValue - (BigInteger)nint.MinValue))) - nint.MinValue).ToNuint() + minValue;
    }

    public static IEnumerable<nuint> GenerateRandomNuints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomNuint(min, max));
}
