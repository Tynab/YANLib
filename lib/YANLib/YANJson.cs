using System.Text.Json;
using static System.Text.Json.JsonNamingPolicy;

namespace YANLib;

public static partial class YANJson
{
    private static readonly JsonSerializerOptions Pnsi = new()
    {
        PropertyNameCaseInsensitive = true
    };

    private static readonly JsonSerializerOptions CamelCasePnp = new()
    {
        PropertyNamingPolicy = CamelCase
    };

    public static string Serialize<T>(this T mdl) => JsonSerializer.Serialize(mdl);

    public static IEnumerable<string> Serializes<T>(this IEnumerable<T> mdls)
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.Serialize();
        }
    }

    public static string CamelSerialize<T>(this T mdl) => JsonSerializer.Serialize(mdl, CamelCasePnp);

    public static IEnumerable<string> CamelSerializes<T>(this IEnumerable<T> mdls)
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.CamelSerialize();
        }
    }

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

    public static IEnumerable<T?> StandardDeserializes<T>(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.StandardDeserialize<T>();
        }
    }

    public static T? Deserialize<T>(this string str)
    {
        try
        {
            return JsonSerializer.Deserialize<T>(str, Pnsi);
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?> Deserializes<T>(this IEnumerable<string> strs)
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.Deserialize<T>();
        }
    }
}
