using System.Diagnostics;
using System.Text.Json;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for JSON serialization and deserialization.
/// </summary>
/// <remarks>
/// This class contains methods for converting objects to and from JSON format,
/// supporting both string and byte array representations.
/// </remarks>
public static partial class YANJson
{
    /// <summary>
    /// Serializes an object to a JSON string.
    /// </summary>
    /// <param name="input">The object to serialize. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="options">The options to control the serialization behavior. If <c>null</c>, uses default options with camel case property naming.</param>
    /// <returns>A JSON string representation of the object, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// When no options are provided, this method uses a default configuration with camel case property naming.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Serialize(this object? input, JsonSerializerOptions? options = null) => input.SerializeImplement(options);

    /// <summary>
    /// Serializes an object to a JSON byte array.
    /// </summary>
    /// <param name="input">The object to serialize. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="options">The options to control the serialization behavior. If <c>null</c>, uses default options with camel case property naming.</param>
    /// <returns>A UTF-8 encoded byte array containing the JSON representation of the object, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// When no options are provided, this method uses a default configuration with camel case property naming.
    /// This method is more efficient than serializing to a string when the result will be used with APIs that accept byte arrays.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static byte[]? SerializeToBytes(this object? input, JsonSerializerOptions? options = null) => input.SerializeToBytesImplement(options);

    /// <summary>
    /// Deserializes a JSON string to an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON to.</typeparam>
    /// <param name="input">The JSON string to deserialize. If <c>null</c> or whitespace, returns <c>default(T)</c>.</param>
    /// <param name="options">The options to control the deserialization behavior. If <c>null</c>, uses default options with case-insensitive property matching.</param>
    /// <returns>An object of type <typeparamref name="T"/> deserialized from the JSON string, or <c>default(T)</c> if the input is <c>null</c>, whitespace, or invalid JSON.</returns>
    /// <remarks>
    /// When no options are provided, this method uses a default configuration with case-insensitive property matching.
    /// If deserialization fails due to invalid JSON or type incompatibility, this method returns <c>default(T)</c> instead of throwing an exception.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Deserialize<T>(this string? input, JsonSerializerOptions? options = null) => input.DeserializeImplement<T>(options);

    /// <summary>
    /// Deserializes a JSON byte array to an object of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the JSON to.</typeparam>
    /// <param name="input">The UTF-8 encoded byte array containing the JSON to deserialize. If <c>null</c>, returns <c>default(T)</c>.</param>
    /// <param name="options">The options to control the deserialization behavior. If <c>null</c>, uses default options with case-insensitive property matching.</param>
    /// <returns>An object of type <typeparamref name="T"/> deserialized from the JSON byte array, or <c>default(T)</c> if the input is <c>null</c> or invalid JSON.</returns>
    /// <remarks>
    /// When no options are provided, this method uses a default configuration with case-insensitive property matching.
    /// If deserialization fails due to invalid JSON or type incompatibility, this method returns <c>default(T)</c> instead of throwing an exception.
    /// This method is more efficient than deserializing from a string when working with APIs that provide byte arrays.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? DeserializeFromBytes<T>(this byte[]? input, JsonSerializerOptions? options = null) => input.DeserializeFromBytesImplement<T>(options);
}
