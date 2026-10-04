using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing collections of objects to collections of nullable types.
/// </summary>
/// <remarks>
/// This partial class contains methods for converting collections of objects to collections of nullable types.
/// It supports both generic and non-generic collections, as well as arrays. Element-wise projections are evaluated sequentially and preserve input order.
/// </remarks>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses a collection of objects to a collection of the specified nullable type.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// Elements that cannot be parsed will be <c>null</c> in the resulting collection.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(this IEnumerable<object?>? input) => input.ParsesImplement<T>();

    /// <summary>
    /// Parses an array of objects to a collection of the specified nullable type.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The array of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method provides a convenient way to parse an array of objects without having to explicitly cast it to <see cref="IEnumerable{T}"/>.
    /// Elements that cannot be parsed will be <c>null</c> in the resulting collection.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(params object?[]? input) => input.ParsesImplement<T>();

    /// <summary>
    /// Parses a non-generic collection of objects to a collection of the specified nullable type.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The non-generic collection of objects to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before parsing.
    /// Elements that cannot be parsed will be <c>null</c> in the resulting collection.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T?>? Parses<T>(this System.Collections.IEnumerable? input) => input.ParsesImplement<T>();

    /// <summary>
    /// Parses a lookup of objects to a lookup of the specified nullable key and element types.
    /// </summary>
    /// <typeparam name="TKey">The key type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <typeparam name="TElement">The element type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The lookup of objects to parse. If <c>null</c> or empty, returns an empty lookup.</param>
    /// <returns>A lookup with keys of type <typeparamref name="TKey"/> and elements of type <typeparamref name="TElement"/>, or an empty lookup if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This method parses both the keys and elements of the input lookup to the specified types.
    /// Keys and elements that cannot be parsed will be <c>null</c> (or <c>default</c> for non-nullable value types) in the resulting lookup.
    /// Groups whose keys parse to the same value are merged into a single group; no exception is thrown.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ILookup<TKey?, TElement?> Parses<TKey, TElement>(this ILookup<object?, object?>? input) => input.ParsesImplement<TKey, TElement>();
}
