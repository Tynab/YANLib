namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a byte using the default format.
    /// Returns the parsed <see cref="byte"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="byte"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static byte ToByte<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToByte(dfltVal.Value) : default;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static byte GenRandomByte<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomByte(min.Value, max) : default;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static byte GenRandomByte<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomByte(min, max.Value) : default;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static byte GenRandomByte<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomByte(min.Value, max) : default;

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <paramref name="max"/>.</returns>
    public static byte GenRandomByte<T>(T? max) where T : struct => max.HasValue ? GenRandomByte(byte.MinValue, max.Value) : default;
}
