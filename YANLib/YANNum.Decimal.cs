namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or 0 if the parsing fails.</returns>
    public static decimal ParseDecimal(this string str) => decimal.TryParse(str, out var num) ? num : 0;

    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static decimal ParseDecimal(this string str, decimal dfltVal) => decimal.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or <see cref="decimal.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or <see cref="decimal.MinValue"/> if the parsing fails.</returns>
    public static decimal ParseDecimalMin(this string str) => decimal.TryParse(str, out var num) ? num : decimal.MinValue;

    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or <see cref="decimal.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or <see cref="decimal.MaxValue"/> if the parsing fails.</returns>
    public static decimal ParseDecimalMax(this string str) => decimal.TryParse(str, out var num) ? num : decimal.MaxValue;

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static decimal RandomNumberDecimal(decimal min, decimal max) => min > max ? 0 : new Random().NextDecimal(min, max);

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <see cref="decimal.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <see cref="decimal.MaxValue"/>.</returns>
    public static decimal RandomNumberDecimal() => RandomNumberDecimal(decimal.MinValue, decimal.MaxValue);

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and the <paramref name="max"/>.</returns>
    public static decimal RandomNumberDecimal(decimal max) => RandomNumberDecimal(decimal.MinValue, max);
}
