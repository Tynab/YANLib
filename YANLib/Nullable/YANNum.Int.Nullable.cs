namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an <see cref="int"/> using the specified format and culture.
    /// Returns the parsed <see cref="int"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="int"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static int? ToInt(this string str, int? dfltVal) => int.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random nullable <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="int"/> value.</param>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A random nullable <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>.</returns>
    public static int? GenRandomInt(int? min, int max) => min.HasValue ? YANLib.YANNum.GenRandomInt(min.Value, max) : null;

    /// <summary>
    /// Generates a random nullable <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see langword="null"/> is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="int"/> value.</param>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A random nullable <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static int? GenRandomInt(int min, int? max) => max.HasValue ? YANLib.YANNum.GenRandomInt(min, max.Value) : null;

    /// <summary>
    /// Generates a random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, a random value between 0 and 1 is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, a random value is generated between 0 and <paramref name="max"/>.
    /// If only <paramref name="max"/> is <see langword="null"/>, a random value is generated between <paramref name="min"/> and 1.
    /// </summary>
    /// <param name="min">The minimum <see cref="int"/> value.</param>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static int? GenRandomInt(int? min, int? max) => min.HasValue ? YANLib.YANNum.GenRandomInt(min.Value, max) : null;

    /// <summary>
    /// Generates a random <see cref="int"/> value between <see cref="int.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, <see cref="int.MaxValue"/> is used.
    /// </summary>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A nullable <see cref="int"/> value representing a random number between <see cref="int.MinValue"/> and <paramref name="max"/>, or <see langword="null"/> if <paramref name="max"/> is <see langword="null"/>.</returns>
    public static int? GenRandomInt(int? max) => max.HasValue ? YANLib.YANNum.GenRandomInt(int.MinValue, max.Value) : null;
}
