using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing objects to unmanaged types and collections.
/// </summary>
/// <remarks>
/// This class contains methods for converting objects to various unmanaged types such as numeric types,
/// <see cref="DateTime"/>, <see cref="Guid"/>, and enums. It supports both individual object parsing
/// and collection parsing, with options for default values and format specifications.
/// </remarks>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses an object to the specified unmanaged type.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The object to parse. If <c>null</c>, returns the default value of <typeparamref name="T"/>.</param>
    /// <param name="defaultValue">The default value to return if parsing fails. If <c>null</c>, returns the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or the default value if parsing fails.</returns>
    /// <remarks>
    /// This method supports parsing to various unmanaged types including numeric types, <see cref="DateTime"/>, <see cref="Guid"/>, and enums.
    /// If the input cannot be parsed to the specified type, the method will return the provided default value or the type's default value.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, IEnumerable<string?>? format = null) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);

    /// <summary>
    /// Parses an object to the specified unmanaged type using the provided format strings.
    /// </summary>
    /// <typeparam name="T">The unmanaged type to parse to.</typeparam>
    /// <param name="input">The object to parse. If <c>null</c>, returns the default value of <typeparamref name="T"/>.</param>
    /// <param name="defaultValue">The default value to return if parsing fails. If <c>null</c>, returns the default value of <typeparamref name="T"/>.</param>
    /// <param name="format">The format strings to use for parsing. Used primarily for <see cref="DateTime"/> parsing.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or the default value if parsing fails.</returns>
    /// <remarks>
    /// This overload accepts format strings as params array for convenience.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T Parse<T>(this object? input, object? defaultValue = null, params string?[]? format) where T : unmanaged => input.ParseImplement<T>(defaultValue, format);
}
