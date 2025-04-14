using YANLib.Implementation.Object;
using static System.Text.Encoding;
using static System.Text.Json.JsonSerializer;

namespace YANLib.Implementation;

internal static partial class YANBytes
{
    internal static byte[]? ToByteArrayImplement(this object? input) => input.IsNullImplement() ? default : UTF8.GetBytes(Serialize(input) ?? string.Empty);

    internal static IEnumerable<byte[]?>? ToByteArraysImplement(this IEnumerable<object?>? input) => input.IsNullEmptyImplement() ? default : input.Select(x => x.ToByteArrayImplement());

    internal static T? FromByteArrayImplement<T>(this byte[]? input) => input.IsNullEmptyImplement() ? default : UTF8.GetString(input).DeserializeImplement<T>();

    internal static IEnumerable<T?>? FromByteArraysImplement<T>(this IEnumerable<byte[]?>? input) => input.IsNullEmptyImplement() ? default : input.Select(x => x.FromByteArrayImplement<T>());
}
