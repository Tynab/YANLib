using System.Numerics;

namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Parses the string representation of a <see cref="nuint"/> using the default format.
    /// Returns the parsed <see cref="nuint"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nuint"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static nuint ToNuint(this string str) => nuint.TryParse(str, out var num) ? num : default;

    public static nuint ToNuint<T>(this string str, T dfltVal) where T : struct => nuint.TryParse(str, out var num) ? num : dfltVal.ToNuint();

    public static nuint ToNuint<T>(this T num) where T : struct
    {
        try
        {
            return new UIntPtr(Convert.ToUInt64(num));
        }
        catch
        {
            return default;
        }
    }

    public static nuint GenRandomNuint<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToNuint();
        var maxValue = max.ToNuint();
        return minValue > maxValue ? default : (new Random().NextInt64(nint.MinValue, (long)(maxValue - (minValue - (BigInteger)nint.MinValue))) - nint.MinValue).ToNuint() + minValue;
    }

    public static nuint GenRandomNuint() => GenRandomNuint(nuint.MinValue, nuint.MaxValue);

    public static nuint GenRandomNuint<T>(T max) where T : struct => GenRandomNuint(nuint.MinValue, max);
}
