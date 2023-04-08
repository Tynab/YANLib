namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a double using the default format.
    /// Returns the parsed <see cref="double"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="double"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static double ParseDouble(this string str, double? dfltVal) => dfltVal.HasValue ? str.ParseDouble(dfltVal.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="double"/> value.</param>
    /// <param name="max">The maximum <see cref="double"/> value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static double RandomNumberDouble(double? min, double max) => min.HasValue ? RandomNumberDouble(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="double"/> value.</param>
    /// <param name="max">The maximum <see cref="double"/> value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static double RandomNumberDouble(double min, double? max) => max.HasValue ? RandomNumberDouble(min, max.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="double"/> value.</param>
    /// <param name="max">The maximum <see cref="double"/> value.</param>
    /// <returns>A random <see cref="double"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static double RandomNumberDouble(double? min, double? max) => min.HasValue ? RandomNumberDouble(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="double"/> value between <see cref="double.MinValue"/> and <paramref name="max"/>.
    /// If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="double"/> value.</param>
    /// <returns>A random <see cref="double"/> value between <see cref="double.MinValue"/> and <paramref name="max"/>.</returns>
    public static double RandomNumberDouble(double? max) => max.HasValue ? RandomNumberDouble(double.MinValue, max.Value) : 0;
}
