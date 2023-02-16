namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Tries to parse the string representation of a byte. Returns the parsed <see cref="byte"/> value, or <paramref name="dfltVal"/> if the parsing fails. If <paramref name="dfltVal"/> is not specified or <see langword="null"/>, returns <see langword="null"/> instead.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to return if the parsing fails. This parameter is optional.</param>
    /// <returns>The parsed <see cref="byte"/> value, <paramref name="dfltVal"/> if the parsing succeeds, or <see langword="null"/> if <paramref name="dfltVal"/> is not specified or <see langword="null"/>.</returns>
    public static byte? ParseByte(this string str, byte? dfltVal) => byte.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="byte"/> value.</param>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random nullable <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static byte? RandomNumberByte(byte? min, byte max) => min.HasValue ? YANLib.YANNum.RandomNumberByte(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="byte"/> value.</param>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random nullable <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static byte? RandomNumberByte(byte min, byte? max) => max.HasValue ? YANLib.YANNum.RandomNumberByte(min, max.Value) : null;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and 255 is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and 255.
    /// </summary>
    /// <param name="min">The minimum <see cref="byte"/> value.</param>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static byte? RandomNumberByte(byte? min, byte? max) => min.HasValue ? YANLib.YANNum.RandomNumberByte(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <paramref name="max"/>. If <paramref name="max"/> is <see langword="null"/>, <see cref="byte.MaxValue"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A nullable <see cref="byte"/> value representing a random number between <see cref="byte.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static byte? RandomNumberByte(byte? max) => max.HasValue ? YANLib.YANNum.RandomNumberByte(byte.MinValue, max.Value) : null;
}
