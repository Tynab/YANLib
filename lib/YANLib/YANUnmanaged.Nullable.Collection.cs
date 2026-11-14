using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing collections of objects to collections of nullable types.
/// </summary>
/// <remarks>
/// This partial class contains methods for converting collections of objects to collections of nullable types.
/// It supports both generic and non-generic collections, as well as arrays. Methods that return
/// <see cref="IEnumerable{T}"/> are lazily evaluated and preserve the input order.
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
    /// The result is lazily evaluated and preserves input order.
    /// Elements that cannot be parsed will be the default value of <typeparamref name="T"/> in the resulting collection: <c>null</c> for a reference
    /// type or a nullable value type, otherwise <c>default(T)</c> (for example <c>0</c> for <see cref="int"/>).
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
    /// The result is lazily evaluated and preserves input order.
    /// Elements that cannot be parsed will be the default value of <typeparamref name="T"/> in the resulting collection: <c>null</c> for a reference
    /// type or a nullable value type, otherwise <c>default(T)</c> (for example <c>0</c> for <see cref="int"/>).
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
    /// The result is lazily evaluated and preserves input order.
    /// Elements that cannot be parsed will be the default value of <typeparamref name="T"/> in the resulting collection: <c>null</c> for a reference
    /// type or a nullable value type, otherwise <c>default(T)</c> (for example <c>0</c> for <see cref="int"/>).
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
    /// Keys and elements that cannot be parsed will be the default value of <typeparamref name="TKey"/> / <typeparamref name="TElement"/> in the
    /// resulting lookup: <c>null</c> for a reference type or a nullable value type, otherwise <c>default(TKey)</c> / <c>default(TElement)</c> (for
    /// example <c>0</c> for <see cref="int"/>). Keys that cannot be parsed and <c>null</c> keys therefore share the group of the default key (for
    /// <see cref="int"/> keys, the group of <c>0</c>).
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static ILookup<TKey?, TElement?> Parses<TKey, TElement>(this ILookup<object?, object?>? input) => input.ParsesImplement<TKey, TElement>();
}
