using System.Diagnostics;
using System.Text.Json;
using static System.Text.Json.JsonNamingPolicy;
using static System.Text.Json.JsonSerializer;

namespace YANLib.Implementation;

internal static partial class YANJson
{
    private static readonly JsonSerializerOptions IsPropertyNameCaseInsensitive = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private static readonly JsonSerializerOptions CamelCasePropertyNamingPolicy = new()
    {
        PropertyNamingPolicy = CamelCase
    };

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static string? SerializeImplement(this object? input, JsonSerializerOptions? options = null)
        => input.IsNullImplement() ? default : options.IsNullImplement() ? Serialize(input, CamelCasePropertyNamingPolicy) : Serialize(input, options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static byte[]? SerializeToBytesImplement(this object? input, JsonSerializerOptions? options = null)
        => input.IsNullImplement() ? default : options.IsNullImplement() ? SerializeToUtf8Bytes(input, CamelCasePropertyNamingPolicy) : SerializeToUtf8Bytes(input, options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? DeserializeImplement<T>(this string? input, JsonSerializerOptions? options = null)
    {
        try
        {
            return input.IsNullWhiteSpaceImplement() ? default : options.IsNullImplement() ? Deserialize<T>(input, IsPropertyNameCaseInsensitive) : Deserialize<T>(input, options);
        }
        catch
        {
            return default;
        }
    }

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static T? DeserializeFromBytesImplement<T>(this byte[]? input, JsonSerializerOptions? options = null)
    {
        try
        {
            return input.IsNullImplement() ? default : options.IsNullImplement() ? Deserialize<T>(input, IsPropertyNameCaseInsensitive) : Deserialize<T>(input, options);
        }
        catch
        {
            return default;
        }
    }
}
