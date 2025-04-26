using System.Diagnostics;
using System.Text.Json;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANJson
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static string? Serialize(this object? input, JsonSerializerOptions? options = null) => input.SerializeImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static byte[]? SerializeToBytes(this object? input, JsonSerializerOptions? options = null) => input.SerializeToBytesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Deserialize<T>(this string? input, JsonSerializerOptions? options = null) => input.DeserializeImplement<T>(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? DeserializeFromBytes<T>(this byte[]? input, JsonSerializerOptions? options = null) => input.DeserializeFromBytesImplement<T>(options);
}
