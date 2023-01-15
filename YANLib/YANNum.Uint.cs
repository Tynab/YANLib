namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to uint, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Uint number.</returns>
    public static uint ParseUint(this string str)
    {
        _ = uint.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to uint, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Uint number.</returns>
    public static uint ParseUint(this string str, uint dfltVal) => uint.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to uint, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Uint number.</returns>
    public static uint ParseUintMin(this string str) => uint.TryParse(str, out var num) ? num : uint.MinValue;

    /// <summary>
    /// Try parse string to uint, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Uint number.</returns>
    public static uint ParseUintMax(this string str) => uint.TryParse(str, out var num) ? num : uint.MaxValue;

    /// <summary>
    /// Generate random number.
    /// </summary>
    /// <returns>Uint random number.</returns>
    public static uint RandomNumberUint() => (uint)new Random().NextInt64(uint.MinValue, uint.MaxValue);

    /// <summary>
    /// Generate random number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0.</param>
    /// <returns>Uint random number.</returns>
    public static uint RandomNumberUint(uint max) => (uint)new Random().NextInt64(uint.MinValue, max);

    /// <summary>
    /// Generate random number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Uint random number.</returns>
    public static uint RandomNumberUint(uint min, uint max) => (uint)(min > max ? 0 : new Random().NextInt64(min, max));
}
