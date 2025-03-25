using System.Collections;
using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

public static partial class YANEnumerable
{
    /// <summary>
    /// Gets the count of elements in the specified enumerable collection.
    /// Optimized to use the most efficient counting method based on the collection type.
    /// </summary>
    /// <param name="input">The enumerable collection to count. Can be <see langword="null"/>.</param>
    /// <returns>The number of elements in the collection, or 0 if the collection is <see langword="null"/>.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static int GetCount(this IEnumerable? input) => input.GetCountImplement();

    /// <summary>
    /// Splits the elements of a list into chunks of the specified size.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="input">The list to be chunked. Can be <see langword="null"/> or empty.</param>
    /// <param name="chunkSize">The maximum size of each chunk. Will be parsed to an integer.</param>
    /// <returns>An enumerable of list chunks, each containing at most the specified number of elements. Returns an empty enumerable if the input is <see langword="null"/>, empty, or the chunk size is 0.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<List<T>> ChunkBySize<T>(this List<T>? input, object? chunkSize) => input.ChunkBySizeImplement(chunkSize);

    /// <summary>
    /// Removes all <see langword="null"/> elements from the specified list.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="input">The list to clean. Can be <see langword="null"/> or empty.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Clean<T>(this List<T>? input) => input.CleanImplement();

    /// <summary>
    /// Creates a new enumerable that contains all non-<see langword="null"/> elements from the specified enumerable.
    /// </summary>
    /// <typeparam name="T">The type of elements in the enumerable.</typeparam>
    /// <param name="input">The enumerable to clean. Can be <see langword="null"/> or empty.</param>
    /// <returns>A new enumerable containing all non-<see langword="null"/> elements, or the original enumerable if it is <see langword="null"/>, empty, or contains only value types.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Clean<T>(this IEnumerable<T>? input) => input.CleanImplement();

    /// <summary>
    /// Creates a new enumerable that contains all non-<see langword="null"/> elements from the specified array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="input">The array to clean. Can be <see langword="null"/> or empty.</param>
    /// <returns>A new enumerable containing all non-<see langword="null"/> elements, or the original array if it is <see langword="null"/>, empty, or contains only value types.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Clean<T>(params T[]? input) => input.CleanImplement();

    /// <summary>
    /// Removes all <see langword="null"/> or empty enumerables from the specified list of enumerables.
    /// Optionally cleans each inner enumerable by removing <see langword="null"/> elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the inner enumerables.</typeparam>
    /// <param name="input">The list of enumerables to clean. Can be <see langword="null"/> or empty.</param>
    /// <param name="deepClean">If <see langword="true"/>, also removes <see langword="null"/> elements from each inner enumerable. Default is <see langword="null"/>.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Cleans<T>(this List<IEnumerable<T>?>? input, bool? deepClean = null) => input.CleansImplement(deepClean);

    /// <summary>
    /// Creates a new enumerable of enumerables that contains all non-<see langword="null"/> and non-empty inner enumerables.
    /// Optionally cleans each inner enumerable by removing <see langword="null"/> elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the inner enumerables.</typeparam>
    /// <param name="input">The enumerable of enumerables to clean. Can be <see langword="null"/> or empty.</param>
    /// <param name="deepClean">If <see langword="true"/>, also removes <see langword="null"/> elements from each inner enumerable. Default is <see langword="null"/>.</param>
    /// <returns>A new enumerable containing all non-<see langword="null"/> and non-empty inner enumerables, or the original enumerable if it is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<IEnumerable<T>?>? Cleans<T>(this IEnumerable<IEnumerable<T>?>? input, bool? deepClean = null) => input.CleansImplement(deepClean);

    /// <summary>
    /// Creates a new enumerable that contains all non-<see langword="null"/>, non-empty, and non-whitespace strings from the specified enumerable.
    /// </summary>
    /// <param name="input">The enumerable of strings to clean. Can be <see langword="null"/> or empty.</param>
    /// <returns>A new enumerable containing all non-<see langword="null"/>, non-empty, and non-whitespace strings, or the original enumerable if it is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Clean(this IEnumerable<string?>? input) => input.CleanImplement();

    /// <summary>
    /// Creates a new enumerable that contains all non-<see langword="null"/>, non-empty, and non-whitespace strings from the specified array.
    /// </summary>
    /// <param name="input">The array of strings to clean. Can be <see langword="null"/> or empty.</param>
    /// <returns>A new enumerable containing all non-<see langword="null"/>, non-empty, and non-whitespace strings, or the original array if it is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<string?>? Clean(params string?[]? input) => input.CleanImplement();

    /// <summary>
    /// Removes all <see langword="null"/> or empty enumerables of strings from the specified list.
    /// Optionally cleans each inner enumerable by removing <see langword="null"/>, empty, or whitespace strings.
    /// </summary>
    /// <param name="input">The list of string enumerables to clean. Can be <see langword="null"/> or empty.</param>
    /// <param name="deepClean">If <see langword="true"/>, also removes <see langword="null"/>, empty, or whitespace strings from each inner enumerable. Default is <see langword="null"/>.</param>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static void Cleans(this List<IEnumerable<string?>?>? input, bool? deepClean = null) => input.CleansImplement(deepClean);

    /// <summary>
    /// Creates a new enumerable of string enumerables that contains all non-<see langword="null"/> and non-empty inner enumerables.
    /// Optionally cleans each inner enumerable by removing <see langword="null"/>, empty, or whitespace strings.
    /// </summary>
    /// <param name="input">The enumerable of string enumerables to clean. Can be <see langword="null"/> or empty.</param>
    /// <param name="deepClean">If <see langword="true"/>, also removes <see langword="null"/>, empty, or whitespace strings from each inner enumerable. Default is <see langword="null"/>.</param>
    /// <returns>A new enumerable containing all non-<see langword="null"/> and non-empty inner enumerables, or the original enumerable if it is <see langword="null"/> or empty.</returns>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<IEnumerable<string?>?>? Cleans(this IEnumerable<IEnumerable<string?>?>? input, bool? deepClean = null) => input.CleansImplement(deepClean);
}
