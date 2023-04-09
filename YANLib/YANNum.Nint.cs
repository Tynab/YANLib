namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a nint using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static nint ToNint(this string str) => nint.TryParse(str, out var num) ? num : default;

    public static nint ToNint<T>(this string str, T dfltVal) where T : struct => nint.TryParse(str, out var num) ? num : dfltVal.ToNint();

    public static nint ToNint<T>(this T num) where T : struct
    {
        try
        {
            return new IntPtr(Convert.ToInt64(num));
        }
        catch
        {
            return default;
        }
    }

    public static nint GenRandomNint<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToNint();
        var maxValue = max.ToNint();
        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToNint();
    }

    public static nint GenRandomNint() => GenRandomNint(nint.MinValue, nint.MaxValue);

    public static nint GenRandomNint<T>(T max) where T : struct => GenRandomNint(nint.MinValue, max);
}
