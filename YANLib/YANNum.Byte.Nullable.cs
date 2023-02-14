namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses a string representation of a number to a value of type <see cref="byte"/>.
    /// </summary>
    /// <param name="str">The string representation of a number to parse. This value must be of type <see cref="string"/>.</param>
    /// <param name="dfltVal">The default value to return if the string representation of a number cannot be parsed. This value must be of type <see cref="byte?"/></param>
    /// <returns>The parsed value of type <see cref="byte"/>, or the default value if the string representation of a number cannot be parsed.</returns>
    public static byte ParseByte(this string str, byte? dfltVal) => dfltVal.HasValue ? str.ParseByte(dfltVal.Value) : (byte)0;

    /// <summary>
    /// Generates a random number within a specified range of values. If the minimum value is not specified, it will default to 0.
    /// </summary>
    /// <param name="min">The minimum value for the random number, or null if no minimum value is desired</param>
    /// <param name="max">The maximum value for the random number</param>
    /// <returns>A random number within the specified range</returns>
    public static byte RandomNumberByte(byte? min, byte max) => min.HasValue ? RandomNumberByte(min.Value, max) : (byte)0;

    /// <summary>
    /// Generates a random number within a specified range of values. If the maximum value is not specified, it will default to 0.
    /// </summary>
    /// <param name="min">The minimum value for the random number</param>
    /// <param name="max">The maximum value for the random number, or null if no maximum value is desired</param>
    /// <returns>A random number within the specified range</returns>
    public static byte RandomNumberByte(byte min, byte? max) => max.HasValue ? RandomNumberByte(min, max.Value) : (byte)0;

    /// <summary>
    /// Generates a random number within a specified range of values. If the minimum or maximum value is not specified, it will default to 0.
    /// </summary>
    /// <param name="min">The minimum value for the random number, or null if no minimum value is desired</param>
    /// <param name="max">The maximum value for the random number, or null if no maximum value is desired</param>
    /// <returns>A random number within the specified range</returns>
    public static byte RandomNumberByte(byte? min, byte? max) => min.HasValue ? RandomNumberByte(min.Value, max) : (byte)0;

    /// <summary>
    /// Generates a random 8-bit unsigned integer within a specified range.
    /// </summary>
    /// <param name="max">The maximum value of the random number to be generated. If this parameter is null, the method will return 0.</param>
    /// <returns>A random 8-bit unsigned integer that is less than or equal to <paramref name="max"/>, or 0 if <paramref name="max"/> is null.</returns>
    public static byte RandomNumberByte(byte? max) => max.HasValue ? RandomNumberByte(byte.MinValue, max.Value) : (byte)0;
}
