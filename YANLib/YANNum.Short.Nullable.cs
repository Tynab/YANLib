namespace YANLib;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a short integer using the default format.
    /// Returns the parsed <see cref="short"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="short"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static short ParseShort(this string str, short? dfltVal) => dfltVal.HasValue ? str.ParseShort(dfltVal.Value) : (short)0;

    /// <summary>
    /// Generates a random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="short"/> value.</param>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static short RandomNumberShort(short? min, short max) => min.HasValue ? RandomNumberShort(min.Value, max) : (short)0;

    /// <summary>
    /// Generates a random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="short"/> value.</param>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static short RandomNumberShort(short min, short? max) => max.HasValue ? RandomNumberShort(min, max.Value) : (short)0;

    /// <summary>
    /// Generates a random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="short"/> value.</param>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A random <see cref="short"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static short RandomNumberShort(short? min, short? max) => min.HasValue ? RandomNumberShort(min.Value, max) : (short)0;

    /// <summary>
    /// Generates a random <see cref="short"/> value between <see cref="short.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="short"/> value.</param>
    /// <returns>A random <see cref="short"/> value between <see cref="short.MinValue"/> and <paramref name="max"/>.</returns>
    public static short RandomNumberShort(short? max) => max.HasValue ? RandomNumberShort(short.MinValue, max.Value) : (short)0;
}
