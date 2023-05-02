using System.Text.Json;
using static System.Text.Json.JsonNamingPolicy;

namespace YANLib;

public static partial class YANJson
{
    
    public static string Serialize<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl);

    public static IEnumerable<string> Serializes<T>(this IEnumerable<T> mdls) where T : class
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

    public static string SerializeCamel<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = false,
        PropertyNamingPolicy = CamelCase
    });

    public static IEnumerable<string> SerializeCamels<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.SerializeCamel();
        }
    }

    public static T? Deserialize<T>(this string str) where T : class
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

    public static IEnumerable<T?> Deserializes<T>(this IEnumerable<string> strs) where T : class
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

    public static T? DeserializeCamel<T>(this string str) where T : class
    {
        try
        {
            return JsonSerializer.Deserialize<T>(str, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = false,
                PropertyNamingPolicy = CamelCase
            });
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?> DeserializeCamels<T>(this IEnumerable<string> strs) where T : class
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeCamel<T>();
        }
    }

    public static T? DeserializeDuo<T>(this string str) where T : class
    {
        T? rslt;
        try
        {
            rslt = str.Deserialize<T>();
        }
        catch
        {
            rslt = default;
        }
        if (rslt is not null && rslt.AnyPropertiesNotDefault())
        {
            return rslt;
        }
        else
        {
            try
            {
                return str.DeserializeCamel<T>();
            }
            catch
            {
                return default;
            }
        }
    }

    public static IEnumerable<T?> DeserializeDuos<T>(this IEnumerable<string> strs) where T : class
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeDuo<T>();
        }
    }

    public static T? DeserializeDuoCamelPriority<T>(this string str) where T : class
    {
        T? rslt;
        try
        {
            rslt = str.DeserializeCamel<T>();
        }
        catch
        {
            rslt = default;
        }
        if (rslt is not null && rslt.AnyPropertiesNotDefault())
        {
            return rslt;
        }
        else
        {
            try
            {
                return str.Deserialize<T>();
            }
            catch
            {
                return default;
            }
        }
    }

    public static IEnumerable<T?> DeserializeDuoCamelPriorities<T>(this IEnumerable<string> strs) where T : class
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeDuoCamelPriority<T>();
        }
    }

    public static T? DeserializeStandard<T>(this string str) where T : class
    {
        try
        {
            return JsonSerializer.Deserialize<T>(str, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = CamelCase,
            });
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?> DeserializeStandards<T>(this IEnumerable<string> strs) where T : class
    {
        if (strs is null || !strs.Any())
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeStandard<T>();
        }
    }
}
