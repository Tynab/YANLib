using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for generating random values from collections of objects.
/// </summary>
/// <remarks>
/// This partial class extends the <see cref="YANRandom"/> class with methods to generate random values
/// of unmanaged types from collections of objects. These methods first parse the objects to the specified
/// type before selecting a random value, providing a convenient way to work with heterogeneous collections.
/// </remarks>
public static partial class YANRandom
{
    /// <summary>
    /// Generates a random value of the specified type from a collection of objects.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to generate a random value for.</typeparam>
    /// <param name="input">The source collection of objects to select and convert to a random value. If <c>null</c> or empty, returns the default value for the type.</param>
    /// <returns>A random value of type <typeparamref name="T"/> selected from the input collection, or the default value if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method first parses the objects in the input collection to the specified type before selecting a random value.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T GenerateRandom<T>(this IEnumerable<object?>? input) where T : unmanaged => input.GenerateRandomImplement<T>();

    /// <summary>
    /// Generates a random value of the specified type from an array of objects.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to generate a random value for.</typeparam>
    /// <param name="input">The source array of objects to select and convert to a random value. If <c>null</c> or empty, returns the default value for the type.</param>
    /// <returns>A random value of type <typeparamref name="T"/> selected from the input array, or the default value if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to select a random value from an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T GenerateRandom<T>(params object?[]? input) where T : unmanaged => input.GenerateRandomImplement<T>();
}
