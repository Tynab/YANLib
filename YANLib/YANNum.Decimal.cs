namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to decimal, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Decimal number.</returns>
    public static decimal ParseDecimal(this string str)
    {
        _ = decimal.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to decimal, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Decimal number.</returns>
    public static decimal ParseDecimal(this string str, decimal dfltVal) => decimal.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to decimal, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Decimal number.</returns>
    public static decimal ParseDecimalMin(this string str) => decimal.TryParse(str, out var num) ? num : decimal.MinValue;

    /// <summary>
    /// Try parse string to decimal, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Decimal number.</returns>
    public static decimal ParseDecimalMax(this string str) => decimal.TryParse(str, out var num) ? num : decimal.MaxValue;

    /// <summary>
    /// Generate random number.
    /// </summary>
    /// <returns>Decimal random number.</returns>
    public static decimal RandomNumberDecimal() => new Random().NextDecimal();

    /// <summary>
    /// Generate random number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0. If not, the inclusive lower bound of the random number flexible to <see cref="decimal.MinValue"/>.</param>
    /// <returns>Decimal random number.</returns>
    public static decimal RandomNumberDecimal(decimal max) => max < 0 ? new Random().NextDecimal(decimal.MinValue, max) : new Random().NextDecimal(0, max);

    /// <summary>
    /// Generate random number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Decimal random number.</returns>
    public static decimal RandomNumberDecimal(decimal min, decimal max) => min > max ? 0 : new Random().NextDecimal(min, max);
}
