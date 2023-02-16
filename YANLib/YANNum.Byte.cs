namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a byte using the default format. Returns the parsed <see cref="byte"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="byte"/> value, or 0 if the parsing fails.</returns>
    public static byte ParseByte(this string str) => byte.TryParse(str, out var num) ? num : (byte)0;

    /// <summary>
    /// Parses the string representation of a byte using the default format. Returns the parsed <see cref="byte"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="byte"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static byte ParseByte(this string str, byte dfltVal) => byte.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a byte using the default format. Returns the parsed <see cref="byte"/> value, or <see cref="byte.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="byte"/> value, or <see cref="byte.MinValue"/> if the parsing fails.</returns>
    public static byte ParseByteMin(this string str) => byte.TryParse(str, out var num) ? num : byte.MinValue;

    /// <summary>
    /// Parses the string representation of a byte using the default format. Returns the parsed <see cref="byte"/> value, or <see cref="byte.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="byte"/> value, or <see cref="byte.MaxValue"/> if the parsing fails.</returns>
    public static byte ParseByteMax(this string str) => byte.TryParse(str, out var num) ? num : byte.MaxValue;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="byte"/> value.</param>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static byte RandomNumberByte(byte min, byte max) => (byte)(min > max ? 0 : new Random().Next(min, max));

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <see cref="byte.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <see cref="byte.MaxValue"/>.</returns>
    public static byte RandomNumberByte() => RandomNumberByte(byte.MinValue, byte.MaxValue);

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random <see cref="byte"/> value between <see cref="byte.MinValue"/> and the <paramref name="max"/>.</returns>
    public static byte RandomNumberByte(byte max) => RandomNumberByte(byte.MinValue, max);
}
