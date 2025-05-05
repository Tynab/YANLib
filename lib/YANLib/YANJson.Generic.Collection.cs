using System.Diagnostics;
using System.Text.Json;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides generic extension methods for JSON serialization of collections.
/// </summary>
/// <remarks>
/// This partial class contains generic methods for converting collections of objects to JSON format,
/// allowing for more type-specific operations.
/// </remarks>
public static partial class YANJson
{
    /// <summary>
    /// Serializes a collection of objects of type <typeparamref name="T"/> to JSON strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to serialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="options">The options to control the serialization behavior. If <c>null</c>, uses default options with camel case property naming.</param>
    /// <returns>A collection of JSON string representations of the objects, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This generic version allows for type-specific processing of collections.
    /// When no options are provided, this method uses a default configuration with camel case property naming.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Serializes<T>(this IEnumerable<T?>? input, JsonSerializerOptions? options = null) => input.SerializesImplement(options);

    /// <summary>
    /// Serializes a collection of objects of type <typeparamref name="T"/> to JSON byte arrays.
    /// </summary>
    /// <typeparam name="T">The type of the objects in the collection.</typeparam>
    /// <param name="input">The collection of objects to serialize. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="options">The options to control the serialization behavior. If <c>null</c>, uses default options with camel case property naming.</param>
    /// <returns>A collection of UTF-8 encoded byte arrays containing the JSON representations of the objects, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This generic version allows for type-specific processing of collections.
    /// When no options are provided, this method uses a default configuration with camel case property naming.
    /// This method is more efficient than serializing to strings when the results will be used with APIs that accept byte arrays.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<byte[]?>? SerializesToBytes<T>(this IEnumerable<T?>? input, JsonSerializerOptions? options = null) => input.SerializesToBytesImplement(options);
}
