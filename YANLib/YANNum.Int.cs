namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an integer using the default format.
    /// Returns the parsed <see cref="int"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="int"/> value, or 0 if the parsing fails.</returns>
    public static int ParseInt(this string str) => int.TryParse(str, out var num) ? num : 0;

    /// <summary>
    /// Parses the string representation of an integer using the default format.
    /// Returns the parsed <see cref="int"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="int"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static int ParseInt(this string str, int dfltVal) => int.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of an integer using the default format.
    /// Returns the parsed <see cref="int"/> value, or <see cref="int.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="int"/> value, or <see cref="int.MinValue"/> if the parsing fails.</returns>
    public static int ParseIntMin(this string str) => int.TryParse(str, out var num) ? num : int.MinValue;

    /// <summary>
    /// Parses the string representation of an integer using the default format.
    /// Returns the parsed <see cref="int"/> value, or <see cref="int.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="int"/> value, or <see cref="int.MaxValue"/> if the parsing fails.</returns>
    public static int ParseIntMax(this string str) => int.TryParse(str, out var num) ? num : int.MaxValue;

    /// <summary>
    /// Generates a random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="int"/> value.</param>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static int RandomNumberInt(int min, int max) => min > max ? 0 : new Random().Next(min, max);

    /// <summary>
    /// Generates a random <see cref="int"/> value between <see cref="int.MinValue"/> and <see cref="int.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="int"/> value between <see cref="int.MinValue"/> and <see cref="int.MaxValue"/>.</returns>
    public static int RandomNumberInt() => RandomNumberInt(int.MinValue, int.MaxValue);

    /// <summary>
    /// Generates a random <see cref="int"/> value between <see cref="int.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A random <see cref="int"/> value between <see cref="int.MinValue"/> and the <paramref name="max"/>.</returns>
    public static int RandomNumberInt(int max) => RandomNumberInt(int.MinValue, max);
}
