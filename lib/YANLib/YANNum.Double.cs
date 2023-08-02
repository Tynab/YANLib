using static System.Linq.Enumerable;

namespace YANLib;

public static partial class YANNum
{

    public static double ToDouble<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToDouble(num);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<double>? ToDouble<T>(this IEnumerable<T> nums) where T : struct => nums.IsEmptyOrNull() ? default : nums.Select(n => n.ToDouble());

    public static double ToDouble(this string str) => double.TryParse(str, out var num) ? num : default;

    public static IEnumerable<double>? ToDouble(this IEnumerable<string> strs) => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToDouble());

    public static double ToDouble<T>(this string str, T dfltVal) where T : struct => double.TryParse(str, out var num) ? num : dfltVal.ToDouble();

    public static IEnumerable<double>? ToDouble<T>(this IEnumerable<string> strs, T dfltVal) where T : struct => strs.IsEmptyOrNull() ? default : strs.Select(s => s.ToDouble(dfltVal));

    public static double GenerateRandomDouble<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDouble();
        var maxValue = max.ToDouble();

        return minValue > maxValue ? default : new Random().NextDouble(minValue, maxValue);
    }

    public static IEnumerable<double> GenerateRandomDoubles<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct => Range(0, size.ToUint().ToInt()).Select(i => GenerateRandomDouble(min, max));

    public static double GenerateRandomDouble() => GenerateRandomDouble(double.MinValue, double.MaxValue);

    public static double GenerateRandomDouble<T>(T max) where T : struct => GenerateRandomDouble(double.MinValue, max);
}
