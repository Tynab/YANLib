using System.Diagnostics;
using System.Text.Json;

namespace YANLib.Implementation;

internal static partial class YANJson
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<string?>? SerializesImplement<T>(this IEnumerable<T?>? input, JsonSerializerOptions? options = null)
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.SerializeImplement(options));

    [DebuggerHidden]
    [DebuggerStepThrough]
    internal static IEnumerable<byte[]?>? SerializesToBytesImplement<T>(this IEnumerable<T?>? input, JsonSerializerOptions? options = null)
        => input.IsNullEmptyImplement() ? default : input.Select(x => x.SerializeToBytesImplement(options));
}
