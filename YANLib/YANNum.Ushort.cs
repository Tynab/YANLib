namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an unsigned short integer using the default format.
    /// Returns the parsed <see cref="ushort"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ushort"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static ushort ToUshort(this string str) => ushort.TryParse(str, out var num) ? num : default;

    public static ushort ToUshort<T>(this string str, T dfltVal) where T : struct => ushort.TryParse(str, out var num) ? num : dfltVal.ToUshort();

    public static ushort ToUshort<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToUInt16(num);
        }
        catch
        {
            return default;
        }
    }

    public static ushort GenRandomUshort<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToUshort();
        var maxValue = max.ToUshort();
        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToUshort();
    }

    public static ushort GenRandomUshort() => GenRandomUshort(ushort.MinValue, ushort.MaxValue);

    public static ushort GenRandomUshort<T>(T max) where T : struct => GenRandomUshort(ushort.MinValue, max);
}
