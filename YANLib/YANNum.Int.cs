namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to int, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Int number.</returns>
    public static int ParseInt(this string str)
    {
        _ = int.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to int, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Int number.</returns>
    public static int ParseInt(this string str, int dfltVal) => int.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to int, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Int number.</returns>
    public static int ParseIntMin(this string str) => int.TryParse(str, out var num) ? num : int.MinValue;

    /// <summary>
    /// Try parse string to int, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Int number.</returns>
    public static int ParseIntMax(this string str) => int.TryParse(str, out var num) ? num : int.MaxValue;

    /// <summary>
    /// Generate random number.
    /// </summary>
    /// <returns>Int random number.</returns>
    public static int RandomNumberInt() => new Random().Next();

    /// <summary>
    /// Generate random number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0. If not, the inclusive lower bound of the random number flexible to <see cref="int.MinValue"/>.</param>
    /// <returns>Int random number.</returns>
    public static int RandomNumberInt(int max) => max < 0 ? new Random().Next(int.MinValue, max) : new Random().Next(0, max);

    /// <summary>
    /// Generate random number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Int random number.</returns>
    public static int RandomNumberInt(int min, int max) => min > max ? 0 : new Random().Next(min, max);
}
