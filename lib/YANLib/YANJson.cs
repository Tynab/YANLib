using System.Text.Json;
using static System.Text.Json.JsonNamingPolicy;

namespace YANLib;

public static partial class YANJson
{
    private static readonly JsonSerializerOptions IsPropertyNameCaseInsensitive = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private static readonly JsonSerializerOptions CamelCasePropertyNamingPolicy = new()
    {
        PropertyNamingPolicy = CamelCase
    };

    public static string StandardSerialize<T>(this T value, JsonSerializerOptions? options = null) => options is null ? JsonSerializer.Serialize(value) : JsonSerializer.Serialize(value, options);

    public static IEnumerable<string>? StandardSerializes<T>(this IEnumerable<T> values, JsonSerializerOptions? options = null) => values.IsEmptyOrNull()
        ? default
        : options is null
        ? values.Select(m => m.StandardSerialize())
        : values.Select(m => m.StandardSerialize(options));

    public static string Serialize<T>(this T value, JsonSerializerOptions? options = null) => options is null ? JsonSerializer.Serialize(value, CamelCasePropertyNamingPolicy) : JsonSerializer.Serialize(value, options);

    public static IEnumerable<string>? Serializes<T>(this IEnumerable<T> values, JsonSerializerOptions? options = null) => values.IsEmptyOrNull()
        ? default
        : options is null
        ? values.Select(m => m.Serialize())
        : values.Select(m => m.Serialize(options));

    public static T? StandardDeserialize<T>(this string json, JsonSerializerOptions? options = null)
    {
        try
        {
            return options is null ? JsonSerializer.Deserialize<T>(json) : JsonSerializer.Deserialize<T>(json, options);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?>? StandardDeserializes<T>(this IEnumerable<string> jsons, JsonSerializerOptions? options = null) => jsons.IsEmptyOrNull()
        ? default
        : options is null
        ? jsons.Select(s => s.StandardDeserialize<T>())
        : jsons.Select(s => s.StandardDeserialize<T>(options));

    public static T? Deserialize<T>(this string json, JsonSerializerOptions? options = null)
    {
        try
        {
            return options is null ? JsonSerializer.Deserialize<T>(json, IsPropertyNameCaseInsensitive) : JsonSerializer.Deserialize<T>(json, options);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<string> jsons, JsonSerializerOptions? options = null) => jsons.IsEmptyOrNull()
        ? default
        : options is null
        ? jsons.Select(s => s.Deserialize<T>())
        : jsons.Select(s => s.Deserialize<T>(options));

    public static T? Deserialize<T>(this byte[] utf8Json, JsonSerializerOptions? options = null)
    {
        try
        {
            return options is null ? JsonSerializer.Deserialize<T>(utf8Json, IsPropertyNameCaseInsensitive) : JsonSerializer.Deserialize<T>(utf8Json, options);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<byte[]> jsons, JsonSerializerOptions? options = null) => jsons.IsEmptyOrNull()
        ? default
        : options is null
        ? jsons.Select(s => s.Deserialize<T>())
        : jsons.Select(s => s.Deserialize<T>(options));
}
