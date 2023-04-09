namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an unsigned integer using the default format.
    /// Returns the parsed <see cref="uint"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="uint"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static uint ToUint(this string str) => uint.TryParse(str, out var num) ? num : default;

    public static uint ToUint<T>(this string str, T dfltVal) where T : struct => uint.TryParse(str, out var num) ? num : dfltVal.ToUint();

    public static uint ToUint<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToUInt32(num);
        }
        catch
        {
            return default;
        }
    }

    public static uint GenRandomUint<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToUint();
        var maxValue = max.ToUint();
        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToUint();
    }

    public static uint GenRandomUint() => GenRandomUint(uint.MinValue, uint.MaxValue);

    public static uint GenRandomUint<T>(T max) where T : struct => GenRandomUint(uint.MinValue, max);
}
