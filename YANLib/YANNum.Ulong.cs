using System.Numerics;

namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an unsigned long integer using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or 0 if the parsing fails.</returns>
    public static ulong ParseUlong(this string str) => ulong.TryParse(str, out var num) ? num : 0;

    /// <summary>
    /// Parses the string representation of an unsigned long integer using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static ulong ParseUlong(this string str, ulong dfltVal) => ulong.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of an unsigned long integer using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or <see cref="ulong.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or <see cref="ulong.MinValue"/> if the parsing fails.</returns>
    public static ulong ParseUlongMin(this string str) => ulong.TryParse(str, out var num) ? num : ulong.MinValue;

    /// <summary>
    /// Parses the string representation of an unsigned long integer using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or <see cref="ulong.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or <see cref="ulong.MaxValue"/> if the parsing fails.</returns>
    public static ulong ParseUlongMax(this string str) => ulong.TryParse(str, out var num) ? num : ulong.MaxValue;

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="ulong"/> value.</param>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A random <see cref="ulong"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ulong RandomNumberUlong(ulong min, ulong max) => min > max ? 0 : (ulong)(new Random().NextInt64(long.MinValue, (long)(max - (min - (BigInteger)long.MinValue))) - long.MinValue) + min;

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <see cref="ulong.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <see cref="ulong.MaxValue"/>.</returns>
    public static ulong RandomNumberUlong() => RandomNumberUlong(ulong.MinValue, ulong.MaxValue);

    /// <summary>
    /// Generates a random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="ulong"/> value.</param>
    /// <returns>A random <see cref="ulong"/> value between <see cref="ulong.MinValue"/> and the <paramref name="max"/>.</returns>
    public static ulong RandomNumberUlong(ulong max) => RandomNumberUlong(ulong.MinValue, max);
}
