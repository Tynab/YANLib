namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the string representation of a number to its 8-bit unsigned integer equivalent. A return value indicates whether the operation succeeded.
    /// </summary>
    /// <param name="str">The string representation of a number</param>
    /// <returns>The 8-bit unsigned integer equivalent of the string representation, or 0 if the conversion failed.</returns>
    public static byte ParseByte(this string str) => byte.TryParse(str, out var num) ? num : (byte)0;

    /// <summary>
    /// Parses the string representation of a number to a byte and returns the parsed value, or the default value if the string could not be parsed.
    /// </summary>
    /// <param name="str">The string representation of the number to parse.</param>
    /// <param name="dfltVal">The default value to return if the string could not be parsed.</param>
    /// <returns>The parsed byte or the default value.</returns>
    public static byte ParseByte(this string str, byte dfltVal) => byte.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Parses the string representation of a number to a byte and returns the parsed value. If the string could not be parsed, the minimum value of a byte is returned instead.
    /// </summary>
    /// <param name="str">The string representation of the number to parse.</param>
    /// <returns>The parsed byte or the minimum value of a byte if the string could not be parsed.</returns>
    public static byte ParseByteMin(this string str) => byte.TryParse(str, out var num) ? num : byte.MinValue;

    /// <summary>
    /// Parses the string representation of a number to a byte and returns the parsed value. If the string could not be parsed, the minimum value of a byte is returned instead.
    /// </summary>
    /// <param name="str">The string representation of the number to parse.</param>
    /// <returns>The parsed byte or the minimum value of a byte if the string could not be parsed.</returns>
    public static byte ParseByteMax(this string str) => byte.TryParse(str, out var num) ? num : byte.MaxValue;

    /// <summary>
    /// Generates a random number of type <see cref="byte"/> within a specified range.
    /// </summary>
    /// <param name="min">The minimum value (inclusive) of the random number generated. This value must be of type <see cref="byte"/>.</param>
    /// <param name="max">The maximum value (exclusive) of the random number generated. This value must be of type <see cref="byte"/>.</param>
    /// <returns>A random number of type <see cref="byte"/> within the specified range.</returns>
    public static byte RandomNumberByte(byte min, byte max) => (byte)(min > max ? 0 : new Random().Next(min, max));

    /// <summary>
    /// Generates a random number of type <see cref="byte"/> within the range of possible values for a <see cref="byte"/>.
    /// </summary>
    /// <returns>A random number of type <see cref="byte"/> within the range of possible values for a <see cref="byte"/>.</returns>
    public static byte RandomNumberByte() => RandomNumberByte(byte.MinValue, byte.MaxValue);

    /// <summary>
    /// Generates a random number of type <see cref="byte"/> within a specified maximum value (exclusive).
    /// </summary>
    /// <param name="max">The maximum value (exclusive) of the random number generated. This value must be of type <see cref="byte"/>.</param>
    /// <returns>A random number of type <see cref="byte"/> within the specified maximum value (exclusive).</returns>
    public static byte RandomNumberByte(byte max) => RandomNumberByte(byte.MinValue, max);
}
