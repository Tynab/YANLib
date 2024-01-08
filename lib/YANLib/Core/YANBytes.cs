using static System.Text.Encoding;

namespace YANLib.Core;

public static partial class YANBytes
{
    /// <summary>
    /// Converts the specified object to a byte array using UTF-8 encoding.
    /// If the object is <see langword="null"/>, returns <see langword="null"/>.
    /// The object is serialized to a string, and if the serialization returns <see langword="null"/>, an empty string is used for the byte conversion.
    /// </summary>
    /// <param name="val">The object to be converted to a byte array. Can be <see langword="null"/>.</param>
    /// <returns>A byte array representing the UTF-8 encoded serialization of the input object, or <see langword="null"/> if the input object is <see langword="null"/>.</returns>
    public static byte[]? ToByteArray(this object? val) => val.IsNull() ? default : UTF8.GetBytes(val.StandardSerialize() ?? string.Empty);

    public static IEnumerable<byte[]?>? ToByteArrays(this IEnumerable<object?>? vals) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToByteArray());

    public static IEnumerable<byte[]?>? ToByteArrays(this ICollection<object?>? vals) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToByteArray());

    public static IEnumerable<byte[]?>? ToByteArrays(params object?[]? vals) => vals.IsEmptyOrNull() ? default : vals.Select(x => x.ToByteArray());

    /// <summary>
    /// Converts a byte array to its equivalent object of type <typeparamref name="T"/>.
    /// If the byte array is <see langword="null"/>, returns the default value of type <typeparamref name="T"/>.
    /// Otherwise, converts the byte array to a string using UTF-8 encoding and deserializes it to an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <param name="arr">The byte array to be converted. Can be <see langword="null"/>.</param>
    /// <returns>The object of type <typeparamref name="T"/> represented by the deserialized byte array, or the default value of type <typeparamref name="T"/> if the byte array is <see langword="null"/>.</returns>
    public static T? FromByteArray<T>(this byte[]? arr) => arr.IsNull() ? default : UTF8.GetString(arr).Deserialize<T>();

    public static IEnumerable<T?>? FromByteArrays<T>(this IEnumerable<byte[]?>? arrs) => arrs.IsEmptyOrNull() ? default : arrs.Select(x => x.FromByteArray<T>());

    public static IEnumerable<T?>? FromByteArrays<T>(this ICollection<byte[]?>? arrs) => arrs.IsEmptyOrNull() ? default : arrs.Select(x => x.FromByteArray<T>());

    public static IEnumerable<T?>? FromByteArrays<T>(params byte[]?[]? arrs) => arrs.IsEmptyOrNull() ? default : arrs.Select(x => x.FromByteArray<T>());
}
