using System.Diagnostics;
using System.Text.Json;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for JSON serialization and deserialization of collections.
/// </summary>
/// <remarks>
/// This partial class contains methods for converting collections of objects to and from JSON format,
/// supporting both string and byte array representations.
/// </remarks>
public static partial class YANJson
{
    /// <summary>
    /// Serializes a collection of objects to JSON strings.
    /// </summary>
    /// <param name="input">The collection of objects to serialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="options">The options to control the serialization behavior. If <c>null</c>, uses default options with camel case property naming.</param>
    /// <returns>A collection of JSON string representations of the objects, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// When no options are provided, this method uses a default configuration with camel case property naming.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Serializes(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.SerializesImplement(options);

    /// <summary>
    /// Serializes an array of objects to JSON strings.
    /// </summary>
    /// <param name="input">The array of objects to serialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of JSON string representations of the objects, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to serialize an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses default options with camel case property naming.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Serializes(params object?[]? input) => input.SerializesImplement();

    /// <summary>
    /// Serializes a non-generic collection of objects to JSON strings.
    /// </summary>
    /// <param name="input">The non-generic collection of objects to serialize. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="options">The options to control the serialization behavior. If <c>null</c>, uses default options with camel case property naming.</param>
    /// <returns>A collection of JSON string representations of the objects, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before serializing.
    /// When no options are provided, this method uses a default configuration with camel case property naming.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Serializes(this System.Collections.IEnumerable? input, JsonSerializerOptions? options = null) => input.SerializesImplement(options);

    /// <summary>
    /// Serializes a collection of objects to JSON byte arrays.
    /// </summary>
    /// <param name="input">The collection of objects to serialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="options">The options to control the serialization behavior. If <c>null</c>, uses default options with camel case property naming.</param>
    /// <returns>A collection of UTF-8 encoded byte arrays containing the JSON representations of the objects, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// When no options are provided, this method uses a default configuration with camel case property naming.
    /// This method is more efficient than serializing to strings when the results will be used with APIs that accept byte arrays.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<byte[]?>? SerializesToBytes(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.SerializesToBytesImplement(options);

    /// <summary>
    /// Serializes an array of objects to JSON byte arrays.
    /// </summary>
    /// <param name="input">The array of objects to serialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of UTF-8 encoded byte arrays containing the JSON representations of the objects, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to serialize an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses default options with camel case property naming.
    /// This method is more efficient than serializing to strings when the results will be used with APIs that accept byte arrays.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<byte[]?>? SerializesToBytes(params object?[]? input) => input.SerializesToBytesImplement();

    /// <summary>
    /// Serializes a non-generic collection of objects to JSON byte arrays.
    /// </summary>
    /// <param name="input">The non-generic collection of objects to serialize. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="options">The options to control the serialization behavior. If <c>null</c>, uses default options with camel case property naming.</param>
    /// <returns>A collection of UTF-8 encoded byte arrays containing the JSON representations of the objects, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before serializing.
    /// When no options are provided, this method uses a default configuration with camel case property naming.
    /// This method is more efficient than serializing to strings when the results will be used with APIs that accept byte arrays.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<byte[]?>? SerializesToBytes(this System.Collections.IEnumerable? input, JsonSerializerOptions? options = null) => input.SerializesToBytesImplement(options);

    /// <summary>
    /// Deserializes a collection of JSON strings to objects of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON to.</typeparam>
    /// <param name="input">The collection of JSON strings to deserialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="options">The options to control the deserialization behavior. If <c>null</c>, uses default options with case-insensitive property matching.</param>
    /// <returns>A collection of objects of type <typeparamref name="T"/> deserialized from the JSON strings, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// When no options are provided, this method uses a default configuration with case-insensitive property matching.
    /// If deserialization of an element fails due to invalid JSON or type incompatibility, that element will be <c>default(T)</c> in the result.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<string?>? input, JsonSerializerOptions? options = null) => input.DeserializesImplement<T>(options);

    /// <summary>
    /// Deserializes an array of JSON strings to objects of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON to.</typeparam>
    /// <param name="input">The array of JSON strings to deserialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of objects of type <typeparamref name="T"/> deserialized from the JSON strings, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to deserialize an array of JSON strings without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses default options with case-insensitive property matching.
    /// If deserialization of an element fails due to invalid JSON or type incompatibility, that element will be <c>default(T)</c> in the result.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Deserializes<T>(params string?[]? input) => input.DeserializesImplement<T>();

    /// <summary>
    /// Deserializes a collection of JSON byte arrays to objects of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON to.</typeparam>
    /// <param name="input">The collection of UTF-8 encoded byte arrays containing the JSON to deserialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="options">The options to control the deserialization behavior. If <c>null</c>, uses default options with case-insensitive property matching.</param>
    /// <returns>A collection of objects of type <typeparamref name="T"/> deserialized from the JSON byte arrays, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// When no options are provided, this method uses a default configuration with case-insensitive property matching.
    /// If deserialization of an element fails due to invalid JSON or type incompatibility, that element will be <c>default(T)</c> in the result.
    /// This method is more efficient than deserializing from strings when working with APIs that provide byte arrays.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? DeserializesFromBytes<T>(this IEnumerable<byte[]?>? input, JsonSerializerOptions? options = null) => input.DeserializesFromBytesImplement<T>(options);

    /// <summary>
    /// Deserializes an array of JSON byte arrays to objects of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON to.</typeparam>
    /// <param name="input">The array of UTF-8 encoded byte arrays containing the JSON to deserialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of objects of type <typeparamref name="T"/> deserialized from the JSON byte arrays, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to deserialize an array of JSON byte arrays without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// This method uses default options with case-insensitive property matching.
    /// If deserialization of an element fails due to invalid JSON or type incompatibility, that element will be <c>default(T)</c> in the result.
    /// This method is more efficient than deserializing from strings when working with APIs that provide byte arrays.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? DeserializesFromBytes<T>(params byte[]?[]? input) => input.DeserializesFromBytesImplement<T>();
}
