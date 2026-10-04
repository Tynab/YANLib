using System.Diagnostics;
using System.Text.Json;

namespace YANLib.Implementation;

internal static partial class YANJson
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? SerializesImplement(this IEnumerable<object?>? input, JsonSerializerOptions? options = null)
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.SerializeImplement(options));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? SerializesImplement(this System.Collections.IEnumerable? input, JsonSerializerOptions? options = null)
        => input is null ? default : input.Cast<object?>().SerializesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<byte[]?>? SerializesToBytesImplement(this IEnumerable<object?>? input, JsonSerializerOptions? options = null)
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.SerializeToBytesImplement(options));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<byte[]?>? SerializesToBytesImplement(this System.Collections.IEnumerable? input, JsonSerializerOptions? options = null)
        => input is null ? default : input.Cast<object?>().SerializesToBytesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? DeserializesImplement<T>(this IEnumerable<string?>? input, JsonSerializerOptions? options = null)
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.DeserializeImplement<T>(options));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? DeserializesFromBytesImplement<T>(this IEnumerable<byte[]?>? input, JsonSerializerOptions? options = null)
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.DeserializeFromBytesImplement<T>(options));
}
