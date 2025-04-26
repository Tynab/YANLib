using System.Diagnostics;
using System.Text.Json;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANJson
{
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Serializes<T>(this IEnumerable<T?>? input, JsonSerializerOptions? options = null) => input.SerializesImplement(options);

    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<byte[]?>? SerializesToBytes<T>(this IEnumerable<T?>? input, JsonSerializerOptions? options = null) => input.SerializesToBytesImplement(options);
}
