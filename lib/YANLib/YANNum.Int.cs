using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static int ToInt(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToInt32(num.ToDecimal());
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToInt();
        }
    }

    public static IEnumerable<int>? ToInt(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToInt(dfltVal));

    public static int GenerateRandomInt(object? min = null, object? max = null)
    {
        var minValue = min is null ? int.MinValue : min.ToInt();
        var maxValue = max is null ? int.MaxValue : max.ToInt();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue);
    }

    public static IEnumerable<int> GenerateRandomInts(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomInt(min, max));
}
