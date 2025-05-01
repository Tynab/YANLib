using System.Diagnostics;

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
}
