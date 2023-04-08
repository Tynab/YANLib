namespace YANLib;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a long integer using the default format.
    /// Returns the parsed <see cref="long"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="long"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static long ParseLong(this string str, long? dfltVal) => dfltVal.HasValue ? str.ParseLong(dfltVal.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="long"/> value.</param>
    /// <param name="max">The maximum <see cref="long"/> value.</param>
    /// <returns>A random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static long RandomNumberLong(long? min, long max) => min.HasValue ? RandomNumberLong(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="long"/> value.</param>
    /// <param name="max">The maximum <see cref="long"/> value.</param>
    /// <returns>A random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static long RandomNumberLong(long min, long? max) => max.HasValue ? RandomNumberLong(min, max.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="long"/> value.</param>
    /// <param name="max">The maximum <see cref="long"/> value.</param>
    /// <returns>A random <see cref="long"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static long RandomNumberLong(long? min, long? max) => min.HasValue ? RandomNumberLong(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="long"/> value between <see cref="long.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="long"/> value.</param>
    /// <returns>A random <see cref="long"/> value between <see cref="long.MinValue"/> and <paramref name="max"/>.</returns>
    public static long RandomNumberLong(long? max) => max.HasValue ? RandomNumberLong(long.MinValue, max.Value) : 0;
}
