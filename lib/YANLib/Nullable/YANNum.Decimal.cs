namespace YANLib.Nullable;

public partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a decimal.
    /// Returns the converted <see cref="decimal"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="decimal"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static decimal? ToDecimal<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToDecimal(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Converts an enumerable of values of a generic value type to an <see cref="IEnumerable{decimal}"/> containing the decimal representations of the values.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/> or empty.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the values to be converted, which must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of values to be converted.</param>
    /// <returns>An <see cref="IEnumerable{decimal}"/> containing the decimal representations of the values.</returns>
    public static IEnumerable<decimal?> ToDecimal<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToDecimal();
        }
    }

    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static decimal? ToDecimal(this string str) => decimal.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{decimal}"/> containing the decimal representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/> or empty.
    /// </summary>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{decimal}"/> containing the decimal representations of the strings.</returns>
    public static IEnumerable<decimal?> ToDecimal(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDecimal();
        }
    }

    /// <summary>
    /// Parses the string representation of a decimal using the default format.
    /// Returns the parsed <see cref="decimal"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="decimal"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static decimal? ToDecimal<T>(this string str, T dfltVal) where T : struct => decimal.TryParse(str, out var num) ? num : dfltVal.ToDecimal();

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{decimal}"/> containing the decimal representations of the strings, using a default value for invalid conversions.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/> or empty.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for invalid conversions.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for invalid conversions.</param>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{decimal}"/> containing the decimal representations of the strings.</returns>
    public static IEnumerable<decimal?> ToDecimal<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToDecimal(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="decimal"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static decimal? GenerateRandomDecimal<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToDecimal();
        var maxValue = max.ToDecimal();
        return minValue.HasValue && maxValue.HasValue ? minValue > maxValue ? default : new Random().NextDecimal(minValue.Value, maxValue.Value) : default;
    }

    /// <summary>
    /// Generates an <see cref="IEnumerable{decimal}"/> sequence of random decimal values between <paramref name="min"/> and <paramref name="max"/>, with the number of values specified by <paramref name="size"/>, using a default value for invalid conversions.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The number of random decimal values to generate.</param>
    /// <returns>An <see cref="IEnumerable{decimal}"/> containing the randomly generated decimal values.</returns>
    public static IEnumerable<decimal?> GenerateRandomDecimals<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < YANLib.YANNum.ToUlong(size); i++)
        {
            yield return GenerateRandomDecimal(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <see cref="decimal.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <see cref="decimal.MaxValue"/>.</returns>
    public static decimal? GenerateRandomDecimal() => GenerateRandomDecimal(decimal.MinValue, decimal.MaxValue);

    /// <summary>
    /// Generates a random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="decimal"/> value between <see cref="decimal.MinValue"/> and <paramref name="max"/>.</returns>
    public static decimal? GenerateRandomDecimal<T>(T max) where T : struct => GenerateRandomDecimal(decimal.MinValue, max);
}
