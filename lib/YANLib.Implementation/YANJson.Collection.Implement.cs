using System.Diagnostics;
using System.Text.Json;

namespace YANLib.Implementation;

internal static partial class YANJson
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? SerializesImplement(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : input.GetCountImplement() < 1_000
        ? options is null ? input.Select(x => x.SerializeImplement()) : input.Select(x => x.SerializeImplement(options))
        : options is null ? input.AsParallel().Select(x => x.SerializeImplement()) : input.AsParallel().Select(x => x.SerializeImplement(options));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? SerializesImplement(this System.Collections.IEnumerable? input, JsonSerializerOptions? options = null)
        => input is null ? default : input.Cast<object?>().SerializesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<byte[]?>? SerializesToBytesImplement(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : input.GetCountImplement() < 1_000
        ? options is null ? input.Select(x => x.SerializeToBytesImplement()) : input.Select(x => x.SerializeToBytesImplement(options))
        : options is null ? input.AsParallel().Select(x => x.SerializeToBytesImplement()) : input.AsParallel().Select(x => x.SerializeToBytesImplement(options));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<byte[]?>? SerializesToBytesImplement(this System.Collections.IEnumerable? input, JsonSerializerOptions? options = null)
        => input is null ? default : input.Cast<object?>().SerializesToBytesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? DeserializesImplement<T>(this IEnumerable<string?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : input.GetCountImplement() < 1_000
        ? options is null ? input.Select(x => x.DeserializeImplement<T>()) : input.Select(x => x.DeserializeImplement<T>(options))
        : options is null ? input.AsParallel().Select(x => x.DeserializeImplement<T>()) : input.AsParallel().Select(x => x.DeserializeImplement<T>(options));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<T?>? DeserializesFromBytesImplement<T>(this IEnumerable<byte[]?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : input.GetCountImplement() < 1_000
        ? options is null ? input.Select(x => x.DeserializeFromBytesImplement<T>()) : input.Select(x => x.DeserializeFromBytesImplement<T>(options))
        : options is null ? input.AsParallel().Select(x => x.DeserializeFromBytesImplement<T>()) : input.AsParallel().Select(x => x.DeserializeFromBytesImplement<T>(options));
}
