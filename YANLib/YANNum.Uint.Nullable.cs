namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a <see cref="uint"/> using the default format.
    /// Returns the parsed <see cref="uint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="uint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static uint ParseUint(this string str, uint? dfltVal) => dfltVal.HasValue ? str.ParseUint(dfltVal.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="uint"/> value.</param>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static uint RandomNumberUint(uint? min, uint max) => min.HasValue ? RandomNumberUint(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="uint"/> value.</param>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static uint RandomNumberUint(uint min, uint? max) => max.HasValue ? RandomNumberUint(min, max.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="uint"/> value.</param>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static uint RandomNumberUint(uint? min, uint? max) => min.HasValue ? RandomNumberUint(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <paramref name="max"/>.</returns>
    public static uint RandomNumberUint(uint? max) => max.HasValue ? RandomNumberUint(uint.MinValue, max.Value) : 0;
}
