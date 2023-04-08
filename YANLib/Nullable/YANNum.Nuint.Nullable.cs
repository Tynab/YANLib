namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a <see cref="nuint"/> using the specified format.
    /// Returns the parsed <see cref="nuint"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static nuint? ParseNuint(this string str, nuint? dfltVal) => nuint.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="nuint"/> value.</param>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A random nullable <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static nuint? RandomNumberNuint(nuint? min, nuint max) => min.HasValue ? YANLib.YANNum.RandomNumberNuint(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="nuint"/> value.</param>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A random nullable <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static nuint? RandomNumberNuint(nuint min, nuint? max) => max.HasValue ? YANLib.YANNum.RandomNumberNuint(min, max.Value) : null;

    /// <summary>
    /// Generates a random nullable <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and <see cref="nuint.MaxValue"/> is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and <see cref="nuint.MaxValue"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="nuint"/> value.</param>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A random nullable <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint? RandomNumberNuint(nuint? min, nuint? max) => min.HasValue ? YANLib.YANNum.RandomNumberNuint(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, the maximum value of <see cref="nuint"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A nullable <see cref="nuint"/> value representing a random number between <see cref="nuint.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static nuint? RandomNumberNuint(nuint? max) => max.HasValue ? YANLib.YANNum.RandomNumberNuint(nuint.MinValue, max.Value) : null;
}
