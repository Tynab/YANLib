namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an integer using the default format.
    /// Returns the parsed <see cref="int"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="int"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static int ToInt(this string str) => int.TryParse(str, out var num) ? num : default;

    public static int ToInt<T>(this string str, T dfltVal) where T : struct => int.TryParse(str, out var num) ? num : dfltVal.ToInt();

    public static int ToInt<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToInt32(num);
        }
        catch
        {
            return default;
        }
    }

    public static int GenRandomInt<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToInt();
        var maxValue = max.ToInt();
        return minValue > maxValue ? default : new Random().Next(minValue, maxValue);
    }

    public static int GenRandomInt() => GenRandomInt(int.MinValue, int.MaxValue);

    public static int GenRandomInt<T>(T max) where T : struct => GenRandomInt(int.MinValue, max);
}
