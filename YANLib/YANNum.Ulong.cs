using System.Numerics;

namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of an unsigned long integer using the default format.
    /// Returns the parsed <see cref="ulong"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ulong"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static ulong ToUlong(this string str) => ulong.TryParse(str, out var num) ? num : default;

    public static ulong ToUlong<T>(this string str, T dfltVal) where T : struct => ulong.TryParse(str, out var num) ? num : dfltVal.ToUlong();

    public static ulong ToUlong<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToUInt64(num);
        }
        catch
        {
            return default;
        }
    }

    public static ulong GenRandomUlong<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToUlong();
        var maxValue = max.ToUlong();
        return minValue > maxValue ? default : (new Random().NextInt64(long.MinValue, (long)(maxValue - (minValue - (BigInteger)long.MinValue))) - long.MinValue).ToUlong() + minValue;
    }

    public static ulong GenRandomUlong() => GenRandomUlong(ulong.MinValue, ulong.MaxValue);

    public static ulong GenRandomUlong<T>(T max) where T : struct => GenRandomUlong(ulong.MinValue, max);
}
