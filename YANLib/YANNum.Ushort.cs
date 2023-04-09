namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an unsigned short integer using the default format.
    /// Returns the parsed <see cref="ushort"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ushort"/> value, or 0 if the parsing fails.</returns>
    public static ushort ParseUshort(this string str) => ushort.TryParse(str, out var num) ? num : (ushort)0;

    /// <summary>
    /// Parses the string representation of an unsigned short integer using the default format.
    /// Returns the parsed <see cref="ushort"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="ushort"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static ushort ParseUshort(this string str, ushort dfltVal) => ushort.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a ushort using the default format.
    /// Returns the parsed <see cref="ushort"/> value, or <see cref="ushort.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ushort"/> value, or <see cref="ushort.MinValue"/> if the parsing fails.</returns>
    public static ushort ParseUshortMin(this string str) => ushort.TryParse(str, out var num) ? num : ushort.MinValue;

    /// <summary>
    /// Parses the string representation of an unsigned short integer using the default format.
    /// Returns the parsed <see cref="ushort"/> value, or <see cref="ushort.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ushort"/> value, or <see cref="ushort.MaxValue"/> if the parsing fails.</returns>
    public static ushort ParseUshortMax(this string str) => ushort.TryParse(str, out var num) ? num : ushort.MaxValue;

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ushort"/> value.</param>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ushort RandomNumberUshort(ushort min, ushort max) => (ushort)(min > max ? 0 : new Random().Next(min, max));

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <see cref="ushort.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <see cref="ushort.MaxValue"/>.</returns>
    public static ushort RandomNumberUshort() => RandomNumberUshort(ushort.MinValue, ushort.MaxValue);

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="ushort"/> value.</param>
    /// <returns>A random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and the <paramref name="max"/>.</returns>
    public static ushort RandomNumberUshort(ushort max) => RandomNumberUshort(ushort.MinValue, max);
}
