namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="double"/> value, or 0 if the parsing fails.</returns>
    public static double ParseDouble(this string str) => double.TryParse(str, out var num) ? num : 0;

    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or the specified default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="double"/> value, or the specified default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static double ParseDouble(this string str, double dfltVal) => double.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or <see cref="double.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="double"/> value, or <see cref="double.MinValue"/> if the parsing fails.</returns>
    public static double ParseDoubleMin(this string str) => double.TryParse(str, out var num) ? num : double.MinValue;

    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or <see cref="double.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="double"/> value, or <see cref="double.MaxValue"/> if the parsing fails.</returns>
    public static double ParseDoubleMax(this string str) => double.TryParse(str, out var num) ? num : double.MaxValue;

    /// <summary>
    /// Generates a random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="double"/> value.</param>
    /// <param name="max">The maximum <see cref="double"/> value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static double RandomNumberDouble(double min, double max) => min > max ? 0 : new Random().NextDouble(min, max);

    /// <summary>
    /// Generates a random <see cref="double"/> value between <see cref="double.MinValue"/> and <see cref="double.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="double"/> value between <see cref="double.MinValue"/> and <see cref="double.MaxValue"/>.</returns>
    public static double RandomNumberDouble() => RandomNumberDouble(double.MinValue, double.MaxValue);

    /// <summary>
    /// Generates a random <see cref="double"/> value between <see cref="double.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="double"/> value.</param>
    /// <returns>A random <see cref="double"/> value between <see cref="double.MinValue"/> and the <paramref name="max"/>.</returns>
    public static double RandomNumberDouble(double max) => RandomNumberDouble(double.MinValue, max);
}
