using System.Text.Json;
using YANLib.Implementation.Object;
using YANLib.Implementation.Text;
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

    internal static string? SerializeImplement(this object? input, JsonSerializerOptions? options = null) => input.IsNullImplement()
        ? default
        : options.IsNullImplement()
        ? Serialize(input, CamelCasePropertyNamingPolicy)
        : Serialize(input, options);

    internal static IEnumerable<string?>? SerializesImplement(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : options.IsNullImplement()
        ? input.Select(x => x.SerializeImplement())
        : input.Select(x => x.SerializeImplement(options));

    internal static byte[]? SerializeToBytesImplement(this object? input, JsonSerializerOptions? options = null) => input.IsNullImplement()
        ? default
        : options.IsNullImplement()
        ? SerializeToUtf8Bytes(input, CamelCasePropertyNamingPolicy)
        : SerializeToUtf8Bytes(input, options);

    internal static IEnumerable<byte[]?>? SerializesToBytesImplement(this IEnumerable<object?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : options.IsNullImplement()
        ? input.Select(x => x.SerializeToBytesImplement())
        : input.Select(x => x.SerializeToBytesImplement(options));

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

    internal static IEnumerable<T?>? DeserializesImplement<T>(this IEnumerable<string?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : options.IsNullImplement()
        ? input.Select(x => x.DeserializeImplement<T>())
        : input.Select(x => x.DeserializeImplement<T>(options));

    internal static T? DeserializeImplement<T>(this byte[]? input, JsonSerializerOptions? options = null)
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

    internal static IEnumerable<T?>? DeserializesImplement<T>(this IEnumerable<byte[]?>? input, JsonSerializerOptions? options = null) => input.IsNullEmptyImplement()
        ? default
        : options.IsNullImplement()
        ? input.Select(x => x.DeserializeImplement<T>())
        : input.Select(x => x.DeserializeImplement<T>(options));
}
