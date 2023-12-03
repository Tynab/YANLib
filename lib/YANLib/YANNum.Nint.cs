using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static nint ToNint(this object? num, object? dfltVal = null)
    {
        try
        {
            return new IntPtr(Convert.ToInt64(num));
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToNint();
        }
    }

    public static IEnumerable<nint>? ToNint(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToNint(dfltVal));

    public static nint GenerateRandomNint(object? min = null, object? max = null)
    {
        var minValue = min is null ? nint.MinValue : min.ToNint();
        var maxValue = max is null ? nint.MaxValue : max.ToNint();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToNint();
    }

    public static IEnumerable<nint> GenerateRandomNints(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomNint(min, max));
}
