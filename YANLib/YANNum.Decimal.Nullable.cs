namespace YANLib;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static decimal ParseDecimal(this string str, decimal? dfltVal) => dfltVal.HasValue ? str.ParseDecimal(dfltVal.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static decimal RandomNumberDecimal(decimal? min, decimal max) => min.HasValue ? RandomNumberDecimal(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static decimal RandomNumberDecimal(decimal min, decimal? max) => max.HasValue ? RandomNumberDecimal(min, max.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static decimal RandomNumberDecimal(decimal? min, decimal? max) => min.HasValue ? RandomNumberDecimal(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.</returns>
    public static decimal RandomNumberDecimal(decimal? max) => max.HasValue ? RandomNumberDecimal(decimal.MinValue, max.Value) : 0;
}
