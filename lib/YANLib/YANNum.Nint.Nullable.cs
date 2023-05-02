namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a native integer (nint).
    /// Returns the converted <see cref="nint"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="nint"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static nint ToNint<T>(this T? num) where T : struct
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
    /// Converts an enumerable of value-type objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{nint}"/> containing the nint representations of the objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value-type objects to be converted.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="nums">The enumerable of value-type objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{nint}"/> containing the nint representations of the objects.</returns>
    public static IEnumerable<nint> ToNint<T>(this IEnumerable<T?> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToNint();
        }
    }

    /// <summary>
    /// Parses the string representation of a pointer-sized signed integer using the default format.
    /// Returns the parsed <see cref="nint"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="nint"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static nint ToNint<T>(this string str, T? dfltVal) where T : struct => dfltVal.HasValue ? str.ToNint(dfltVal.Value) : default;

    /// <summary>
    /// Converts an enumerable of strings to an <see cref="IEnumerable{nint}"/> containing the nint representations of the strings, with an optional default value for conversion.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value for conversion.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="strs">The enumerable of strings to be converted.</param>
    /// <param name="dfltVal">
    /// The default value for conversion if a string cannot be parsed to nint.
    /// Used when conversion fails for a particular string.
    /// </param>
    /// <returns>An <see cref="IEnumerable{nint}"/> containing the nint representations of the strings.</returns>
    public static IEnumerable<nint> ToNint<T>(this IEnumerable<string> strs, T? dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToNint(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint GenerateRandomNint<T1, T2>(T1? min, T2 max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNint(min.Value, max) : default;

    /// <summary>
    /// Generates an enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>, with a specified size.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable, specifying the number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1? min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>, with a specified size.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable, specifying the number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1? min, T2 max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint GenerateRandomNint<T1, T2>(T1 min, T2? max) where T1 : struct where T2 : struct => max.HasValue ? GenerateRandomNint(min, max.Value) : default;

    /// <summary>
    /// Generates an enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>, with a specified size.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable, specifying the number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1 min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>, with a specified size.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable, specifying the number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1 min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static nint GenerateRandomNint<T1, T2>(T1? min, T2? max) where T1 : struct where T2 : struct => min.HasValue ? GenerateRandomNint(min.Value, max) : default;

    /// <summary>
    /// Generates an enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>, with a specified size.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable, specifying the number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1? min, T2? max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    /// <summary>
    /// Generates an enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>, with a specified size.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the enumerable, specifying the number of random values to generate.</param>
    /// <returns>An enumerable of random <see cref="IntPtr"/> values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<nint> GenerateRandomNints<T1, T2, T>(T1? min, T2? max, T? size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomNint(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="nint"/> value between <see cref="nint.MinValue"/> and <paramref name="max"/>.</returns>
    public static nint GenerateRandomNint<T>(T? max) where T : struct => max.HasValue ? GenerateRandomNint(nint.MinValue, max.Value) : default;
}
