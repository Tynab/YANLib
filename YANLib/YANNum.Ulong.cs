using System.Numerics;

namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to ulong, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Ulong number.</returns>
    public static ulong ParseUlong(this string str)
    {
        _ = ulong.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to ulong, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Ulong number.</returns>
    public static ulong ParseUlong(this string str, ulong dfltVal) => ulong.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to ulong, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Ulong number.</returns>
    public static ulong ParseUlongMin(this string str) => ulong.TryParse(str, out var num) ? num : ulong.MinValue;

    /// <summary>
    /// Try parse string to ulong, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Ulong number.</returns>
    public static ulong ParseUlongMax(this string str) => ulong.TryParse(str, out var num) ? num : ulong.MaxValue;

    /// <summary>
    /// Generate random number.
    /// </summary>
    /// <returns>Ulong random number.</returns>
    public static ulong RandomNumberUlong() => (ulong)(new Random().NextInt64(long.MinValue, long.MaxValue) - long.MinValue);

    /// <summary>
    /// Generate random number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0.</param>
    /// <returns>Ulong random number.</returns>
    public static ulong RandomNumberUlong(ulong max) => (ulong)(new Random().NextInt64(long.MinValue, (long)(max + (BigInteger)long.MinValue)) - long.MinValue);

    /// <summary>
    /// Generate random number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Ulong random number.</returns>
    public static ulong RandomNumberUlong(ulong min, ulong max) => min > max ? 0 : (ulong)(new Random().NextInt64(long.MinValue, (long)(max - (min - (BigInteger)long.MinValue))) - long.MinValue) + min;
}
