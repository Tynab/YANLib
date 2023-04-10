namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a pointer-sized signed integer using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static nint ToNint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToNint(dfltVal.Value) : default;

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint GenRandomNint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomNint(min.Value, max) : default;

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint GenRandomNint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenRandomNint(min, max.Value) : default;

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint GenRandomNint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenRandomNint(min.Value, max) : default;

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <paramref name="max"/>.</returns>
    public static nint GenRandomNint<T>(T? max) where T : struct => max.HasValue ? GenRandomNint(nint.MinValue, max.Value) : default;
}
