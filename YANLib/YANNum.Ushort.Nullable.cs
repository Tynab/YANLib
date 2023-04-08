namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an <see cref="ushort"/> using the default format.
    /// Returns the parsed <see cref="ushort"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="ushort"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static ushort ParseUshort(this string str, ushort? dfltVal) => dfltVal.HasValue ? str.ParseUshort(dfltVal.Value) : (ushort)0;

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ushort"/> value.</param>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ushort RandomNumberUshort(ushort? min, ushort max) => min.HasValue ? RandomNumberUshort(min.Value, max) : (ushort)0;

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ushort"/> value.</param>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ushort RandomNumberUshort(ushort min, ushort? max) => max.HasValue ? RandomNumberUshort(min, max.Value) : (ushort)0;

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ushort"/> value.</param>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ushort RandomNumberUshort(ushort? min, ushort? max) => min.HasValue ? RandomNumberUshort(min.Value, max) : (ushort)0;

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <paramref name="max"/>.</returns>
    public static ushort RandomNumberUshort(ushort? max) => max.HasValue ? RandomNumberUshort(ushort.MinValue, max.Value) : (ushort)0;
}
