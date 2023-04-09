namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an unsigned integer using the default format.
    /// Returns the parsed <see cref="uint"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="uint"/> value, or 0 if the parsing fails.</returns>
    public static uint ParseUint(this string str) => uint.TryParse(str, out var num) ? num : 0;

    /// <summary>
    /// Parses the string representation of an unsigned integer using the default format.
    /// Returns the parsed <see cref="uint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="uint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static uint ParseUint(this string str, uint dfltVal) => uint.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of an unsigned integer using the default format.
    /// Returns the parsed <see cref="uint"/> value, or <see cref="uint.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="uint"/> value, or <see cref="uint.MinValue"/> if the parsing fails.</returns>
    public static uint ParseUintMin(this string str) => uint.TryParse(str, out var num) ? num : uint.MinValue;

    /// <summary>
    /// Parses the string representation of a uint using the default format.
    /// Returns the parsed <see cref="uint"/> value, or <see cref="uint.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="uint"/> value, or <see cref="uint.MaxValue"/> if the parsing fails.</returns>
    public static uint ParseUintMax(this string str) => uint.TryParse(str, out var num) ? num : uint.MaxValue;

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="uint"/> value.</param>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static uint RandomNumberUint(uint min, uint max) => (uint)(min > max ? 0 : new Random().NextInt64(min, max));

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <see cref="uint.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <see cref="uint.MaxValue"/>.</returns>
    public static uint RandomNumberUint() => RandomNumberUint(uint.MinValue, uint.MaxValue);

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="uint"/> value.</param>
    /// <returns>A random <see cref="uint"/> value between <see cref="uint.MinValue"/> and the <paramref name="max"/>.</returns>
    public static uint RandomNumberUint(uint max) => RandomNumberUint(uint.MinValue, max);
}
