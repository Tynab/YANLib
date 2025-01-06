using System.Text.Json;
using YANLib.Object;
using YANLib.Text;
using static System.Text.Json.JsonNamingPolicy;

namespace YANLib;

public static partial class YANJson
{
    private static readonly JsonSerializerOptions IsPropertyNameCaseInsensitive = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private static readonly JsonSerializerOptions CamelCasePropertyNamingPolicy = new()
    {
        PropertyNamingPolicy = CamelCase
    };

    /// <summary>
    /// Serializes the specified object to a JSON string using the provided JsonSerializerOptions.
    /// Returns <see langword="null"/> if the object is <see langword="null"/>.
    /// Uses default serialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The object to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>A JSON string representation of the object, or <see langword="null"/> if the object is <see langword="null"/>.</returns>
    public static string? StandardSerialize(this object? input, JsonSerializerOptions? options = null) => input.IsNull()
        ? default
        : options.IsNull()
        ? JsonSerializer.Serialize(input)
        : JsonSerializer.Serialize(input, options);

    /// <summary>
    /// Serializes a collection of objects to a collection of JSON strings using the provided JsonSerializerOptions.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty.
    /// Uses default serialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The collection of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of JSON strings, or <see langword="null"/> if the collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? StandardSerializes(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.StandardSerialize())
        : input.Select(x => x.StandardSerialize(options));

    /// <summary>
    /// Serializes a collection (ICollection) of objects to a collection of JSON strings using the provided JsonSerializerOptions.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty.
    /// Uses default serialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The ICollection of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of JSON strings, or <see langword="null"/> if the collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? StandardSerializes(this ICollection<object?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.StandardSerialize())
        : input.Select(x => x.StandardSerialize(options));

    /// <summary>
    /// Serializes an array of objects to a collection of JSON strings using the provided JsonSerializerOptions.
    /// Returns <see langword="null"/> if the array is <see langword="null"/> or empty.
    /// Uses default serialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The array of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of JSON strings, or <see langword="null"/> if the array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? StandardSerializes(this object?[]? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.StandardSerialize())
        : input.Select(x => x.StandardSerialize(options));

    /// <summary>
    /// Serializes the specified object to a JSON string using the provided JsonSerializerOptions, with a default camel case property naming policy.
    /// Returns <see langword="null"/> if the object is <see langword="null"/>.
    /// Uses camel case property naming policy if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The object to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>A JSON string representation of the object, or <see langword="null"/> if the object is <see langword="null"/>.</returns>
    public static string? Serialize(this object? input, JsonSerializerOptions? options = null) => input.IsNull()
        ? default
        : options.IsNull()
        ? JsonSerializer.Serialize(input, CamelCasePropertyNamingPolicy)
        : JsonSerializer.Serialize(input, options);

    /// <summary>
    /// Serializes a collection of objects to a collection of JSON strings using the provided JsonSerializerOptions, with a default camel case property naming policy.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty.
    /// Uses camel case property naming policy if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The collection of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of JSON strings, or <see langword="null"/> if the collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Serializes(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.Serialize())
        : input.Select(x => x.Serialize(options));

    /// <summary>
    /// Serializes a collection (ICollection) of objects to a collection of JSON strings using the provided JsonSerializerOptions, with a default camel case property naming policy.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty.
    /// Uses camel case property naming policy if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The ICollection of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of JSON strings, or <see langword="null"/> if the collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Serializes(this ICollection<object?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.Serialize())
        : input.Select(x => x.Serialize(options));

    /// <summary>
    /// Serializes an array of objects to a collection of JSON strings using the provided JsonSerializerOptions, with a default camel case property naming policy.
    /// Returns <see langword="null"/> if the array is <see langword="null"/> or empty.
    /// Uses camel case property naming policy if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The array of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of JSON strings, or <see langword="null"/> if the array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Serializes(this object?[]? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.Serialize())
        : input.Select(x => x.Serialize(options));

