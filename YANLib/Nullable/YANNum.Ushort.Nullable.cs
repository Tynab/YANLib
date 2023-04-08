namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a <see cref="ushort"/> value.
    /// Returns the parsed <see cref="ushort"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="ushort"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static ushort? ParseUshort(this string str, ushort? dfltVal) => ushort.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ushort"/> value.</param>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A random nullable <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static ushort? RandomNumberUshort(ushort? min, ushort max) => min.HasValue ? YANLib.YANNum.RandomNumberUshort(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ushort"/> value.</param>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A random nullable <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static ushort? RandomNumberUshort(ushort min, ushort? max) => max.HasValue ? YANLib.YANNum.RandomNumberUshort(min, max.Value) : null;

    /// <summary>
    /// Generates a random nullable <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and <see cref="ushort.MaxValue"/> is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and <see cref="ushort.MaxValue"/>.
    /// </summary>
    /// <param name="min">The minimum <see cref="ushort"/> value.</param>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A random nullable <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ushort? RandomNumberUshort(ushort? min, ushort? max) => min.HasValue ? YANLib.YANNum.RandomNumberUshort(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, the maximum value of <see cref="ushort"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A nullable <see cref="ushort"/> value representing a random number between <see cref="ushort.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static ushort? RandomNumberUshort(ushort? max) => max.HasValue ? YANLib.YANNum.RandomNumberUshort(ushort.MinValue, max.Value) : null;
}
