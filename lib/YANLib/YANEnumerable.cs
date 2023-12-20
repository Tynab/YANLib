using System.Diagnostics.CodeAnalysis;
using static System.Math;
using static System.Nullable;

namespace YANLib;

public static partial class YANEnumerable
{
    /// <summary>
    /// Divides a collection of elements into chunks of a specified size.
    /// If the source collection is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="srcs">The source collection of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source collection.</returns>
    public static IEnumerable<List<T?>> ChunkBySize<T>(this IEnumerable<T?>? srcs, object? chunkSize)
    {
        var size = (int)chunkSize.ToUint();

        if (srcs.IsEmptyOrNull() || size is 0)
        {
            yield break;
        }

        var srcsList = srcs.ToList();
        var cnt = srcsList.Count;

        for (var i = 0; i < cnt; i += size)
        {
            yield return srcsList.GetRange(i, Min(size, cnt - i));
        }
    }

    /// <summary>
    /// Divides a collection (ICollection) of elements into chunks of a specified size.
    /// If the source collection is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="srcs">The source ICollection of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source collection.</returns>
    public static IEnumerable<List<T?>> ChunkBySize<T>(this ICollection<T?>? srcs, object? chunkSize)
    {
        var size = (int)chunkSize.ToUint();

        if (srcs.IsEmptyOrNull() || size is 0)
        {
            yield break;
        }

        var cnt = srcs.Count;

        for (var i = 0; i < cnt; i += size)
        {
            yield return srcs.ToList().GetRange(i, Min(size, cnt - i));
        }
    }

    /// <summary>
    /// Divides an array of elements into chunks of a specified size.
    /// If the source array is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="srcs">The source array of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source array.</returns>
    public static IEnumerable<List<T?>> ChunkBySize<T>(this T?[]? srcs, object? chunkSize)
    {
        var size = (int)chunkSize.ToUint();

        if (srcs.IsEmptyOrNull() || size is 0)
        {
            yield break;
        }

        var cnt = srcs.Length;

        for (var i = 0; i < cnt; i += size)
        {
            yield return srcs.ToList().GetRange(i, Min(size, cnt - i));
        }
    }

    /// <summary>
    /// Divides a list of elements into chunks of a specified size.
    /// If the source list is <see langword="null"/> or empty, or if the chunk size is zero, yields no results.
    /// </summary>
    /// <param name="srcs">The source list of elements to be chunked. Can be <see langword="null"/>.</param>
    /// <param name="chunkSize">The size of each chunk. Can be <see langword="null"/>, resulting in a default size of 0.</param>
    /// <returns>An enumerable collection of lists, each containing a chunk of elements from the source list.</returns>
    public static IEnumerable<List<T?>> ChunkBySize<T>(this List<T?>? srcs, object? chunkSize)
    {
        var size = (int)chunkSize.ToUint();

        if (srcs.IsEmptyOrNull() || size is 0)
        {
            yield break;
        }

        var cnt = srcs.Count;

        for (var i = 0; i < cnt; i += size)
        {
            yield return srcs.GetRange(i, Min(size, cnt - i));
        }
    }

