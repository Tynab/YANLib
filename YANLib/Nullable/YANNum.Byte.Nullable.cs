namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to byte, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Byte number.</returns>
    public static byte? ParseByte(this string str, byte? dfltVal) => byte.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Generate random byte number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return null.</param>
    /// <returns>Byte random number.</returns>
    public static byte? RandomNumberByte(byte? min, byte max) => min.HasValue ? YANLib.YANNum.RandomNumberByte(min.Value, max) : null;

    /// <summary>
    /// Generate random byte number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return null.</param>
    /// <returns>Byte random number.</returns>
    public static byte? RandomNumberByte(byte min, byte? max) => max.HasValue ? YANLib.YANNum.RandomNumberByte(min, max.Value) : null;

    /// <summary>
    /// Generate random byte number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return null.</param>
    /// <returns>Byte random number.</returns>
    public static byte? RandomNumberByte(byte? min, byte? max) => min.HasValue ? YANLib.YANNum.RandomNumberByte(min.Value, max) : null;

    /// <summary>
    /// Generate random byte number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to null.</param>
    /// <returns>Byte random number.</returns>
    public static byte? RandomNumberByte(byte? max) => max.HasValue ? YANLib.YANNum.RandomNumberByte(byte.MinValue, max.Value) : null;
}
