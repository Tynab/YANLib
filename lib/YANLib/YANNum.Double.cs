using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static double ToDouble(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToDouble(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToDouble();
        }
    }

    public static IEnumerable<double>? ToDouble(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToDouble(dfltVal));

    public static double GenerateRandomDouble(object? min = null, object? max = null) => new Random().NextDouble(min, max);

    public static IEnumerable<double> GenerateRandomDoubles(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDouble(min, max));
}
