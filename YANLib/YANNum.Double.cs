namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="double"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static double ToDouble(this string str) => double.TryParse(str, out var num) ? num : default;

    public static double ToDouble<T>(this string str, T dfltVal) where T : struct => double.TryParse(str, out var num) ? num : dfltVal.ToDouble();

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

    public static double GenRandomDouble<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDouble();
        var maxValue = max.ToDouble();
        return minValue > maxValue ? default : new Random().NextDouble(minValue, maxValue);
    }

    public static double GenRandomDouble() => GenRandomDouble(double.MinValue, double.MaxValue);

    public static double GenRandomDouble<T>(T max) where T : struct => GenRandomDouble(double.MinValue, max);
}
