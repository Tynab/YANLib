namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to an integer.
    /// Returns the converted <see cref="int"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="int"/> value, or <see langword="default"/> if the conversion fails.</returns>
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

    /// <summary>
    /// Parses the string representation of an integer using the default format.
    /// Returns the parsed <see cref="int"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="int"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static int ToInt(this string str) => int.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Parses the string representation of an integer using the default format.
    /// Returns the parsed <see cref="int"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="int"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static int ToInt<T>(this string str, T dfltVal) where T : struct => int.TryParse(str, out var num) ? num : dfltVal.ToInt();

    /// <summary>
    /// Generates a random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="int"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static int GenRandomInt<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToInt();
        var maxValue = max.ToInt();
        return minValue > maxValue ? default : new Random().Next(minValue, maxValue);
    }

    /// <summary>
    /// Generates a random <see cref="int"/> value between <see cref="int.MinValue"/> and <see cref="int.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="int"/> value between <see cref="int.MinValue"/> and <see cref="int.MaxValue"/>.</returns>
    public static int GenRandomInt() => GenRandomInt(int.MinValue, int.MaxValue);

    /// <summary>
    /// Generates a random <see cref="int"/> value between <see cref="int.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="int"/> value between <see cref="int.MinValue"/> and <paramref name="max"/>.</returns>
    public static int GenRandomInt<T>(T max) where T : struct => GenRandomInt(int.MinValue, max);
}
