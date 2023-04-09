namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a signed byte using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static sbyte ToSbyte(this string str) => sbyte.TryParse(str, out var num) ? num : default;

    public static sbyte ToSbyte<T>(this string str, T dfltVal) where T : struct => sbyte.TryParse(str, out var num) ? num : dfltVal.ToSbyte();

    public static sbyte ToSbyte<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToSByte(num);
        }
        catch
        {
            return default;
        }
    }

    public static sbyte GenRandomSbyte<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToSbyte();
        var maxValue = max.ToSbyte();
        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToSbyte();
    }

    public static sbyte GenRandomSbyte() => GenRandomSbyte(sbyte.MinValue, sbyte.MaxValue);

    public static sbyte GenRandomSbyte<T>(T max) where T : struct => GenRandomSbyte(sbyte.MinValue, max);
}
