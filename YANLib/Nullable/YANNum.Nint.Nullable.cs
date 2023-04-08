namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an integer using the default format.
    /// Returns the parsed <see cref="nint"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nint"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static nint? ParseNint(this string str, nint? dfltVal) => nint.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="nint"/> value.</param>
    /// <param name="max">The maximum <see cref="nint"/> value.</param>
    /// <returns>A random nullable <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static nint? RandomNumberNint(nint? min, nint max) => min.HasValue ? YANLib.YANNum.RandomNumberNint(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="nint"/> value.</param>
    /// <param name="max">The maximum <see cref="nint"/> value.</param>
    /// <returns>A random nullable <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static nint? RandomNumberNint(nint min, nint? max) => max.HasValue ? YANLib.YANNum.RandomNumberNint(min, max.Value) : null;

    /// <summary>
    /// Generates a random nullable <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and 1 is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and 1.
    /// </summary>
    /// <param name="min">The minimum nullable <see cref="nint"/> value.</param>
    /// <param name="max">The maximum nullable <see cref="nint"/> value.</param>
    /// <returns>A random nullable <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint? RandomNumberNint(nint? min, nint? max) => min.HasValue ? YANLib.YANNum.RandomNumberNint(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see cref="nint.MaxValue"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="nint"/> value.</param>
    /// <returns>A nullable <see cref="nint"/> value representing a random number between <see cref="nint.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static nint? RandomNumberNint(nint? max) => max.HasValue ? YANLib.YANNum.RandomNumberNint(nint.MinValue, max.Value) : null;
}
