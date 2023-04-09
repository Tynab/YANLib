namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a long using the default format.
    /// Returns the parsed <see cref="long"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="long"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static long ToLong(this string str) => long.TryParse(str, out var num) ? num : default;

    public static long ToLong<T>(this string str, T dfltVal) where T : struct => long.TryParse(str, out var num) ? num : dfltVal.ToLong();

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

    public static long GenRandomLong<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToLong();
        var maxValue = max.ToLong();
        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue);
    }

    public static long GenRandomLong() => GenRandomLong(long.MinValue, long.MaxValue);

    public static long GenRandomLong<T>(T max) where T : struct => GenRandomLong(long.MinValue, max);
}
