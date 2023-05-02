namespace YANLib;

public partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a signed byte (sbyte).
    /// Returns the converted <see cref="sbyte"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="sbyte"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static sbyte ToSbyte<T>(this T? num) where T : struct
    {
        try
        {
            return Convert.ToSByte(num);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{sbyte}"/> containing the signed byte representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{sbyte}"/> containing the signed byte representations of the objects.</returns>
    public static IEnumerable<sbyte> ToSbyte<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToSbyte();
        }
    }

    /// <summary>
    /// Parses the string representation of an <see cref="sbyte"/> using the default format.
    /// Returns the parsed <see cref="sbyte"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="sbyte"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static sbyte ToSbyte<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToSbyte(dfltVal.Value) : default;

    /// <summary>
    /// Converts an enumerable of strings to an <see cref="IEnumerable{sbyte}"/> containing the signed byte representations of the strings, using the specified default value for invalid string representations.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for invalid string representations.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <param name="dfltVal">The default value to be used for invalid string representations.</param>
    /// <returns>An <see cref="IEnumerable{sbyte}"/> containing the signed byte representations of the strings.</returns>
    public static IEnumerable<sbyte> ToSbyte<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToSbyte(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static sbyte GenerateRandomSbyte<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomSbyte(min.Value, max) : default;

    /// <summary>
    /// Generates an enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>, with the specified number of values to generate given by <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size parameter, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<sbyte> GenerateRandomSbytes<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomSbyte(min, max);
        }
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>, with the specified number of values to generate given by <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size parameter, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<sbyte> GenerateRandomSbytes<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomSbyte(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static sbyte GenerateRandomSbyte<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomSbyte(min, max.Value) : default;

    /// <summary>
    /// Generates an enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>, with the specified number of values to generate given by <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size parameter, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<sbyte> GenerateRandomSbytes<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomSbyte(min, max);
        }
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>, with the specified number of values to generate given by <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size parameter, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<sbyte> GenerateRandomSbytes<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomSbyte(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static sbyte GenerateRandomSbyte<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomSbyte(min.Value, max) : default;

    /// <summary>
    /// Generates an enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>, with the specified number of values to generate given by <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size parameter, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<sbyte> GenerateRandomSbytes<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomSbyte(min, max);
        }
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>, with the specified number of values to generate given by <paramref name="size"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size parameter, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="sbyte"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<sbyte> GenerateRandomSbytes<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomSbyte(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="sbyte"/> value between <see cref="sbyte.MinValue"/> and <paramref name="max"/>.</returns>
    public static sbyte GenerateRandomSbyte<T>(T? max) where T : struct => max.HasValue ? GenerateRandomSbyte(sbyte.MinValue, max.Value) : default;
}
