using YANLib.Object;
using YANLib.Text;
using YANLib.Unmanaged;
using static System.Math;
using static System.Nullable;

namespace YANLib;

public static partial class YANEnumerable
{
    /// <summary>
    /// Divides a collection of elements into chunks of a specified size.
    /// If the source collection is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="input">The source collection of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source collection.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this IEnumerable<T>? input, object? chunkSize)
    {
        var size = chunkSize.To<uint>().To<int>();

        if (input.IsNullOEmpty() || size is 0)
        {
            yield break;
        }

        var source = input.ToList();
        var count = source.Count;

        for (var i = 0; i < count; i += size)
        {
            yield return source.GetRange(i, Min(size, count - i));
        }
    }

    /// <summary>
    /// Divides a collection (ICollection) of elements into chunks of a specified size.
    /// If the source collection is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="input">The source ICollection of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source collection.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this ICollection<T>? input, object? chunkSize)
    {
        var size = chunkSize.To<uint>().To<int>();

        if (input.IsNullOEmpty() || size is 0)
        {
            yield break;
        }

        var count = input.Count;

        for (var i = 0; i < count; i += size)
        {
            yield return input.ToList().GetRange(i, Min(size, count - i));
        }
    }

    /// <summary>
    /// Divides an array of elements into chunks of a specified size.
    /// If the source array is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="input">The source array of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source array.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this T[]? input, object? chunkSize)
    {
        var size = chunkSize.To<uint>().To<int>();

        if (input.IsNullOEmpty() || size is 0)
        {
            yield break;
        }

        var count = input.Length;

        for (var i = 0; i < count; i += size)
        {
            yield return input.ToList().GetRange(i, Min(size, count - i));
        }
    }

    /// <summary>
    /// Divides a list of elements into chunks of a specified size.
    /// If the source list is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="input">The source list of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source list.</returns>
    public static IEnumerable<List<T>> ChunkBySize<T>(this List<T>? input, object? chunkSize)
    {
        var size = chunkSize.To<uint>().To<int>();

        if (input.IsNullOEmpty() || size is 0)
        {
            yield break;
        }

        var count = input.Count;

        for (var i = 0; i < count; i += size)
        {
            yield return input.GetRange(i, Min(size, count - i));
        }
    }

    public static IEnumerable<T>? Clean<T>(this IEnumerable<T>? input)
    {
        if (input.IsNullOEmpty())
        {
            return input;
        }

        var type = typeof(T);

        return type.IsClass || GetUnderlyingType(type).IsNotNull() ? input.Where(x => x.IsNotNull()) : input;
    }

    public static IEnumerable<T>? Clean<T>(this ICollection<T>? input)
    {
        if (input.IsNullOEmpty())
        {
            return input;
        }

        var type = typeof(T);

        return type.IsClass || GetUnderlyingType(type).IsNotNull() ? input.Where(x => x.IsNotNull()) : input;
    }

    public static IEnumerable<T>? Clean<T>(params T[]? input)
    {
        if (input.IsNullOEmpty())
        {
            return input;
        }

        var type = typeof(T);

        return type.IsClass || GetUnderlyingType(type).IsNotNull() ? input.Where(x => x.IsNotNull()) : input;
    }

    public static void Clean<T>(this List<T>? input)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        var type = typeof(T);

