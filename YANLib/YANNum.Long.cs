namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to long, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Long number.</returns>
    public static long ParseLong(this string str)
    {
        _ = long.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to long, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Long number.</returns>
    public static long ParseLong(this string str, long dfltVal) => long.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to long, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Long number.</returns>
    public static long ParseLongMin(this string str) => long.TryParse(str, out var num) ? num : long.MinValue;

    /// <summary>
    /// Try parse string to long, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Long number.</returns>
    public static long ParseLongMax(this string str) => long.TryParse(str, out var num) ? num : long.MaxValue;

    /// <summary>
    /// Generate random long number.
    /// </summary>
    /// <returns>Long random number.</returns>
    public static long RandomNumberLong() => new Random().NextInt64();

    /// <summary>
    /// Generate random long number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0. If not, the inclusive lower bound of the random number flexible to <see cref="long.MinValue"/>.</param>
    /// <returns>Long random number.</returns>
    public static long RandomNumberLong(long max) => max < 0 ? new Random().NextInt64(long.MinValue, max) : new Random().NextInt64(0, max);

    /// <summary>
    /// Generate random long number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Long random number.</returns>
    public static long RandomNumberLong(long min, long max) => min > max ? 0 : new Random().NextInt64(min, max);
}
