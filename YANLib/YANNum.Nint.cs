namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to nint, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Nint number.</returns>
    public static nint ParseNint(this string str)
    {
        _ = nint.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to nint, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Nint number.</returns>
    public static nint ParseNint(this string str, nint dfltVal) => nint.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to nint, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Nint number.</returns>
    public static nint ParseNintMin(this string str) => nint.TryParse(str, out var num) ? num : nint.MinValue;

    /// <summary>
    /// Try parse string to nint, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Nint number.</returns>
    public static nint ParseNintMax(this string str) => nint.TryParse(str, out var num) ? num : nint.MaxValue;

    /// <summary>
    /// Generate random number.
    /// </summary>
    /// <returns>Nint random number.</returns>
    public static nint RandomNumberNint() => (nint)new Random().NextInt64(nint.MinValue, nint.MaxValue);

    /// <summary>
    /// Generate random number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0. If not, the inclusive lower bound of the random number flexible to <see cref="nint.MinValue"/>.</param>
    /// <returns>Nint random number.</returns>
    public static nint RandomNumberNint(nint max) => (nint)(max < 0 ? new Random().NextInt64(nint.MinValue, max) : new Random().NextInt64(0, max));

    /// <summary>
    /// Generate random number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Nint random number.</returns>
    public static nint RandomNumberNint(nint min, nint max) => (nint)(min > max ? 0 : new Random().NextInt64(min, max));
}
