using System.Diagnostics;

namespace YANLib;

/// <summary>
/// Provides methods for generating collections of random nullable values.
/// </summary>
/// <remarks>
/// This class extends the <see cref="YANRandom"/> class with methods to generate collections of random nullable values.
/// It supports specifying the size of the collection. For large collections (size >= 1000), parallel processing is used
/// for better performance.
/// </remarks>
public static partial class YANRandom
{
    /// <summary>
    /// Generates a collection of random nullable values of the specified type.
    /// </summary>
    /// <typeparam name="T">The type to generate random nullable values for.</typeparam>
    /// <param name="size">The size of the collection to generate. If <c>null</c>, a default size is used.</param>
    /// <returns>A collection of random nullable values of the specified type.</returns>
    /// <remarks>For large collections (size >= 1000), parallel processing is used for better performance.</remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?> GenerateRandoms<T>(object? size = null) => Implementation.YANRandom.GenerateRandomsImplement<T>(size);
}
