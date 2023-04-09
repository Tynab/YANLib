namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a short integer using the default format.
    /// Returns the parsed <see cref="short"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="short"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static short ToShort(this string str) => short.TryParse(str, out var num) ? num : default;

    public static short ToShort<T>(this string str, T dfltVal) where T : struct => short.TryParse(str, out var num) ? num : dfltVal.ToShort();

    public static short ToShort<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToInt16(num);
        }
        catch
        {
            return default;
        }
    }

    public static short GenRandomShort<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToShort();
        var maxValue = max.ToShort();
        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToShort();
    }

    public static short GenRandomShort() => GenRandomShort(short.MinValue, short.MaxValue);

    public static short GenRandomShort<T>(T max) where T : struct => GenRandomShort(short.MinValue, max);
}
