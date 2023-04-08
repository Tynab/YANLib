namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a byte using the default format.
    /// Returns the parsed <see cref="byte"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="byte"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static byte ParseByte(this string str, byte? dfltVal) => dfltVal.HasValue ? str.ParseByte(dfltVal.Value) : (byte)0;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="byte"/> value.</param>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static byte RandomNumberByte(byte? min, byte max) => min.HasValue ? RandomNumberByte(min.Value, max) : (byte)0;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="byte"/> value.</param>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static byte RandomNumberByte(byte min, byte? max) => max.HasValue ? RandomNumberByte(min, max.Value) : (byte)0;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="byte"/> value.</param>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static byte RandomNumberByte(byte? min, byte? max) => min.HasValue ? RandomNumberByte(min.Value, max) : (byte)0;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <paramref name="max"/>.</returns>
    public static byte RandomNumberByte(byte? max) => max.HasValue ? RandomNumberByte(byte.MinValue, max.Value) : (byte)0;
}
