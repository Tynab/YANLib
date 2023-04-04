namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an <see cref="nuint"/> using the default format. Returns the parsed <see cref="nuint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails. If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static nuint ParseNuint(this string str, nuint? dfltVal) => dfltVal.HasValue ? str.ParseNuint(dfltVal.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="nuint"/> value.</param>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint RandomNumberNuint(nuint? min, nuint max) => min.HasValue ? RandomNumberNuint(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="nuint"/> value.</param>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint RandomNumberNuint(nuint min, nuint? max) => max.HasValue ? RandomNumberNuint(min, max.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>. If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="nuint"/> value.</param>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A random <see cref="nuint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nuint RandomNumberNuint(nuint? min, nuint? max) => min.HasValue ? RandomNumberNuint(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <paramref name="max"/>. If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="nuint"/> value.</param>
    /// <returns>A random <see cref="nuint"/> value between <see cref="nuint.MinValue"/> and <paramref name="max"/>.</returns>
    public static nuint RandomNumberNuint(nuint? max) => max.HasValue ? RandomNumberNuint(nuint.MinValue, max.Value) : 0;
}
