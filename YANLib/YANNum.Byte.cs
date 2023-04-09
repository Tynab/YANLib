﻿namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a byte using the default format.
    /// Returns the parsed <see cref="byte"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="byte"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static byte ToByte(this string str) => byte.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Parses the string representation of a byte using the default format and returns the parsed <see cref="byte"/> value,
    /// or the specified default value if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="byte"/> value, or the specified default value if the parsing fails.</returns>
    public static byte ToByte<T>(this string str, T dfltVal) where T : struct => byte.TryParse(str, out var num) ? num : dfltVal.ToByte();

    /// <summary>
    /// Converts the specified value to a byte.
    /// Returns the converted <see cref="byte"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="byte"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static byte ToByte<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToByte(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Generates a random byte between the specified minimum and maximum values, inclusive.
    /// Returns the generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>The generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.</returns>
    public static byte GenRandomByte<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var newMin = min.ToByte();
        var newMax = max.ToByte();
        return (byte)(newMin > newMax ? default : new Random().Next(newMin, newMax));
    }

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <see cref="byte.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <see cref="byte.MaxValue"/>.</returns>
    public static byte GenRandomByte() => GenRandomByte(byte.MinValue, byte.MaxValue);

    /// <summary>
    /// Generates a random byte between <see cref="byte.MinValue"/> and the specified maximum value, inclusive.
    /// Returns the generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>The generated <see cref="byte"/> value, or <see langword="default"/> if the generation fails.</returns>
    public static byte GenRandomByte<T>(T max) where T : struct => GenRandomByte(byte.MinValue, max);
}
