namespace YANLib.Nullable;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a native integer (nint).
    /// Returns the converted <see cref="nint"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="nint"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static nint? ToNint<T>(this T num) where T : struct
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

    /// <summary>
    /// Parses the string representation of a nint using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static nint? ToNint(this string str) => nint.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Parses the string representation of a nint using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static nint? ToNint<T>(this string str, T dfltVal) where T : struct => nint.TryParse(str, out var num) ? num : dfltVal.ToNint();

    /// <summary>
    /// Generates a random <see cref="IntPtr"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="IntPtr"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint? GenerateRandomNint<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToNint();
        var maxValue = max.ToNint();
        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().NextInt64(minValue.Value, maxValue.Value).ToNint() : default;
    }

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <see cref="nint.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <see cref="nint.MaxValue"/>.</returns>
    public static nint? GenerateRandomNint() => GenerateRandomNint(nint.MinValue, nint.MaxValue);

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <paramref name="max"/>.</returns>
    public static nint? GenerateRandomNint<T>(T max) where T : struct => GenerateRandomNint(nint.MinValue, max);
}
