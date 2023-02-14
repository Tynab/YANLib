namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Converts the string representation of a number to its 8-bit unsigned integer equivalent. A return value indicates whether the conversion succeeded or failed.
    /// </summary>
    /// <param name="str">A string containing a number to convert.</param>
    /// <param name="dfltVal">The default value to be returned if the conversion fails.</param>
    /// <returns>An 8-bit unsigned integer equivalent to the number contained in the string, or <paramref name="dfltVal"/> if the conversion failed.</returns>
    public static byte? ParseByte(this string str, byte? dfltVal) => byte.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generates a random 8-bit unsigned integer within a specified range.
    /// </summary>
    /// <param name="min">The minimum value of the random number to be generated. If this parameter is null, the method will return null.</param>
    /// <param name="max">The maximum value of the random number to be generated.</param>
    /// <returns>A random 8-bit unsigned integer that is greater than or equal to <paramref name="min"/> and less than or equal to <paramref name="max"/>, or null if <paramref name="min"/> is null.</returns>
    public static byte? RandomNumberByte(byte? min, byte max) => min.HasValue ? YANLib.YANNum.RandomNumberByte(min.Value, max) : null;

    /// <summary>
    /// Generates a random 8-bit unsigned integer within a specified range.
    /// </summary>
    /// <param name="min">The minimum value of the random number to be generated.</param>
    /// <param name="max">The maximum value of the random number to be generated. If this parameter is null, the method will return null.</param>
    /// <returns>A random 8-bit unsigned integer that is greater than or equal to <paramref name="min"/> and less than or equal to <paramref name="max"/>, or null if <paramref name="max"/> is null.</returns>
    public static byte? RandomNumberByte(byte min, byte? max) => max.HasValue ? YANLib.YANNum.RandomNumberByte(min, max.Value) : null;

    /// <summary>
    /// Generates a random 8-bit unsigned integer within a specified range.
    /// </summary>
    /// <param name="min">The minimum value of the random number to be generated. If this parameter is null, the method will return null.</param>
    /// <param name="max">The maximum value of the random number to be generated. If this parameter is null, the method will return null.</param>
    /// <returns>A random 8-bit unsigned integer that is greater than or equal to <paramref name="min"/> and less than or equal to <paramref name="max"/>, or null if either <paramref name="min"/> or <paramref name="max"/> is null.</returns>
    public static byte? RandomNumberByte(byte? min, byte? max) => min.HasValue ? YANLib.YANNum.RandomNumberByte(min.Value, max) : null;

    /// <summary>
    /// Generates a random 8-bit unsigned integer within a specified range.
    /// </summary>
    /// <param name="max">The maximum value of the random number to be generated. If this parameter is null, the method will return null.</param>
    /// <returns>A random 8-bit unsigned integer that is greater than or equal to the minimum value (0) and less than or equal to <paramref name="max"/>, or null if <paramref name="max"/> is null.</returns>
    public static byte? RandomNumberByte(byte? max) => max.HasValue ? YANLib.YANNum.RandomNumberByte(byte.MinValue, max.Value) : null;
}