    /// <summary>
    /// Cleans a collection of nullable elements by removing <see langword="null"/> values.
    /// For classes and nullable value types, <see langword="null"/> elements are removed. For non-nullable value types, no elements are removed.
    /// If the source collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="srcs">The source collection of nullable elements. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection with <see langword="null"/> elements removed, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T?>? Clean<T>(this IEnumerable<T?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return default;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t) is not null ? srcs.Where(x => x is not null) : srcs;
    }

    /// <summary>
    /// Cleans a collection (ICollection) of nullable elements by removing <see langword="null"/> values.
    /// For classes and nullable value types, <see langword="null"/> elements are removed. For non-nullable value types, no elements are removed.
    /// If the source collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="srcs">The source ICollection of nullable elements. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection with <see langword="null"/> elements removed, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T?>? Clean<T>(this ICollection<T?>? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return default;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t) is not null ? srcs.Where(x => x is not null) : srcs;
    }

    /// <summary>
    /// Cleans an array of nullable elements by removing <see langword="null"/> values.
    /// For classes and nullable value types, <see langword="null"/> elements are removed. For non-nullable value types, no elements are removed.
    /// If the source array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="srcs">The source array of nullable elements. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection with <see langword="null"/> elements removed, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<T?>? Clean<T>(this T?[]? srcs)
    {
        if (srcs.IsEmptyOrNull())
        {
            return default;
        }

        var t = typeof(T);

        return t.IsClass || GetUnderlyingType(t) is not null ? srcs.Where(x => x is not null) : srcs;
    }

    /// <summary>
    /// Cleans a collection of strings by removing <see langword="null"/> or white-space strings.
    /// If the source collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="srcs">The source collection of strings. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection with <see langword="null"/> or white-space strings removed, or <see langword="null"/> if the input collection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Clean(this IEnumerable<string?>? srcs) => srcs.IsEmptyOrNull() ? default : srcs.Where(x => x.IsNotWhiteSpaceAndNull());

    /// <summary>
    /// Cleans a collection (ICollection) of strings by removing <see langword="null"/> or white-space strings.
    /// If the source collection is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="srcs">The source ICollection of strings. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection with <see langword="null"/> or white-space strings removed, or <see langword="null"/> if the input ICollection is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Clean(this ICollection<string?>? srcs) => srcs.IsEmptyOrNull() ? default : srcs.Where(x => x.IsNotWhiteSpaceAndNull());

    /// <summary>
    /// Cleans an array of strings by removing <see langword="null"/> or white-space strings.
    /// If the source array is <see langword="null"/> or empty, returns <see langword="null"/>.
    /// </summary>
    /// <param name="srcs">The source array of strings. Can be <see langword="null"/>.</param>
    /// <returns>An enumerable collection with <see langword="null"/> or white-space strings removed, or <see langword="null"/> if the input array is <see langword="null"/> or empty.</returns>
    public static IEnumerable<string?>? Clean(this string?[]? srcs) => srcs.IsEmptyOrNull() ? default : srcs.Where(x => x.IsNotWhiteSpaceAndNull());

    /// <summary>
    /// Determines whether the specified IEnumerable collection is <see langword="null"/> or contains no elements.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the collection is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmptyOrNull<T>([NotNullWhen(false)] this IEnumerable<T?>? srcs) => srcs is null || !srcs.Any();

    /// <summary>
    /// Determines whether the specified ICollection collection is <see langword="null"/> or contains no elements.
    /// </summary>
    /// <param name="srcs">The ICollection collection to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the collection is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmptyOrNull<T>([NotNullWhen(false)] this ICollection<T?>? srcs) => srcs is null || srcs.Count is 0;

    /// <summary>
    /// Determines whether the specified array is <see langword="null"/> or contains no elements.
    /// </summary>
    /// <param name="srcs">The array to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the array is <see langword="null"/> or empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsEmptyOrNull<T>([NotNullWhen(false)] this T?[]? srcs) => srcs is null || srcs.Length is 0;

    /// <summary>
    /// Determines whether the specified IEnumerable collection is not <see langword="null"/> and contains at least one element.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the collection is not <see langword="null"/> and not empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyAndNull<T>([NotNullWhen(true)] this IEnumerable<T?>? srcs) => srcs is not null && srcs.Any();

    /// <summary>
    /// Determines whether the specified ICollection collection is not <see langword="null"/> and contains at least one element.
    /// </summary>
    /// <param name="srcs">The ICollection collection to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the collection is not <see langword="null"/> and not empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyAndNull<T>([NotNullWhen(true)] this ICollection<T?>? srcs) => srcs is not null && srcs.Count is not 0;

    /// <summary>
    /// Determines whether the specified array is not <see langword="null"/> and contains at least one element.
    /// </summary>
    /// <param name="srcs">The array to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if the array is not <see langword="null"/> and not empty; otherwise, <see langword="false"/>.</returns>
    public static bool IsNotEmptyAndNull<T>([NotNullWhen(true)] this T?[]? srcs) => srcs is not null && srcs.Length is not 0;

    /// <summary>
    /// Determines whether all elements in the specified IEnumerable collection of class type are either <see langword="null"/> or have all properties set to default values.
    /// Returns <see langword="true"/> only if the collection is not <see langword="null"/>, not empty, and all elements are <see langword="null"/> or have default property values.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default property values; otherwise, <see langword="false"/>.</returns>
    public static bool AllEmptyOrNull<T>(this IEnumerable<T?>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x is not null || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether all elements in the specified ICollection collection of class type are either <see langword="null"/> or have all properties set to default values.
    /// Returns <see langword="true"/> only if the collection is not <see langword="null"/>, not empty, and all elements are <see langword="null"/> or have default property values.
    /// </summary>
    /// <param name="srcs">The ICollection collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default property values; otherwise, <see langword="false"/>.</returns>
    public static bool AllEmptyOrNull<T>(this ICollection<T?>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x is not null || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether all elements in the specified array of class type are either <see langword="null"/> or have all properties set to default values.
    /// Returns <see langword="true"/> only if the array is not <see langword="null"/>, not empty, and all elements are <see langword="null"/> or have default property values.
    /// </summary>
    /// <param name="srcs">The array of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if all elements are <see langword="null"/> or have default property values; otherwise, <see langword="false"/>.</returns>
    public static bool AllEmptyOrNull<T>(this T?[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x is not null || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether any element in the specified IEnumerable collection of class type is either <see langword="null"/> or has all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and any element is <see langword="null"/> or has default property values.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEmptyOrNull<T>(this IEnumerable<T?>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x is null || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether any element in the specified ICollection collection of class type is either <see langword="null"/> or has all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and any element is <see langword="null"/> or has default property values.
    /// </summary>
    /// <param name="srcs">The ICollection collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEmptyOrNull<T>(this ICollection<T?>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x is null || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether any element in the specified array of class type is either <see langword="null"/> or has all properties set to default values.
    /// Returns <see langword="true"/> if the array is not <see langword="null"/>, not empty, and any element is <see langword="null"/> or has default property values.
    /// </summary>
    /// <param name="srcs">The array of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyEmptyOrNull<T>(this T?[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x is null || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether all elements in the specified IEnumerable collection of class type are not <see langword="null"/> and do not have all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and no element is <see langword="null"/> or has all properties set to default values.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if no element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEmptyAndNull<T>(this IEnumerable<T?>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x is null || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether all elements in the specified ICollection collection of class type are not <see langword="null"/> and do not have all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and no element is <see langword="null"/> or has all properties set to default values.
    /// </summary>
    /// <param name="srcs">The ICollection collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if no element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEmptyAndNull<T>(this ICollection<T?>? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x is null || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether all elements in the specified array of class type are not <see langword="null"/> and do not have all properties set to default values.
    /// Returns <see langword="true"/> if the array is not <see langword="null"/>, not empty, and no element is <see langword="null"/> or has all properties set to default values.
    /// </summary>
    /// <param name="srcs">The array of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if no element is <see langword="null"/> or has all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AllNotEmptyAndNull<T>(this T?[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && !srcs.Any(x => x is null || x.AllPropertiesDefault());

    /// <summary>
    /// Determines whether any element in the specified IEnumerable collection of class type is not <see langword="null"/> or does not have all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and any element is not <see langword="null"/> or does not have all properties set to default values.
    /// </summary>
    /// <param name="srcs">The IEnumerable collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is not <see langword="null"/> or does not have all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEmptyAndNull<T>(this IEnumerable<T?>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x is not null || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether any element in the specified ICollection collection of class type is not <see langword="null"/> or does not have all properties set to default values.
    /// Returns <see langword="true"/> if the collection is not <see langword="null"/>, not empty, and any element is not <see langword="null"/> or does not have all properties set to default values.
    /// </summary>
    /// <param name="srcs">The ICollection collection of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is not <see langword="null"/> or does not have all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEmptyAndNull<T>(this ICollection<T?>? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x is not null || x.AnyPropertiesNotDefault());

    /// <summary>
    /// Determines whether any element in the specified array of class type is not <see langword="null"/> or does not have all properties set to default values.
    /// Returns <see langword="true"/> if the array is not <see langword="null"/>, not empty, and any element is not <see langword="null"/> or does not have all properties set to default values.
    /// </summary>
    /// <param name="srcs">The array of class type elements to check. Can be <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if any element is not <see langword="null"/> or does not have all properties set to default values; otherwise, <see langword="false"/>.</returns>
    public static bool AnyNotEmptyAndNull<T>(this T?[]? srcs) where T : class => srcs.IsNotEmptyAndNull() && srcs.Any(x => x is not null || x.AnyPropertiesNotDefault());
}
