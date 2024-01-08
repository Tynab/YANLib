using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANBytes
{
    /// <summary>
    /// Converts a collection of objects to their respective byte array representations.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is converted to a byte array; if an object is <see langword="null"/>, a <see langword="null"/> byte array is yielded.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to byte arrays. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of byte arrays representing each object's byte array representation.</returns>
    public static IEnumerable<byte[]?> ToByteArrays(this IEnumerable<object?>? vals)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToByteArray();
        }
    }

    /// <summary>
    /// Converts a collection (ICollection) of objects to their respective byte array representations.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is converted to a byte array; if an object is <see langword="null"/>, a <see langword="null"/> byte array is yielded.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to byte arrays. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of byte arrays representing each object's byte array representation.</returns>
    public static IEnumerable<byte[]?> ToByteArrays(this ICollection<object?>? vals)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToByteArray();
        }
    }

    /// <summary>
    /// Converts an array of objects to their respective byte array representations.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each object in the array is converted to a byte array; if an object is <see langword="null"/>, a <see langword="null"/> byte array is yielded.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to byte arrays. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of byte arrays representing each object's byte array representation.</returns>
    public static IEnumerable<byte[]?> ToByteArrays(this object?[]? vals)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.ToByteArray();
        }
    }

    /// <summary>
    /// Converts a collection of byte arrays to their respective objects of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each byte array in the collection is converted to an object of type <typeparamref name="T"/>; if conversion fails or the byte array is <see langword="null"/>, a <see langword="null"/> value of type <typeparamref name="T"/> is yielded.
    /// </summary>
    /// <param name="arrs">The collection of byte arrays to be converted. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the byte arrays.</returns>
    public static IEnumerable<T?> FromByteArrays<T>(this IEnumerable<byte[]?>? arrs)
    {
        if (arrs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var arr in arrs)
        {
            yield return arr.FromByteArray<T>();
        }
    }

    /// <summary>
    /// Converts a collection (ICollection) of byte arrays to their respective objects of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each byte array in the collection is converted to an object of type <typeparamref name="T"/>; if conversion fails or the byte array is <see langword="null"/>, a <see langword="null"/> value of type <typeparamref name="T"/> is yielded.
    /// </summary>
    /// <param name="arrs">The ICollection of byte arrays to be converted. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the byte arrays.</returns>
    public static IEnumerable<T?> FromByteArrays<T>(this ICollection<byte[]?>? arrs)
    {
        if (arrs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var arr in arrs)
        {
            yield return arr.FromByteArray<T>();
        }
    }

    /// <summary>
    /// Converts an array of byte arrays to their respective objects of type <typeparamref name="T"/>.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each byte array in the array is converted to an object of type <typeparamref name="T"/>; if conversion fails or the byte array is <see langword="null"/>, a <see langword="null"/> value of type <typeparamref name="T"/> is yielded.
    /// </summary>
    /// <param name="arrs">The array of byte arrays to be converted. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the byte arrays.</returns>
    public static IEnumerable<T?> FromByteArrays<T>(this byte[]?[]? arrs)
    {
        if (arrs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var arr in arrs)
        {
            yield return arr.FromByteArray<T>();
        }
    }
}
