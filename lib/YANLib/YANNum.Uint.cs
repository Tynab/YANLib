namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to an unsigned integer.
    /// Returns the converted <see cref="uint"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="uint"/> value, or <see langword="default"/> if the conversion fails.</returns>
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

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{byte}"/> containing the byte representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the objects.</returns>
    public static IEnumerable<uint> ToUint<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToUint();
        }
    }

    /// <summary>
    /// Parses the string representation of an unsigned integer using the default format.
    /// Returns the parsed <see cref="uint"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="uint"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static uint ToUint(this string str) => uint.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Converts an enumerable of strings to an <see cref="IEnumerable{uint}"/> containing the uint representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{uint}"/> containing the uint representations of the strings.</returns>
    public static IEnumerable<uint> ToUint(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUint();
        }
    }

    /// <summary>
    /// Parses the string representation of an unsigned integer using the default format.
    /// Returns the parsed <see cref="uint"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="uint"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static uint ToUint<T>(this string str, T dfltVal) where T : struct => uint.TryParse(str, out var num) ? num : dfltVal.ToUint();

    /// <summary>
    /// Converts an enumerable of strings to an <see cref="IEnumerable{uint}"/> containing the uint representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value for the conversion to uint.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <param name="dfltVal">The default value for the conversion to uint.</param>
    /// <returns>An <see cref="IEnumerable{uint}"/> containing the uint representations of the strings.</returns>
    public static IEnumerable<uint> ToUint<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUint(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="uint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static uint GenerateRandomUint<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToUint();
        var maxValue = max.ToUint();
        return minValue > maxValue ? default : new Random().NextInt64(minValue, maxValue).ToUint();
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="uint"/> values between <paramref name="min"/> and <paramref name="max"/>.
    /// The size of the enumerable is determined by the <paramref name="size"/> parameter.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty enumerable is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size parameter, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable.</param>
    /// <returns>An enumerable of random <see cref="uint"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<uint> GenerateRandomUints<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUint(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <see cref="uint.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <see cref="uint.MaxValue"/>.</returns>
    public static uint GenerateRandomUint() => GenerateRandomUint(uint.MinValue, uint.MaxValue);

    /// <summary>
    /// Generates a random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="uint"/> value between <see cref="uint.MinValue"/> and <paramref name="max"/>.</returns>
    public static uint GenerateRandomUint<T>(T max) where T : struct => GenerateRandomUint(uint.MinValue, max);
}
