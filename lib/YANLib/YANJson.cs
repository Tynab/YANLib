using System.Text.Json;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for JSON serialization and deserialization.
/// This static partial class offers methods to convert objects or collections of objects
/// to JSON strings and to parse JSON strings or byte arrays into objects. It supports both
/// single instances and collections, as well as custom <see cref="JsonSerializerOptions"/>.
/// </summary>
public static partial class YANJson
{
    /// <summary>
    /// Serializes the specified object to its JSON string representation.
    /// If the input is null, the method returns null.
    /// If no serializer options are provided, a default camelCase naming policy is used.
    /// </summary>
    /// <param name="input">The object to serialize. May be null.</param>
    /// <param name="options">
    /// Optional <see cref="JsonSerializerOptions"/> to customize the serialization.
    /// If not provided, default options (including camelCase naming) are used.
    /// </param>
    /// <returns>
    /// A JSON string representing the input object, or null if the input is null.
    /// </returns>
    public static string? Serialize(this object? input, JsonSerializerOptions? options = null) => input.SerializeImplement(options);

    /// <summary>
    /// Serializes each object in the specified enumerable collection to its JSON string representation.
    /// If the input collection is null or empty, the method returns null.
    /// </summary>
    /// <param name="input">The collection of objects to serialize. May be null or empty.</param>
    /// <param name="options">
    /// Optional <see cref="JsonSerializerOptions"/> to customize the serialization.
    /// If not provided, default options (including camelCase naming) are used.
    /// </param>
    /// <returns>
    /// An enumerable collection of JSON strings corresponding to each object in the input,
    /// or null if the input collection is null or empty.
    /// </returns>
    public static IEnumerable<string?>? Serializes(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.SerializesImplement(options);

    /// <summary>
    /// Serializes each object from the specified array to its JSON string representation.
    /// If the input array is null or empty, the method returns null.
    /// </summary>
    /// <param name="input">A params array of objects to serialize. May be null or empty.</param>
    /// <returns>
    /// An enumerable collection of JSON strings for each provided object, or null if the input is null or empty.
    /// </returns>
    public static IEnumerable<string?>? Serializes(params object?[]? input) => input.SerializesImplement();

    /// <summary>
    /// Deserializes the specified JSON string to an object of type <typeparamref name="T"/>.
    /// If the input is null, empty, or consists only of whitespace, the method returns default for <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type into which to deserialize the JSON string.</typeparam>
    /// <param name="input">The JSON string to deserialize. May be null or whitespace.</param>
    /// <param name="options">
    /// Optional <see cref="JsonSerializerOptions"/> to customize the deserialization.
    /// If not provided, default options (including property name case-insensitivity) are used.
    /// </param>
    /// <returns>
    /// An instance of type <typeparamref name="T"/> representing the deserialized JSON, or default(T) if deserialization fails.
    /// </returns>
    public static T? Deserialize<T>(this string? input, JsonSerializerOptions? options = null) => input.DeserializeImplement<T>(options);

    /// <summary>
    /// Deserializes each JSON string in the specified enumerable collection into objects of type <typeparamref name="T"/>.
    /// If the input collection is null or empty, the method returns null.
    /// </summary>
    /// <typeparam name="T">The type into which to deserialize each JSON string.</typeparam>
    /// <param name="input">The collection of JSON strings to deserialize. May be null or empty.</param>
    /// <param name="options">
    /// Optional <see cref="JsonSerializerOptions"/> to customize the deserialization.
    /// If not provided, default options (including property name case-insensitivity) are used.
    /// </param>
    /// <returns>
    /// An enumerable collection of objects of type <typeparamref name="T"/> resulting from deserialization,
    /// or null if the input collection is null or empty.
    /// </returns>
    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<string?>? input, JsonSerializerOptions? options = null) => input.DeserializesImplement<T>(options);

    /// <summary>
    /// Deserializes each JSON string in the specified params array into objects of type <typeparamref name="T"/>.
    /// If the input array is null or empty, the method returns null.
    /// </summary>
    /// <typeparam name="T">The type into which to deserialize each JSON string.</typeparam>
    /// <param name="input">A params array of JSON strings. May be null or empty.</param>
    /// <returns>
    /// An enumerable collection of objects of type <typeparamref name="T"/> obtained from deserializing the input JSON strings,
    /// or null if the input is null or empty.
    /// </returns>
    public static IEnumerable<T?>? Deserializes<T>(params string?[]? input) => input.DeserializesImplement<T>();

    /// <summary>
    /// Deserializes the specified byte array into an object of type <typeparamref name="T"/>.
    /// If the input byte array is null, the method returns default for <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type into which to deserialize the byte array.</typeparam>
    /// <param name="input">The byte array representing JSON data. May be null.</param>
    /// <param name="options">
    /// Optional <see cref="JsonSerializerOptions"/> to customize the deserialization.
    /// If not provided, default options (including property name case-insensitivity) are used.
    /// </param>
    /// <returns>
    /// An instance of type <typeparamref name="T"/> resulting from deserialization of the byte array,
    /// or default(T) if deserialization fails.
    /// </returns>
    public static T? Deserialize<T>(this byte[]? input, JsonSerializerOptions? options = null) => input.DeserializeImplement<T>(options);

    /// <summary>
    /// Deserializes each byte array in the specified enumerable collection into objects of type <typeparamref name="T"/>.
    /// If the input collection is null or empty, the method returns null.
    /// </summary>
    /// <typeparam name="T">The type into which to deserialize each byte array.</typeparam>
    /// <param name="input">The collection of byte arrays representing JSON data. May be null or empty.</param>
    /// <param name="options">
    /// Optional <see cref="JsonSerializerOptions"/> to customize the deserialization.
    /// If not provided, default options (including property name case-insensitivity) are used.
    /// </param>
    /// <returns>
    /// An enumerable collection of objects of type <typeparamref name="T"/> obtained from the deserialization of the input byte arrays,
    /// or null if the input collection is null or empty.
    /// </returns>
    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<byte[]?>? input, JsonSerializerOptions? options = null) => input.DeserializesImplement<T>(options);

    /// <summary>
    /// Deserializes each byte array from the specified params array into objects of type <typeparamref name="T"/>.
    /// If the input array is null or empty, the method returns null.
    /// </summary>
    /// <typeparam name="T">The type into which to deserialize each byte array.</typeparam>
    /// <param name="input">A params array of byte arrays representing JSON data. May be null or empty.</param>
    /// <returns>
    /// An enumerable collection of deserialized objects of type <typeparamref name="T"/>,
    /// or null if the input is null or empty.
    /// </returns>
    public static IEnumerable<T?>? Deserializes<T>(params byte[]?[]? input) => input.DeserializesImplement<T>();
}
