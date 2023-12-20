using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{
    public static decimal ToDecimal(this object? num, object? dfltVal = null)
    {
        try
        {
            return Convert.ToDecimal(num);
        }
        catch
        {
            return dfltVal is null ? default : dfltVal.ToDecimal();
        }
    }

    public static IEnumerable<decimal>? ToDecimal(this IEnumerable<object?> nums, object? dfltVal = null) => nums.IsEmptyOrNull() ? default : nums.Select(x => x.ToDecimal(dfltVal));

    public static decimal GenerateRandomDecimal(object? min = null, object? max = null) => new Random().NextDecimal(min, max);

    public static IEnumerable<decimal> GenerateRandomDecimals(object? min = null, object? max = null, object? size = null) => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDecimal(min, max));
}
