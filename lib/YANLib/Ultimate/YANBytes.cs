namespace YANLib.Ultimate;

public static partial class YANBytes
{
    /// <summary>
    /// Converts a collection of objects to an enumerable collection of byte arrays using UTF-8 encoding.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// For each object in the collection, serializes it and converts the serialized string to a byte array.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to byte arrays. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of byte arrays, each representing the UTF-8 encoded serialization of an element in the input collection, or <see langword="null"/> for each <see langword="null"/> object in the collection.</returns>
    public static IEnumerable<byte[]?>? ToByteArrays(this IEnumerable<object?> vals)
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
    /// Converts a collection of byte arrays to an enumerable collection of objects of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each byte array in the collection is converted to an object of type <typeparamref name="T"/> using UTF-8 encoding and deserialization.
    /// </summary>
    /// <param name="arrs">The collection of byte arrays to be converted. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, each represented by the deserialized byte array, or the default value of type <typeparamref name="T"/> for each <see langword="null"/> byte array in the collection.</returns>
    public static IEnumerable<T?>? FromByteArrays<T>(this IEnumerable<byte[]?> arrs)
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
