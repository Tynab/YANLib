namespace YANLib;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a signed byte integer using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static sbyte ParseSbyte(this string str, sbyte? dfltVal) => dfltVal.HasValue ? str.ParseSbyte(dfltVal.Value) : (sbyte)0;

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="sbyte"/> value.</param>
    /// <param name="max">The maximum <see cref="sbyte"/> value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static sbyte RandomNumberSbyte(sbyte? min, sbyte max) => min.HasValue ? RandomNumberSbyte(min.Value, max) : (sbyte)0;

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="sbyte"/> value.</param>
    /// <param name="max">The maximum <see cref="sbyte"/> value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static sbyte RandomNumberSbyte(sbyte min, sbyte? max) => max.HasValue ? RandomNumberSbyte(min, max.Value) : (sbyte)0;

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// If only <paramref name="min"/> is <see langword="null"/>, it defaults to 0.
    /// If only <paramref name="max"/> is <see langword="null"/>, it defaults to the maximum value that can be represented by an <see cref="sbyte"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="max"/> is less than 0, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="sbyte"/> value.</param>
    /// <param name="max">The maximum <see cref="sbyte"/> value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static sbyte RandomNumberSbyte(sbyte? min, sbyte? max) => min.HasValue ? RandomNumberSbyte(min.Value, max) : (sbyte)0;

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="sbyte"/> value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <paramref name="max"/>.</returns>
    public static sbyte RandomNumberSbyte(sbyte? max) => max.HasValue ? RandomNumberSbyte(sbyte.MinValue, max.Value) : (sbyte)0;
}
