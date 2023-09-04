using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{

    public static int ToInt<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToInt32(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<int>? ToInt<T>(this IEnumerable<T> nums) where T : struct => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToInt());

    public static int ToInt(this string str) => int.TryParse(str, out var num) ? num : default;

    public static IEnumerable<int>? ToInt(this IEnumerable<string> strs) => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToInt());

    public static int ToInt<T>(this string str, T dfltVal) where T : struct => int.TryParse(str, out var num) ? num : dfltVal.ToInt();

    public static IEnumerable<int>? ToInt<T>(this IEnumerable<string> strs, T dfltVal) where T : struct => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToInt(dfltVal));

    public static int GenerateRandomInt<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToInt();
        var maxValue = max.ToInt();

        return minValue > maxValue ? default : new Random().Next(minValue, maxValue);
    }

    public static IEnumerable<int> GenerateRandomInts<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomInt(min, max));

    public static int GenerateRandomInt() => GenerateRandomInt(int.MinValue, int.MaxValue);

    public static int GenerateRandomInt<T>(T max) where T : struct => GenerateRandomInt(int.MinValue, max);
}
