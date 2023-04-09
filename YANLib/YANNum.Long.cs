namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a long using the default format.
    /// Returns the parsed <see cref="long"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="long"/> value, or 0 if the parsing fails.</returns>
    public static long ParseLong(this string str) => long.TryParse(str, out var num) ? num : 0;

    /// <summary>
    /// Parses the string representation of a long integer using the default format.
    /// Returns the parsed <see cref="long"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="long"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static long ParseLong(this string str, long dfltVal) => long.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a long integer using the default format.
    /// Returns the parsed <see cref="long"/> value, or <see cref="long.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="long"/> value, or <see cref="long.MinValue"/> if the parsing fails.</returns>
    public static long ParseLongMin(this string str) => long.TryParse(str, out var num) ? num : long.MinValue;

    /// <summary>
    /// Parses the string representation of a long using the default format.
    /// Returns the parsed <see cref="long"/> value, or <see cref="long.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="long"/> value, or <see cref="long.MaxValue"/> if the parsing fails.</returns>
    public static long ParseLongMax(this string str) => long.TryParse(str, out var num) ? num : long.MaxValue;

    /// <summary>
    /// Generates a random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="long"/> value.</param>
    /// <param name="max">The maximum <see cref="long"/> value.</param>
    /// <returns>A random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static long RandomNumberLong(long min, long max) => min > max ? 0 : new Random().NextInt64(min, max);

    /// <summary>
    /// Generates a random <see cref="long"/> value between <see cref="long.MinValue"/> and <see cref="long.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="long"/> value between <see cref="long.MinValue"/> and <see cref="long.MaxValue"/>.</returns>
    public static long RandomNumberLong() => RandomNumberLong(long.MinValue, long.MaxValue);

    /// <summary>
    /// Generates a random <see cref="long"/> value between <see cref="long.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="long"/> value.</param>
    /// <returns>A random <see cref="long"/> value between <see cref="long.MinValue"/> and the <paramref name="max"/>.</returns>
    public static long RandomNumberLong(long max) => RandomNumberLong(long.MinValue, max);
}
