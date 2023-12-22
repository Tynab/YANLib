using System.Text.Json;
using YANLib.Core;

namespace YANLib.Ultimate.Core;

public static partial class YANJson
{
    /// <summary>
    /// Serializes a collection of objects into their respective JSON string representations using the standard JSON serializer with optional customization.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is serialized to a JSON string using provided serialization options.
    /// </summary>
    /// <param name="vals">The collection of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON serialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of JSON strings representing the serialized objects.</returns>
    public static IEnumerable<string?> StandardSerializes(this IEnumerable<object?>? vals, JsonSerializerOptions? options = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.StandardSerialize(options);
        }
    }

    /// <summary>
    /// Serializes a collection (ICollection) of objects into their respective JSON string representations using the standard JSON serializer with optional customization.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is serialized to a JSON string using provided serialization options.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON serialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of JSON strings representing the serialized objects.</returns>
    public static IEnumerable<string?> StandardSerializes(this ICollection<object?>? vals, JsonSerializerOptions? options = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.StandardSerialize(options);
        }
    }

    /// <summary>
    /// Serializes an array of objects into their respective JSON string representations using the standard JSON serializer with optional customization.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each object in the array is serialized to a JSON string using provided serialization options.
    /// </summary>
    /// <param name="vals">The array of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON serialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of JSON strings representing the serialized objects.</returns>
    public static IEnumerable<string?> StandardSerializes(this object?[]? vals, JsonSerializerOptions? options = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.StandardSerialize(options);
        }
    }

    /// <summary>
    /// Serializes a collection of objects into their respective JSON string representations using a custom JSON serializer with optional serialization options.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is serialized to a JSON string using the provided serialization options.
    /// </summary>
    /// <param name="vals">The collection of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON serialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of JSON strings representing the serialized objects with custom settings.</returns>
    public static IEnumerable<string?> Serializes(this IEnumerable<object?>? vals, JsonSerializerOptions? options = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.Serialize(options);
        }
    }

    /// <summary>
    /// Serializes a collection (ICollection) of objects into their respective JSON string representations using a custom JSON serializer with optional serialization options.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each object in the collection is serialized to a JSON string using the provided serialization options.
    /// </summary>
    /// <param name="vals">The ICollection of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON serialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of JSON strings representing the serialized objects with custom settings.</returns>
    public static IEnumerable<string?> Serializes(this ICollection<object?>? vals, JsonSerializerOptions? options = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.Serialize(options);
        }
    }

    /// <summary>
    /// Serializes an array of objects into their respective JSON string representations using a custom JSON serializer with optional serialization options.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each object in the array is serialized to a JSON string using the provided serialization options.
    /// </summary>
    /// <param name="vals">The array of objects to be serialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON serialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of JSON strings representing the serialized objects with custom settings.</returns>
    public static IEnumerable<string?> Serializes(this object?[]? vals, JsonSerializerOptions? options = null)
    {
        if (vals.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var val in vals)
        {
            yield return val.Serialize(options);
        }
    }

    /// <summary>
    /// Deserializes a collection of JSON strings into their respective objects of type <typeparamref name="T"/> using the standard JSON deserializer with optional customization.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each JSON string in the collection is deserialized into an object of type <typeparamref name="T"/> using provided deserialization options; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the JSON strings are to be deserialized.</typeparam>
    /// <param name="strs">The collection of JSON strings to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON deserialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the JSON strings.</returns>
    public static IEnumerable<T?> StandardDeserializes<T>(this IEnumerable<string?>? strs, JsonSerializerOptions? options = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.StandardDeserialize<T>(options);
        }
    }

    /// <summary>
    /// Deserializes a collection (ICollection) of JSON strings into their respective objects of type <typeparamref name="T"/> using the standard JSON deserializer with optional customization.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each JSON string in the collection is deserialized into an object of type <typeparamref name="T"/> using provided deserialization options; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the JSON strings are to be deserialized.</typeparam>
    /// <param name="strs">The ICollection of JSON strings to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON deserialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the JSON strings.</returns>
    public static IEnumerable<T?> StandardDeserializes<T>(this ICollection<string?>? strs, JsonSerializerOptions? options = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.StandardDeserialize<T>(options);
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings into their respective objects of type <typeparamref name="T"/> using the standard JSON deserializer with optional customization.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each JSON string in the array is deserialized into an object of type <typeparamref name="T"/> using provided deserialization options; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the JSON strings are to be deserialized.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON deserialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the JSON strings.</returns>
    public static IEnumerable<T?> StandardDeserializes<T>(this string?[]? strs, JsonSerializerOptions? options = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.StandardDeserialize<T>(options);
        }
    }

    /// <summary>
    /// Deserializes a collection of JSON strings into their respective objects of type <typeparamref name="T"/> using a custom JSON deserializer with optional deserialization options.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each JSON string in the collection is deserialized into an object of type <typeparamref name="T"/> using the provided deserialization options; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the JSON strings are to be deserialized.</typeparam>
    /// <param name="strs">The collection of JSON strings to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON deserialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the JSON strings.</returns>
    public static IEnumerable<T?> Deserializes<T>(this IEnumerable<string?>? strs, JsonSerializerOptions? options = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Deserialize<T>(options);
        }
    }

    /// <summary>
    /// Deserializes a collection (ICollection) of JSON strings into their respective objects of type <typeparamref name="T"/> using a custom JSON deserializer with optional deserialization options.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each JSON string in the collection is deserialized into an object of type <typeparamref name="T"/> using the provided deserialization options; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the JSON strings are to be deserialized.</typeparam>
    /// <param name="strs">The ICollection of JSON strings to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON deserialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the JSON strings.</returns>
    public static IEnumerable<T?> Deserializes<T>(this ICollection<string?>? strs, JsonSerializerOptions? options = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Deserialize<T>(options);
        }
    }

    /// <summary>
    /// Deserializes an array of JSON strings into their respective objects of type <typeparamref name="T"/> using a custom JSON deserializer with optional deserialization options.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each JSON string in the array is deserialized into an object of type <typeparamref name="T"/> using the provided deserialization options; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the JSON strings are to be deserialized.</typeparam>
    /// <param name="strs">The array of JSON strings to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON deserialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the JSON strings.</returns>
    public static IEnumerable<T?> Deserializes<T>(this string?[]? strs, JsonSerializerOptions? options = null)
    {
        if (strs.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var str in strs)
        {
            yield return str.Deserialize<T>(options);
        }
    }

    /// <summary>
    /// Deserializes a collection of UTF-8 JSON byte arrays into their respective objects of type <typeparamref name="T"/> using a custom JSON deserializer with optional deserialization options.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each UTF-8 JSON byte array in the collection is deserialized into an object of type <typeparamref name="T"/> using the provided deserialization options; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the UTF-8 JSON byte arrays are to be deserialized.</typeparam>
    /// <param name="utf8Jsons">The collection of UTF-8 JSON byte arrays to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON deserialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the UTF-8 JSON byte arrays.</returns>
    public static IEnumerable<T?> Deserializes<T>(this IEnumerable<byte[]?>? utf8Jsons, JsonSerializerOptions? options = null)
    {
        if (utf8Jsons.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var utf8Json in utf8Jsons)
        {
            yield return utf8Json.Deserialize<T>(options);
        }
    }

    /// <summary>
    /// Deserializes a collection (ICollection) of UTF-8 JSON byte arrays into their respective objects of type <typeparamref name="T"/> using a custom JSON deserializer with optional deserialization options.
    /// If the collection is <see langword="null"/> or empty, yields no results.
    /// Each UTF-8 JSON byte array in the collection is deserialized into an object of type <typeparamref name="T"/> using the provided deserialization options; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the UTF-8 JSON byte arrays are to be deserialized.</typeparam>
    /// <param name="utf8Jsons">The ICollection of UTF-8 JSON byte arrays to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON deserialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the UTF-8 JSON byte arrays.</returns>
    public static IEnumerable<T?> Deserializes<T>(this ICollection<byte[]?>? utf8Jsons, JsonSerializerOptions? options = null)
    {
        if (utf8Jsons.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var utf8Json in utf8Jsons)
        {
            yield return utf8Json.Deserialize<T>(options);
        }
    }

    /// <summary>
    /// Deserializes an array of UTF-8 JSON byte arrays into their respective objects of type <typeparamref name="T"/> using a custom JSON deserializer with optional deserialization options.
    /// If the array is <see langword="null"/> or empty, yields no results.
    /// Each UTF-8 JSON byte array in the array is deserialized into an object of type <typeparamref name="T"/> using the provided deserialization options; if deserialization fails, a <see langword="null"/> value is yielded.
    /// </summary>
    /// <typeparam name="T">The type of objects to which the UTF-8 JSON byte arrays are to be deserialized.</typeparam>
    /// <param name="utf8Jsons">The array of UTF-8 JSON byte arrays to be deserialized. Can be <see langword="null"/>.</param>
    /// <param name="options">Options for customizing the JSON deserialization. Can be <see langword="null"/> for default options.</param>
    /// <returns>An enumerable collection of objects of type <typeparamref name="T"/> representing the deserialized results from the UTF-8 JSON byte arrays.</returns>
    public static IEnumerable<T?> Deserializes<T>(this byte[]?[]? utf8Jsons, JsonSerializerOptions? options = null)
    {
        if (utf8Jsons.IsEmptyOrNull())
        {
            yield break;
        }

        foreach (var utf8Json in utf8Jsons)
        {
            yield return utf8Json.Deserialize<T>(options);
        }
    }
}
