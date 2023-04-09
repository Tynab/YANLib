using System.Numerics;

namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a <see cref="nuint"/> using the default format.
    /// Returns the parsed <see cref="nuint"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or 0 if the parsing fails.</returns>
    public static nuint ParseNuint(this string str) => nuint.TryParse(str, out var num) ? num : 0;

    /// <summary>
    /// Parses the string representation of a <see cref="nuint"/> using the default format.
    /// Returns the parsed <see cref="nuint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static nuint ParseNuint(this string str, nuint dfltVal) => nuint.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of an unsigned integer using the default format.
    /// Returns the parsed <see cref="nuint"/> value, or <see cref="nuint.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or <see cref="nuint.MinValue"/> if the parsing fails.</returns>
    public static nuint ParseNuintMin(this string str) => nuint.TryParse(str, out var num) ? num : nuint.MinValue;

    /// <summary>
    /// Parses the string representation of an unsigned integer using the default format.
    /// Returns the parsed <see cref="nuint"/> value, or <see cref="nuint.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or <see cref="nuint.MaxValue"/> if the parsing fails.</returns>
    public static nuint ParseNuintMax(this string str) => nuint.TryParse(str, out var num) ? num : nuint.MaxValue;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="nuint"/> value.</param>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint RandomNumberNuint(nuint min, nuint max) => min > max ? 0 : (nuint)(new Random().NextInt64(nint.MinValue, (long)(max - (min - (BigInteger)nint.MinValue))) - nint.MinValue) + min;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <see cref="nuint.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <see cref="nuint.MaxValue"/>.</returns>
    public static nuint RandomNumberNuint() => RandomNumberNuint(nuint.MinValue, nuint.MaxValue);

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and the <paramref name="max"/>.</returns>
    public static nuint RandomNumberNuint(nuint max) => RandomNumberNuint(nuint.MinValue, max);
}
