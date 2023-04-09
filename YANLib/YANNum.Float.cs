namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a <see cref="float"/> using the default format.
    /// Returns the parsed <see cref="float"/> value, or 0 if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="float"/> value, or 0 if the parsing fails.</returns>
    public static float ParseFloat(this string str) => float.TryParse(str, out var num) ? num : 0;

    /// <summary>
    /// Parses the string representation of a <see cref="float"/> using the default format.
    /// Returns the parsed <see cref="float"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="float"/> value, or the default value specified by the <paramref name="dfltVal"/> parameter if the parsing fails.</returns>
    public static float ParseFloat(this string str, float dfltVal) => float.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a floating-point number using the default format.
    /// Returns the parsed <see cref="float"/> value, or <see cref="float.MinValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="float"/> value, or <see cref="float.MinValue"/> if the parsing fails.</returns>
    public static float ParseFloatMin(this string str) => float.TryParse(str, out var num) ? num : float.MinValue;

    /// <summary>
    /// Parses the string representation of a float using the default format.
    /// Returns the parsed <see cref="float"/> value, or <see cref="float.MaxValue"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="float"/> value, or <see cref="float.MaxValue"/> if the parsing fails.</returns>
    public static float ParseFloatMax(this string str) => float.TryParse(str, out var num) ? num : float.MaxValue;

    /// <summary>
    /// Generates a random <see cref="float"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, 0 is returned.
    /// </summary>
    /// <param name="min">The minimum <see cref="float"/> value.</param>
    /// <param name="max">The maximum <see cref="float"/> value.</param>
    /// <returns>A random <see cref="float"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static float RandomNumberFloat(float min, float max) => min > max ? 0 : new Random().NextSingle(min, max);

    /// <summary>
    /// Generates a random <see cref="float"/> value between <see cref="float.MinValue"/> and <see cref="float.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="float"/> value between <see cref="float.MinValue"/> and <see cref="float.MaxValue"/>.</returns>
    public static float RandomNumberFloat() => RandomNumberFloat(float.MinValue, float.MaxValue);

    /// <summary>
    /// Generates a random <see cref="float"/> value between <see cref="float.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <param name="max">The maximum <see cref="float"/> value.</param>
    /// <returns>A random <see cref="float"/> value between <see cref="float.MinValue"/> and the <paramref name="max"/>.</returns>
    public static float RandomNumberFloat(float max) => RandomNumberFloat(float.MinValue, max);
}