    /// <summary>
    /// Deserializes the JSON string to an object of type <typeparamref name="T"/>.
    /// If the JSON string is <see langword="null"/>, empty, or white space, returns the default value of type <typeparamref name="T"/>.
    /// The deserialization uses the specified <see cref="JsonSerializerOptions"/> if provided; otherwise, it uses default options.
    /// If deserialization fails, returns the default value of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of object to deserialize to.</typeparam>
    /// <param name="input">The JSON string to deserialize. Can be <see langword="null"/> or white space.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> to use for deserialization. Can be <see langword="null"/>.</param>
    /// <returns>The deserialized object of type <typeparamref name="T"/>, or the default value of type <typeparamref name="T"/> if deserialization fails or the JSON string is <see langword="null"/> or white space.</returns>
    public static T? StandardDeserialize<T>(this string? input, JsonSerializerOptions? options = null)
    {
        try
        {
            return input.IsNullWhiteSpace() ? default : options.IsNull() ? JsonSerializer.Deserialize<T>(input) : JsonSerializer.Deserialize<T>(input, options);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Deserializes a collection of JSON strings into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty, or if deserialization of any JSON string fails.
    /// Uses default deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The collection of JSON strings to be deserialized. Can be <see langword="null"/> or contain white-space strings.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the collection is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? StandardDeserializes<T>(this IEnumerable<string?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.StandardDeserialize<T>())
        : input.Select(x => x.StandardDeserialize<T>(options));

    /// <summary>
    /// Deserializes a collection (ICollection) of JSON strings into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty, or if deserialization of any JSON string fails.
    /// Uses default deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The ICollection of JSON strings to be deserialized. Can be <see langword="null"/> or contain white-space strings.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the collection is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? StandardDeserializes<T>(this ICollection<string?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.StandardDeserialize<T>())
        : input.Select(x => x.StandardDeserialize<T>(options));

    /// <summary>
    /// Deserializes an array of JSON strings into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions.
    /// Returns <see langword="null"/> if the array is <see langword="null"/> or empty, or if deserialization of any JSON string fails.
    /// Uses default deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The array of JSON strings to be deserialized. Can be <see langword="null"/> or contain white-space strings.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the array is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? StandardDeserializes<T>(this string?[]? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.StandardDeserialize<T>())
        : input.Select(x => x.StandardDeserialize<T>(options));

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
    public static T? Deserialize<T>(this string? input, JsonSerializerOptions? options = null)
    {
        try
        {
            return input.IsNullWhiteSpace() ? default : options.IsNull() ? JsonSerializer.Deserialize<T>(input, IsPropertyNameCaseInsensitive) : JsonSerializer.Deserialize<T>(input, options);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Deserializes a collection of JSON strings into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions, with a default case-insensitive property name policy.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty, or if deserialization of any JSON string fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The collection of JSON strings to be deserialized. Can be <see langword="null"/> or contain white-space strings.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the collection is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<string?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.Deserialize<T>())
        : input.Select(x => x.Deserialize<T>(options));

    /// <summary>
    /// Deserializes a collection (ICollection) of JSON strings into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions, with a default case-insensitive property name policy.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty, or if deserialization of any JSON string fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The ICollection of JSON strings to be deserialized. Can be <see langword="null"/> or contain white-space strings.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the collection is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? Deserializes<T>(this ICollection<string?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.Deserialize<T>())
        : input.Select(x => x.Deserialize<T>(options));

    /// <summary>
    /// Deserializes an array of JSON strings into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions, with a default case-insensitive property name policy.
    /// Returns <see langword="null"/> if the array is <see langword="null"/> or empty, or if deserialization of any JSON string fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The array of JSON strings to be deserialized. Can be <see langword="null"/> or contain white-space strings.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the array is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? Deserializes<T>(this string?[]? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.Deserialize<T>())
        : input.Select(x => x.Deserialize<T>(options));

    /// <summary>
    /// Deserializes the UTF-8 JSON byte array into an object of type <typeparamref name="T"/> using the provided JsonSerializerOptions, with a default case-insensitive property name policy.
    /// Returns the default value of <typeparamref name="T"/> if the byte array is <see langword="null"/>, or if deserialization fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The UTF-8 JSON byte array to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An object of type <typeparamref name="T"/> deserialized from the byte array, or the default value of <typeparamref name="T"/> if deserialization fails.</returns>
    public static T? Deserialize<T>(this byte[]? input, JsonSerializerOptions? options = null)
    {
        try
        {
            return input.IsNull() ? default : options.IsNull() ? JsonSerializer.Deserialize<T>(input, IsPropertyNameCaseInsensitive) : JsonSerializer.Deserialize<T>(input, options);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Deserializes a collection of UTF-8 JSON byte arrays into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions, with a default case-insensitive property name policy.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty, or if deserialization of any byte array fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The collection of UTF-8 JSON byte arrays to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the collection is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<byte[]?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.Deserialize<T>())
        : input.Select(x => x.Deserialize<T>(options));

    /// <summary>
    /// Deserializes a collection (ICollection) of UTF-8 JSON byte arrays into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions,
    /// with a default case-insensitive property name policy.
    /// Returns <see langword="null"/> if the collection is <see langword="null"/> or empty, or if deserialization of any byte array fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The ICollection of UTF-8 JSON byte arrays to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the collection is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? Deserializes<T>(this ICollection<byte[]?>? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.Deserialize<T>())
        : input.Select(x => x.Deserialize<T>(options));

    /// <summary>
    /// Deserializes an array of UTF-8 JSON byte arrays into a collection of objects of type <typeparamref name="T"/> using the provided JsonSerializerOptions, with a default case-insensitive property name policy.
    /// Returns <see langword="null"/> if the array is <see langword="null"/> or empty, or if deserialization of any byte array fails.
    /// Uses case-insensitive property name deserialization settings if no JsonSerializerOptions are provided.
    /// </summary>
    /// <param name="input">The array of UTF-8 JSON byte arrays to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">The options to control the behavior of the JsonSerializer. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/>, or <see langword="null"/> if the array is <see langword="null"/> or deserialization fails.</returns>
    public static IEnumerable<T?>? Deserializes<T>(this byte[]?[]? input, JsonSerializerOptions? options = null) => input.IsNullEmpty()
        ? default
        : options.IsNull()
        ? input.Select(x => x.Deserialize<T>())
        : input.Select(x => x.Deserialize<T>(options));
}
