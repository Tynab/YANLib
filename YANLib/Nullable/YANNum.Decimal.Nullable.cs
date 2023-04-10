namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a decimal number using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static decimal? ToDecimal(this string str, decimal? dfltVal) => decimal.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random nullable <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static decimal? GenRandomDecimal(decimal? min, decimal max) => min.HasValue ? YANLib.YANNum.GenRandomDecimal(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random nullable <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static decimal? GenRandomDecimal(decimal min, decimal? max) => max.HasValue ? YANLib.YANNum.GenRandomDecimal(min, max.Value) : null;

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and 1 is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and 1.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static decimal? GenRandomDecimal(decimal? min, decimal? max) => min.HasValue ? YANLib.YANNum.GenRandomDecimal(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see cref="decimal.MaxValue"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A nullable <see cref="decimal"/> value representing a random number between <see cref="decimal.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static decimal? GenRandomDecimal(decimal? max) => max.HasValue ? YANLib.YANNum.GenRandomDecimal(decimal.MinValue, max.Value) : null;
}
