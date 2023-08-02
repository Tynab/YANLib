using System.Text.Json;
using static System.Text.Json.JsonNamingPolicy;

namespace YANLib;

public static partial class YANJson
{
    private static readonly JsonSerializerOptions IsPropNameCaseInsJsonSerializerOpt = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private static readonly JsonSerializerOptions PropNamingPolWkCaseJsonSerializerOpt = new()
    {
        PropertyNamingPolicy = CamelCase
    };

    public static string Serialize<T>(this T mdl) => JsonSerializer.Serialize(mdl);

    public static IEnumerable<string>? Serializes<T>(this IEnumerable<T> mdls) => mdls.IsEmptyOrNull() ? default : mdls.Select(m => m.Serialize());

    public static string CamelSerialize<T>(this T mdl) => JsonSerializer.Serialize(mdl, PropNamingPolWkCaseJsonSerializerOpt);

    public static IEnumerable<string>? CamelSerializes<T>(this IEnumerable<T> mdls) => mdls.IsEmptyOrNull() ? default : mdls.Select(m => m.CamelSerialize());

    public static T? StandardDeserialize<T>(this string str)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(str);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?>? StandardDeserializes<T>(this IEnumerable<string> strs) => strs.IsEmptyOrNull() ? default : strs.Select(s => s.StandardDeserialize<T>());

    public static T? Deserialize<T>(this string str)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(str, IsPropNameCaseInsJsonSerializerOpt);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?>? Deserializes<T>(this IEnumerable<string> strs) => strs.IsEmptyOrNull() ? default : strs.Select(s => s.Deserialize<T>());
}
