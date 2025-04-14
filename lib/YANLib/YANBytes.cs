using YANLib.Implementation;

namespace YANLib;

public static partial class YANBytes
{
    /// <summary>
    /// Converts the specified object to a byte array using UTF-8 encoding.
    /// If the object is <see langword="null"/>, returns <see langword="null"/>.
    /// The object is serialized to a string, and if the serialization returns <see langword="null"/>, an empty string is used for the byte conversion.
    /// </summary>
    /// <param name="input">The object to be converted to a byte array. Can be <see langword="null"/>.</param>
    /// <returns>A byte array representing the UTF-8 encoded serialization of the input object, or <see langword="null"/> if the input object is <see langword="null"/>.</returns>
    public static byte[]? ToByteArray(this object? input) => input.ToByteArrayImplement();

    /// <summary>
    /// Converts a collection of objects into their respective byte array representations using UTF-8 encoding.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the collection is serialized and converted to a byte array.
    /// </summary>
    /// <param name="input">The collection of objects to be converted to byte arrays. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of byte arrays representing the UTF-8 encoded serializations of the input objects, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<byte[]?>? ToByteArrays(this IEnumerable<object?>? input) => input.ToByteArraysImplement();

    /// <summary>
    /// Converts an array of objects into their respective byte array representations using UTF-8 encoding.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each object in the array is serialized and converted to a byte array.
    /// </summary>
    /// <param name="input">The array of objects to be converted to byte arrays. Can be <see langword="null"/>.</param>
    /// <returns>An array of byte arrays representing the UTF-8 encoded serializations of the input objects, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<byte[]?>? ToByteArrays(params object?[]? input) => input.ToByteArraysImplement();

    /// <summary>
    /// Converts a byte array to its equivalent object of type <typeparamref name="T"/>.
    /// If the byte array is <see langword="null"/>, returns the default value of type <typeparamref name="T"/>.
    /// Otherwise, converts the byte array to a string using UTF-8 encoding and deserializes it to an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="input">The byte array to be converted. Can be <see langword="null"/>.</param>
    /// <returns>The object of type <typeparamref name="T"/> represented by the deserialized byte array, or the default value of type <typeparamref name="T"/> if the byte array is <see langword="null"/>.</returns>
    public static T? FromByteArray<T>(this byte[]? input) => input.FromByteArrayImplement<T>();

    /// <summary>
    /// Deserializes a collection of byte arrays into their respective objects of type <typeparamref name="T"/>.
    /// If the collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each byte array in the collection is deserialized into an object of type <typeparamref name="T"/>; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the byte arrays are to be deserialized.</typeparam>
    /// <param name="input">The collection of byte arrays to be deserialized. Can be <see langword="null"/>.</param>
    /// <returns>
    /// An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the byte arrays, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.
    /// </returns>
    public static IEnumerable<T?>? FromByteArrays<T>(this IEnumerable<byte[]?>? input) => input.FromByteArraysImplement<T>();

    /// <summary>
    /// Deserializes an array of byte arrays into their respective objects of type <typeparamref name="T"/>.
    /// If the array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// Each byte array in the array is deserialized into an object of type <typeparamref name="T"/>; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the byte arrays are to be deserialized.</typeparam>
    /// <param name="input">The array of byte arrays to be deserialized. Can be <see langword="null"/>.</param>
    /// <returns>An array of objects of type <typeparamref name="T"/> representing the deserialized results from the byte arrays, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T?>? FromByteArrays<T>(params byte[]?[]? input) => input.FromByteArraysImplement<T>();
}
