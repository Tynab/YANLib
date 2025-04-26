using System.Diagnostics;
using System.Text.Json;

namespace YANLib.Implementation;

internal static partial class YANJson
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? SerializesImplement<T>(this IEnumerable<T?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : input.GetCountImplement() < 1_000
        ? options.IsNullImplement() ? input.Select(x => x.SerializeImplement()) : input.Select(x => x.SerializeImplement(options))
        : options.IsNullImplement() ? input.AsParallel().Select(x => x.SerializeImplement()) : input.AsParallel().Select(x => x.SerializeImplement(options));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<byte[]?>? SerializesToBytesImplement<T>(this IEnumerable<T?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : input.GetCountImplement() < 1_000
        ? options.IsNullImplement() ? input.Select(x => x.SerializeToBytesImplement()) : input.Select(x => x.SerializeToBytesImplement(options))
        : options.IsNullImplement() ? input.AsParallel().Select(x => x.SerializeToBytesImplement()) : input.AsParallel().Select(x => x.SerializeToBytesImplement(options));
}
