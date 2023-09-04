using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{

    public static long ToLong<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToInt64(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<long>? ToLong<T>(this IEnumerable<T> nums) where T : struct => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToLong());

    public static long ToLong(this string str) => long.TryParse(str, out var num) ? num : default;

    public static IEnumerable<long>? ToLong(this IEnumerable<string> strs) => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToLong());

    public static long ToLong<T>(this string str, T dfltVal) where T : struct => long.TryParse(str, out var num) ? num : dfltVal.ToLong();

    public static IEnumerable<long>? ToLong<T>(this IEnumerable<string> strs, T dfltVal) where T : struct => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToLong(dfltVal));

    public static long GenerateRandomLong<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToLong();
        var maxValue = max.ToLong();

        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue);
    }

    public static IEnumerable<long> GenerateRandomLongs<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomLong(min, max));

    public static long GenerateRandomLong() => GenerateRandomLong(long.MinValue, long.MaxValue);

    public static long GenerateRandomLong<T>(T max) where T : struct => GenerateRandomLong(long.MinValue, max);
}
