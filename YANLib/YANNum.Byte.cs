namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse <see cref="string"/> to <see cref="byte"/>, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Byte number.</returns>
    public static byte ParseByte(this string str) => byte.TryParse(str, out var num) ? num : (byte)0;

    /// <summary>
    /// Try parse string to byte, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Byte number.</returns>
    public static byte ParseByte(this string str, byte dfltVal) => byte.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to byte, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Byte number.</returns>
    public static byte ParseByteMin(this string str) => byte.TryParse(str, out var num) ? num : byte.MinValue;

    /// <summary>
    /// Try parse string to byte, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Byte number.</returns>
    public static byte ParseByteMax(this string str) => byte.TryParse(str, out var num) ? num : byte.MaxValue;

    /// <summary>
    /// Generate random byte number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Byte random number.</returns>
    public static byte RandomNumberByte(byte min, byte max) => (byte)(min > max ? 0 : new Random().Next(min, max));

    /// <summary>
    /// Generate random byte number.
    /// </summary>
    /// <returns>Byte random number.</returns>
    public static byte RandomNumberByte() => RandomNumberByte(byte.MinValue, byte.MaxValue);

    /// <summary>
    /// Generate random byte number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0.</param>
    /// <returns>Byte random number.</returns>
    public static byte RandomNumberByte(byte max) => RandomNumberByte(byte.MinValue, max);
}
