using System.Text.Json;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANJson
{
    /// <summary>
    /// Serializes the specified object to a JSON string using the provided JsonSerializerOptions, with a default camel case property naming policy.
    /// Returns <see langword="null"/> if the object is <see langword="null"/>.
    /// Uses camel case property naming policy if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The object to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>A JSON string representation of the object, or <see langword="null"/> if the object is <see langword="null"/>.</returns>
    public static string? Serialize(this object? input, JsonSerializerOptions? options = null) => input.SerializeImplement(options);

    /// <summary>
    /// Serializes a collection of objects to a collection of JSON strings using the provided JsonSerializerOptions, with a default camel case property naming policy.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty.
    /// Uses camel case property naming policy if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The collection of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of JSON strings, or <see langword="null"/> if the collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Serializes(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.SerializesImplement(options);

    public static IEnumerable<string?>? Serializes(params object?[]? input) => input.SerializesImplement();

    /// <summary>
    /// Deserializes the JSON string to an object of type <typeparamref name="T"/>, with property name case insensitivity.
    /// If the JSON string is <see langword="null"/>, empty, or white space, returns the default value of type <typeparamref name="T"/>.
    /// The deserialization uses the specified <see cref="JsonSerializerOptions"/> if provided; otherwise, it defaults to case-insensitive property names.
    /// If deserialization fails, returns the default value of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of object to deserialize to.</typeparam>
    /// <param name="input">The JSON string to deserialize. Can be <see langword="null"/> or white space.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> to use for deserialization. Can be <see langword="null"/>. Defaults to case-insensitive property names if <see langword="null"/>.</param>
    /// <returns>The deserialized object of type <typeparamref name="T"/>, or the default value of type <typeparamref name="T"/> if deserialization fails or the JSON string is <see langword="null"/> or white space.</returns>
    public static T? Deserialize<T>(this string? input, JsonSerializerOptions? options = null) => input.DeserializeImplement<T>(options);

    /// <summary>
    /// Deserializes a collection of JSON strings into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions, with a default case-insensitive property name policy.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty, or if deserialization of any JSON string fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The collection of JSON strings to be deserialized. Can be <see langword="null"/> or contain white-space strings.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the collection is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<string?>? input, JsonSerializerOptions? options = null) => input.DeserializesImplement<T>(options);

    public static IEnumerable<T?>? Deserializes<T>(params string?[]? input) => input.DeserializesImplement<T>();

    /// <summary>
    /// Deserializes the UTF-8 JSON byte array into an object of type <typeparamref name="T"/> using the provided JsonSerializerOptions, with a default case-insensitive property name policy.
    /// Returns the default value of <typeparamref name="T"/> if the byte array is <see langword="null"/>, or if deserialization fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The UTF-8 JSON byte array to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An object of type <typeparamref name="T"/> deserialized from the byte array, or the default value of <typeparamref name="T"/> if deserialization fails.</returns>
    public static T? Deserialize<T>(this byte[]? input, JsonSerializerOptions? options = null) => input.DeserializeImplement<T>(options);

    /// <summary>
    /// Deserializes a collection of UTF-8 JSON byte arrays into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions, with a default case-insensitive property name policy.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty, or if deserialization of any byte array fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The collection of UTF-8 JSON byte arrays to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the collection is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<byte[]?>? input, JsonSerializerOptions? options = null) => input.DeserializesImplement<T>(options);

    public static IEnumerable<T?>? Deserializes<T>(params byte[]?[]? input) => input.DeserializesImplement<T>();
}
