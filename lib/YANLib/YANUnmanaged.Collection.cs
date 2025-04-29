using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing collections of objects to collections of unmanaged types.
/// </summary>
/// <remarks>
/// This partial class contains methods specifically for working with collections, supporting both
/// generic and non-generic collections. For large collections, these methods utilize parallel processing
/// for improved performance.
/// </remarks>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses a collection of objects to a collection of the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses a collection of objects to a collection of the specified unmanaged type using the provided format strings.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The collection of objects to parse. If <c>null</c> or empty, returns <c>null</c>.</param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c> or empty.</returns>
    /// <remarks>
    /// This overload accepts format strings as params array for convenience.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this IEnumerable<object?>? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses a non-generic collection of objects to a collection of the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The non-generic collection of objects to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method first casts the non-generic collection to a generic collection of objects before parsing.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this System.Collections.IEnumerable? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses a non-generic collection of objects to a collection of the specified unmanaged type using the provided format strings.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The non-generic collection of objects to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <param name="defaultValue">The default value to use for elements that cannot be parsed. If <c>null</c>, uses the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>A collection of parsed values of type <typeparamref name="T"/>, or <c>null</c> if the input is <c>null</c>.</returns>
    /// <remarks>
    /// This overload accepts format strings as params array for convenience.
    /// This method first casts the non-generic collection to a generic collection of objects before parsing.
    /// For large collections (1000+ elements), this method will use parallel processing for better performance.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static IEnumerable<T>? Parses<T>(this System.Collections.IEnumerable? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParsesImplement<T>(defaultValue, format);
}
