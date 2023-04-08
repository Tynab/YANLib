namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an <see cref="ulong"/> using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static ulong ParseUlong(this string str, ulong? dfltVal) => dfltVal.HasValue ? str.ParseUlong(dfltVal.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ulong"/> value.</param>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ulong RandomNumberUlong(ulong? min, ulong max) => min.HasValue ? RandomNumberUlong(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ulong"/> value.</param>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ulong RandomNumberUlong(ulong min, ulong? max) => max.HasValue ? RandomNumberUlong(min, max.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/> or <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ulong"/> value.</param>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ulong RandomNumberUlong(ulong? min, ulong? max) => min.HasValue ? RandomNumberUlong(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <paramref name="max"/>.</returns>
    public static ulong RandomNumberUlong(ulong? max) => max.HasValue ? RandomNumberUlong(ulong.MinValue, max.Value) : 0;
}
