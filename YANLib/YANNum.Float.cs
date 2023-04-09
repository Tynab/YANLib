namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a <see cref="float"/> using the default format.
    /// Returns the parsed <see cref="float"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="float"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static float ToFloat(this string str) => float.TryParse(str, out var num) ? num : default;

    public static float ToFloat<T>(this string str, T dfltVal) where T : struct => float.TryParse(str, out var num) ? num : dfltVal.ToFloat();

    public static float ToFloat<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToSingle(num);
        }
        catch
        {
            return default;
        }
    }

    public static float GenRandomFloat<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToFloat();
        var maxValue = max.ToFloat();
        return minValue > maxValue ? default : new Random().NextSingle(minValue, maxValue);
    }

    public static float GenRandomFloat() => GenRandomFloat(float.MinValue, float.MaxValue);

    public static float GenRandomFloat<T>(T max) where T : struct => GenRandomFloat(float.MinValue, max);
}
