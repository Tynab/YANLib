namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Tries to parse the string representation of a decimal. Returns the parsed <see cref="decimal"/> value, or <paramref name="dfltVal"/> if the parsing fails. If <paramref name="dfltVal"/> is not specified or <see langword="null"/>, returns <see langword="null"/> instead.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to return if the parsing fails. This parameter is optional.</param>
    /// <returns>The parsed <see cref="decimal"/> value, <paramref name="dfltVal"/> if the parsing succeeds, or <see langword="null"/> if <paramref name="dfltVal"/> is not specified or <see langword="null"/>.</returns>
    public static decimal? ParseDecimal(this string str, decimal? dfltVal) => decimal.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random nullable <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static decimal? RandomNumberDecimal(decimal? min, decimal max) => min.HasValue ? YANLib.YANNum.RandomNumberDecimal(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random nullable <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static decimal? RandomNumberDecimal(decimal min, decimal? max) => max.HasValue ? YANLib.YANNum.RandomNumberDecimal(min, max.Value) : null;

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and 1 is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and 1.
    /// </summary>
    /// <param name="min">The minimum <see cref="decimal"/> value.</param>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static decimal? RandomNumberDecimal(decimal? min, decimal? max) => min.HasValue ? YANLib.YANNum.RandomNumberDecimal(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>. If <paramref name="max"/> is <see langword="null"/>, <see cref="decimal.MaxValue"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="decimal"/> value.</param>
    /// <returns>A nullable <see cref="decimal"/> value representing a random number between <see cref="decimal.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static decimal? RandomNumberDecimal(decimal? max) => max.HasValue ? YANLib.YANNum.RandomNumberDecimal(decimal.MinValue, max.Value) : null;
}
