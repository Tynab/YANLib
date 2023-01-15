using System.Numerics;

namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to nuint, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Nuint number.</returns>
    public static nuint ParseNuint(this string str)
    {
        _ = nuint.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to nuint, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Nuint number.</returns>
    public static nuint ParseNuint(this string str, nuint dfltVal) => nuint.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to nuint, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Nuint number.</returns>
    public static nuint ParseNuintMin(this string str) => nuint.TryParse(str, out var num) ? num : nuint.MinValue;

    /// <summary>
    /// Try parse string to nuint, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Nuint number.</returns>
    public static nuint ParseNuintMax(this string str) => nuint.TryParse(str, out var num) ? num : nuint.MaxValue;

    /// <summary>
    /// Generate random number.
    /// </summary>
    /// <returns>Nuint random number.</returns>
    public static nuint RandomNumberNuint() => (nuint)(new Random().NextInt64(nint.MinValue, nint.MaxValue) - nint.MinValue);

    /// <summary>
    /// Generate random number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0.</param>
    /// <returns>Nuint random number.</returns>
    public static nuint RandomNumberNuint(nuint max) => (nuint)(new Random().NextInt64(nint.MinValue, (long)(max + (BigInteger)nint.MinValue)) - nint.MinValue);

    /// <summary>
    /// Generate random number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Nuint random number.</returns>
    public static nuint RandomNumberNuint(nuint min, nuint max) => min > max ? 0 : (nuint)(new Random().NextInt64(nint.MinValue, (long)(max - (min - (BigInteger)nint.MinValue))) - nint.MinValue) + min;
}
