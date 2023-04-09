namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a byte using the default format.
    /// Returns the parsed <see cref="byte"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="byte"/> value, or the default value <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static byte? ToByte<T>(this string str, T? dfltVal) where T : struct => byte.TryParse(str, out var num) ? num : dfltVal.ToByte();

    /// <summary>
    /// Generates a random byte between the specified minimum and maximum values, inclusive.
    /// Returns the generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>The generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.</returns>
    public static byte? GenRandomByte<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? YANLib.YANNum.GenRandomByte(min.Value, max) : default;

    /// <summary>
    /// Generates a random byte between the specified minimum and maximum values, inclusive.
    /// Returns the generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>The generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.</returns>
    public static byte? GenRandomByte<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? YANLib.YANNum.GenRandomByte(min, max.Value) : default;

    /// <summary>
    /// Generates a random byte between the specified minimum and maximum values, inclusive.
    /// Returns the generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>The generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.</returns>
    public static byte? GenRandomByte<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? YANLib.YANNum.GenRandomByte(min.Value, max) : default;

    /// <summary>
    /// Generates a random byte between the minimum value of 0 and the specified maximum value, inclusive.
    /// Returns the generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>The generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.</returns>
    public static byte? GenRandomByte<T>(T? max) where T : struct => max.HasValue ? YANLib.YANNum.GenRandomByte(byte.MinValue, max.Value) : default;
}
