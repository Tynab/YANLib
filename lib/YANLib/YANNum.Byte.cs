namespace YANLib;

public static partial class YANNum
{
    /// <summary>
    /// Converts the specified value to a byte.
    /// Returns the converted <see cref="byte"/> value, or <see langword="default"/> if the conversion fails.
    /// </summary>
    /// <typeparam name="T">The type of the value to be converted, which must be a value type.</typeparam>
    /// <param name="num">The value to be converted.</param>
    /// <returns>The converted <see cref="byte"/> value, or <see langword="default"/> if the conversion fails.</returns>
    public static byte ToByte<T>(this T num) where T : struct
    {
        try
        {
            return Convert.ToByte(num);
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
    public static IEnumerable<byte> ToByte<T>(params T[] nums) where T : struct
    {
        if(nums is null || nums.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Length; i++)
        {
            yield return nums[i].ToByte();
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
    public static IEnumerable<byte> ToByte<T>(this IEnumerable<T> nums) where T : struct
    {
        if (nums is null || !nums.Any())
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToByte();
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
    public static IEnumerable<byte> ToByte<T>(this IReadOnlyCollection<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToByte();
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
    public static IEnumerable<byte> ToByte<T>(this IReadOnlyList<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < nums.Count; i++)
        {
            yield return nums[i].ToByte();
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
    public static IEnumerable<byte> ToByte<T>(this IReadOnlySet<T> nums) where T : struct
    {
        if (nums is null || nums.Count < 1)
        {
            yield break;
        }
        foreach (var num in nums)
        {
            yield return num.ToByte();
        }
    }

    /// <summary>
    /// Parses the string representation of a byte using the default format.
    /// Returns the parsed <see cref="byte"/> value, or <see langword="default"/> if the parsing fails.
    /// </summary>
    /// <param name="str">The string to be parsed.</param>
    /// <returns>The parsed <see cref="byte"/> value, or <see langword="default"/> if the parsing fails.</returns>
    public static byte ToByte(this string str) => byte.TryParse(str, out var num) ? num : default;

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte(params string[] strs)
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToByte();
        }
    }

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToByte();
        }
    }

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte(this IReadOnlyCollection<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToByte();
        }
    }

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte(this IReadOnlyList<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToByte();
        }
    }

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte(this IReadOnlySet<string> strs)
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToByte();
        }
    }

    /// <summary>
    /// Parses the string representation of a byte using the default format.
    /// Returns the parsed <see cref="byte"/> value, or <paramref name="dfltVal"/> if the parsing fails.
    /// </summary>
    /// <typeparam name="T">The type of the default value to be returned, which must be a value type.</typeparam>
    /// <param name="str">The string to be parsed.</param>
    /// <param name="dfltVal">The default value to be returned if the parsing fails.</param>
    /// <returns>The parsed <see cref="byte"/> value, or <paramref name="dfltVal"/> if the parsing fails.</returns>
    public static byte ToByte<T>(this string str, T dfltVal) where T : struct => byte.TryParse(str, out var num) ? num : dfltVal.ToByte();

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings, using a default value for invalid conversions.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for invalid conversions.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for invalid conversions.</param>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte<T>(T dfltVal, params string[] strs) where T : struct
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].ToByte(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings, using a default value for invalid conversions.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for invalid conversions.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for invalid conversions.</param>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte<T>(this IEnumerable<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToByte(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings, using a default value for invalid conversions.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for invalid conversions.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for invalid conversions.</param>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte<T>(this IReadOnlyCollection<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToByte(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings, using a default value for invalid conversions.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for invalid conversions.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for invalid conversions.</param>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte<T>(this IReadOnlyList<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].ToByte(dfltVal);
        }
    }

    /// <summary>
    /// Converts an enumerable of string objects to an <see cref="IEnumerable{byte}"/> containing the byte representations of the strings, using a default value for invalid conversions.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the default value to be used for invalid conversions.
    /// Must be a value type.
    /// </typeparam>
    /// <param name="dfltVal">The default value to be used for invalid conversions.</param>
    /// <param name="strs">The enumerable of string objects to be converted.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the byte representations of the strings.</returns>
    public static IEnumerable<byte> ToByte<T>(this IReadOnlySet<string> strs, T dfltVal) where T : struct
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var num in strs)
        {
            yield return num.ToByte(dfltVal);
        }
    }

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, <see langword="default"/> is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="byte"/> value between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static byte GenerateRandomByte<T1, T2>(T1 min, T2 max) where T1 : struct where T2 : struct
    {
        var minValue = min.ToByte();
        var maxValue = max.ToByte();
        return minValue > maxValue ? default : new Random().Next(minValue, maxValue).ToByte();
    }

    /// <summary>
    /// Generates a sequence of random <see cref="byte"/> values between <paramref name="min"/> and <paramref name="max"/> with a specified size.
    /// If <paramref name="min"/> is greater than <paramref name="max"/>, an empty sequence is returned.
    /// </summary>
    /// <typeparam name="T1">The type of the minimum value, which must be a value type.</typeparam>
    /// <typeparam name="T2">The type of the maximum value, which must be a value type.</typeparam>
    /// <typeparam name="T">The type of the size of the generated sequence, which must be a value type.</typeparam>
    /// <param name="min">The minimum value.</param>
    /// <param name="max">The maximum value.</param>
    /// <param name="size">The size of the generated sequence.</param>
    /// <returns>An <see cref="IEnumerable{byte}"/> containing the random byte values between <paramref name="min"/> and <paramref name="max"/>.</returns>
    public static IEnumerable<byte> GenerateRandomByte<T1, T2, T>(T1 min, T2 max, T size) where T1 : struct where T2 : struct where T : struct
    {
        for (var i = 0ul; i < size.ToUlong(); i++)
        {
            yield return GenerateRandomByte(min, max);
        }
    }

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <see cref="byte.MaxValue"/>.
    /// </summary>
    /// <returns>A random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <see cref="byte.MaxValue"/>.</returns>
    public static byte GenerateRandomByte() => GenerateRandomByte(byte.MinValue, byte.MaxValue);

    /// <summary>
    /// Generates a random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <paramref name="max"/>.
    /// </summary>
    /// <typeparam name="T">The type of the maximum value, which must be a value type.</typeparam>
    /// <param name="max">The maximum value.</param>
    /// <returns>A random <see cref="byte"/> value between <see cref="byte.MinValue"/> and <paramref name="max"/>.</returns>
    public static byte GenerateRandomByte<T>(T max) where T : struct => GenerateRandomByte(byte.MinValue, max);
}
