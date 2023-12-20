using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static float ToFloat(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToSingle(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToFloat();
        }
    }

    public static IEnumerable<float>? ToFloat<T>(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToFloat(dfltVal));

    public static float GenerateRandomFloat(object? min = null, object? max = null) => new Random().NextSingle(min, max);

    public static IEnumerable<float> GenerateRandomFloats(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomFloat(min, max));
}
