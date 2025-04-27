using System.Diagnostics;
using System.Text.Json;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANJson
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Serializes(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.SerializesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Serializes(params object?[]? input) => input.SerializesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Serializes(this System.Collections.IEnumerable? input, JsonSerializerOptions? options = null) => input.SerializesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<byte[]?>? SerializesToBytes(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.SerializesToBytesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<byte[]?>? SerializesToBytes(params object?[]? input) => input.SerializesToBytesImplement();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<byte[]?>? SerializesToBytes(this System.Collections.IEnumerable? input, JsonSerializerOptions? options = null) => input.SerializesToBytesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<string?>? input, JsonSerializerOptions? options = null) => input.DeserializesImplement<T>(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Deserializes<T>(params string?[]? input) => input.DeserializesImplement<T>();

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? DeserializesFromBytes<T>(this IEnumerable<byte[]?>? input, JsonSerializerOptions? options = null) => input.DeserializesFromBytesImplement<T>(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? DeserializesFromBytes<T>(params byte[]?[]? input) => input.DeserializesFromBytesImplement<T>();
}
