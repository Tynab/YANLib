namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a unsigned short integer.
    /// Returns the converted <see cref="ushort"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="ushort"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static ushort ToUshort<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToUInt16(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{ushort}"/> containing the ushort representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ushort}"/> containing the ushort representations of the objects.</returns>
    public static IEnumerable<ushort> ToUshort<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToUshort();
        }
    }

    /// <summary>
    /// Parses the string representation of an unsigned short integer using the default format.
    /// Returns the parsed <see cref="ushort"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="ushort"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static ushort ToUshort(this string str) => ushort.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Converts an enumerable of strings to an <see cref="IEnumerable{ushort}"/> containing the ushort representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <returns>An <see cref="IEnumerable{ushort}"/> containing the ushort representations of the strings.</returns>
    public static IEnumerable<ushort> ToUshort(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUshort();
        }
    }

    /// <summary>
    /// Parses the string representation of an unsigned short using the default format.
    /// Returns the parsed <see cref="ushort"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="ushort"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static ushort ToUshort<T>(this string str, T dfltVal) where T : struct => ushort.TryParse(str, out var num) ? num : dfltVal.ToUshort();

    /// <summary>
    /// Converts an enumerable of strings to an <see cref="IEnumerable{ushort}"/> containing the ushort representations of the strings, using the specified default value for conversion failure.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value for conversion failure.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <param name="dfltVal">The default value to be used for conversion failure.</param>
    /// <returns>An <see cref="IEnumerable{ushort}"/> containing the ushort representations of the strings.</returns>
    public static IEnumerable<ushort> ToUshort<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToUshort(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="ushort"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static ushort GenerateRandomUshort<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToUshort();
        var maxValue = max.ToUshort();
        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToUshort();
    }

    /// <summary>
    /// Generates an enumerable sequence of random <see cref="ushort"/> values between <paramref name="min"/> and <paramref name="max"/>, with the specified size.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable sequence.</param>
    /// <returns>An enumerable sequence of random <see cref="ushort"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<ushort> GenerateRandomUshorts<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomUshort(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <see cref="ushort.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <see cref="ushort.MaxValue"/>.</returns>
    public static ushort GenerateRandomUshort() => GenerateRandomUshort(ushort.MinValue, ushort.MaxValue);

    /// <summary>
    /// Generates a random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="ushort"/> value between <see cref="ushort.MinValue"/> and <paramref name="max"/>.</returns>
    public static ushort GenerateRandomUshort<T>(T max) where T : struct => GenerateRandomUshort(ushort.MinValue, max);
}
