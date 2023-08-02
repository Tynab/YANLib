using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{

    public static decimal ToDecimal<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToDecimal(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<decimal>? ToDecimal<T>(this IEnumerable<T?> nums) where T : struct => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToDecimal());

    public static decimal ToDecimal<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToDecimal(dfltVal.Value) : default;

    public static IEnumerable<decimal>? ToDecimal<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToDecimal(dfltVal));

    public static decimal GenerateRandomDecimal<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomDecimal(min.Value, max) : default;

    public static IEnumerable<decimal> GenerateRandomDecimals<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDecimal(min, max));

    public static IEnumerable<decimal> GenerateRandomDecimals<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDecimal(min, max));

    public static decimal GenerateRandomDecimal<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomDecimal(min, max.Value) : default;

    public static IEnumerable<decimal> GenerateRandomDecimals<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDecimal(min, max));

    public static IEnumerable<decimal> GenerateRandomDecimals<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDecimal(min, max));

    public static decimal GenerateRandomDecimal<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomDecimal(min.Value, max) : default;

    public static IEnumerable<decimal> GenerateRandomDecimals<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDecimal(min, max));

    public static IEnumerable<decimal> GenerateRandomDecimals<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDecimal(min, max));

    public static decimal GenerateRandomDecimal<T>(T? max) where T : struct => max.HasValue ? GenerateRandomDecimal(decimal.MinValue, max.Value) : default;
}
