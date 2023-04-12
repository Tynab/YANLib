using System.Text.Json;
using static System.Text.Json.JsonNamingPolicy;

namespace YANLib;

public static partial class YANJson
{
    public static string Serialize<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl);

    public static IEnumerable<string> Serialize<T>(params T[] mdls) where T : class
    {
        if (mdls is null || mdls.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Length; i++)
        {
            yield return JsonSerializer.Serialize(mdls[i]);
        }
    }

    public static IEnumerable<string> Serialize<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is null || !mdls.Any())
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return JsonSerializer.Serialize(mdl);
        }
    }

    public static IEnumerable<string> Serialize<T>(this IReadOnlyCollection<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return JsonSerializer.Serialize(mdl);
        }
    }

    public static IEnumerable<string> Serialize<T>(this IReadOnlyList<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Count; i++)
        {
            yield return JsonSerializer.Serialize(mdls[i]);
        }
    }

    public static IEnumerable<string> Serialize<T>(this IReadOnlySet<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return JsonSerializer.Serialize(mdl);
        }
    }

    public static string SerializeCamel<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl, new JsonSerializerOptions
    {
        PropertyNamingPolicy = CamelCase,
        PropertyNameCaseInsensitive = false
    });

    public static IEnumerable<string> SerializeCamel<T>(params T[] mdls) where T : class
    {
        if (mdls is null || mdls.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Length; i++)
        {
            yield return mdls[i].SerializeCamel();
        }
    }

    public static IEnumerable<string> SerializeCamel<T>(this IEnumerable<T> mdls) where T : class
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

    public static IEnumerable<string> SerializeCamel<T>(this IReadOnlyCollection<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.SerializeCamel();
        }
    }

    public static IEnumerable<string> SerializeCamel<T>(this IReadOnlyList<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Count; i++)
        {
            yield return mdls[i].SerializeCamel();
        }
    }

    public static IEnumerable<string> SerializeCamel<T>(this IReadOnlySet<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count <= 0)
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

    public static IEnumerable<T?> Deserialize<T>(params string[] strs) where T : class
    {
        if (strs is null || strs.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].Deserialize<T>();
        }
    }

    public static IEnumerable<T?> Deserialize<T>(this IEnumerable<string> strs) where T : class
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

    public static IEnumerable<T?> Deserialize<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is null || strs.Count <= 0)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.Deserialize<T>();
        }
    }

    public static IEnumerable<T?> Deserialize<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is null || strs.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].Deserialize<T>();
        }
    }

    public static IEnumerable<T?> Deserialize<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is null || strs.Count <= 0)
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
                PropertyNamingPolicy = CamelCase,
                PropertyNameCaseInsensitive = false
            });
        }
        catch
        {
            return default;
        }
    }

    public static IEnumerable<T?> DeserializeCamel<T>(params string[] strs) where T : class
    {
        if (strs is null || strs.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].DeserializeCamel<T>();
        }
    }

    public static IEnumerable<T?> DeserializeCamel<T>(this IEnumerable<string> strs) where T : class
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

    public static IEnumerable<T?> DeserializeCamel<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is null || strs.Count <= 0)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeCamel<T>();
        }
    }

    public static IEnumerable<T?> DeserializeCamel<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is null || strs.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].DeserializeCamel<T>();
        }
    }

    public static IEnumerable<T?> DeserializeCamel<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is null || strs.Count <= 0)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeCamel<T>();
        }
    }

    public static T? DeserializeStandard<T>(this string str) where T : class
    {
        T? rslt;
        try
        {
            rslt = JsonSerializer.Deserialize<T>(str, new JsonSerializerOptions
            {
                PropertyNamingPolicy = CamelCase,
                PropertyNameCaseInsensitive = false
            });
        }
        catch
        {
            rslt = default;
        }
        if (rslt == null || rslt.AllPropertiesDefault())
        {
            try
            {
                rslt = JsonSerializer.Deserialize<T>(str);
            }
            catch
            {
                rslt = default;
            }
        }
        return rslt;
    }

    public static IEnumerable<T?> DeserializeStandard<T>(params string[] strs) where T : class
    {
        if (strs is null || strs.Length <= 0)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].DeserializeStandard<T>();
        }
    }

    public static IEnumerable<T?> DeserializeStandard<T>(this IEnumerable<string> strs) where T : class
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

    public static IEnumerable<T?> DeserializeStandard<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is null || strs.Count <= 0)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeStandard<T>();
        }
    }

    public static IEnumerable<T?> DeserializeStandard<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is null || strs.Count <= 0)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].DeserializeStandard<T>();
        }
    }

    public static IEnumerable<T?> DeserializeStandard<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is null || strs.Count <= 0)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeStandard<T>();
        }
    }
}
