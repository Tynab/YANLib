namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a signed byte using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or 0 if the parsing fails.</returns>
    public static sbyte ParseSbyte(this string str) => sbyte.TryParse(str, out var num) ? num : (sbyte)0;

    /// <summary>
    /// Parses the string representation of an <see cref="sbyte"/> using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static sbyte ParseSbyte(this string str, sbyte dfltVal) => sbyte.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a signed byte using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or <see cref="sbyte.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or <see cref="sbyte.MinValue"/> if the parsing fails.</returns>
    public static sbyte ParseSbyteMin(this string str) => sbyte.TryParse(str, out var num) ? num : sbyte.MinValue;

    /// <summary>
    /// Parses the string representation of a signed byte using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or <see cref="sbyte.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or <see cref="sbyte.MaxValue"/> if the parsing fails.</returns>
    public static sbyte ParseSbyteMax(this string str) => sbyte.TryParse(str, out var num) ? num : sbyte.MaxValue;

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="sbyte"/> value.</param>
    /// <param name="max">The maximum <see cref="sbyte"/> value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static sbyte RandomNumberSbyte(sbyte min, sbyte max) => (sbyte)(min > max ? 0 : new Random().Next(min, max));

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <see cref="sbyte.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <see cref="sbyte.MaxValue"/>.</returns>
    public static sbyte RandomNumberSbyte() => RandomNumberSbyte(sbyte.MinValue, sbyte.MaxValue);

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="sbyte"/> value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and the <paramref name="max"/>.</returns>
    public static sbyte RandomNumberSbyte(sbyte max) => RandomNumberSbyte(sbyte.MinValue, max);
}
