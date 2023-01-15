namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Try parse string to ushort, if failed return 0.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Ushort number.</returns>
    public static ushort ParseUshort(this string str)
    {
        _ = ushort.TryParse(str, out var num);
        return num;
    }

    /// <summary>
    /// Try parse string to ushort, if failed return default value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <param name="dfltVal">Default value.</param>
    /// <returns>Ushort number.</returns>
    public static ushort ParseUshort(this string str, ushort dfltVal) => ushort.TryParse(str, out var num) ? num : dfltVal;

    /// <summary>
    /// Try parse string to ushort, if failed return min value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Ushort number.</returns>
    public static ushort ParseUshortMin(this string str) => ushort.TryParse(str, out var num) ? num : ushort.MinValue;

    /// <summary>
    /// Try parse string to ushort, if failed return max value.
    /// </summary>
    /// <param name="str">Input string.</param>
    /// <returns>Ushort number.</returns>
    public static ushort ParseUshortMax(this string str) => ushort.TryParse(str, out var num) ? num : ushort.MaxValue;

    /// <summary>
    /// Generate random ushort number.
    /// </summary>
    /// <returns>Ushort random number.</returns>
    public static ushort RandomNumberUshort() => (ushort)new Random().Next(ushort.MinValue, ushort.MaxValue);

    /// <summary>
    /// Generate random ushort number with max value.
    /// </summary>
    /// <param name="max">The exclusive upper bound of the random number to be generated. <paramref name="max"/> must be greater than or equal to 0.</param>
    /// <returns>Ushort random number.</returns>
    public static ushort RandomNumberUshort(ushort max) => (ushort)new Random().Next(ushort.MinValue, max);

    /// <summary>
    /// Generate random ushort number with min and max value.
    /// </summary>
    /// <param name="min">The inclusive lower bound of the random number returned.</param>
    /// <param name="max">The exclusive upper bound of the random number returned. <paramref name="max"/> must be greater than or equal to <paramref name="min"/>. If not, return 0.</param>
    /// <returns>Ushort random number.</returns>
    public static ushort RandomNumberUshort(ushort min, ushort max) => (ushort)(min > max ? 0 : new Random().Next(min, max));
}
