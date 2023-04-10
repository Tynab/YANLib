namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an unsigned long integer using the specified format and culture.
    /// Returns the parsed <see cref="ulong"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static ulong? ToUlong(this string str, ulong? dfltVal) => ulong.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ulong"/> value.</param>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A random nullable <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static ulong? GenRandomUlong(ulong? min, ulong max) => min.HasValue ? YANLib.YANNum.GenRandomUlong(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ulong"/> value.</param>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A random nullable <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static ulong? GenRandomUlong(ulong min, ulong? max) => max.HasValue ? YANLib.YANNum.GenRandomUlong(min, max.Value) : null;

    /// <summary>
    /// Generates a random nullable <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and <see cref="ulong.MaxValue"/> is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and <see cref="ulong.MaxValue"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="ulong"/> value.</param>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A random nullable <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ulong? GenRandomUlong(ulong? min, ulong? max) => min.HasValue ? YANLib.YANNum.GenRandomUlong(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, the maximum value of <see cref="ulong"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A nullable <see cref="ulong"/> value representing a random number between <see cref="ulong.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static ulong? GenRandomUlong(ulong? max) => max.HasValue ? YANLib.YANNum.GenRandomUlong(ulong.MinValue, max.Value) : null;
}