        if (type.IsClass || GetUnderlyingType(type).IsNotNull())
        {
            _ = input.RemoveAll(x => x.IsNull());
        }
    }

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this IEnumerable<IEnumerable<T>?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this IEnumerable<ICollection<T>?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this IEnumerable<T[]?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this ICollection<IEnumerable<T>?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this ICollection<ICollection<T>?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this ICollection<T[]?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this IEnumerable<T>?[]? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this ICollection<T>?[]? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this T[]?[]? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static void Cleans<T>(this List<IEnumerable<T>?>? input, bool? deepClean = null)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            input.ForEach(x => x = x.Clean());
        }

        _ = input.RemoveAll(x => x.IsNullOEmpty());
    }

    public static void Cleans<T>(this List<ICollection<T>?>? input, bool? deepClean = null)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            input.ForEach(x => x = (ICollection<T>?)x.Clean());
        }

        _ = input.RemoveAll(x => x.IsNullOEmpty());
    }

    public static void Cleans<T>(this List<T[]?>? input, bool? deepClean = null)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            input.ForEach(x => x = x.Clean()?.ToArray());
        }

        _ = input.RemoveAll(x => x.IsNullOEmpty());
    }

    public static void Cleans<T>(this List<List<T>?>? input, bool? deepClean = null)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            input.ForEach(x => x.Clean());
        }

        _ = input.RemoveAll(x => x.IsNullOEmpty());
    }

    /// <summary>
    /// Filters out <see langword="null"/>, empty, or white-space strings from a collection of strings.
    /// If the collection is <see langword="null"/> or empty, it is returned as-is.
    /// Applicable to collections of strings, removing elements that are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The collection of strings to be filtered. Can be <see langword="null"/>.</param>
    /// <returns>A filtered collection with <see langword="null"/>, empty, or white-space strings removed, or the original collection if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Clean(this IEnumerable<string?>? input) => input.IsNullOEmpty() ? input : input.Where(x => x.IsNotNullNWhiteSpace());

    /// <summary>
    /// Filters out <see langword="null"/>, empty, or white-space strings from a collection (ICollection) of strings.
    /// If the collection is <see langword="null"/> or empty, it is returned as-is.
    /// Applicable to collections of strings, removing elements that are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The ICollection of strings to be filtered. Can be <see langword="null"/>.</param>
    /// <returns>A filtered collection with <see langword="null"/>, empty, or white-space strings removed, or the original collection if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Clean(this ICollection<string?>? input) => input.IsNullOEmpty() ? input : input.Where(x => x.IsNotNullNWhiteSpace());

    /// <summary>
    /// Filters out <see langword="null"/>, empty, or white-space strings from an array of strings.
    /// If the array is <see langword="null"/> or empty, it is returned as-is.
    /// Applicable to arrays of strings, removing elements that are <see langword="null"/>, empty, or consist only of white-space characters.
    /// </summary>
    /// <param name="input">The array of strings to be filtered. Can be <see langword="null"/>.</param>
    /// <returns>A filtered array with <see langword="null"/>, empty, or white-space strings removed, or the original array if it is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Clean(params string?[]? input) => input.IsNullOEmpty() ? input : input.Where(x => x.IsNotNullNWhiteSpace());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<IEnumerable<string?>?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<ICollection<string?>?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<string?[]?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<IEnumerable<string?>?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<ICollection<string?>?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<string?[]?>? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<string?>?[]? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this ICollection<string?>?[]? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static IEnumerable<IEnumerable<string?>?>? Cleans(this string?[]?[]? input, bool? deepClean = null) => input.IsNullOEmpty()
        ? input
        : (deepClean.HasValue && deepClean.Value ? input.Select(x => x.Clean()) : input).Where(x => x.IsNotNullNEmpty());

    public static void Cleans(this List<IEnumerable<string?>?>? input, bool? deepClean = null)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            input.ForEach(x => x = x.Clean());
        }

        _ = input.RemoveAll(x => x.IsNullOEmpty());
    }

    public static void Cleans(this List<ICollection<string?>?>? input, bool? deepClean = null)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            input.ForEach(x => x = (ICollection<string?>?)x.Clean());
        }

        _ = input.RemoveAll(x => x.IsNullOEmpty());
    }

    public static void Cleans(this List<string?[]?>? input, bool? deepClean = null)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            input.ForEach(x => x = x.Clean()?.ToArray());
        }

        _ = input.RemoveAll(x => x.IsNullOEmpty());
    }

    public static void Cleans(this List<List<string?>?>? input, bool? deepClean = null)
    {
        if (input.IsNullOEmpty())
        {
            return;
        }

        if (deepClean.HasValue && deepClean.Value)
        {
            input.ForEach(x => x.Clean());
        }

        _ = input.RemoveAll(x => x.IsNullOEmpty());
    }
}
