namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an unsigned integer using the specified format.
    /// Returns the parsed <see cref="uint"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="uint"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static uint? ParseUint(this string str, uint? dfltVal) => uint.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="uint"/> value.</param>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A random nullable <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static uint? RandomNumberUint(uint? min, uint max) => min.HasValue ? YANLib.YANNum.GenRandomUint(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="uint"/> value.</param>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A random nullable <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static uint? RandomNumberUint(uint min, uint? max) => max.HasValue ? YANLib.YANNum.GenRandomUint(min, max.Value) : null;

    /// <summary>
    /// Generates a random nullable <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and <see cref="uint.MaxValue"/> is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and <see cref="uint.MaxValue"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="uint"/> value.</param>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A random nullable <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static uint? RandomNumberUint(uint? min, uint? max) => min.HasValue ? YANLib.YANNum.GenRandomUint(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, the maximum value of <see cref="uint"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A nullable <see cref="uint"/> value representing a random number between <see cref="uint.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static uint? RandomNumberUint(uint? max) => max.HasValue ? YANLib.YANNum.GenRandomUint(uint.MinValue, max.Value) : null;
}
