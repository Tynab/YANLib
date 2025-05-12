using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for generating collections of random values from collections of objects.
/// </summary>
/// <remarks>
/// This partial class extends the <see cref="YANRandom"/> class with methods to generate collections of random values
/// of unmanaged types from collections of objects. These methods first parse the objects to the specified
/// type before selecting random values, providing a convenient way to work with heterogeneous collections.
/// For large collections, these methods utilize parallel processing for improved performance.
/// </remarks>
public static partial class YANRandom
{
    /// <summary>
    /// Generates a collection of random values of the specified type from a collection of objects.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to generate random values for.</typeparam>
    /// <param name="input">The source collection of objects to select and convert to random values. If <c>null</c> or empty, returns an empty collection.</param>
    /// <param name="size">The size of the collection to generate. If <c>null</c>, a default size is used.</param>
    /// <param name="allowDuplicates">If <c>true</c>, allows duplicate values in the result; otherwise, ensures all values are unique.</param>
    /// <returns>A collection of random values of type <typeparamref name="T"/> selected from the input collection.</returns>
    /// <remarks>
    /// This method first parses the objects in the input collection to the specified type before selecting random values.
    /// If <paramref name="allowDuplicates"/> is <c>false</c> and the requested size is larger than the input collection size,
    /// the result will contain all elements from the input collection in random order.
    /// For large collections (size >= 1000), parallel processing is used for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T> GenerateRandoms<T>(this IEnumerable<object?>? input, object? size = null, bool allowDuplicates = true) where T : unmanaged => input.GenerateRandomsImplement<T>(size, allowDuplicates);
}
