using System.Text.Json;
using static System.Text.Json.JsonNamingPolicy;

namespace YANLib;

public static partial class YANJson
{
    /// <summary>
    /// Serializes the given object of type <typeparamref name="T"/> to a JSON string using the default JSON serialization settings.
    /// </summary>
    /// <typeparam name="T">The type of the object to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdl">The object to be serialized.</param>
    /// <returns>A JSON string representing the serialized object.</returns>
    public static string Serialize<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl);

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.</returns>
    public static IEnumerable<string> Serialize<T>(params T[] mdls) where T : class
    {
        if (mdls is null || mdls.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Length; i++)
        {
            yield return mdls[i].Serialize();
        }
    }

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.</returns>
    public static IEnumerable<string> Serialize<T>(this IEnumerable<T> mdls) where T : class
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

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.</returns>
    public static IEnumerable<string> Serialize<T>(this IReadOnlyCollection<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count < 1)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.Serialize();
        }
    }

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.</returns>
    public static IEnumerable<string> Serialize<T>(this IReadOnlyList<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Count; i++)
        {
            yield return mdls[i].Serialize();
        }
    }

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects.</returns>
    public static IEnumerable<string> Serialize<T>(this IReadOnlySet<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count < 1)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.Serialize();
        }
    }

    /// <summary>
    /// Serializes the given object of type <typeparamref name="T"/> to a JSON string using the default JSON serialization settings,
    /// with the property names in camelCase and case sensitivity for property names set to false.
    /// </summary>
    /// <typeparam name="T">The type of the object to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdl">The object to be serialized.</param>
    /// <returns>A JSON string representing the serialized object with camelCase property names and case sensitivity for property names set to false.</returns>
    public static string SerializeCamel<T>(this T mdl) where T : class => JsonSerializer.Serialize(mdl, new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = false,
        PropertyNamingPolicy = CamelCase
    });

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects,
    /// with the property names in camelCase and case sensitivity for property names set to false.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects with camelCase property names and case sensitivity for property names set to false.</returns>
    public static IEnumerable<string> SerializeCamel<T>(params T[] mdls) where T : class
    {
        if (mdls is null || mdls.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Length; i++)
        {
            yield return mdls[i].SerializeCamel();
        }
    }

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects,
    /// with the property names in camelCase and case sensitivity for property names set to false.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects with camelCase property names and case sensitivity for property names set to false.</returns>
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

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects,
    /// with the property names in camelCase and case sensitivity for property names set to false.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects with camelCase property names and case sensitivity for property names set to false.</returns>
    public static IEnumerable<string> SerializeCamel<T>(this IReadOnlyCollection<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count < 1)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.SerializeCamel();
        }
    }

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects,
    /// with the property names in camelCase and case sensitivity for property names set to false.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects with camelCase property names and case sensitivity for property names set to false.</returns>
    public static IEnumerable<string> SerializeCamel<T>(this IReadOnlyList<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < mdls.Count; i++)
        {
            yield return mdls[i].SerializeCamel();
        }
    }

    /// <summary>
    /// Serializes an enumerable of objects of type <typeparamref name="T"/> to an <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects,
    /// with the property names in camelCase and case sensitivity for property names set to false.
    /// Returns an empty sequence if the input enumerable is <see langword="null"/>, empty, or contains only <see langword="null"/> objects.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be serialized. Must be a reference type.</typeparam>
    /// <param name="mdls">The enumerable of objects to be serialized.</param>
    /// <returns>An <see cref="IEnumerable{string}"/> containing JSON strings representing the serialized objects with camelCase property names and case sensitivity for property names set to false.</returns>
    public static IEnumerable<string> SerializeCamel<T>(this IReadOnlySet<T> mdls) where T : class
    {
        if (mdls is null || mdls.Count < 1)
        {
            yield break;
        }
        foreach (var mdl in mdls)
        {
            yield return mdl.SerializeCamel();
        }
    }

    /// <summary>
    /// Deserializes a JSON string to an object of type <typeparamref name="T"/> using the default JSON deserialization settings.
    /// Returns the deserialized object, or <see langword="default"/> if the deserialization fails.
    /// </summary>
    /// <typeparam name="T">The type of the object to be deserialized. Must be a reference type.</typeparam>
    /// <param name="str">The JSON string to be deserialized.</param>
    /// <returns>The deserialized object, or <see langword="default"/> if the deserialization fails.</returns>
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> Deserialize<T>(params string[] strs) where T : class
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].Deserialize<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> Deserialize<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.Deserialize<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> Deserialize<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].Deserialize<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> Deserialize<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.Deserialize<T>();
        }
    }

    /// <summary>
    /// Deserializes a JSON string to an object of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false.
    /// Returns the deserialized object, or <see langword="default"/> if the deserialization fails.
    /// </summary>
    /// <typeparam name="T">The type of the object to be deserialized. Must be a reference type.</typeparam>
    /// <param name="str">The JSON string to be deserialized.</param>
    /// <returns>The deserialized object, or <see langword="default"/> if the deserialization fails.</returns>
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false.
    /// Returns an enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.</returns>
    public static IEnumerable<T?> DeserializeCamel<T>(params string[] strs) where T : class
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].DeserializeCamel<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false.
    /// Returns an enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.</returns>
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false.
    /// Returns an enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.</returns>
    public static IEnumerable<T?> DeserializeCamel<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeCamel<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false.
    /// Returns an enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.</returns>
    public static IEnumerable<T?> DeserializeCamel<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].DeserializeCamel<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false.
    /// Returns an enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or an empty sequence if the input array is <see langword="null"/>, empty, or contains only <see langword="null"/> strings.</returns>
    public static IEnumerable<T?> DeserializeCamel<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeCamel<T>();
        }
    }

    /// <summary>
    /// Deserializes a JSON string to an object of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// If the deserialization fails, returns <see langword="default"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to be deserialized. Must be a reference type.</typeparam>
    /// <param name="str">The JSON string to be deserialized.</param>
    /// <returns>The deserialized object, or <see langword="default"/> if the deserialization fails.</returns>
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuo<T>(params string[] strs) where T : class
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].DeserializeDuo<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuo<T>(this IEnumerable<string> strs) where T : class
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuo<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeDuo<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuo<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].DeserializeDuo<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuo<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeDuo<T>();
        }
    }

    /// <summary>
    /// Deserializes a JSON string to an object of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// If the deserialization fails, returns <see langword="default"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to be deserialized. Must be a reference type.</typeparam>
    /// <param name="str">The JSON string to be deserialized.</param>
    /// <returns>The deserialized object, or <see langword="default"/> if the deserialization fails.</returns>
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuoCamelPriority<T>(params string[] strs) where T : class
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].DeserializeDuoCamelPriority<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuoCamelPriority<T>(this IEnumerable<string> strs) where T : class
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuoCamelPriority<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeDuoCamelPriority<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuoCamelPriority<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].DeserializeDuoCamelPriority<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeDuoCamelPriority<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeDuoCamelPriority<T>();
        }
    }

    /// <summary>
    /// Deserializes a JSON string to an object of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// If the deserialization fails, returns <see langword="default"/>.
    /// </summary>
    /// <typeparam name="T">The type of the object to be deserialized. Must be a reference type.</typeparam>
    /// <param name="str">The JSON string to be deserialized.</param>
    /// <returns>The deserialized object, or <see langword="default"/> if the deserialization fails.</returns>
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeStandard<T>(params string[] strs) where T : class
    {
        if (strs is null || strs.Length < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Length; i++)
        {
            yield return strs[i].DeserializeStandard<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
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

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeStandard<T>(this IReadOnlyCollection<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeStandard<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeStandard<T>(this IReadOnlyList<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        for (var i = 0; i < strs.Count; i++)
        {
            yield return strs[i].DeserializeStandard<T>();
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings to an enumerable of objects of type <typeparamref name="T"/> using the default JSON deserialization settings, with camelCase property names and case sensitivity for property names set to false as additional options.
    /// Returns an enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.
    /// </summary>
    /// <typeparam name="T">The type of the objects to be deserialized. Must be a reference type.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized.</param>
    /// <returns>An enumerable of deserialized objects, or <see langword="default"/> if the deserialization fails for any of the input strings.</returns>
    public static IEnumerable<T?> DeserializeStandard<T>(this IReadOnlySet<string> strs) where T : class
    {
        if (strs is null || strs.Count < 1)
        {
            yield break;
        }
        foreach (var str in strs)
        {
            yield return str.DeserializeStandard<T>();
        }
    }
}
