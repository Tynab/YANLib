using System.Diagnostics;
using YANLib.Implementation;

namespace YANLib;

/// <summary>
/// Provides extension methods for parsing objects to nullable types.
/// </summary>
/// <remarks>
/// This partial class extends the functionality of <see cref="YANUnmanaged"/> to support parsing
/// to nullable types, including both nullable value types and reference types. Unlike the non-nullable
/// parsing methods, these methods return null instead of default values when parsing fails.
/// </remarks>
public static partial class YANUnmanaged
{
    /// <summary>
    /// Parses an object to the specified nullable type.
    /// </summary>
    /// <typeparam name="T">The type to parse to. Can be any type, including reference types and nullable value types.</typeparam>
    /// <param name="input">The object to parse. If <c>null</c>, returns <c>null</c>.</param>
    /// <returns>The parsed value of type <typeparamref name="T"/>, or <c>null</c> if parsing fails or the input is <c>null</c>.</returns>
    /// <remarks>
    /// This method supports parsing to various types including strings, numeric types, <see cref="DateTime"/>, <see cref="Guid"/>, and enums.
    /// Unlike the non-nullable version, this method returns <c>null</c> instead of a default value when parsing fails.
    /// </remarks>
    [DebuggerHidden]
    [DebuggerStepThrough]
    public static T? Parse<T>(this object? input) => input.ParseImplement<T>();
}
