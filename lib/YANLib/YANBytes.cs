using static System.Text.Encoding;

namespace YANLib;

public static partial class YANBytes
{
    /// <summary>
    /// Converts the specified object to a byte array using UTF-8 encoding.
    /// If the object is <see langword="null"/>, returns <see langword="null"/>.
    /// The object is serialized to a string, and if the serialization returns <see langword="null"/>, an empty string is used for the byte conversion.
    /// </summary>
    /// <param name="val">The object to be converted to a byte array. Can be <see langword="null"/>.</param>
    /// <returns>A byte array representing the UTF-8 encoded serialization of the input object, or <see langword="null"/> if the input object is <see langword="null"/>.</returns>
    public static byte[]? ToByteArray(this object? val) => val is null ? default : UTF8.GetBytes(val.StandardSerialize() ?? string.Empty);

    /// <summary>
    /// Converts a collection of objects to an enumerable collection of byte arrays.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a byte array.
    /// </summary>
    /// <param name="vals">The collection of objects to be converted to byte arrays. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of byte arrays, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<byte[]?>? ToByteArrays(this IEnumerable<object?>? vals) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToByteArray());

    /// <summary>
    /// Converts a collection (ICollection) of objects to an enumerable collection of byte arrays.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is converted to a byte array.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be converted to byte arrays. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of byte arrays, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<byte[]?>? ToByteArrays(this ICollection<object?>? vals) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToByteArray());

    /// <summary>
    /// Converts an array of objects to an enumerable collection of byte arrays.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is converted to a byte array.
    /// </summary>
    /// <param name="vals">The array of objects to be converted to byte arrays. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of byte arrays, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<byte[]?>? ToByteArrays(this object?[]? vals) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToByteArray());

    /// <summary>
    /// Converts a byte array to its equivalent object of type <typeparamref name="T"/>.
    /// If the byte array is <see langword="null"/>, returns the default value of type <typeparamref name="T"/>.
    /// Otherwise, converts the byte array to a string using UTF-8 encoding and deserializes it to an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arr">The byte array to be converted. Can be <see langword="null"/>.</param>
    /// <returns>The object of type <typeparamref name="T"/> represented by the deserialized byte array, or the default value of type <typeparamref name="T"/> if the byte array is <see langword="null"/>.</returns>
    public static T? FromByteArray<T>(this byte[]? arr) => arr is null ? default : UTF8.GetString(arr).Deserialize<T>();

    /// <summary>
    /// Converts a collection of byte arrays to an enumerable collection of objects of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each byte array in the collection is converted to an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arrs">The collection of byte arrays to be converted. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T?>? FromByteArrays<T>(this IEnumerable<byte[]?>? arrs) => arrs.IsEmptyOrNull() ? default : arrs.Select(x => x.FromByteArray<T>());

    /// <summary>
    /// Converts a collection (ICollection) of byte arrays to an enumerable collection of objects of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each byte array in the collection is converted to an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arrs">The ICollection of byte arrays to be converted. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T?>? FromByteArrays<T>(this ICollection<byte[]?>? arrs) => arrs.IsEmptyOrNull() ? default : arrs.Select(x => x.FromByteArray<T>());

    /// <summary>
    /// Converts an array of byte arrays to an enumerable collection of objects of type <typeparamref name="T"/>.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each byte array in the array is converted to an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arrs">The array of byte arrays to be converted. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T?>? FromByteArrays<T>(this byte[]?[]? arrs) => arrs.IsEmptyOrNull() ? default : arrs.Select(x => x.FromByteArray<T>());
}
