namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to short, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Short number.</returns>
    public static short ParseShort(this string str)
    {
        _ = short.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to short, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Short number.</returns>
    public static short ParseShort(this string str, short dfltVal) => short.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to short, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Short number.</returns>
    public static short ParseShortMin(this string str) => short.TryParse(str, out var num) ? num : short.MinValue;

    /// <summary>
    /// Try parse string to short, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Short number.</returns>
    public static short ParseShortMax(this string str) => short.TryParse(str, out var num) ? num : short.MaxValue;

    /// <summary>
    /// Generate random short number.
    /// </summary>
    /// <returns>Short random number.</returns>
    public static short RandomNumberShort() => (short)new Random().Next(short.MinValue, short.MaxValue);

    /// <summary>
    /// Generate random short number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated.
    /// <paramref name="max"/> must be greater than or equal to 0.
    /// If not, the inclusive lower bound of the random number flexible to <see cref="short.MinValue"/>.</param>
    /// <returns>Short random number.</returns>
    public static short RandomNumberShort(short max)
    {
        var rnd = new Random();
        return (short)(max < 0 ? rnd.Next(short.MinValue, max) : rnd.Next(0, max));
    }

    /// <summary>
    /// Generate random short number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned.
    /// <paramref name="max"/> must be greater than or equal to <paramref name="min"/>.
    /// If not, return 0.</param>
    /// <returns>Short random number.</returns>
    public static short RandomNumberShort(short min, short max) => (short)(min > max ? 0 : new Random().Next(min, max));
}
