namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a short integer using the default format.
    /// Returns the parsed <see cref="short"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="short"/> value, or 0 if the parsing fails.</returns>
    public static short ParseShort(this string str) => short.TryParse(str, out var num) ? num : (sbyte)0;

    /// <summary>
    /// Parses the string representation of a short using the default format.
    /// Returns the parsed <see cref="short"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="short"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static short ParseShort(this string str, short dfltVal) => short.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a <see cref="short"/> using the default format.
    /// Returns the parsed <see cref="short"/> value, or <see cref="short.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="short"/> value, or <see cref="short.MinValue"/> if the parsing fails.</returns>
    public static short ParseShortMin(this string str) => short.TryParse(str, out var num) ? num : short.MinValue;

    /// <summary>
    /// Parses the string representation of a short integer using the default format.
    /// Returns the parsed <see cref="short"/> value, or <see cref="short.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="short"/> value, or <see cref="short.MaxValue"/> if the parsing fails.</returns>
    public static short ParseShortMax(this string str) => short.TryParse(str, out var num) ? num : short.MaxValue;

    /// <summary>
    /// Generates a random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="short"/> value.</param>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static short RandomNumberShort(short min, short max) => (short)(min > max ? 0 : new Random().Next(min, max));

    /// <summary>
    /// Generates a random <see cref="short"/> value between <see cref="short.MinValue"/> and <see cref="short.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="short"/> value between <see cref="short.MinValue"/> and <see cref="short.MaxValue"/>.</returns>
    public static short RandomNumberShort() => RandomNumberShort(short.MinValue, short.MaxValue);

    /// <summary>
    /// Generates a random <see cref="short"/> value between <see cref="short.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A random <see cref="short"/> value between <see cref="short.MinValue"/> and the <paramref name="max"/>.</returns>
    public static short RandomNumberShort(short max) => RandomNumberShort(short.MinValue, max);
}
