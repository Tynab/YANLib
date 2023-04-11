using System.Text.Json;
using static System.Text.Json.JsonNamingPolicy;

namespace YANLib;

public static partial class YANJson
{
    public static string Serialize<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl);

    public static IEnumerable<string> Serialize<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is not null && mdls.Any())
        {
            foreach (var mdl in mdls)
            {
                yield return JsonSerializer.Serialize(mdl);
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<string> Serialize<T>(this IReadOnlyCollection<T> mdls) where T : class
    {
        if (mdls is not null && mdls.Count > 0)
        {
            foreach (var mdl in mdls)
            {
                yield return JsonSerializer.Serialize(mdl);
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<string> Serialize<T>(this IReadOnlyList<T> mdls) where T : class
    {
        if (mdls is not null && mdls.Count > 0)
        {
            for (var i = 0; i < mdls.Count; i++)
            {
                yield return JsonSerializer.Serialize(mdls[i]);
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<string> Serialize<T>(this IReadOnlySet<T> mdls) where T : class
    {
        if (mdls is not null && mdls.Count > 0)
        {
            foreach (var mdl in mdls)
            {
                yield return JsonSerializer.Serialize(mdl);
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<string> Serialize<T>(params T[] mdls) where T : class
    {
        if (mdls is not null && mdls.Length > 0)
        {
            for (var i = 0; i < mdls.Length; i++)
            {
                yield return JsonSerializer.Serialize(mdls[i]);
            }
        }
        else
        {
            yield break;
        }
    }

    public static string SerializeCamel<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl, new JsonSerializerOptions
    {
        PropertyNamingPolicy = CamelCase,
        PropertyNameCaseInsensitive = false
    });

    public static IEnumerable<string> SerializeCamel<T>(this IEnumerable<T> mdls) where T : class
    {
        if (mdls is not null && mdls.Any())
        {
            foreach (var mdl in mdls)
            {
                yield return mdl.SerializeCamel();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<string> SerializeCamel<T>(this IReadOnlyCollection<T> mdls) where T : class
    {
        if (mdls is not null && mdls.Count > 0)
        {
            foreach (var mdl in mdls)
            {
                yield return mdl.SerializeCamel();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<string> SerializeCamel<T>(this IReadOnlyList<T> mdls) where T : class
    {
        if (mdls is not null && mdls.Count > 0)
        {
            for (var i = 0; i < mdls.Count; i++)
            {
                yield return mdls[i].SerializeCamel();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<string> SerializeCamel<T>(this IReadOnlySet<T> mdls) where T : class
    {
        if (mdls is not null && mdls.Count > 0)
        {
            foreach (var mdl in mdls)
            {
                yield return mdl.SerializeCamel();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<string> SerializeCamel<T>(params T[] mdls) where T : class
    {
        if (mdls is not null && mdls.Length > 0)
        {
            for (var i = 0; i < mdls.Length; i++)
            {
                yield return mdls[i].SerializeCamel();
            }
        }
        else
        {
            yield break;
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

    public static IEnumerable<T?> Deserialize<T>(this IEnumerable<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.Deserialize<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> Deserialize<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.Deserialize<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> Deserialize<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.Deserialize<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> Deserialize<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.Deserialize<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> Deserialize<T>(params string[] strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.Deserialize<T>();
            }
        }
        else
        {
            yield break;
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

    public static IEnumerable<T?> DeserializeCamel<T>(this IEnumerable<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeCamel<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> DeserializeCamel<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeCamel<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> DeserializeCamel<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeCamel<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> DeserializeCamel<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeCamel<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> DeserializeCamel<T>(params string[] strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeCamel<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static T? DeserializeStandard<T>(this string str) where T : class
    {
        T? rslt;
        try
        {
            rslt = JsonSerializer.Deserialize<T>(str);
        }
        catch
        {
            rslt = default;
        }
        if (rslt == null || rslt.AllPropertiesDefault())
        {
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
        }
        return rslt;
    }

    public static IEnumerable<T?> DeserializeStandard<T>(this IEnumerable<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeStandard<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> DeserializeStandard<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeStandard<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> DeserializeStandard<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeStandard<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> DeserializeStandard<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeStandard<T>();
            }
        }
        else
        {
            yield break;
        }
    }

    public static IEnumerable<T?> DeserializeStandard<T>(params string[] strs) where T : class
    {
        if (strs is not null && strs.Any())
        {
            foreach (var str in strs)
            {
                yield return str.DeserializeStandard<T>();
            }
        }
        else
        {
            yield break;
        }
    }
}
