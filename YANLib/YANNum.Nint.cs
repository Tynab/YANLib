namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a nint using the default format.
    /// Returns the parsed <see cref="nint"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nint"/> value, or 0 if the parsing fails.</returns>
    public static nint ParseNint(this string str) => nint.TryParse(str, out var num) ? num : 0;

    /// <summary>
    /// Parses the string representation of a nint using the default format.
    /// Returns the parsed <see cref="nint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static nint ParseNint(this string str, nint dfltVal) => nint.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a nint (an integer that is the same size as a pointer) using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <see cref="nint.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <see cref="nint.MinValue"/> if the parsing fails.</returns>
    public static nint ParseNintMin(this string str) => nint.TryParse(str, out var num) ? num : nint.MinValue;

    /// <summary>
    /// Parses the string representation of a <see cref="nint"/> using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <see cref="nint.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <see cref="nint.MaxValue"/> if the parsing fails.</returns>
    public static nint ParseNintMax(this string str) => nint.TryParse(str, out var num) ? num : nint.MaxValue;

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="nint"/> value.</param>
    /// <param name="max">The maximum <see cref="nint"/> value.</param>
    /// <returns>A random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint RandomNumberNint(nint min, nint max) => (nint)(min > max ? 0 : new Random().NextInt64(min, max));

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <see cref="nint.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <see cref="nint.MaxValue"/>.</returns>
    public static nint RandomNumberNint() => RandomNumberNint(nint.MinValue, nint.MaxValue);

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="byte"/> value.</param>
    /// <returns>A random <see cref="byte"/> value between <see cref="byte.MinValue"/> and the <paramref name="max"/>.</returns>
    public static nint RandomNumberNint(nint max) => RandomNumberNint(nint.MinValue, max);
}
