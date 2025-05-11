using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides methods for generating collections of random values for unmanaged types.
/// </summary>
/// <remarks>
/// This class extends the <see cref="YANRandom"/> class with methods to generate collections of random values
/// for unmanaged types. It supports specifying minimum and maximum values for the generated values, as well as
/// the size of the collection. For large collections (size >= 1000), parallel processing is used for better performance.
/// </remarks>
public static partial class YANRandom
{
    /// <summary>
    /// Generates a collection of random values of the specified unmanaged type within the specified range.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to generate random values for.</typeparam>
    /// <param name="min">The inclusive lower bound of the random values returned. If <c>null</c>, the minimum value for the type is used.</param>
    /// <param name="max">The exclusive upper bound of the random values returned. If <c>null</c>, the maximum value for the type is used.</param>
    /// <param name="size">The size of the collection to generate. If <c>null</c>, a default size is used.</param>
    /// <returns>A collection of random values of the specified type within the specified range.</returns>
    /// <remarks>For large collections (size >= 1000), parallel processing is used for better performance.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T> GenerateRandoms<T>(object? min = null, object? max = null, object? size = null) where T : unmanaged => Implementation.YANRandom.GenerateRandomsImplement<T>(min, max, size);

    /// <summary>
    /// Generates a collection of random values from the specified input collection.
    /// </summary>
    /// <typeparam name="T">The unmanaged type of elements in the collection.</typeparam>
    /// <param name="input">The source collection to select random values from. If <c>null</c> or empty, returns an empty collection.</param>
    /// <param name="size">The size of the collection to generate. If <c>null</c>, a default size is used.</param>
    /// <param name="allowDuplicates">If <c>true</c>, allows duplicate values in the result; otherwise, ensures all values are unique.</param>
    /// <returns>A collection of random values selected from the input collection.</returns>
    /// <remarks>
    /// If <paramref name="allowDuplicates"/> is <c>false</c> and the requested size is larger than the input collection size,
    /// the result will contain all elements from the input collection in random order.
    /// For large collections (size >= 1000), parallel processing is used for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T> GenerateRandoms<T>(this IEnumerable<T>? input, object? size = null, bool allowDuplicates = true) where T : unmanaged => input.GenerateRandomsImplement(size, allowDuplicates);

    /// <summary>
    /// Generates a collection of random values of the specified type from a non-generic collection.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to generate random values for.</typeparam>
    /// <param name="input">The source non-generic collection to select random values from. If <c>null</c> or empty, returns an empty collection.</param>
    /// <param name="size">The size of the collection to generate. If <c>null</c>, a default size is used.</param>
    /// <param name="allowDuplicates">If <c>true</c>, allows duplicate values in the result; otherwise, ensures all values are unique.</param>
    /// <returns>A collection of random values of type <typeparamref name="T"/> selected from the input collection.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of the specified type before selecting random values.
    /// If <paramref name="allowDuplicates"/> is <c>false</c> and the requested size is larger than the input collection size,
    /// the result will contain all elements from the input collection in random order.
    /// For large collections (size >= 1000), parallel processing is used for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T> GenerateRandoms<T>(this System.Collections.IEnumerable? input, object? size = null, bool allowDuplicates = true) where T : unmanaged => input.GenerateRandomsImplement<T>(size, allowDuplicates);
}
