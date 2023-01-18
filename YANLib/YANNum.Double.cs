namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to double, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Double number.</returns>
    public static double ParseDouble(this string str)
    {
        _ = double.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to double, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Double number.</returns>
    public static double ParseDouble(this string str, double dfltVal) => double.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to double, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Double number.</returns>
    public static double ParseDoubleMin(this string str) => double.TryParse(str, out var num) ? num : double.MinValue;

    /// <summary>
    /// Try parse string to double, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Double number.</returns>
    public static double ParseDoubleMax(this string str) => double.TryParse(str, out var num) ? num : double.MaxValue;

    /// <summary>
    /// Generate random double number.
    /// </summary>
    /// <returns>Double random number.</returns>
    public static double RandomNumberDouble() => new Random().NextDouble();

    /// <summary>
    /// Generate random double number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0. If not, the inclusive lower bound of the random number flexible to <see cref="double.MinValue"/>.</param>
    /// <returns>Double random number.</returns>
    public static double RandomNumberDouble(double max)
    {
        var rnd = new Random();
        return max < 0 ? rnd.NextDouble(double.MinValue, max) : rnd.NextDouble(0, max);
    }

    /// <summary>
    /// Generate random double number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Double random number.</returns>
    public static double RandomNumberDouble(double min, double max) => min > max ? 0 : new Random().NextDouble(min, max);
}
