namespace YANLib;

public partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an integer using the default format. Returns the parsed integer value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails. If <paramref name="dfltVal"/> is <see langword="null"/>, returns 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed integer value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing succeeds, otherwise 0.</returns>
    public static int ParseInt(this string str, int? dfltVal) => dfltVal.HasValue ? str.ParseInt(dfltVal.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="min"/> is greater than <paramref name="max"/> or <paramref name="min"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="int"/> value.</param>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static int RandomNumberInt(int? min, int max) => min.HasValue ? RandomNumberInt(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>. If <paramref name="max"/> is <see langword="null"/> or <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="int"/> value.</param>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static int RandomNumberInt(int min, int? max) => max.HasValue ? RandomNumberInt(min, max.Value) : 0;

    /// <summary>
    /// Generates a random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>. If both <paramref name="min"/> and <paramref name="max"/> are <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="int"/> value.</param>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static int RandomNumberInt(int? min, int? max) => min.HasValue ? RandomNumberInt(min.Value, max) : 0;

    /// <summary>
    /// Generates a random <see cref="int"/> value between <see cref="int.MinValue"/> and <paramref name="max"/>. If <paramref name="max"/> is <see langword="null"/>, 0 is returned.
    /// </summary>
    /// <param name="max">The maximum <see cref="int"/> value.</param>
    /// <returns>A random <see cref="int"/> value between <see cref="int.MinValue"/> and <paramref name="max"/>.</returns>
    public static int RandomNumberInt(int? max) => max.HasValue ? RandomNumberInt(int.MinValue, max.Value) : 0;
}
