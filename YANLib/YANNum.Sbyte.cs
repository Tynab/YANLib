namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to sbyte, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Sbyte number.</returns>
    public static sbyte ParseSbyte(this string str)
    {
        _ = sbyte.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to sbyte, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Sbyte number.</returns>
    public static sbyte ParseSbyte(this string str, sbyte dfltVal) => sbyte.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to sbyte, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Sbyte number.</returns>
    public static sbyte ParseSbyteMin(this string str) => sbyte.TryParse(str, out var num) ? num : sbyte.MinValue;

    /// <summary>
    /// Try parse string to sbyte, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Sbyte number.</returns>
    public static sbyte ParseSbyteMax(this string str) => sbyte.TryParse(str, out var num) ? num : sbyte.MaxValue;

    /// <summary>
    /// Generate random sbyte number.
    /// </summary>
    /// <returns>Sbyte random number.</returns>
    public static sbyte RandomNumberSbyte() => (sbyte)new Random().Next(sbyte.MinValue, sbyte.MaxValue);

    /// <summary>
    /// Generate random sbyte number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0. If not, the inclusive lower bound of the random number flexible to <see cref="sbyte.MinValue"/>.</param>
    /// <returns>Sbyte random number.</returns>
    public static sbyte RandomNumberSbyte(sbyte max) => (sbyte)(max < 0 ? new Random().Next(sbyte.MinValue, max) : new Random().Next(0, max));

    /// <summary>
    /// Generate random sbyte number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Sbyte random number.</returns>
    public static sbyte RandomNumberSbyte(sbyte min, sbyte max) => (sbyte)(min > max ? 0 : new Random().Next(min, max));
}
